using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                context.Response.WriteAsync("hi,ni hao hini ");
                // Do work that doesn't write to the Response.
                await next.Invoke();  //�����������仰�Ļ����������ͻ��·
                // Do logging or other work that doesn't write to the Response.
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World!");
            });
            /*
             * 1���쳣/������
��Ӧ���ڿ�������������ʱ��
������Ա�쳣ҳ�м�� (UseDeveloperExceptionPage) ����Ӧ������ʱ����
���ݿ����ҳ�м���������ݿ�����ʱ����
��Ӧ������������������ʱ��
�쳣��������м�� (UseExceptionHandler) ���������м�����������쳣��
HTTP �ϸ��䰲ȫЭ�� (HSTS) �м�� (UseHsts) ��� Strict-Transport-Security ��ͷ��
            2��
             * ������������м����˳�� ��ò�Ҫ�ı�˳��
             * if (env.IsDevelopment())
      {
          app.UseDeveloperExceptionPage();
          app.UseDatabaseErrorPage();
      }
      else
      {
          app.UseExceptionHandler("/Error");
          app.UseHsts();
      }
    //HTTPS �ض����м�� (UseHttpsRedirection) �� HTTP �����ض��� HTTPS��
      app.UseHttpsRedirection();
            /��̬�ļ��м�� (UseStaticFiles) ���ؾ�̬�ļ������򻯽�һ��������
      app.UseStaticFiles();
            //Cookie �����м�� (UseCookiePolicy) ʹӦ�÷���ŷ��һ�����ݱ������� (GDPR) �涨��
      // app.UseCookiePolicy();
            //����·�������·���м�� (UseRouting)��
      app.UseRouting();
      // app.UseRequestLocalization();
      // app.UseCors();
            //�����֤�м�� (UseAuthentication) ���Զ��û����������֤��Ȼ��Ż������û����ʰ�ȫ��Դ��
      app.UseAuthentication();
            ///������Ȩ�û����ʰ�ȫ��Դ����Ȩ�м�� (UseAuthorization)��
      app.UseAuthorization();
            ///�Ự�м�� (UseSession) ������ά���Ự״̬�� ���Ӧ��ʹ�ûỰ״̬
            ///������ Cookie �����м��֮��� MVC �м��֮ǰ���ûỰ�м����
      // app.UseSession();
            ///���ڽ� Razor Pages �ս����ӵ�����ܵ����ս��·���м�������� MapRazorPages �� UseEndpoints����
      // app.UseResponseCaching();

      app.UseEndpoints(endpoints =>
      {
          endpoints.MapRazorPages();
          endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");
      });

             */
        }
    }
}
