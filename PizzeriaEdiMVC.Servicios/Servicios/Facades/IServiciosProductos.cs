using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;

namespace PizzeriaEdiMVC.Servicios.Servicios.Facades
{
    public interface IServiciosProductos
    {
        List<ProductoListDto> GetLista(string tipo);
        bool Existe(ProductoEditDto productoEditDto);
        void Guardar(ProductoEditDto productoDto);
        ProductoEditDto GetProductoPorId(int? id);
        void Borrar(int tipoVmProductoId);
    }
}
