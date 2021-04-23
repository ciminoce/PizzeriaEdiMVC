using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.ViewModels.Producto;

namespace PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto
{
    public class TipoProductoDetailsViewModel
    {
        public TipoProductoListViewModel TipoProductoListViewModel { get; set; }
        public List<ProductoListViewModel> ProductosVm { get; set; }

    }
}
