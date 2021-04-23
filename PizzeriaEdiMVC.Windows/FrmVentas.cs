using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PizzeriaEdiMVC.Entidades.DTOs.Venta;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;
using PizzeriaEdiMVC.Windows.Ninject;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmVentas : Form
    {
        public FrmVentas(IServicioVentas servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private readonly IServicioVentas _servicio;
        
        private List<VentaListDto> _lista;
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            
            try
            {
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var ventaListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ventaListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, VentaListDto ventaListDto)
        {
            r.Cells[cmnNroVenta.Index].Value = ventaListDto.VentaId;
            r.Cells[cmnFechaVenta.Index].Value = ventaListDto.FechaVenta.ToShortDateString();

            r.Tag = ventaListDto;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbDetalle_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            try
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                var ventaDto = (VentaListDto)r.Tag;
                ventaDto = _servicio.GetVentaPorId(ventaDto.VentaId);
                FrmVerDetallePedido frm = new FrmVerDetallePedido();
                frm.Text = $"Detalles del Pedido {ventaDto.VentaId}";
                frm.SetDetalle(ventaDto.ItemsVentas);
                frm.ShowDialog(this);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmVentasAE frm = DI.Create<FrmVentasAE>();
            DialogResult dr=frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                
            }
        }
    }
}
