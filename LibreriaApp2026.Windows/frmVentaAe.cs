using LibreriaApp2026.Servicios.DTOs.Cliente;
using LibreriaApp2026.Servicios.DTOs.FormaDePago;
using LibreriaApp2026.Servicios.DTOs.Venta;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmVentaAe : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IClienteServicio _clienteServicio;
        private readonly IFormaDePagoServicio _formaDePagoServicio;
        private readonly EditorVenta _editorVenta = new();
        private readonly BindingSource _bindingSource = new();

        public frmVentaAe(IServiceProvider serviceProvider,
            IClienteServicio clienteServicio,
            IFormaDePagoServicio formaDePagoServicio)
        {
            InitializeComponent();
            Helpers.Tema.Aplicar(this);
            _serviceProvider = serviceProvider;
            _clienteServicio = clienteServicio;
            _formaDePagoServicio = formaDePagoServicio;
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.DataSource = _bindingSource;
        }

        public bool DataChanged { get; private set; }

        private void frmVentaAe_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToString("g");
            txtEstado.Text = "Pendiente";
            CargarComboClientes();
            CargarComboFormasDePago();
            MostrarDetalle();
        }

        //solo se puede vender a clientes activos
        private void CargarComboClientes()
        {
            var resultado = _clienteServicio.FiltrarPorActivo(true);
            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }
            var lista = resultado.Value!;
            lista.Insert(0, new ClienteListDto { ClienteId = 0, NombreCompleto = "Seleccione", Documento = string.Empty });
            cboClientes.DataSource = lista;
            cboClientes.DisplayMember = nameof(ClienteListDto.NombreCompleto);
            cboClientes.ValueMember = nameof(ClienteListDto.ClienteId);
            cboClientes.SelectedIndex = 0;
        }

        private void CargarComboFormasDePago()
        {
            var resultado = _formaDePagoServicio.FiltrarPorActivo(true);
            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }
            var lista = resultado.Value!;
            lista.Insert(0, new FormaDePagoListDto { FormaDePagoId = 0, Nombre = "Seleccione" });
            cboFormasDePago.DataSource = lista;
            cboFormasDePago.DisplayMember = nameof(FormaDePagoListDto.Nombre);
            cboFormasDePago.ValueMember = nameof(FormaDePagoListDto.FormaDePagoId);
            cboFormasDePago.SelectedIndex = 0;
        }

        //muestra el domicilio del cliente (para el envío a domicilio)
        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedItem is ClienteListDto cliente && cliente.ClienteId > 0)
            {
                txtDireccion.Text = string.IsNullOrWhiteSpace(cliente.Direccion) ? "(sin domicilio cargado)" : cliente.Direccion;
                txtLocalidad.Text = cliente.Localidad;
                txtProvincia.Text = cliente.Provincia;
                txtCodigoPostal.Text = cliente.CodigoPostal;
            }
            else
            {
                txtDireccion.Clear();
                txtLocalidad.Clear();
                txtProvincia.Clear();
                txtCodigoPostal.Clear();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmAgregarProductoVenta>())
            {
                if (frm.ShowDialog() != DialogResult.OK) return;
                var detalle = frm.GetDetalle();
                if (detalle is null) return;
                try
                {
                    _editorVenta.AgregarProducto(detalle);
                    MostrarDetalle();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEditarCantidad_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not DetalleVentaDto detalle)
            {
                MessageBox.Show("Debe seleccionar un producto de la venta",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (detalle.Stock is null)
            {
                MessageBox.Show("Los libros digitales se venden de a una unidad.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var respuesta = Microsoft.VisualBasic.Interaction.InputBox(
                $"Cantidad de {detalle.Producto} (stock disponible: {detalle.Stock}):",
                "Editar cantidad", detalle.Cantidad.ToString());
            if (string.IsNullOrWhiteSpace(respuesta)) return;//canceló

            if (!int.TryParse(respuesta, out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un número entero.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                _editorVenta.ModificarCantidad(detalle.ProductoId, cantidad);
                MostrarDetalle();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not DetalleVentaDto detalle)
            {
                MessageBox.Show("Debe seleccionar un producto de la venta",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dr = MessageBox.Show($"¿Desea quitar {detalle.Producto} de la venta?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;

            _editorVenta.QuitarProducto(detalle.ProductoId);
            MostrarDetalle();
        }

        private void MostrarDetalle()
        {
            _bindingSource.DataSource = _editorVenta.Detalles.ToList();
            _bindingSource.ResetBindings(false);
            txtTotal.Text = _editorVenta.Total.ToString("C2");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;
            try
            {
                var ventaDto = new VentaCreateDto
                {
                    ClienteId = (int)cboClientes.SelectedValue!,
                    FormaDePagoId = (int)cboFormasDePago.SelectedValue!,
                    Detalles = _editorVenta.ObtenerDetallesParaGuardar(),
                };

                //si el servicio rechaza la venta (ej: otro usuario vendió el stock) el carrito queda cargado para corregirlo.
                //Cada intento usa un scope nuevo, así el stock se vuelve a leer de la base de datos
                using var scope = _serviceProvider.CreateScope();
                var ventaServicio = scope.ServiceProvider.GetRequiredService<IVentaServicio>();
                var resultado = ventaServicio.Agregar(ventaDto);
                if (resultado.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultado.Errors);
                    return;
                }
                DataChanged = true;
                MessageBox.Show($"Venta N° {resultado.Value} registrada correctamente.",
                    "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!_editorVenta.EstaVacia)
            {
                var dr = MessageBox.Show("¿Desea descartar la venta?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) return;
            }
            DialogResult = DialogResult.Cancel;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboClientes.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboClientes, "Debe seleccionar un cliente");
            }
            if (cboFormasDePago.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider1.SetError(cboFormasDePago, "Debe seleccionar una forma de pago");
            }
            if (_editorVenta.EstaVacia)
            {
                valido = false;
                errorProvider1.SetError(dgvDetalle, "Debe agregar al menos un producto");
            }
            return valido;
        }
    }
}
