using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.NetCoreStudy.Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Asp.NetCoreStudy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMyDependency, MyDependency2>();
            //暂时生存期服务 (AddTransient) 是每次从服务容器进行请求时创建的。 这种生存期适合轻量级、 无状态的服务。
            services.AddTransient<IOperationTransient, Operation>();
          //  作用域生存期服务(AddScoped) 以每个客户端请求（连接）一次的方式创建。
            services.AddScoped<IOperationScoped, Operation>();
            ///单一实例生存期服务 (AddSingleton) 是在第一次请求时（或者在运行 Startup.ConfigureServices 
            ///并且使用服务注册指定实例时）创建的。 每个后续请求都使用相同的实例。
            ///如果应用需要单一实例行为，建议允许服务容器管理服务的生存期。 
            ///不要实现单一实例设计模式并提供用户代码来管理对象在类中的生存期。
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            ///暂时性对象始终不同。 IndexModel 和中间件中的临时 OperationId 值不同。
            //   范围内对象对每个请求而言是相同的，但在请求之间不同。
            /// 单一实例对象对于每个请求是相同的。
            app.UseMiddleware<MyMiddleware>();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
