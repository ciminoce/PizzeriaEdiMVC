using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;

namespace PizzeriaEdiMVC.Servicios.Servicios.Facades
{
    public interface IServiciosTipoProducto
    {
        List<TipoProductoListDto> GetLista();
        TipoProductoEditDto GetTipoPorId(int? id);
        void Guardar(TipoProductoEditDto tipoProducto);
        void Borrar(int? id);
        bool Existe(TipoProductoEditDto tipoProducto);
        bool EstaRelacionado(TipoProductoEditDto tipoDto);
        List<TipoProductoCantidadListDto> GetListaTipoCantidad();
        TipoProductoDetailsDto GetDetallesPorId(int? id);


    }
}
