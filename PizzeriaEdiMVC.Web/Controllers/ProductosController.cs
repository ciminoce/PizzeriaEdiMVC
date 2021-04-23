using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.ViewModels.Producto;
using PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;
using PizzeriaEdiMVC.Web.Classes;

namespace PizzeriaEdiMVC.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IServiciosProductos _servicio;
        private readonly IServiciosTipoProducto _serviciosTipoProducto;

        private readonly IMapper _mapper;

        private readonly string folder = "~/Content/Imagenes/Productos/";
        public ProductosController(IServiciosProductos servicio, IServiciosTipoProducto serviciosTipoProducto)
        {
            _servicio = servicio;
            _serviciosTipoProducto = serviciosTipoProducto;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        // GET: Productos
        public ActionResult Index(string tipoProducto=null)
        {
            var listaDto = _servicio.GetLista(tipoProducto);
            var listaVm = _mapper.Map<List<ProductoListViewModel>>(listaDto);

            var productoFilterVm = new ProductosFilterListViewModel
            {
                Productos = listaVm,
                TipoProductos = _mapper.Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista())
            };
            return View(productoFilterVm);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductoEditDto productoEditDto = _servicio.GetProductoPorId(id);
            if (productoEditDto==null)
            {
                return HttpNotFound("Código no existente...");
            }
            ProductoDetailsViewModel productoVm = _mapper.Map<ProductoDetailsViewModel>(productoEditDto);

            return View(productoVm);

        }
        [HttpGet]
        public ActionResult Create()
        {
            ProductoEditViewModel productoVm = new ProductoEditViewModel
            {
                Activo = true,
                Imagen = $"SinImagenDisponible.jpg",
                TipoProductos = _mapper
                    .Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista())
            };
            return View(productoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoEditViewModel productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Imagen = $"SinImagenDisponible.jpg";
                productoVm.Activo = true;
                productoVm.TipoProductos = _mapper
                    .Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                return View(productoVm);
            }

            ProductoEditDto productoDto = _mapper.Map<ProductoEditDto>(productoVm);
            if (_servicio.Existe(productoDto))
            {
                ModelState.AddModelError(string.Empty, @"Producto existente...");
                productoVm.Imagen = $"SinImagenDisponible.jpg";
                productoVm.Activo = true;
                productoVm.TipoProductos = _mapper
                    .Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                return View(productoVm);
            }

            try
            {
                if (productoVm.ImagenFile != null)
                {
                    productoDto.Imagen = $"{productoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(productoDto);

                if (productoVm.ImagenFile != null)
                {
                    var file = $"{productoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(productoVm.ImagenFile, folder, file);
                }

                TempData["Msg"] = "Producto agregado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                productoVm.Imagen = $"SinImagenDisponible.jpg";
                productoVm.Activo = true;
                productoVm.TipoProductos = _mapper
                    .Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                return View(productoVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductoEditDto productoEditDto = _servicio.GetProductoPorId(id);
            ProductoEditViewModel productoVm = _mapper.Map<ProductoEditViewModel>(productoEditDto);
            productoVm.TipoProductos = _mapper
                .Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista());
            if (productoVm.Imagen == null)
            {
                productoVm.Imagen = $"SinImagenDisponible.jpg";
            }
            else
            {
                productoVm.Imagen = $"{productoVm.Imagen}";
            }

            return View(productoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoEditViewModel productoVm)
        {
            if (!ModelState.IsValid)
            {
                productoVm.Imagen = $"SinImagenDisponible.jpg";

                productoVm.TipoProductos = _mapper
                    .Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                return View(productoVm);
            }

            ProductoEditDto productoDto = _mapper.Map<ProductoEditDto>(productoVm);
            if (_servicio.Existe(productoDto))
            {
                ModelState.AddModelError(string.Empty, @"Producto existente...");
                productoVm.Imagen = $"SinImagenDisponible.jpg";

                productoVm.TipoProductos = _mapper
                    .Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                return View(productoVm);
            }

            try
            {
                if (productoVm.ImagenFile != null)
                {
                    productoDto.Imagen = $"{productoVm.ImagenFile.FileName}";
                }

                _servicio.Guardar(productoDto);

                if (productoVm.ImagenFile != null)
                {
                    var file = $"{productoVm.ImagenFile.FileName}";
                    var response = FileHelper.UploadPhoto(productoVm.ImagenFile, folder, file);
                }

                TempData["Msg"] = "Producto editado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                productoVm.Imagen = $"{folder}SinImagenDisponible.jpg";

                productoVm.TipoProductos = _mapper
                    .Map<List<TipoProductoListViewModel>>(_serviciosTipoProducto.GetLista());
                return View(productoVm);
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductoEditDto productoEditDto = _servicio.GetProductoPorId(id);
            if (productoEditDto == null)
            {
                return HttpNotFound("Código de tipo de producto inexistente...");
            }

            ProductoListDto productoDto =_mapper.Map<ProductoListDto>(_servicio.GetProductoPorId(id));
            var tipoProducto=_serviciosTipoProducto.GetTipoPorId(productoEditDto.TipoProductoId);
            productoDto.TipoProducto = tipoProducto.Descripcion;

            ProductoListViewModel productoVm = _mapper.Map<ProductoListViewModel>(productoDto);
            
            return View(productoVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductoListViewModel productoVm)
        {
            try
            {
                ProductoListDto productoDto = _mapper
                    .Map<ProductoListDto>(_servicio.GetProductoPorId(productoVm.ProductoId));
                productoVm = _mapper.Map<ProductoListViewModel>(productoDto);

                _servicio.Borrar(productoVm.ProductoId);
                TempData["Msg"] = "Registro borrado...";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(productoVm);
            }
        }
    }
}