namespace PizzeriaEdiMVC.Entidades.Entidades
{
    public class ItemVenta
    {
        public int ItemVentaId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
