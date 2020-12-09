using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCoreStudy
{
    public interface ITestAutofac
    {
        string WriteMessage();
    }
    public class TestAutofac : ITestAutofac
    {
        public string WriteMessage()
        {
            return "AutoFac.ccccccccccccccccccccccccc";
        }
    }
}
