using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.ViewModels.Venta;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;

namespace PizzeriaEdiMVC.Web.Controllers
{
    public class VentasController : Controller
    {
        private readonly IServicioVentas _servicio;

        private readonly IMapper _mapper;

        public VentasController(IServicioVentas servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Ventas
        public ActionResult Index()
        {
            var ventasDto = _servicio.GetLista();
            var ventasVm = _mapper.Map<List<VentaListViewModel>>(ventasDto);
            return View(ventasVm);
        }
    }
}