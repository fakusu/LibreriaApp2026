using LibreriaApp2026.Servicios.DTOs.Tema;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmTemaAe : Form
    {
        private TemaUpdateDto? _temaUpdateDto;
        private readonly ITemaServicio _temaServicio;
        private bool _esEdicion = false;

        public frmTemaAe(ITemaServicio temaServicio)
        {
            InitializeComponent();
            _temaServicio = temaServicio;
        }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//para avisar al listado que hubo conflicto de concurrencia

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_temaUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtNombre.Text = _temaUpdateDto.Nombre;
                txtDescripcion.Text = _temaUpdateDto.Descripcion;
                chkActivo.Checked = _temaUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        public void SetTema(TemaUpdateDto? temaEditDto)
        {
            _temaUpdateDto = temaEditDto;
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
                    //la descripción no es obligatoria: si está vacía se guarda null
                    string? descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text)
                        ? null : txtDescripcion.Text;

                    if (!_esEdicion)
                    {
                        var temaCreateDto = new TemaCreateDto
                        {
                            Nombre = txtNombre.Text,
                            Descripcion = descripcion,
                            Activo = true
                        };
                        var resultadoAgregar = _temaServicio.Agregar(temaCreateDto);
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
                        _temaUpdateDto!.Nombre = txtNombre.Text;
                        _temaUpdateDto.Descripcion = descripcion;
                        _temaUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _temaServicio.Editar(_temaUpdateDto);
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
            txtDescripcion.Clear();
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
            return valido;
        }
    }
}
