using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Infrastructure.Page
{
    public class PageAndSortRequest : PageRequest, IPageAndSortRequest
    {
        public virtual string Sorting { get; set; }
    }
}
