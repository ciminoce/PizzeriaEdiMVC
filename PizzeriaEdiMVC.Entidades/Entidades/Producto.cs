namespace PizzeriaEdiMVC.Entidades.Entidades
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Detalles { get; set; }
        public string Imagen { get; set; }
        public int TipoProductoId { get; set; }
        public bool Activo { get; set; }
        public TipoProducto TipoProducto { get; set; }

    }
}
