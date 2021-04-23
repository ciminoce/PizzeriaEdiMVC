using System.Runtime.Remoting.Messaging;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;

namespace PizzeriaEdiMVC.Entidades.DTOs.ItemVenta
{
    public class ItemVentaListDto
    {
        public int ItemVentaId { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public decimal Total => Cantidad * PrecioUnitario;
    }
}
