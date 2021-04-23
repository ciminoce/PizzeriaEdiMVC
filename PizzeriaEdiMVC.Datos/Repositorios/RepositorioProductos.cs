using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using PizzeriaEdiMVC.Datos.Repositorios.Facades;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.Repositorios
{
    public class RepositorioProductos:IRepositorioProductos
    {
        private readonly PizzeriaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioProductos(PizzeriaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public List<ProductoListDto> GetLista(string tipo)
        {
            try
            {

                if (tipo==null)
                {
                    var lista = _context.Productos.Include(p => p.TipoProducto)
                .Select(p => new ProductoListDto
                {
                    ProductoId = p.ProductoId,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio,
                    TipoProducto = p.TipoProducto.Descripcion,
                    Activo = p.Activo,
                    Imagen = p.Imagen
                }).ToList();
                    return lista;

                }
                else
                {
                    var lista = _context.Productos.Include(p => p.TipoProducto)
                        .Where(p=>p.TipoProducto.Descripcion==tipo)
                        .Select(p => new ProductoListDto
                        {
                            ProductoId = p.ProductoId,
                            Descripcion = p.Descripcion,
                            Precio = p.Precio,
                            TipoProducto = p.TipoProducto.Descripcion,
                            Activo = p.Activo,
                            Imagen = p.Imagen
                        }).ToList();
                    return lista;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al intentar leer los productos");
            }
        }

        public bool Existe(Producto producto)
        {
            if (producto.ProductoId == 0)
            {
                return _context.Productos.Any(p => p.Descripcion == producto.Descripcion);
            }

            return _context.Productos.Any(p =>
                p.Descripcion == producto.Descripcion && p.ProductoId != producto.ProductoId);
        }

        public void Guardar(Producto producto)
        {
            try
            {
                if (producto.ProductoId == 0)
                {
                    _context.Productos.Add(producto);
                }
                else
                {
                    var productoInDb = _context
                        .Productos
                        .SingleOrDefault(p => p.ProductoId == producto.ProductoId);
                    productoInDb.TipoProductoId = producto.TipoProductoId;
                    productoInDb.Descripcion = producto.Descripcion;
                    productoInDb.ProductoId = producto.ProductoId;
                    productoInDb.Activo = producto.Activo;
                    productoInDb.Imagen = producto.Imagen;
                    productoInDb.Detalles = producto.Detalles;
                    productoInDb.Precio = producto.Precio;
                    _context.Entry(productoInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar un producto");
            }
        }

        public ProductoEditDto GetProductoPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<ProductoEditDto>(_context.Productos
                        .Include(p=>p.TipoProducto)
                        .SingleOrDefault(p => p.ProductoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer  un producto");
            }
           
        }

        public void Borrar(int tipoVmProductoId)
        {
            try
            {
                var productoInDb = _context.Productos.SingleOrDefault(p => p.ProductoId == tipoVmProductoId);
                if (productoInDb == null)
                {
                    throw new Exception("Producto inexistente...");

                }

                _context.Entry(productoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar un producto");
            }
        }
    }
}
