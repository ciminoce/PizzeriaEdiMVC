using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Servicios.Servicios.Facades;
using PizzeriaEdiMVC.Windows.Ninject;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmProductos : Form
    {
        public FrmProductos(IServiciosProductos servicio, IServiciosTipoProducto serviciosTipoProducto)
        {
            InitializeComponent();
            _servicio = servicio;
            _serviciosTipoProducto = serviciosTipoProducto;
        }

        private IServiciosTipoProducto _serviciosTipoProducto;
        private IServiciosProductos _servicio;
        private List<ProductoListDto> lista;
        private IMapper _mapper;
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            _mapper = PizzeriaEdiMVC.Mapeador.Mapeador.CrearMapper();
            ActializarGrilla();
        }

        private void ActializarGrilla()
        {
            try
            {
                lista = _servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var producto in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, producto);
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

        private void SetearFila(DataGridViewRow r, ProductoListDto producto)
        {
            r.Cells[cmnProducto.Index].Value = producto.Descripcion;
            r.Cells[cmnTipoProducto.Index].Value = producto.TipoProducto;
            r.Cells[cmnPrecio.Index].Value = producto.Precio;
            r.Cells[cmnActivo.Index].Value = producto.Activo;

            r.Tag = producto;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProductosAE frm = DI.Create<FrmProductosAE>();
            frm.Text = "Agregar Producto";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ProductoEditDto productoEditDto = frm.GetTipo();
                    if (_servicio.Existe(productoEditDto))
                    {
                        MessageBox.Show("Registro repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _servicio.Guardar(productoEditDto);
                    DataGridViewRow r = ConstruirFila();
                    var productoListDto = _mapper.Map<ProductoListDto>(productoEditDto);
                    productoListDto.TipoProducto = (_serviciosTipoProducto
                            .GetTipoPorId(productoEditDto.TipoProductoId))
                        .Descripcion;
                    SetearFila(r, productoListDto);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            var productoListDto = r.Tag as ProductoListDto;
            var productoListDtoCopia = (ProductoListDto)productoListDto.Clone();
            FrmProductosAE frm = DI.Create<FrmProductosAE>();
            frm.Text = "Editar Producto";
            ProductoEditDto productoEditDto = _servicio.GetProductoPorId(productoListDto.ProductoId);
            frm.SetProducto(productoEditDto);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            productoEditDto = frm.GetTipo();
            if (_servicio.Existe(productoEditDto))
            {
                MessageBox.Show("Registro repetido...", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, productoListDtoCopia);
                return;
            }
            try
            {
                _servicio.Guardar(productoEditDto);
                productoListDto = _mapper.Map<ProductoListDto>(productoEditDto);
                productoListDto.TipoProducto = (_serviciosTipoProducto
                    .GetTipoPorId(productoEditDto.TipoProductoId)).Descripcion;
                SetearFila(r, productoListDto);
                MessageBox.Show("Registro modificado...", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, productoListDtoCopia);


            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            var productoDto = r.Tag as ProductoListDto;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el registro de {productoDto.Descripcion}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            try
            {
                _servicio.Borrar(productoDto.ProductoId);
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

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarProductos frm = DI.Create<FrmBuscarProductos>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }

            var tipoDto = frm.GetTipoProducto();
            try
            {
                lista = _servicio.GetLista(tipoDto.Descripcion);
                MostrarDatosEnGrilla();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActializarGrilla();
        }
    }
}
