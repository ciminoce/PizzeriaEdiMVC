using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.DTOs.ItemVenta;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.DTOs.Venta;
using PizzeriaEdiMVC.Entidades.Entidades;
using PizzeriaEdiMVC.Entidades.Entidades.Enums;
using PizzeriaEdiMVC.Entidades.ViewModels.Carrito;
using PizzeriaEdiMVC.Entidades.ViewModels.Venta;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;

namespace PizzeriaEdiMVC.Web.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IServiciosProductos _servicioProductos;
        private readonly IServicioVentas _servicio;
        private IMapper _mapper;

        public CarritoController(IServiciosProductos servicioProductos, IServicioVentas servicio)
        {
            _servicioProductos = servicioProductos;
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public ActionResult Index(Carrito carrito, string returnUrl)
        {
            List<ItemCarritoListViewModel> listaItems = _mapper.Map<List<ItemCarritoListViewModel>>(carrito.GetItems());
            return View(new CarritoListViewModel
            {
                Items = listaItems,
                ReturnUrl = returnUrl
            });
        }

        public ActionResult AddToCart(Carrito carrito, int productoId, string returnUrl)
        {
            ProductoEditDto productoDto = _servicioProductos.GetProductoPorId(productoId);
            if (productoDto != null)
            {
                Producto producto = _mapper.Map<Producto>(productoDto);
                carrito.AgregarAlCarrito(producto, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ActionResult RemoveFromCart(Carrito carrito, int productoId, string returnUrl)
        {
            Producto producto = _mapper.Map<Producto>(_servicioProductos.GetProductoPorId(productoId));
            if (producto != null)
            {
                carrito.EliminarDelCarrito(producto);
            }

            return RedirectToAction("Index", new { returnUrl });

        }
        public PartialViewResult Summary(Carrito carrito)
        {
            return PartialView(carrito);
        }

        public ActionResult CheckOut(Carrito carrito)
        {
            if (carrito.GetItems().Count==0)
            {
                ModelState.AddModelError(string.Empty,"No tiene compras efectuadas!!!");
            }

            var carritoVm = _mapper.Map<CarritoListViewModel>(carrito);

            return View(carritoVm);
        }

        public ActionResult CancelarPedido(Carrito carrito)
        {
            carrito.VaciarCarrito();
            return RedirectToAction("Index", "Productos");
        }

        public ActionResult ConfirmarPedido(Carrito carrito)
        {
            try
            {
                List<ItemVentaEditDto> listaItems = new List<ItemVentaEditDto>();
                foreach (var item in carrito.listaItems)
                {
                    ItemVentaEditDto itemDto = new ItemVentaEditDto
                    {
                        Producto = _mapper.Map<ProductoListDto>(item.Producto),
                        Cantidad = item.Cantidad,
                        PrecioUnitario = item.Producto.Precio

                    };
                    listaItems.Add(itemDto);
                }
                VentaEditDto ventaEditDto = new VentaEditDto
                {
                    FechaVenta = DateTime.Now,
                    ModalidadVenta = ModalidadVenta.TakeAway,
                    EstadoVenta = EstadoVenta.Finalizada,
                    ItemsVentas = listaItems
                    
                };
                 _servicio.Guardar(ventaEditDto);
                ViewBag.VentaId = ventaEditDto.VentaId;
                carrito.VaciarCarrito();
                return View("VentaGuardada");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,e.Message);
            }

            return View("ErrorAlProcesarPedido");
        }
        public ActionResult GeneratePdf(int id)
        {
            return new Rotativa.ActionAsPdf("GeneratePdfPreview", new { ventaId = id });
        }

        public ActionResult GeneratePdfPreview(int ventaId)
        {
            var ventaDto = _servicio.GetVentaPorId(ventaId);
            var ventaVm = _mapper.Map<VentaDetailsViewModel>(ventaDto);
            return View(ventaVm);
        }

    }
}