using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Infrastructure.Page
{
    /// <summary>
    /// 返回时接口
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    public interface IRequest<out TResponse> 
    {
    }
}
