using LibreriaApp2026.Entidades;
using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.DTOs.LibroDigital;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmLibroDigitalAe : Form
    {
        private LibroDigitalUpdateDto? _libroUpdateDto;
        private readonly ILibroDigitalServicio _libroServicio;
        private readonly IEditorialServicio _editorialServicio;
        private bool _esEdicion = false;

        public frmLibroDigitalAe(ILibroDigitalServicio libroServicio, IEditorialServicio editorialServicio)
        {
            InitializeComponent();
            _libroServicio = libroServicio;
            _editorialServicio = editorialServicio;
        }

        public bool DataChanged { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            nudAnio.Minimum = Libro.AnioMinimo;
            nudAnio.Maximum = DateTime.Today.Year;
            CargarComboEditoriales();
            if (_libroUpdateDto is null)
            {
                nudAnio.Value = DateTime.Today.Year;
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtTitulo.Text = _libroUpdateDto.Titulo;
                txtDescripcion.Text = _libroUpdateDto.Descripcion;
                txtISBN.Text = _libroUpdateDto.ISBN;
                cboEditorial.SelectedValue = _libroUpdateDto.EditorialId;
                nudAnio.Value = _libroUpdateDto.AnioPublicacion;
                nudPrecio.Value = _libroUpdateDto.Precio;
                nudStock.Value = _libroUpdateDto.Stock;
                cboFormato.Text = _libroUpdateDto.Formato;
                nudTamanio.Value = _libroUpdateDto.TamanioMB;
                txtUrlDescarga.Text = _libroUpdateDto.UrlDescarga;
                chkActivo.Checked = _libroUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        private void CargarComboEditoriales()
        {
            var resultadoConsulta = _editorialServicio.FiltrarPorActivo(true);
            if (resultadoConsulta.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                return;
            }
            var lista = resultadoConsulta.Value!.OrderBy(e => e.Nombre).ToList();
            //si el libro que se edita tiene una editorial que ya no está activa, se agrega igual para no perderla
            if (_libroUpdateDto is not null && !lista.Any(e => e.EditorialId == _libroUpdateDto.EditorialId))
            {
                var resultadoEditorial = _editorialServicio.ObtenerPorId(_libroUpdateDto.EditorialId);
                if (resultadoEditorial.IsSuccess)
                {
                    lista.Add(resultadoEditorial.Value!);
                }
            }
            lista.Insert(0, new EditorialListDto { EditorialId = 0, Nombre = "Seleccione" });
            cboEditorial.DataSource = lista;
            cboEditorial.DisplayMember = "Nombre";
            cboEditorial.ValueMember = "EditorialId";
            cboEditorial.SelectedIndex = 0;
        }

        public void SetLibro(LibroDigitalUpdateDto? libroEditDto)
        {
            _libroUpdateDto = libroEditDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {
                        var libroCreateDto = new LibroDigitalCreateDto
                        {
                            Titulo = txtTitulo.Text,
                            Descripcion = txtDescripcion.Text,
                            ISBN = txtISBN.Text,
                            EditorialId = (int)cboEditorial.SelectedValue!,
                            AnioPublicacion = (int)nudAnio.Value,
                            Precio = nudPrecio.Value,
                            Stock = (int)nudStock.Value,
                            Formato = cboFormato.Text,
                            TamanioMB = nudTamanio.Value,
                            UrlDescarga = txtUrlDescarga.Text,
                            Activo = true
                        };
                        var resultadoAgregar = _libroServicio.Agregar(libroCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        var respuestaAgregarOtro = MessageBox.Show("Registro agregado\n¿Desea agregar otro?",
                                "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                        if (respuestaAgregarOtro == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        InicializarControles();
                    }
                    else
                    {
                        _libroUpdateDto!.Titulo = txtTitulo.Text;
                        _libroUpdateDto.Descripcion = txtDescripcion.Text;
                        _libroUpdateDto.ISBN = txtISBN.Text;
                        _libroUpdateDto.EditorialId = (int)cboEditorial.SelectedValue!;
                        _libroUpdateDto.AnioPublicacion = (int)nudAnio.Value;
                        _libroUpdateDto.Precio = nudPrecio.Value;
                        _libroUpdateDto.Stock = (int)nudStock.Value;
                        _libroUpdateDto.Formato = cboFormato.Text;
                        _libroUpdateDto.TamanioMB = nudTamanio.Value;
                        _libroUpdateDto.UrlDescarga = txtUrlDescarga.Text;
                        _libroUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _libroServicio.Editar(_libroUpdateDto);
                        if (resultadoEditar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);
                            return;
                        }
                        DataChanged = true;
                        MessageBox.Show("Registro editado satisfactoriamente",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarControles()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();
            txtISBN.Clear();
            cboEditorial.SelectedIndex = 0;
            nudAnio.Value = DateTime.Today.Year;
            nudPrecio.Value = 0;
            nudStock.Value = 0;
            cboFormato.SelectedIndex = -1;
            cboFormato.Text = string.Empty;
            nudTamanio.Value = 0;
            txtUrlDescarga.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
            txtTitulo.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTitulo, "El título es requerido");
            }
            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                valido = false;
                errorProvider1.SetError(txtISBN, "El ISBN es requerido");
            }
            if (cboEditorial.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboEditorial, "Debe seleccionar una editorial");
            }
            if (string.IsNullOrWhiteSpace(cboFormato.Text))
            {
                valido = false;
                errorProvider1.SetError(cboFormato, "El formato es requerido");
            }
            if (nudTamanio.Value <= 0)
            {
                valido = false;
                errorProvider1.SetError(nudTamanio, "El tamaño debe ser mayor a cero");
            }
            if (string.IsNullOrWhiteSpace(txtUrlDescarga.Text))
            {
                valido = false;
                errorProvider1.SetError(txtUrlDescarga, "La URL de descarga es requerida");
            }
            return valido;
        }
    }
}
