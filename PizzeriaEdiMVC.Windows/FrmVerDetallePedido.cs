using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PizzeriaEdiMVC.Entidades.DTOs.ItemVenta;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.DTOs.Venta;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmVerDetallePedido : Form
    {
        public FrmVerDetallePedido()
        {
            InitializeComponent();
        }

        private List<ItemVentaListDto> _lista;
        public void SetDetalle(List<ItemVentaListDto> listaDetalle)
        {
            _lista = listaDetalle;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var item in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, item);
                AgregarFila(r);

            }
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ItemVentaListDto item)
        {
            r.Cells[cmnProducto.Index].Value =item.Producto;
            r.Cells[cmnPrecioUnitario.Index].Value = item.PrecioUnitario;
            r.Cells[cmnCantidad.Index].Value = item.Cantidad;
            r.Cells[cmnTotal.Index].Value = item.Total;

        }
    }
}
