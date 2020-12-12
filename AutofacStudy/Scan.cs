using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutofacStudy
{
    /// <summary>
    /// 程序集扫描
    /// </summary>
    class Scan
    {
        
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {

            //var builder = new ContainerBuilder();
            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            //Container = builder.Build();
            //var dataAccess = Assembly.GetExecutingAssembly();


            //RegisterAssemblyTypes() 接收包含一个或多个程序集的数组作为参数. 默认地, 程序中所有具体的类都将被注册. 
            //包括内部类(internal)和嵌套的私有类. 你可以使用LINQ表达式过滤注册的类型集合.

            //AsImplementedInterfaces 方法介绍
            //　在很多情况下，一个类可能实现了多个接口， 如果我们通过  builder.RegisterType<xxxBLL>().As<IxxxBLL>(); 
            //这种方式按部就班排着把这个类注册给每个接口，实现几个接口，就要写几行注册代码，很繁琐，我们可以通过 AsImplementedInterfaces() 方法，可以把一个类注册给它实现的全部接口。
            //builder.RegisterAssemblyTypes(dataAccess)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();
            ///4.8.0 版本中 PublicOnly() 扩展方法被引入了, 
            ///这使得数据的封装变得更容易了. 如果你只想要你的公有方法被注册, 使用 PublicOnly():
            //     builder.RegisterAssemblyTypes(dataAccess)
            //.PublicOnly();
            #region MyRegion 排除类型Except
            ///
            //  builder.RegisterAssemblyTypes(asm)
            //.Except<MyUnwantedType>();
            #endregion
            #region 模板全部注册
            ///RegisterAssemblyModules() 的重载 不接受类型参数 ,
            ///它将会注册所提供程序集列表中的所有实现 IModule 的类. 在下面的示例中 所有的模块 都将被注册:
            ///通过模板扫描注册
            var assembly = typeof(AComponent).Assembly;
            var builder = new ContainerBuilder();

            // Registers both modules
            builder.RegisterAssemblyModules(assembly);
            #endregion
            ///使用 泛型类型参数 的 RegisterAssemblyModules() 
            ///的重载允许你指定一个所有模块都必须从它派生的基类.
            ///在下面的示例中 只有一个模块 被注册了因为扫描被限制了
            var assembly1 = typeof(AComponent).Assembly;
            var builde1r = new ContainerBuilder();

            // Registers AModule but not BModule
            builde1r.RegisterAssemblyModules<AModule>(assembly1);
        }
        public class AModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.Register(c => new AComponent()).As<AComponent>();
            }
        }

        public class BModule : Autofac.Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                builder.Register(c => new BComponent()).As<BComponent>();
            }
        }

    }
    public class BComponent
    {
        public BComponent()
        {
        }
    }
    public class AComponent
    {
        public AComponent()
        {
        }
    }
}
