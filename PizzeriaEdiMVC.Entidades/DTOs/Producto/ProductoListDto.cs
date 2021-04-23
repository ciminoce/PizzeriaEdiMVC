using System;

namespace PizzeriaEdiMVC.Entidades.DTOs.Producto
{
    public class ProductoListDto:ICloneable
    {
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string TipoProducto { get; set; }
        public bool Activo { get; set; }
        public string Imagen { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
