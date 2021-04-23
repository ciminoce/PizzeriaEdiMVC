using System.ComponentModel.DataAnnotations;

namespace PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto
{
    public class TipoProductoCantidadListViewModel
    {
        public int TipoProductoId { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Cant. Productos")]
        public int CantidadProductos { get; set; }
    }
}
