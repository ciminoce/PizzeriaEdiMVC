using PizzeriaEdiMVC.Entidades.DTOs.Producto;

namespace PizzeriaEdiMVC.Entidades.DTOs.ItemVenta
{
    public class ItemVentaEditDto
    {
        public int ItemVentaId { get; set; }
        public int VentaId { get; set; }
        public ProductoListDto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

    }
}
