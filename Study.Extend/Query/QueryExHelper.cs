using Study.Infrastructure.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Study.Extend.Query
{
   public static class QueryExHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="t"></param>
        public static PageResultDto<TSource> SourcePage<TSource,T>(this IQueryable<TSource> source, T t) where T : IPageRequest
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TSource), "p");
            Expression condition = null;
            foreach (PropertyInfo item in typeof(TSource).GetProperties())
            {
                ///如果为空则不加入搜索，关于时间类型暂时不处理
                if (item.PropertyType == typeof(string))
                {
                    var data = item.GetValue(t);
                    if (data==null||data.ToString()=="") continue;
                    ConstantExpression constant = Expression.Constant(data);
                    Expression propertyExpression = Expression.Property(parameter, typeof(TSource).GetProperty(item.Name));
                    BinaryExpression binary = Expression.Equal(constant, propertyExpression);
                    if (condition == null)
                    {
                        condition = binary;
                    }
                    else
                    {
                        condition = Expression.And(condition, binary);
                    }

                }

            }
            if (condition == null)
            {
                ConstantExpression constant = Expression.Constant("1");
                ConstantExpression constant2 = Expression.Constant("1");
                BinaryExpression binary = Expression.Equal(constant, constant2);
                condition = binary;

            }
            Expression<Func<TSource, bool>> expression = Expression.Lambda<Func<TSource, bool>>(condition, parameter);
            var list = source.Where(expression).Skip(t.PageSize * (t.PageIndex - 1)).Take(t.PageSize).ToList();
            return new PageResultDto<TSource> { 
                  List = list,
                   PageSize=t.PageSize,
                   PageIndex=t.PageIndex,
                   TotalPages=2,
                    TotalCount=3
            };


        }
    }
    
}
