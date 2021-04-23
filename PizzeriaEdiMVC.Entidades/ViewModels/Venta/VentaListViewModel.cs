using System;
using System.ComponentModel.DataAnnotations;
using PizzeriaEdiMVC.Entidades.Entidades.Enums;

namespace PizzeriaEdiMVC.Entidades.ViewModels.Venta
{
    public class VentaListViewModel
    {
        [Display(Name = "Vta. Nro.")]
        public int VentaId { get; set; }

        [Display(Name = "Fecha Vta.")]
        [DataType(DataType.Date)]
        public DateTime FechaVenta { get; set; }

        [Display(Name = "Modalidad Vta.")]
        public ModalidadVenta ModalidadVenta { get; set; }

        [Display(Name = "Estado Vta.")]
        public EstadoVenta EstadoVenta { get; set; }

    }
}
