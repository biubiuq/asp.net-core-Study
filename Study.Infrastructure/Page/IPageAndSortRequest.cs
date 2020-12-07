using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Infrastructure.Page
{
    /// <summary>
    /// 获取分页并排序请求
    /// </summary>
    public interface IPageAndSortRequest : IPageRequest, ISortRequest
    {

    }
    public class PageAndSortRequest : PageRequest, IPageAndSortRequest
    {
        public virtual string Sorting { get; set; }
    }
}
