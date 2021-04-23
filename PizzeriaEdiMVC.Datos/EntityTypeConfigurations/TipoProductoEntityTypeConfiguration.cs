using System.Data.Entity.ModelConfiguration;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.EntityTypeConfigurations
{
    public class TipoProductoEntityTypeConfiguration:EntityTypeConfiguration<TipoProducto>
    {
        public TipoProductoEntityTypeConfiguration()
        {
            ToTable("TipoProductos");
        }
    }
}
