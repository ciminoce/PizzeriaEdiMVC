using System;
using System.Collections.Generic;
using AutoMapper;
using PizzeriaEdiMVC.Datos;
using PizzeriaEdiMVC.Datos.Repositorios.Facades;
using PizzeriaEdiMVC.Entidades.DTOs.Venta;
using PizzeriaEdiMVC.Entidades.Entidades;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;

namespace PizzeriaEdiMVC.Servicios.Servicios
{
    public class ServicioVentas : IServicioVentas
    {
        private readonly PizzeriaDbContext _context;
        private readonly IRepositorioVentas _repositorio;
        private readonly IRepositorioItemVentas _repositorioItems;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicioVentas(PizzeriaDbContext context, IRepositorioVentas repositorio,
            IRepositorioItemVentas repositorioItems, IUnitOfWork unitOfWork)
        {
            _context = context;
            _repositorio = repositorio;
            _repositorioItems = repositorioItems;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public ServicioVentas(PizzeriaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public void Guardar(VentaEditDto ventaDto)
        {
            Venta venta = _mapper.Map<Venta>(ventaDto);
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var venta1 = new Venta()
                    {
                        VentaId = venta.VentaId,
                        FechaVenta = venta.FechaVenta,
                        ModalidadVenta = venta.ModalidadVenta,
                        EstadoVenta = venta.EstadoVenta
                    };
                    _repositorio.Guardar(venta1);
                    _unitOfWork.Save();
                    foreach (var item in venta.ItemsVentas)
                    {
                        var item1 = new ItemVenta()
                        {
                            ItemVentaId = item.ItemVentaId,
                            VentaId = venta1.VentaId,
                            ProductoId = item.Producto.ProductoId,
                            PrecioUnitario = item.PrecioUnitario,
                            Cantidad = item.Cantidad
                        };
                        
                        
                        _repositorioItems.Guardar(item1);

                    }
                    _unitOfWork.Save();
                    tran.Commit();
                    ventaDto.VentaId = venta1.VentaId;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new Exception(e.Message);

                }
            }

        }

        public VentaListDto GetVentaPorId(int ventaId)
        {
            try
            {
                var venta=_repositorio.GetVentaPorId(ventaId);
                venta.ItemsVentas = _repositorioItems.GetLista(ventaId);
                return venta;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<VentaListDto> GetLista()
        {
            try
            {
                var ventas = _repositorio.GetLista();
                return ventas;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
