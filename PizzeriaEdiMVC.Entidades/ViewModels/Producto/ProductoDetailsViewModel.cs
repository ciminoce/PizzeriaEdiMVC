using System.ComponentModel.DataAnnotations;

namespace PizzeriaEdiMVC.Entidades.ViewModels.Producto
{
    public class ProductoDetailsViewModel
    {
        public int ProductoId { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Tipo de Producto")]
        public string TipoProducto { get; set; }

        public decimal Precio { get; set; }

        public string Detalles { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        public bool Activo { get; set; }

    }
}
