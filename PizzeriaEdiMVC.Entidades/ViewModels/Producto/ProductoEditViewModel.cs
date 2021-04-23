using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto;

namespace PizzeriaEdiMVC.Entidades.ViewModels.Producto
{
    public class ProductoEditViewModel
    {
        public int ProductoId { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50,ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres",MinimumLength = 3)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1,int.MaxValue,ErrorMessage = "El precio debe ser positivo")]
        public decimal Precio { get; set; }

        [MaxLength(256,ErrorMessage = "El campo {0} no puede contener más de {1} caracteres")]
        public string Detalles { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Imagen { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo de Producto")]
        [Range(1,int.MaxValue,ErrorMessage = "Debe seleccionar un tipo de producto")]
        public int TipoProductoId { get; set; }
        public bool Activo { get; set; }
        public HttpPostedFileBase ImagenFile { get; set; }
        public List<TipoProductoListViewModel> TipoProductos { get; set; }

    }
}
