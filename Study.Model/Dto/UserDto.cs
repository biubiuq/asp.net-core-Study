using Study.Infrastructure.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Study.Model.Dto
{
    public class UserDto : User, IPageRequest
    {
        [Range(1, int.MaxValue)]
        public virtual int PageSize { get; set; } = 10;

        [Range(1, int.MaxValue)]
        public virtual int PageIndex { get; set; } = 1;
    }
}
