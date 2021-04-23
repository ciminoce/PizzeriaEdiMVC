using System.Data.Entity.ModelConfiguration;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.EntityTypeConfigurations
{
    public class ProductoEntityTypeConfigurations:EntityTypeConfiguration<Producto>
    {
        public ProductoEntityTypeConfigurations()
        {
            ToTable("Productos");
        }
    }
}
