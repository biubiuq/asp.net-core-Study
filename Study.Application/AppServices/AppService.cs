using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Application.AppServices
{
   public class AppService
    {
        /// <summary>
        /// 当前容器
        /// </summary>
        public IServiceProvider ServiceProvider { get; set; }

        public AppService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

      
     
    }
}
