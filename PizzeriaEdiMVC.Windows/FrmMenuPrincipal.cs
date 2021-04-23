using System;
using System.Windows.Forms;
using PizzeriaEdiMVC.Windows.Ninject;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void TipoProductosButton_Click(object sender, EventArgs e)
        {
            FrmTipoProductos frm = DI.Create<FrmTipoProductos>();
            frm.ShowDialog(this);
        }

        private void ProductosButton_Click(object sender, EventArgs e)
        {
            FrmProductos frm = DI.Create<FrmProductos>();
            frm.ShowDialog(this);

        }

        private void VentasButton_Click(object sender, EventArgs e)
        {
            FrmVentas frm = DI.Create<FrmVentas>();
            frm.ShowDialog(this);
        }
    }
}
