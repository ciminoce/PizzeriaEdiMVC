using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto;

namespace PizzeriaEdiMVC.Entidades.ViewModels.Producto
{
    public class ProductosFilterListViewModel
    {
        public List<ProductoListViewModel> Productos { get; set; }
        public List<TipoProductoListViewModel> TipoProductos { get; set; }

    }
}
