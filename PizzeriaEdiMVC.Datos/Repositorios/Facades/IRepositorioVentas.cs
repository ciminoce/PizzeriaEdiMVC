using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.Venta;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioVentas
    {
        
        void Guardar(Venta venta);
        VentaListDto GetVentaPorId(int ventaId);
        List<VentaListDto> GetLista();
    }
}
