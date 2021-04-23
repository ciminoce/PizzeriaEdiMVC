using System;
using System.Windows.Forms;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Entidades.Entidades;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmVentasAE : Form
    {
        public FrmVentasAE()
        {
            InitializeComponent();
        }

        private Carrito carrito = new Carrito();
        private IMapper _mapper;
        private void FrmVentasAE_Load(object sender, EventArgs e)
        {
            _mapper = PizzeriaEdiMVC.Mapeador.Mapeador.CrearMapper();
            Helper.Helper.CargarComboTipoProductos(ref TiposComboBox);
            ProductosComboBox.Enabled = false;
        }

        private void TiposComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TiposComboBox.SelectedIndex > 0)
            {
                var tipoSeleccionado = (TipoProductoListDto) TiposComboBox.SelectedItem;
                Helper.Helper.CargarComboProductos(tipoSeleccionado.Descripcion,ref ProductosComboBox);
                ProductosComboBox.Enabled = true;
            }
            else
            {
                ProductosComboBox.DataSource = null;
                ProductosComboBox.Enabled = false;
            }
        }

        private ProductoListDto productoSeleccionado;
        private void ProductosComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProductosComboBox.SelectedIndex>0)
            {
                productoSeleccionado = (ProductoListDto) ProductosComboBox.SelectedItem;
                PrecioUnitTextBox.Text = productoSeleccionado.Precio.ToString();
            }
            else
            {
                productoSeleccionado = null;
                PrecioUnitTextBox.Clear();
            }
        }

        private void CancelarProductoButton_Click(object sender, EventArgs e)
        {
            InicializarControles();
        }

        private void InicializarControles()
        {
            ProductosComboBox.DataSource = null;
            PrecioUnitTextBox.Clear();
            productoSeleccionado = null;
            TiposComboBox.SelectedIndex = 0;
            TiposComboBox.Focus();
        }

        private void AceptarProductoButton_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto
            {
                ProductoId = productoSeleccionado.ProductoId,
                Descripcion = productoSeleccionado.Descripcion,
                Precio = productoSeleccionado.Precio
            };
            var itemCarrito = new ItemCarrito
            {
                Producto = producto,
                Cantidad = (int) CantidadNumericUpDown.Value
            };
            carrito.AgregarAlCarrito(producto,(int)CantidadNumericUpDown.Value);
            MostrarDatosEnGrilla();
            CalcularTotal();
            InicializarControles();
        }

        private void MostrarDatosEnGrilla()
        {
            PedidoDataGridView.Rows.Clear();
            foreach (var itemCarrito in carrito.listaItems)
            {
                var r = ConstruirFila();
                SetearFila(r,itemCarrito);
                AgregarFila(r);
                
            }
        }

        private void CalcularTotal()
        {
            TotalPedidoTextBox.Text = carrito.TotalCarrito().ToString();
        }


        private void AgregarFila(DataGridViewRow r)
        {
            PedidoDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ItemCarrito itemCarrito)
        {
            r.Cells[cmnProducto.Index].Value = itemCarrito.Producto.Descripcion;
            r.Cells[cmnPrecioUnitario.Index].Value = itemCarrito.Producto.Precio;
            r.Cells[cmnCantidad.Index].Value = itemCarrito.Cantidad;
            r.Cells[cmnTotal.Index].Value = itemCarrito.Cantidad * itemCarrito.Producto.Precio;

            r.Tag = itemCarrito;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(PedidoDataGridView);
            return r;
        }
    }
}
