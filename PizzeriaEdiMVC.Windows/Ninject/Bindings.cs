using Ninject.Modules;
using PizzeriaEdiMVC.Datos;
using PizzeriaEdiMVC.Datos.Repositorios;
using PizzeriaEdiMVC.Datos.Repositorios.Facades;
using PizzeriaEdiMVC.Servicios.Servicios;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;

namespace PizzeriaEdiMVC.Windows.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<PizzeriaDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositorioTipoProductos>().To<RepositorioTipoProductos>();
            Bind<IServiciosTipoProducto>().To<ServiciosTipoProducto>();

            Bind<IRepositorioProductos>().To<RepositorioProductos>();
            Bind<IServiciosProductos>().To<ServiciosProductos>();

            Bind<IRepositorioVentas>().To<RepositorioVentas>();
            Bind<IRepositorioItemVentas>().To<RepositorioItemVentas>();
            Bind<IServicioVentas>().To<ServicioVentas>();


        }
    }
}
