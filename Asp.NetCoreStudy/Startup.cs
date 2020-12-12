using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
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
            ///��NuGet������ð� MediatR.Extensions.Microsoft.DependencyInjection
            services.AddControllers();
            ///MediatR ֪����  https://www.jianshu.com/p/583bcba352ec
            MediatR Document WIKI https://github.com/jbogard/MediatR/wiki
ASP.NET Core ʹ�� MediatR�� ���ڷ����붩�� https://www.cnblogs.com/guokun/p/11001052.html
            ///
            ///
            services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());  //���Զ������Ϣ�࣬������Ϣ��ע�뵽������

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
