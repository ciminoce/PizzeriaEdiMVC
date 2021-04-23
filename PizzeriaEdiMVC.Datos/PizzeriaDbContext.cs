using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Datos
{
    public class PizzeriaDbContext:DbContext
    {
        public PizzeriaDbContext():base("MiConexion")
        {
            Database.CommandTimeout = 50;
            Configuration.UseDatabaseNullSemantics = true;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<PizzeriaDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //evita el borrado en cascada
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly()); //le digo que tome las configuraciones del  mismo assembly
        }

        public DbSet<TipoProducto> TipoProductos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<ItemVenta> ItemVentas { get; set; }
    }
}
