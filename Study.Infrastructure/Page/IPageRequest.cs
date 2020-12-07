using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Infrastructure.Page
{
    /// <summary>
    /// 获取分页请求
    /// </summary>
    public interface IPageRequest
    {
        /// <summary>
        /// 每页条数
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// 查询页码
        /// </summary>
        int PageIndex { get; set; }
    }
    public class PageRequest : IPageRequest
    {
        [Range(1, int.MaxValue)]
        public virtual int PageSize { get; set; } = 10;

        [Range(1, int.MaxValue)]
        public virtual int PageIndex { get; set; } = 1;
    }
}
