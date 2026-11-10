using LibreriaApp2026.Servicios.DTOs.LibroFisico;

namespace LibreriaApp2026.Windows
{
    public partial class frmDetalleLibroFisico : Form
    {
        private LibroFisicoDetailDto _libroDto = null!;

        public frmDetalleLibroFisico()
        {
            InitializeComponent();
            Helpers.Tema.Aplicar(this);
        }

        public void SetLibro(LibroFisicoDetailDto libroDto)
        {
            _libroDto = libroDto;
        }

        private void frmDetalleLibroFisico_Load(object sender, EventArgs e)
        {
            MostrarDatos(_libroDto);
        }

        private void MostrarDatos(LibroFisicoDetailDto libroDto)
        {
            Text = $"Detalle de {libroDto.Titulo}";
            txtTitulo.Text = libroDto.Titulo;
            txtIsbn.Text = libroDto.ISBN;
            txtAnio.Text = libroDto.AnioPublicacion.ToString();
            txtEditorial.Text = libroDto.Editorial;
            txtPrecio.Text = libroDto.Precio.ToString("C2");
            txtStock.Text = libroDto.Stock.ToString();
            txtPaginas.Text = libroDto.CantidadPaginas.ToString();
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
