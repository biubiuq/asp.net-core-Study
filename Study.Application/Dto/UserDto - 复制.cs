using Study.Infrastructure.Page;
using Study.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Study.Application.Dto
{
    /// <summary>
    /// 查询参数实体类
    /// </summary>
    public class RoleDto : role, IPageRequest
    {
        [Range(1, int.MaxValue)]
        public virtual int PageSize { get; set; } = 10;

        [Range(1, int.MaxValue)]
        public virtual int PageIndex { get; set; } = 1;
    }
}
