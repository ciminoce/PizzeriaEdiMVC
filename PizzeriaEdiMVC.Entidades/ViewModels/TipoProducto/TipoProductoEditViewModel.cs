using System.ComponentModel.DataAnnotations;

namespace PizzeriaEdiMVC.Entidades.ViewModels.TipoProducto
{
    public class TipoProductoEditViewModel
    {
        public int TipoProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50,ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres",MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    }
}
