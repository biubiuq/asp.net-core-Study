using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
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
                context.Response.ContentType = "text/plain;charset=utf-8";
                await next.Invoke();

            });
            ///ͨ�����м����װ�����У�����ͨ����չ���������� �뿼�������м����
            ///���м��ͨ����ѯ�ַ������õ�ǰ�����������
            app.Use(async (context, next) =>
            {
                var cultureQuery = context.Request.Query["culture"];
                if (!string.IsNullOrWhiteSpace(cultureQuery))
                {
                    var culture = new CultureInfo(cultureQuery);

                    CultureInfo.CurrentCulture = culture;
                    CultureInfo.CurrentUICulture = culture;
                }

                // Call the next delegate/middleware in the pipeline
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    $"Hello ���{CultureInfo.CurrentCulture.DisplayName}");
            });
            /*
             * ʲô���������Ҫ�м��?
             * ��ô����ʱʹ���м���أ��ҵ�����������ǵ�Ӧ�ó����к�ҵ���ϵ�����һЩ��Ҫ�ڹܵ��������������ʹ�ã����������֤��Session�洢����־��¼�ȡ���ʵ���ǵ� asp.net core��Ŀ�б����Ѿ������˺ܶ���м����
             
             */




















            /*
             * 
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
