using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioProductos
    {
        List<ProductoListDto> GetLista(string tipo);
        bool Existe(Producto producto);
        void Guardar(Producto producto);
        ProductoEditDto GetProductoPorId(int? id);
        void Borrar(int tipoVmProductoId);
    }
}
