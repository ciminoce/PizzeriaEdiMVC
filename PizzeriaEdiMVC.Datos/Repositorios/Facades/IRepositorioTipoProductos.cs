using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioTipoProductos
    {
        List<TipoProductoListDto> GetLista();
        TipoProductoEditDto GetTipoPorId(int? id);
        void Guardar(TipoProducto tipoProducto);
        void Borrar(int? id);
        bool Existe(TipoProducto tipoProducto);
        bool EstaRelacionado(TipoProducto tipo);
        List<TipoProductoCantidadListDto> GetListaTipoCantidad();
        TipoProductoDetailsDto GetDetallesPorId(int? id);
    }
}
