using LibreriaApp2026.Servicios.DTOs.Editorial;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmEditorialAe : Form
    {
        private EditorialUpdateDto? _editorialUpdateDto;
        private readonly IEditorialServicio _editorialServicio;
        private bool _esEdicion = false;

        public frmEditorialAe(IEditorialServicio editorialServicio)
        {
            InitializeComponent();
            _editorialServicio = editorialServicio;
        }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//para avisar al listado que hubo conflicto de concurrencia

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_editorialUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtNombre.Text = _editorialUpdateDto.Nombre;
                txtPaisOrigen.Text = _editorialUpdateDto.PaisOrigen;
                chkActivo.Checked = _editorialUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        public void SetEditorial(EditorialUpdateDto? editorialEditDto)
        {
            _editorialUpdateDto = editorialEditDto;
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
                        var editorialCreateDto = new EditorialCreateDto
                        {
                            Nombre = txtNombre.Text,
                            PaisOrigen = txtPaisOrigen.Text,
                            Activo = true
                        };
                        var resultadoAgregar = _editorialServicio.Agregar(editorialCreateDto);
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
                        _editorialUpdateDto!.Nombre = txtNombre.Text;
                        _editorialUpdateDto.PaisOrigen = txtPaisOrigen.Text;
                        _editorialUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _editorialServicio.Editar(_editorialUpdateDto);
                        if (resultadoEditar.IsConcurrencyConflict)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);
                            ConcurrencyConflict = true;
                            DialogResult = DialogResult.Cancel;
                            Close();
                            return;
                        }
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
            txtNombre.Clear();
            txtPaisOrigen.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
            txtNombre.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "El nombre es requerido");
            }
            if (string.IsNullOrWhiteSpace(txtPaisOrigen.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPaisOrigen, "El país de origen es requerido");
            }
            return valido;
        }
    }
}
