using System.Data.Entity.ModelConfiguration;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.EntityTypeConfigurations
{
    public class ItemVentaEntityTypeConfigurations:EntityTypeConfiguration<ItemVenta>
    {
        public ItemVentaEntityTypeConfigurations()
        {
            ToTable("ItemVentas");
        }
    }
}
