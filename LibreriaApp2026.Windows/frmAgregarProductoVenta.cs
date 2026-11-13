using LibreriaApp2026.Servicios.DTOs.Venta;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;

namespace LibreriaApp2026.Windows
{
    public partial class frmAgregarProductoVenta : Form
    {
        private readonly IVentaServicio _ventaServicio;
        private ProductoVentaDto? _productoSeleccionado;
        private DetalleVentaDto? _detalle;

        public frmAgregarProductoVenta(IVentaServicio ventaServicio)
        {
            InitializeComponent();
            Helpers.Tema.Aplicar(this);
            _ventaServicio = ventaServicio;
            dgvProductos.AutoGenerateColumns = false;
            AcceptButton = btnBuscar;//Enter en el buscador
        }

        public DetalleVentaDto? GetDetalle()
        {
            return _detalle;
        }

        private void frmAgregarProductoVenta_Load(object sender, EventArgs e)
        {
            CargarProductos(null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarProductos(string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim());
        }

        //solo aparecen libros activos de editoriales activas
        private void CargarProductos(string? textoBuscar)
        {
            var resultado = _ventaServicio.ObtenerProductosParaVenta(textoBuscar);
            if (resultado.IsFailure)
            {
                ErrorHelper.MostrarErrores(resultado.Errors);
                return;
            }
            dgvProductos.DataSource = resultado.Value;
            MostrarSeleccionado();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            MostrarSeleccionado();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//doble clic en el encabezado
            btnOK_Click(sender, e);
        }

        private void MostrarSeleccionado()
        {
            errorProvider1.Clear();
            _productoSeleccionado = dgvProductos.CurrentRow?.DataBoundItem as ProductoVentaDto;
            if (_productoSeleccionado is null)
            {
                txtProducto.Clear();
                txtPrecio.Clear();
                txtSubtotal.Clear();
                lblStock.Text = string.Empty;
                nudCantidad.Enabled = false;
                return;
            }

            txtProducto.Text = _productoSeleccionado.Titulo;
            txtPrecio.Text = _productoSeleccionado.Precio.ToString("C2");
            if (_productoSeleccionado.EsDigital)
            {
                //los libros digitales se venden de a una unidad
                nudCantidad.Maximum = 1;
                nudCantidad.Value = 1;
                nudCantidad.Enabled = false;
                lblStock.Text = "Libro digital: se vende de a una unidad.";
            }
            else
            {
                int stock = _productoSeleccionado.Stock!.Value;
                nudCantidad.Maximum = Math.Max(stock, 1);
                nudCantidad.Value = 1;
                nudCantidad.Enabled = stock > 0;
                lblStock.Text = stock > 0 ? $"Stock disponible: {stock}" : "Sin stock disponible.";
            }
            CalcularSubtotal();
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            if (_productoSeleccionado is null) return;
            txtSubtotal.Text = (_productoSeleccionado.Precio * nudCantidad.Value).ToString("C2");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (_productoSeleccionado is null)
            {
                errorProvider1.SetError(dgvProductos, "Debe seleccionar un producto");
                return;
            }
            if (!_productoSeleccionado.EsDigital && _productoSeleccionado.Stock <= 0)
            {
                errorProvider1.SetError(nudCantidad, "El libro no tiene stock");
                return;
            }

            _detalle = new DetalleVentaDto
            {
                ProductoId = _productoSeleccionado.ProductoId,
                Producto = _productoSeleccionado.Titulo,
                Tipo = _productoSeleccionado.Tipo,
                Cantidad = (int)nudCantidad.Value,
                PrecioUnitario = _productoSeleccionado.Precio,
                Stock = _productoSeleccionado.Stock,
            };
            DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
