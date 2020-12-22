using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Study.Application
{
    public static class ApplicationModule
    {
        /// <summary>
        /// 注册AppService
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMyAppServices(this IServiceCollection services, IConfiguration configuration)
        {
          //获取当前程序所在的程序级
            Assembly appServiceAssembly = Assembly.GetExecutingAssembly();
            //注册MediatR
            services.AddMediatR(appServiceAssembly);

            return services;
        }
    }
}
