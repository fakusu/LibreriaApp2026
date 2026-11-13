using LibreriaApp2026.Servicios.DTOs.Venta;

namespace LibreriaApp2026.Windows
{
    public partial class frmDetalleVenta : Form
    {
        private VentaDetailDto _ventaDto = null!;

        public frmDetalleVenta()
        {
            InitializeComponent();
            Helpers.Tema.Aplicar(this);
            dgvDetalle.AutoGenerateColumns = false;
        }

        public void SetVenta(VentaDetailDto ventaDto)
        {
            _ventaDto = ventaDto;
        }

        private void frmDetalleVenta_Load(object sender, EventArgs e)
        {
            MostrarDatos(_ventaDto);
        }

        private void MostrarDatos(VentaDetailDto ventaDto)
        {
            Text = $"Detalle de la venta N° {ventaDto.VentaId}";
            txtVentaId.Text = ventaDto.VentaId.ToString();
            txtFecha.Text = ventaDto.FechaVenta.ToString("g");
            txtEstado.Text = ventaDto.Estado;
            txtCliente.Text = ventaDto.Cliente;
            txtDocumento.Text = ventaDto.Documento;
            txtDomicilio.Text = ventaDto.Domicilio ?? "(sin domicilio cargado)";
            txtFormaDePago.Text = ventaDto.FormaDePago;
            dgvDetalle.DataSource = ventaDto.Detalles;
            txtTotal.Text = ventaDto.ImporteTotal.ToString("C2");
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
