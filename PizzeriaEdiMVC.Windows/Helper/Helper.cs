using System.Windows.Forms;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;
using PizzeriaEdiMVC.Windows.Ninject;

namespace PizzeriaEdiMVC.Windows.Helper
{
    public class Helper
    {
        public static void CargarComboTipoProductos(ref ComboBox combo)
        {
            IServiciosTipoProducto serviciosTipoProducto = DI.Create<IServiciosTipoProducto>();
            var lista = serviciosTipoProducto.GetLista();
            var defaultTipo = new TipoProductoListDto
            {
                TipoProductoId = 0,
                Descripcion = "<Seleccione un Tipo>"
            };
            lista.Insert(0, defaultTipo);
            combo.DataSource = lista;
            combo.ValueMember = "TipoProductoId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;

        }

        public static void CargarComboProductos(string tipoSeleccionadon, ref ComboBox combo)
        {
            IServiciosProductos serviciosProductos = DI.Create<IServiciosProductos>();
            var lista = serviciosProductos.GetLista(tipoSeleccionadon);
            var defaultProducto = new ProductoListDto
            {
                ProductoId = 0,
                Descripcion = "<Seleccione Producto>"
            };
            lista.Insert(0,defaultProducto);
            combo.DataSource = lista;
            combo.ValueMember = "ProductoId";
            combo.DisplayMember = "Descripcion";
            combo.SelectedIndex = 0;
        }
    }
}
