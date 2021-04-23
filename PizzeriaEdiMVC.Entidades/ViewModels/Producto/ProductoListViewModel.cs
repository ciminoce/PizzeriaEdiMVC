using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace PizzeriaEdiMVC.Entidades.ViewModels.Producto
{
    public class ProductoListViewModel
    {
        public int ProductoId { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        [Display(Name = "Tipo de Producto")]
        public string TipoProducto { get; set; }
        public bool Activo { get; set; }
        public string Imagen { get; set; }

    }
}
