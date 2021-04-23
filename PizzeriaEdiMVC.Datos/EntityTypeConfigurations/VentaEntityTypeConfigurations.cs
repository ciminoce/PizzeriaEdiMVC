using System.Data.Entity.ModelConfiguration;
using AutoMapper.Configuration;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos.EntityTypeConfigurations
{
    public class VentaEntityTypeConfigurations:EntityTypeConfiguration<Venta>
    {
        public VentaEntityTypeConfigurations()
        {
            ToTable("Ventas");
        }
    }
}
