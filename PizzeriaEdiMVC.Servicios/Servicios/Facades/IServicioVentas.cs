using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.Venta;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Servicios.Servicios.Facades
{
    public interface IServicioVentas
    {
        void Guardar(VentaEditDto ventaDto);
        VentaListDto GetVentaPorId(int ventaId);
        List<VentaListDto> GetLista();
    }
}
