using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Asp.NetCoreStudy.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class dependencyController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMyDependency _myDependency;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;
        private readonly IOperationScoped _scopedOperation;

        public dependencyController(
            ILogger<dependencyController> logger,
            IMyDependency myDependency, IOperationTransient transientOperation,
                      IOperationScoped scopedOperation,
                      IOperationSingleton singletonOperation)
        {
            _logger = logger;
            _myDependency = myDependency;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
        }

        public void OnGet()
        {
           // _myDependency.WriteMessage("Index2Model.OnGet");
            _logger.LogInformation("dependencyController Transient: " + _transientOperation.OperationId);
            _logger.LogInformation("dependencyController Scoped: " + _scopedOperation.OperationId);
            _logger.LogInformation("dependencyController Singleton: " + _singletonOperation.OperationId);
        }
    }
    public interface IMyDependency
    {
        void WriteMessage(string message);
    }
    public class MyDependency : IMyDependency
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine($"MyDependency.WriteMessage Message: {message}");
        }
    }
    public class MyDependency2 : IMyDependency
    {
        private readonly ILogger<MyDependency2> _logger;

        public MyDependency2(ILogger<MyDependency2> logger)
        {
            _logger = logger;
        }

        public void WriteMessage(string message)
        {
      
            _logger.LogInformation($"MyDependency2.WriteMessage Message: {message}");
        }
    }
    /// <summary>
    /// ////////依赖注入的不同周期
    /// 
    /// </summary>
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface IOperationTransient : IOperation { }
    public interface IOperationScoped : IOperation { }
    public interface IOperationSingleton : IOperation { }
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
        }

        public string OperationId { get; }
    }
}
