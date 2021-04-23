using PizzeriaEdiMVC.Entidades.ViewModels.Producto;

namespace PizzeriaEdiMVC.Entidades.ViewModels.Carrito
{
    public class ItemCarritoListViewModel
    {
        public ProductoListViewModel ProductoListViewModel { get; set; }
        public int Cantidad { get; set; }
    }
}
