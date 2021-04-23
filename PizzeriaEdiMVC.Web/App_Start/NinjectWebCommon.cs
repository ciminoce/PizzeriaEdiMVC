using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using PizzeriaEdiMVC.Datos;
using PizzeriaEdiMVC.Datos.Repositorios;
using PizzeriaEdiMVC.Datos.Repositorios.Facades;
using PizzeriaEdiMVC.Servicios.Servicios;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;
using PizzeriaEdiMVC.Web;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace PizzeriaEdiMVC.Web
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
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
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IServiciosTipoProducto>().To<ServiciosTipoProducto>().InRequestScope();
            kernel.Bind<IRepositorioTipoProductos>().To<RepositorioTipoProductos>().InRequestScope();

            kernel.Bind<IServiciosProductos>().To<ServiciosProductos>().InRequestScope();
            kernel.Bind<IRepositorioProductos>().To<RepositorioProductos>().InRequestScope();

            kernel.Bind<IServicioVentas>().To<ServicioVentas>().InRequestScope();
            kernel.Bind<IRepositorioVentas>().To<RepositorioVentas>().InRequestScope();
            kernel.Bind<IRepositorioItemVentas>().To<RepositorioItemVentas>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(PizzeriaDbContext)).ToSelf().InSingletonScope();


        }
    }
}