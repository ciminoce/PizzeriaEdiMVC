using System;
using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.Entidades.Enums;

namespace PizzeriaEdiMVC.Entidades.Entidades
{
    public class Venta
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public ModalidadVenta ModalidadVenta { get; set; }
        public EstadoVenta EstadoVenta { get; set; }
        public List<ItemVenta> ItemsVentas { get; set; } = new List<ItemVenta>();
    }
}
