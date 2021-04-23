using System.Collections.Generic;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;

namespace PizzeriaEdiMVC.Entidades.DTOs.TipoProducto
{
    public class TipoProductoDetailsDto
    {
        public TipoProductoListDto Tipo { get; set; }
        public List<ProductoListDto> ProductosListDto{ get; set; }
    }
}
