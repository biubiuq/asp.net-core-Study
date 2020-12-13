using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.NetCoreStudy
{
    public class Ping : IRequest<string>
    {
        //可以自定义任意的字段
        public string Title { get; set; }
        public string Content { get; set; }
    }
    public class PingHandler : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            Console.WriteLine("PingHandler Doing..." + request.Title);
            return Task.FromResult("ok");
        }
    }




    #region 多播发送接口
    //Publish 方法的默认实现：同步循环每个处理程序，一个失败不影响后边的处理程序，这样可以确保每个处理程序都依次运行，而且按照顺序运行。
    // 根据发布通知的不同需求，您可能需要不同的策略来处理通知，也许您想并行发布所有通知，或者使用您自己的异常处理逻辑包装每个通知处理程序。
    //　在 MediatR.Examples.PublishStrategies 中可以找到一些示例实现， 其实就是使用 PublishStrategy 枚举设置不同的策略，参考以下链接。
    /// <summary>
    ///  定义多播消息类，需要继承INotification
    /// </summary>
    public class NotyPing : INotification
    {
        public string Message { get; set; }
    }
    public class Noty1Handler : INotificationHandler<NotyPing>
    {
        public Task Handle(NotyPing notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Noty1Handler Doing..." + notification.Message);
            return Task.CompletedTask;
        }
    }
    public class Noty2Handler : INotificationHandler<NotyPing>
    {
        public Task Handle(NotyPing notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Noty2Handler Doing..." + notification.Message);
            return Task.CompletedTask;
        }
    }
    #endregion


}
