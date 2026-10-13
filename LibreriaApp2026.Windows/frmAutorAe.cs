using LibreriaApp2026.Servicios.DTOs.Autor;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmAutorAe : Form
    {
        private AutorUpdateDto? _autorUpdateDto;
        private readonly IAutorServicio _autorServicio;
        private bool _esEdicion = false;

        public frmAutorAe(IAutorServicio autorServicio)
        {
            InitializeComponent();
            _autorServicio = autorServicio;
        }

        public bool DataChanged { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dtpFechaNacimiento.MaxDate = DateTime.Today;
            if (_autorUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtNombre.Text = _autorUpdateDto.Nombre;
                txtApellido.Text = _autorUpdateDto.Apellido;
                dtpFechaNacimiento.Value = _autorUpdateDto.FechaNacimiento;
                txtNacionalidad.Text = _autorUpdateDto.Nacionalidad;
                chkActivo.Checked = _autorUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        public void SetAutor(AutorUpdateDto? autorEditDto)
        {
            _autorUpdateDto = autorEditDto;
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
                        var autorCreateDto = new AutorCreateDto
                        {
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            FechaNacimiento = dtpFechaNacimiento.Value.Date,
                            Nacionalidad = txtNacionalidad.Text,
                            Activo = true
                        };
                        var resultadoAgregar = _autorServicio.Agregar(autorCreateDto);
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
                        _autorUpdateDto!.Nombre = txtNombre.Text;
                        _autorUpdateDto.Apellido = txtApellido.Text;
                        _autorUpdateDto.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                        _autorUpdateDto.Nacionalidad = txtNacionalidad.Text;
                        _autorUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _autorServicio.Editar(_autorUpdateDto);
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
            txtApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtNacionalidad.Clear();
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
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "El apellido es requerido");
            }
            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                valido = false;
                errorProvider1.SetError(dtpFechaNacimiento, "La fecha de nacimiento no puede ser futura");
            }
            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNacionalidad, "La nacionalidad es requerida");
            }
            return valido;
        }
    }
}
