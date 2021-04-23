using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PizzeriaEdiMVC.Entidades.DTOs.Producto;
using PizzeriaEdiMVC.Entidades.DTOs.TipoProducto;

namespace PizzeriaEdiMVC.Windows
{
    public partial class FrmProductosAE : Form
    {
        public FrmProductosAE()
        {
            InitializeComponent();
        }

        private ProductoEditDto productoDto;

        public ProductoEditDto GetTipo()
        {
            return productoDto;
        }
        private readonly string _imagenNoDisponible = Application.StartupPath + "\\Imagenes\\Productos\\SinImagenDisponible.jpg";
        private readonly string _archivoNoEncontrado = Application.StartupPath + "\\Imagenes\\Productos\\" + "ArchivoNoEncontrado.jpg";
        private readonly string _rutaCarpetaImagenes = Application.StartupPath + "\\Imagenes\\Productos\\";
        private string _rutaDelArchivo = "";

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboTipoProductos(ref TipoProductoComboBox);
            if (productoDto==null)
            {
                ImagePictureBox.Image=Image.FromFile(_imagenNoDisponible);
                return;
            }

            DescripcionTextBox.Text = productoDto.Descripcion;
            DetallesTextBox.Text = productoDto.Detalles;
            PrecioTextBox.Text = productoDto.Precio.ToString();
            ActivoCheckBox.Checked = productoDto.Activo;
            TipoProductoComboBox.SelectedValue = productoDto.TipoProductoId;
            if (productoDto.Imagen!=null)
            {
                //Antes se podria verificar si existe el archivo de la imagen
                 ImagePictureBox.Image=Image.FromFile($"{_rutaCarpetaImagenes}{productoDto.Imagen}");
                 _rutaDelArchivo = productoDto.Imagen;
            }
            else
            {
               ImagePictureBox.Image = Image.FromFile(_imagenNoDisponible);

            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (productoDto==null)
                {
                    productoDto = new ProductoEditDto();
                }

                productoDto.Descripcion = DescripcionTextBox.Text;
                productoDto.Detalles = DetallesTextBox.Text;
                productoDto.Precio = decimal.Parse(PrecioTextBox.Text);
                productoDto.Activo = ActivoCheckBox.Checked;
                productoDto.Imagen = _rutaDelArchivo;
                productoDto.TipoProductoId = ((TipoProductoListDto) TipoProductoComboBox.SelectedItem).TipoProductoId;
                DialogResult = DialogResult.OK;

            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            return valido;
        }

        private void BuscarImagenButton_Click(object sender, EventArgs e)
        {
            //Abro un filedialog para buscar un archivo de imagen
            OpenFileDialog openFileDialog1 = new OpenFileDialog
                //Seteo que no se pueda elegir más de uno a la vez
                //Pongo los filtros 
                //Por defecto busco bitmaps
                {
                    InitialDirectory = _rutaCarpetaImagenes,
                    Multiselect = false,
                    Filter = @" Imagenes(*.BMP;*.JPG;*.GIF;*.PGN)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*",
                    FilterIndex = 1
                };
            //Abro el cuadro de diálogo
            DialogResult dr = openFileDialog1.ShowDialog(this);
            //Si el dialogo termina OK
            if (dr == DialogResult.OK)
            {
                //Tomo el nombre del archivo de imagen con su ruta
                //archivoNombreConRuta = openFileDialog1.FileName;
                ImagePictureBox.Image = Image.FromFile(openFileDialog1.FileName);
                _rutaDelArchivo = Path.GetFileName(openFileDialog1.FileName);
                //_producto.Imagen = _rutaDelArchivo;
            }

        }

        public void SetProducto(ProductoEditDto productoEditDto)
        {
            productoDto = productoEditDto;
        }
    }
}
