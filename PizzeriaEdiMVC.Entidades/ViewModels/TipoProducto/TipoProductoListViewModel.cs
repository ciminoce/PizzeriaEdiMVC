using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto
{
    public class TipoProductoListViewModel
    {
        public int TipoProductoId { get; set; }

        [Display (Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display (Name = @"Cant. Productos")] 
        public int CantidadProductos { get; set; }


    }
}
