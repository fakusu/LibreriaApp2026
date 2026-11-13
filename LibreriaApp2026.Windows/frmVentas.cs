using LibreriaApp2026.Entidades.Enums;
using LibreriaApp2026.Servicios.DTOs.Venta;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmVentas : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource = new BindingSource();

        //para paginar
        private EstadoNavegacion _estado = new(10);

        //para ordenar (por defecto, las más nuevas primero)
        private string campoOrdenar = "FechaVenta";
        private bool esAscendente = false;
        //para filtrar
        private EstadoVenta? filtroEstado = null;
        private string? textoBuscar = null;

        public frmVentas(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            Helpers.Tema.Aplicar(this);
            _serviceProvider = serviceProvider;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.DataSource = _bindingSource;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmVentaAe frm = scope.ServiceProvider.GetRequiredService<frmVentaAe>())
                {
                    frm.Text = "Nueva Venta";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        RecargarGrilla();
                    }
                }
            }
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            MostrarDetalle();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//doble clic en el encabezado
            MostrarDetalle();
        }

        private void MostrarDetalle()
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ventaListDto = (VentaListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var ventaServicio = scope.ServiceProvider.GetRequiredService<IVentaServicio>();
                    var resultadoConsulta = ventaServicio.ObtenerDetalle(ventaListDto.VentaId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    using (var frm = scope.ServiceProvider.GetRequiredService<frmDetalleVenta>())
                    {
                        frm.SetVenta(resultadoConsulta.Value!);
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbFacturar_Click(object sender, EventArgs e)
        {
            CambiarEstado(facturar: true);
        }

        private void tsbAnular_Click(object sender, EventArgs e)
        {
            CambiarEstado(facturar: false);
        }

        private void CambiarEstado(bool facturar)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ventaListDto = (VentaListDto)_bindingSource.Current;
            if (ventaListDto.Estado != nameof(EstadoVenta.Pendiente))
            {
                MessageBox.Show($"La venta N° {ventaListDto.VentaId} ya está {ventaListDto.Estado.ToLower()}.\nSolo se pueden facturar o anular ventas pendientes.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pregunta = facturar
                ? $"¿Desea facturar la venta N° {ventaListDto.VentaId} de {ventaListDto.Cliente} por {ventaListDto.ImporteTotal:C2}?"
                : $"¿Desea anular la venta N° {ventaListDto.VentaId}?\nSe devolverá el stock de los libros físicos.";
            var dr = MessageBox.Show(pregunta, facturar ? "Confirmar Facturación" : "Confirmar Anulación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;

            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var ventaServicio = scope.ServiceProvider.GetRequiredService<IVentaServicio>();
                    //el RowVersion de la grilla detecta si otro usuario cambió la venta mientras tanto
                    var dto = new VentaCambioEstadoDto
                    {
                        VentaId = ventaListDto.VentaId,
                        RowVersion = ventaListDto.RowVersion
                    };
                    var resultado = facturar ? ventaServicio.Facturar(dto) : ventaServicio.Anular(dto);
                    if (resultado.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultado.Errors);
                        if (resultado.IsConcurrencyConflict)
                        {
                            RecargarGrilla();
                        }
                        return;
                    }
                    MessageBox.Show(facturar ? "Venta facturada satisfactoriamente" : "Venta anulada satisfactoriamente",
                        "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var ventaServicio = scope.ServiceProvider
                    .GetRequiredService<IVentaServicio>();
                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = ventaServicio
                        .ObtenerPaginado(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroEstado,
                            textoBuscar);

                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;

                    _estado.Actualizar(resultado.CantidadRegistros);

                    //si la página pedida ya no existe se vuelve a consultar
                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = ventaServicio
                            .ObtenerPaginado(
                                _estado.PaginaActual,
                                _estado.RegistrosPorPagina,
                                campoOrdenar,
                                esAscendente,
                                filtroEstado,
                                textoBuscar);

                        if (resultadoConsulta.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                            return;
                        }

                        resultado = resultadoConsulta.Value!;

                        _estado.Actualizar(resultado.CantidadRegistros);
                    }

                    _bindingSource.DataSource = resultado.Items;

                    lblCantidad.Text = _estado.TextoRegistros();
                    lblPaginas.Text = _estado.TextoPaginas();

                    btnPrimero.Enabled = _estado.PuedeIrAnterior();
                    btnAnterior.Enabled = _estado.PuedeIrAnterior();
                    btnSiguiente.Enabled = _estado.PuedeIrSiguiente();
                    btnUltimo.Enabled = _estado.PuedeIrSiguiente();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void FiltrarPorEstado(EstadoVenta estado)
        {
            filtroEstado = estado;
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = Helpers.Tema.FiltroActivo;
            RecargarGrilla();
        }

        private void pendientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(EstadoVenta.Pendiente);
        }

        private void facturadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(EstadoVenta.Facturada);
        }

        private void anuladasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltrarPorEstado(EstadoVenta.Anulada);
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            textoBuscar = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroEstado = null;
            textoBuscar = null;
            txtBuscar.Clear();
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = Helpers.Tema.FiltroInactivo;
            RecargarGrilla();
        }

        private void dgvDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var campo = dgvDatos.Columns[e.ColumnIndex].DataPropertyName;
            esAscendente = campo == campoOrdenar ? !esAscendente : true;
            campoOrdenar = campo;
            RecargarGrilla();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            _estado.PrimeraPagina();
            RecargarGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _estado.PaginaAnterior();
            RecargarGrilla();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _estado.PaginaSiguiente();
            RecargarGrilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _estado.UltimaPagina();
            RecargarGrilla();
        }
    }
}
