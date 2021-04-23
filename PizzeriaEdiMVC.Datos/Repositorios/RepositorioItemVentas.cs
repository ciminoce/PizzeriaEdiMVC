using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using PizzeriaEdiMVC.Datos.Repositorios.Facades;
using PizzeriaEdiMVC.Entidades.DTOs.ItemVenta;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.Repositorios
{
    public class RepositorioItemVentas:IRepositorioItemVentas
    {
        private readonly PizzeriaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioItemVentas(PizzeriaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public void Guardar(ItemVenta itemVenta)
        {
            if (itemVenta.ItemVentaId == 0)
            {
                _context.ItemVentas.Add(itemVenta);
            }else
            {
                var itemInDb = _context.ItemVentas.SingleOrDefault(iv => iv.ItemVentaId == itemVenta.ItemVentaId);
                itemInDb.Cantidad = itemVenta.Cantidad;
                itemInDb.ProductoId = itemVenta.ProductoId;
                itemInDb.PrecioUnitario = itemVenta.PrecioUnitario;

                _context.Entry(itemInDb).State = EntityState.Modified;


            }
        }

        public List<ItemVentaListDto> GetLista(int ventaId)
        {
            try
            {
                var lista=_context.ItemVentas.Include(iv=>iv.Producto).Where(iv => iv.VentaId == ventaId).ToList();
                return _mapper.Map<List<ItemVentaListDto>>(lista);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
