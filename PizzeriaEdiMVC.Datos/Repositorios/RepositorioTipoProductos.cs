using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using PizzeriaEdiMVC.Datos.Repositorios.Facades;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.Repositorios
{
    public class RepositorioTipoProductos:IRepositorioTipoProductos
    {
        private readonly PizzeriaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioTipoProductos(PizzeriaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public List<TipoProductoListDto> GetLista()
        {
            try
            {
                var lista = _context.TipoProductos.ToList();
                return _mapper.Map<List<TipoProductoListDto>>(lista);
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los tipos de productos");
            }
        }

        public TipoProductoDetailsDto GetDetallesPorId(int? id)
        {
            try
            {
                var tipoDetalle = _context.TipoProductos
                    .GroupJoin(_context.Productos, tp => tp.TipoProductoId, p => p.TipoProductoId,
                        (tipo, productos) => new 
                        {
                            Tipo = tipo,
                            Productos= productos
                        })
                    .SingleOrDefault(tp =>tp.Tipo.TipoProductoId == id);
                TipoProductoDetailsDto tipoDetalleDto = null;
                if (tipoDetalle != null)
                {
                    //tipoDetalleDto = new TipoProductoDetailsDto
                    //{
                    //    Tipo = _mapper.Map<TipoProductoListDto>(tipoDetalle.Tipo),
                    //    ProductosListDto = _mapper.Map<List<ProductoListDto>>(tipoDetalle.Productos.ToList())
                    //};
                    tipoDetalleDto = new TipoProductoDetailsDto();
                    tipoDetalleDto.Tipo = _mapper.Map<TipoProductoListDto>(tipoDetalle.Tipo);
                    tipoDetalleDto.ProductosListDto =
                        _mapper.Map<List<ProductoListDto>>(tipoDetalle.Productos.ToList());


                }
                return tipoDetalleDto;
            }
            catch (Exception ex )
            {
                throw new Exception("Error al intentar leer los tipos de productos");
            }
        }

        public List<TipoProductoCantidadListDto> GetListaTipoCantidad()
        {
            try
            {
                var lista=_context.TipoProductos
                    .GroupJoin(_context.Productos,tp=>tp.TipoProductoId,p=>p.TipoProductoId,
                        (tipo, productos) => new TipoProductoCantidadListDto
                        {
                           TipoProductoId= tipo.TipoProductoId,
                           Descripcion= tipo.Descripcion,
                           CantidadProductos= productos.Count()
                        })
                    .ToList();
                //return _mapper.Map<List<TipoProductoListDto>>(lista);
                return lista;
            }
            catch (Exception )
            {
                throw new Exception("Error al intentar leer los tipos de productos");
            }
        }

        public TipoProductoEditDto GetTipoPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<TipoProductoEditDto>(_context.TipoProductos
                        .SingleOrDefault(tp => tp.TipoProductoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer un tipo de producto");
            }
        }

        public void Guardar(TipoProducto tipoProducto)
        {
            try
            {
                if (tipoProducto.TipoProductoId == 0)
                {
                    _context.TipoProductos.Add(tipoProducto);
                }
                else
                {
                    var tipoInDb = _context.TipoProductos
                        .SingleOrDefault(tp=>tp.TipoProductoId==tipoProducto.TipoProductoId);
                    tipoInDb.Descripcion = tipoProducto.Descripcion;
                    _context.Entry(tipoInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Error al agregar/editar un tipo de producto");
            }

        }

        public void Borrar(int? id)
        {
            try
            {
                var tipoInDb = _context.TipoProductos
                    .SingleOrDefault(tp=>tp.TipoProductoId==id);
                _context.Entry(tipoInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error al borrar un tipo de producto");
            }
        }

        public bool Existe(TipoProducto tipoProducto)
        {
            try
            {
                if (tipoProducto.TipoProductoId == 0)
                {
                    return _context.TipoProductos.Any(tp => tp.Descripcion == tipoProducto.Descripcion);
                }

                return _context.TipoProductos.Any(tp =>
                    tp.Descripcion == tipoProducto.Descripcion && tp.TipoProductoId == tipoProducto.TipoProductoId);

            }
            catch (Exception)
            {

                throw new Exception("Error al verificar si existe un Tipo de Producto");
            }

        }

        public bool EstaRelacionado(TipoProducto tipo)
        {
            try
            {
                return _context.Productos.Any(p => p.TipoProductoId == tipo.TipoProductoId);
            }
            catch (Exception)
            {

                throw new Exception("Error al verificar si está relacionado un Tipo de Producto");
            }

        }

    }
}
