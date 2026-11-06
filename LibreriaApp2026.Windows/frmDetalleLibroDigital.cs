using LibreriaApp2026.Servicios.DTOs.LibroDigital;

namespace LibreriaApp2026.Windows
{
    public partial class frmDetalleLibroDigital : Form
    {
        private LibroDigitalDetailDto _libroDto = null!;

        public frmDetalleLibroDigital()
        {
            InitializeComponent();
        }

        public void SetLibro(LibroDigitalDetailDto libroDto)
        {
            _libroDto = libroDto;
        }

        private void frmDetalleLibroDigital_Load(object sender, EventArgs e)
        {
            MostrarDatos(_libroDto);
        }

        private void MostrarDatos(LibroDigitalDetailDto libroDto)
        {
            Text = $"Detalle de {libroDto.Titulo}";
            txtTitulo.Text = libroDto.Titulo;
            txtIsbn.Text = libroDto.ISBN;
            txtAnio.Text = libroDto.AnioPublicacion.ToString();
            txtEditorial.Text = libroDto.Editorial;
            txtPrecio.Text = libroDto.Precio.ToString("C2");
            txtFormato.Text = libroDto.Formato;
            txtTamanio.Text = libroDto.TamanioMB.ToString("N2");
            txtUrl.Text = libroDto.UrlDescarga;
            txtDescripcion.Text = libroDto.Descripcion;
            lstAutores.DataSource = libroDto.Autores;
            lstTemas.DataSource = libroDto.Temas;
            chkActivo.Checked = libroDto.Activo;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
