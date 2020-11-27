using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreStudy
{
    /// <summary>
    /// 具有类型为 RequestDelegate 的参数的公共构造函数。
    ///名为 Invoke 或 InvokeAsync 的公共方法。 此方法必须：
    ///返回 Task。
    ///接受类型 HttpContext 的第一个参数。
    /// </summary>
    public class RequestCultureMiddleware
    {
     
        private readonly RequestDelegate _next;

        /// <summary>
        /// 中间件构造函数使用的范围内生存期服务不与其他依赖关系注入类型共享
        /// 如果必须在中间件和其他类型之间共享范围内服务，
        /// 请将这些服务添加到 Invoke 方法的签名。 Invoke 方法可接受由 DI 填充的其他参数：
        /// </summary>
        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;

            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
      
    }
    public static class RequestCultureMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCulture(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}
