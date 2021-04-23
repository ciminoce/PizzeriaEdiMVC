using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PizzeriaEdiMVC.Entidades.Entidades;
using PizzeriaEdiMVC.Web.Binders;

namespace PizzeriaEdiMVC.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Init();
            AreaRegistration.RegisterAllAreas();
            ModelBinders.Binders.Add(typeof(Carrito), new CarritoModelBinder());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
