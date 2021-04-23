using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;

namespace PizzeriaEdiMVC.Web.Controllers
{
    public class TipoProductosController : Controller
    {
        private readonly IServiciosTipoProducto _servicio;
        private readonly IServiciosProductos _servicioProductos;
        private readonly IMapper _mapper;

        public TipoProductosController(IServiciosTipoProducto servicio,IServiciosProductos servicioProductos)
        {
            _servicio = servicio;
            _servicioProductos = servicioProductos;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: TipoProductos
        public ActionResult Index()
        {
            var listaDto = _servicio.GetListaTipoCantidad();
            var listaVm = _mapper.Map<List<TipoProductoCantidadListViewModel>>(listaDto);
            return View(listaVm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoProductoEditDto tipoDto = _servicio.GetTipoPorId(id);
            if (tipoDto == null)
            {
                return HttpNotFound("Código de tipo de producto inexistente...");
            }

            TipoProductoDetailsDto tipoDetailDto = _servicio.GetDetallesPorId(id);

            TipoProductoDetailsViewModel tipoDetailVm = _mapper.Map<TipoProductoDetailsViewModel>(tipoDetailDto);
            return View(tipoDetailVm);

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoProductoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoProductoEditDto tipoDto = _mapper.Map<TipoProductoEditDto>(tipoVm);
            if (_servicio.Existe(tipoDto))
            {
                ModelState.AddModelError(string.Empty,"Registro existente...");
                return View(tipoVm);
            }

            try
            {
                _servicio.Guardar(tipoDto);
                TempData["Msg"] = "Registro agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoProductoEditDto tipoDto = _servicio.GetTipoPorId(id);
            if (tipoDto==null)
            {
                return HttpNotFound("Código de tipo de producto inexistente...");
            }

            TipoProductoEditViewModel tipoVm = _mapper.Map<TipoProductoEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoProductoEditViewModel tipoVm)
        {
            TipoProductoEditDto tipoDto = _mapper.Map<TipoProductoEditDto>(tipoVm);
            if (_servicio.EstaRelacionado(tipoDto))
            {
                ModelState.AddModelError(String.Empty, "Registro relacionado con otras tablas... Baja denegada");
                return View(tipoVm);

            }

            try
            {
                tipoVm = _mapper.Map<TipoProductoEditViewModel>(_servicio.GetTipoPorId(tipoVm.TipoProductoId));

                _servicio.Borrar(tipoVm.TipoProductoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(tipoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoProductoEditDto tipoDto = _servicio.GetTipoPorId(id);
            if (tipoDto==null)
            {
                return HttpNotFound("Código de tipo de producto no encontrado...");
            }
            TipoProductoEditViewModel tipoVm = _mapper.Map<TipoProductoEditViewModel>(tipoDto);
            return View(tipoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoProductoEditViewModel tipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }

            TipoProductoEditDto tipoDto = _mapper.Map<TipoProductoEditDto>(tipoVm);
            if (_servicio.Existe(tipoDto))
            {
                ModelState.AddModelError(string.Empty,"Registro duplicado...");
                return View(tipoVm);
            }

            try
            {
                _servicio.Guardar(tipoDto);
                TempData["Msg"] = "Registro modificado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
                return View(tipoVm);
            }
        }
    }
}