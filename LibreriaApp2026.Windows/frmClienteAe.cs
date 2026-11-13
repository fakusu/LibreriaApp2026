using LibreriaApp2026.Entidades.Validaciones;
using LibreriaApp2026.Servicios.DTOs.Cliente;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmClienteAe : Form
    {
        private ClienteUpdateDto? _clienteUpdateDto;
        private readonly IClienteServicio _clienteServicio;
        private bool _esEdicion = false;

        public frmClienteAe(IClienteServicio clienteServicio)
        {
            InitializeComponent();
            Helpers.Tema.Aplicar(this);
            FiltroTeclado.SoloLetras(txtNombre, txtApellido, txtProvincia);
            FiltroTeclado.SoloDigitos(txtDocumento);
            FiltroTeclado.Telefono(txtTelefono);
            FiltroTeclado.LetrasYDigitos(txtCodigoPostal);
            _clienteServicio = clienteServicio;
        }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//para avisar al listado que hubo conflicto de concurrencia

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_clienteUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtNombre.Text = _clienteUpdateDto.Nombre;
                txtApellido.Text = _clienteUpdateDto.Apellido;
                txtDocumento.Text = _clienteUpdateDto.Documento;
                txtTelefono.Text = _clienteUpdateDto.Telefono;
                txtEmail.Text = _clienteUpdateDto.Email;
                txtCalle.Text = _clienteUpdateDto.Calle;
                txtNumero.Text = _clienteUpdateDto.Numero;
                txtLocalidad.Text = _clienteUpdateDto.Localidad;
                txtProvincia.Text = _clienteUpdateDto.Provincia;
                txtCodigoPostal.Text = _clienteUpdateDto.CodigoPostal;
                chkActivo.Checked = _clienteUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        public void SetCliente(ClienteUpdateDto? clienteEditDto)
        {
            _clienteUpdateDto = clienteEditDto;
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
                        var clienteCreateDto = new ClienteCreateDto
                        {
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Documento = txtDocumento.Text,
                            Telefono = txtTelefono.Text,
                            Email = txtEmail.Text,
                            Calle = txtCalle.Text,
                            Numero = txtNumero.Text,
                            Localidad = txtLocalidad.Text,
                            Provincia = txtProvincia.Text,
                            CodigoPostal = txtCodigoPostal.Text,
                            Activo = true
                        };
                        var resultadoAgregar = _clienteServicio.Agregar(clienteCreateDto);
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
                        _clienteUpdateDto!.Nombre = txtNombre.Text;
                        _clienteUpdateDto.Apellido = txtApellido.Text;
                        _clienteUpdateDto.Documento = txtDocumento.Text;
                        _clienteUpdateDto.Telefono = txtTelefono.Text;
                        _clienteUpdateDto.Email = txtEmail.Text;
                        _clienteUpdateDto.Calle = txtCalle.Text;
                        _clienteUpdateDto.Numero = txtNumero.Text;
                        _clienteUpdateDto.Localidad = txtLocalidad.Text;
                        _clienteUpdateDto.Provincia = txtProvincia.Text;
                        _clienteUpdateDto.CodigoPostal = txtCodigoPostal.Text;
                        _clienteUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _clienteServicio.Editar(_clienteUpdateDto);
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
            foreach (var textBox in new[] { txtNombre, txtApellido, txtDocumento, txtTelefono, txtEmail,
                txtCalle, txtNumero, txtLocalidad, txtProvincia, txtCodigoPostal })
            {
                textBox.Clear();
            }
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
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDocumento, "El documento es requerido");
            }
            else if (!Formatos.EsDni(txtDocumento.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDocumento, "El documento debe ser un DNI de 7 u 8 dígitos");
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Formatos.EsEmail(txtEmail.Text))
            {
                valido = false;
                errorProvider1.SetError(txtEmail, "El email no tiene un formato válido");
            }
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !Formatos.EsNombrePersona(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "Solo letras, espacios, apóstrofos, guiones y puntos");
            }
            if (!string.IsNullOrWhiteSpace(txtApellido.Text) && !Formatos.EsNombrePersona(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "Solo letras, espacios, apóstrofos, guiones y puntos");
            }
            if (!string.IsNullOrWhiteSpace(txtTelefono.Text) && !Formatos.EsTelefono(txtTelefono.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTelefono, "Solo números, espacios, +, - y paréntesis (al menos 6 dígitos)");
            }
            if (!string.IsNullOrWhiteSpace(txtNumero.Text) && !Formatos.EsNumeroCalle(txtNumero.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNumero, "Número (puede llevar una letra, ej: 930 B) o S/N");
            }
            if (!string.IsNullOrWhiteSpace(txtLocalidad.Text) && !Formatos.EsLocalidad(txtLocalidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtLocalidad, "Solo letras, números, espacios, puntos y guiones");
            }
            if (!string.IsNullOrWhiteSpace(txtProvincia.Text) && !Formatos.EsSoloLetras(txtProvincia.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProvincia, "Solo letras, espacios, puntos y guiones");
            }
            if (!string.IsNullOrWhiteSpace(txtCodigoPostal.Text) && !Formatos.EsCodigoPostal(txtCodigoPostal.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCodigoPostal, "4 dígitos (ej: 1042) o CPA (ej: C1042AAB)");
            }
            //el domicilio es opcional, pero si se carga tiene que estar completo (para el envío a domicilio)
            var domicilio = new[] { txtCalle, txtNumero, txtLocalidad, txtProvincia };
            if (domicilio.Append(txtCodigoPostal).Any(t => !string.IsNullOrWhiteSpace(t.Text)))
            {
                foreach (var t in domicilio.Where(t => string.IsNullOrWhiteSpace(t.Text)))
                {
                    valido = false;
                    errorProvider1.SetError(t, "Complete el domicilio (calle, número, localidad y provincia)");
                }
            }
            return valido;
        }
    }
}
