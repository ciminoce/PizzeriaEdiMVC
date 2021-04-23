using System.ComponentModel.DataAnnotations;

namespace PizzeriaEdiMVC.Entidades.ViewModels.ItemVenta
{
    public class ItemVentaListViewModel
    {
        public int ItemVentaid { get; set; }
        public string Producto { get; set; }

        [Display(Name = "Precio Unit.")]
        public decimal PrecioUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Total => PrecioUnitario * Cantidad;

    }
}
