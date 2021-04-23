using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;
using PizzeriaEdiMVC.Windows.Ninject;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmTipoProductos : Form
    {
        public FrmTipoProductos(IServiciosTipoProducto servicio)
        {
            InitializeComponent();
            _servicio = servicio;
        }

        private IMapper _mapper;
        private IServiciosTipoProducto _servicio;
        private List<TipoProductoListDto> _lista;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTipoProductos_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = PizzeriaEdiMVC.Mapeador.Mapeador.CrearMapper();
                //_servicio=new ServiciosTipoProducto();
                _lista = _servicio.GetLista();
                MostrarDatosEnGrilla();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var tipoProducto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, tipoProducto);
                AgregarFila(r);

            }
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r=new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, TipoProductoListDto tipoProducto)
        {
            r.Cells[cmnTipoProducto.Index].Value = tipoProducto.Descripcion;

            r.Tag = tipoProducto;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmTipoProductosAE frm = DI.Create<FrmTipoProductosAE>();
            frm.Text = "Agregar Nuevo Tipo de Producto";
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.OK)
            {
                try
                {
                    TipoProductoEditDto tipoEditDto = frm.GetTipo();
                    if (_servicio.Existe(tipoEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(tipoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var tipoListDto = _mapper.Map<TipoProductoListDto>(tipoEditDto);
                    SetearFila(r,tipoListDto);
                    AgregarFila(r);
                    MessageBox.Show("Registro agregado...", "Mensaje", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count==0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            var tipoDto = r.Tag as TipoProductoListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {tipoDto.Descripcion}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr==DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(tipoDto.TipoProductoId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Registro borrado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            var tipoDto = r.Tag as TipoProductoListDto;
            var tipoDtoCopia = (TipoProductoListDto) tipoDto.Clone();
            FrmTipoProductosAE frm = DI.Create<FrmTipoProductosAE>();
            frm.Text = "Editar Tipo de Producto";
            TipoProductoEditDto tipoEditDto = _mapper.Map<TipoProductoEditDto>(tipoDto);
            frm.SetTipo(tipoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            tipoEditDto = frm.GetTipo();
            if (_servicio.Existe(tipoEditDto))
            {
                MessageBox.Show("Registro repetido...", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r,tipoDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(tipoEditDto);
                var tipoListDto = _mapper.Map<TipoProductoListDto>(tipoEditDto);
                SetearFila(r, tipoListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, tipoDtoCopia);


            }

        }
    }
}
