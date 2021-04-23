using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzeriaEdiMVC.Entidades.Entidades.Enums;
using PizzeriaEdiMVC.Entidades.ViewModels.ItemVenta;

namespace PizzeriaEdiMVC.Entidades.ViewModels.Venta
{
    public class VentaDetailsViewModel
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
        public List<ItemVentaListViewModel> Detalles { get; set; }

    }
}
