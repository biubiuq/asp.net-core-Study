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
                await next.Invoke();  //如果不调用这句话的话下面的请求就会短路
                // Do logging or other work that doesn't write to the Response.
            });
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World!");
            });
            /*
             * 1：异常/错误处理
当应用在开发环境中运行时：
开发人员异常页中间件 (UseDeveloperExceptionPage) 报告应用运行时错误。
数据库错误页中间件报告数据库运行时错误。
当应用在生产环境中运行时：
异常处理程序中间件 (UseExceptionHandler) 捕获以下中间件中引发的异常。
HTTP 严格传输安全协议 (HSTS) 中间件 (UseHsts) 添加 Strict-Transport-Security 标头。
            2：
             * 这是正常添加中间件的顺序 最好不要改变顺序
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
    //HTTPS 重定向中间件 (UseHttpsRedirection) 将 HTTP 请求重定向到 HTTPS。
      app.UseHttpsRedirection();
            /静态文件中间件 (UseStaticFiles) 返回静态文件，并简化进一步请求处理。
      app.UseStaticFiles();
            //Cookie 策略中间件 (UseCookiePolicy) 使应用符合欧盟一般数据保护条例 (GDPR) 规定。
      // app.UseCookiePolicy();
            //用于路由请求的路由中间件 (UseRouting)。
      app.UseRouting();
      // app.UseRequestLocalization();
      // app.UseCors();
            //身份验证中间件 (UseAuthentication) 尝试对用户进行身份验证，然后才会允许用户访问安全资源。
      app.UseAuthentication();
            ///用于授权用户访问安全资源的授权中间件 (UseAuthorization)。
      app.UseAuthorization();
            ///会话中间件 (UseSession) 建立和维护会话状态。 如果应用使用会话状态
            ///，请在 Cookie 策略中间件之后和 MVC 中间件之前调用会话中间件。
      // app.UseSession();
            ///用于将 Razor Pages 终结点添加到请求管道的终结点路由中间件（带有 MapRazorPages 的 UseEndpoints）。
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
