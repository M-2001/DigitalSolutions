[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DigitalSolutions.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DigitalSolutions.NinjectWebCommon), "Stop")]

namespace DigitalSolutions
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using DigitalSolutions.Domain;
    using DigitalSolutions.Services;
    using System.Collections.Generic;


    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        private static void RegisterServices(IKernel kernel)
        {
            //init services injector
            ServiceInjector injector = new ServiceInjector(kernel);
            kernel.Bind<IServiceInjector>().ToConstant(injector);

            //init service bus
            IServiceBus serviceBus = new ServiceBus(injector);
            kernel.Bind<IServiceBus>().ToConstant(serviceBus);

            //infrastructure services
            kernel.Bind<IDbContext>().To<GlobalDbContext>().InRequestScope();

            //query services
            //kernel.Bind<IBlogQueryService>().To<BlogQueryService>().InRequestScope();
            kernel.Bind<ICustomerQueryService>().To<CustomerQueryService>().InRequestScope();

            //command services
            injector.Bind<ICustomerCommandService, CustomerCommandService>();


        }
    }


    public sealed class ServiceInjector : IServiceInjector
    {
        private static IKernel kernel;
        private static List<Type> types;

        public ServiceInjector(IKernel krn)
        {
            kernel = krn;
            types = new List<Type>();
        }

        public void Bind<Intf, Impl>() where Impl : Intf
        {
            types.Add(typeof(Intf));
            kernel.Bind<Intf>().To<Impl>().InRequestScope();
        }

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }


        public object Get(Type type)
        {
            return kernel.Get(type);
        }

        public List<Type> GetTypes()
        {
            return types;
        }

        public void BindConst<Intf, Impl>(Impl impl) where Impl : Intf
        {
            throw new NotImplementedException();
        }
    }

}
