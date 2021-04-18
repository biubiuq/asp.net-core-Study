using Study.Infrastructure.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Application.Response
{

   public class UserResponse<T> : IRequest<T>
    {
        public T data { get; set; }
        public int code { get; set; }
     //   public T info { get; set; }
    }
}
