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
            //��ʱ�����ڷ��� (AddTransient) ��ÿ�δӷ���������������ʱ�����ġ� �����������ʺ��������� ��״̬�ķ���
            services.AddTransient<IOperationTransient, Operation>();
          //  �����������ڷ���(AddScoped) ��ÿ���ͻ����������ӣ�һ�εķ�ʽ������
            services.AddScoped<IOperationScoped, Operation>();
            ///��һʵ�������ڷ��� (AddSingleton) ���ڵ�һ������ʱ������������ Startup.ConfigureServices 
            ///����ʹ�÷���ע��ָ��ʵ��ʱ�������ġ� ÿ����������ʹ����ͬ��ʵ����
            ///���Ӧ����Ҫ��һʵ����Ϊ������������������������������ڡ� 
            ///��Ҫʵ�ֵ�һʵ�����ģʽ���ṩ�û�������������������е������ڡ�
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
            ///��ʱ�Զ���ʼ�ղ�ͬ�� IndexModel ���м���е���ʱ OperationId ֵ��ͬ��
            //   ��Χ�ڶ����ÿ�������������ͬ�ģ���������֮�䲻ͬ��
            /// ��һʵ���������ÿ����������ͬ�ġ�
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
