using Asp.NetCoreStudy.Controller;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreStudy
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;

        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger,
            IOperationTransient transientOperation,
            IOperationSingleton singletonOperation)
        {
            _logger = logger;
            _transientOperation = transientOperation;
            _singletonOperation = singletonOperation;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            IOperationScoped scopedOperation)
        {
            _logger.LogInformation("MyMiddleware Transient: " + _transientOperation.OperationId);
            _logger.LogInformation("MyMiddleware Scoped: " + scopedOperation.OperationId);
            _logger.LogInformation("MyMiddleware Singleton: " + _singletonOperation.OperationId);

            await _next(context);
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
