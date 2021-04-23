using System;
using System.Windows.Forms;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmTipoProductosAE : Form
    {
        public FrmTipoProductosAE()
        {
            InitializeComponent();
        }

        private TipoProductoEditDto tipoDto;
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public TipoProductoEditDto GetTipo()
        {
            return tipoDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (tipoDto!=null)
            {
                TipoProductoTextBox.Text = tipoDto.Descripcion;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (tipoDto==null)
                {
                    tipoDto = new TipoProductoEditDto();

                }

                tipoDto.Descripcion = TipoProductoTextBox.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TipoProductoTextBox.Text.Trim()))
            {
                valido = false;
                errorProvider1.SetError(TipoProductoTextBox,"El tipo de producto es requerido");

            }

            return valido;
        }

        public void SetTipo(TipoProductoEditDto tipoEditDto)
        {
            tipoDto = tipoEditDto;
        }
    }
}
