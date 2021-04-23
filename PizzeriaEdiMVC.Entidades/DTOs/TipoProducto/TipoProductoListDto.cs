using System;

namespace PizzeriaEdiMVC.Entidades.DTOs.TipoProducto
{
    public class TipoProductoListDto:ICloneable
    {
        public int TipoProductoId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
