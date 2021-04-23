using System.Collections.Generic;

namespace PizzeriaEdiMVC.Entidades.ViewModels.Carrito
{
    public class CarritoListViewModel
    {
        public List<ItemCarritoListViewModel> Items { get; set; }
        public string ReturnUrl { get; set; }

    }
}
