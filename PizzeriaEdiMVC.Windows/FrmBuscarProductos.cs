using System;
using System.Windows.Forms;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmBuscarProductos : Form
    {
        public FrmBuscarProductos()
        {
            InitializeComponent();
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmBuscarProductos_Load(object sender, EventArgs e)
        {
            Helper.Helper.CargarComboTipoProductos(ref TipoProductoComboBox);
        }

        private TipoProductoListDto tipoDto;
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                tipoDto = TipoProductoComboBox.SelectedItem as TipoProductoListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (TipoProductoComboBox.SelectedIndex==0)
            {
                valido = false;
                errorProvider1.SetError(TipoProductoComboBox,"Debe seleccionar un tipo");
            }

            return valido;
        }

        public TipoProductoListDto GetTipoProducto()
        {
            return tipoDto;
        }
    }
}
