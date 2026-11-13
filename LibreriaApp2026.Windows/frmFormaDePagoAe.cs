using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmFormaDePagoAe : Form
    {
        private FormaDePagoUpdateDto? _formaDePagoUpdateDto;
        private readonly IFormaDePagoServicio _formaDePagoServicio;
        private bool _esEdicion = false;

        public frmFormaDePagoAe(IFormaDePagoServicio formaDePagoServicio)
        {
            InitializeComponent();
            Helpers.Tema.Aplicar(this);
            _formaDePagoServicio = formaDePagoServicio;
        }

        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//para avisar al listado que hubo conflicto de concurrencia

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_formaDePagoUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtNombre.Text = _formaDePagoUpdateDto.Nombre;
                chkActivo.Checked = _formaDePagoUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        public void SetFormaDePago(FormaDePagoUpdateDto? formaDePagoEditDto)
        {
            _formaDePagoUpdateDto = formaDePagoEditDto;
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
                        var formaDePagoCreateDto = new FormaDePagoCreateDto
                        {
                            Nombre = txtNombre.Text,
                            Activo = true
                        };
                        var resultadoAgregar = _formaDePagoServicio.Agregar(formaDePagoCreateDto);
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
                        _formaDePagoUpdateDto!.Nombre = txtNombre.Text;
                        _formaDePagoUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _formaDePagoServicio.Editar(_formaDePagoUpdateDto);
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
