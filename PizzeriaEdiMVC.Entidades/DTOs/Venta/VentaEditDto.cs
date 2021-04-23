using System;
using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.ItemVenta;
using PizzeriaEdiMVC.Entidades.Entidades.Enums;

namespace PizzeriaEdiMVC.Entidades.DTOs.Venta
{
    public class VentaEditDto
    {
        public int VentaId { get; set; }
        public DateTime FechaVenta { get; set; }
        public ModalidadVenta ModalidadVenta { get; set; }
        public EstadoVenta EstadoVenta { get; set; }
        public List<ItemVentaEditDto> ItemsVentas { get; set; } = new List<ItemVentaEditDto>();

    }
}
