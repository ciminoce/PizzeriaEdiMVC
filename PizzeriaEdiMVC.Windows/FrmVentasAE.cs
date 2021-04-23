using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AutoMapper;
using PizzeriaEdiMVC.Entidades.DTOs.ItemVenta;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;
using PizzeriaEdiMVC.Entidades.DTOs.Venta;
using PizzeriaEdiMVC.Entidades.Entidades;
using PizzeriaEdiMVC.Entidades.Entidades.Enums;

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
                var tipoSeleccionado = (TipoProductoListDto)TiposComboBox.SelectedItem;
                Helper.Helper.CargarComboProductos(tipoSeleccionado.Descripcion, ref ProductosComboBox);
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
            if (ProductosComboBox.SelectedIndex > 0)
            {
                productoSeleccionado = (ProductoListDto)ProductosComboBox.SelectedItem;
                PrecioUnitTextBox.Text = productoSeleccionado.Precio.ToString();
                CantidadNumericUpDown.Enabled = true;
            }
            else
            {
                productoSeleccionado = null;
                PrecioUnitTextBox.Clear();
                CantidadNumericUpDown.Enabled = false;
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
            PrecioTotalTextBox.Clear();
            CantidadNumericUpDown.Value = 0;
            TiposComboBox.Focus();
        }

        private void AceptarProductoButton_Click(object sender, EventArgs e)
        {

            if (ValidarProducto())
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
                    Cantidad = (int)CantidadNumericUpDown.Value
                };
                carrito.AgregarAlCarrito(producto, (int)CantidadNumericUpDown.Value);
                MostrarDatosEnGrilla();
                CalcularTotal();
                InicializarControles();

            }
        }

        private bool ValidarProducto()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (TiposComboBox.SelectedIndex > 0)
            {
                if (ProductosComboBox.SelectedIndex == 0)
                {
                    valido = false;
                    errorProvider1.SetError(ProductosComboBox, "Debe seleccionar un producto");
                }

                if (CantidadNumericUpDown.Value == 0)
                {
                    valido = false;
                    errorProvider1.SetError(CantidadNumericUpDown, "Debe llevar al menos un producto");

                }

            }
            else
            {
                valido = false;
                errorProvider1.SetError(TiposComboBox, "Debe seleccionar un tipo de producto");
            }
            return valido;
        }

        private void MostrarDatosEnGrilla()
        {
            PedidoDataGridView.Rows.Clear();
            foreach (var itemCarrito in carrito.listaItems)
            {
                var r = ConstruirFila();
                SetearFila(r, itemCarrito);
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

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (productoSeleccionado!=null)
            {
                PrecioTotalTextBox.Text = (productoSeleccionado.Precio * CantidadNumericUpDown.Value).ToString("C");
                
            }
        }

        private void PedidoDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (PedidoDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            if (e.ColumnIndex != 4)
            {
                return;
            }

            var r = PedidoDataGridView.SelectedRows[0];
            var item = (ItemCarrito)r.Tag;
            DialogResult dr = MessageBox.Show($"¿Desea dar de baja el item {item.Producto.Descripcion}?",
                "Confirmar Baja",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            carrito.EliminarDelCarrito(item.Producto);
            MostrarDatosEnGrilla();
            CalcularTotal();
            InicializarControles();

        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                List<ItemVentaEditDto> listaItems = new List<ItemVentaEditDto>();
                foreach (var item in carrito.listaItems)
                {
                    ItemVentaEditDto itemDto = new ItemVentaEditDto
                    {
                        Producto = _mapper.Map<ProductoListDto>(item.Producto),
                        Cantidad = item.Cantidad,
                        PrecioUnitario = item.Producto.Precio

                    };
                    listaItems.Add(itemDto);
                }
                ventaEditDto = new VentaEditDto
                {
                    FechaVenta = DateTime.Now,
                    ModalidadVenta = ModalidadVenta.TakeAway,
                    EstadoVenta = EstadoVenta.Finalizada,
                    ItemsVentas = listaItems

                };
                
                carrito.VaciarCarrito();
                DialogResult = DialogResult.OK;

            }
        }

        private VentaEditDto ventaEditDto;
        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            return valido;

        }

        public VentaEditDto GetVenta()
        {
            return ventaEditDto;
        }
    }
}
