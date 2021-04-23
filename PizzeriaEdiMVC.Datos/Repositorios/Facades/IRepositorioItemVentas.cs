using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.ItemVenta;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioItemVentas
    {
        void Guardar(ItemVenta itemVenta);
        List<ItemVentaListDto> GetLista(int ventaId);
    }
}
