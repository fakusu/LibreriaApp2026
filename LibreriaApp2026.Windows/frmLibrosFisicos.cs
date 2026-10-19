using LibreriaApp2026.Servicios.DTOs.LibroFisico;
using LibreriaApp2026.Servicios.Interfaces;
using LibreriaApp2026.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmLibrosFisicos : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource = new BindingSource();

        //para paginar
        private EstadoNavegacion _estado = new(10);

        //para ordenar
        private string campoOrdenar = "Titulo";
        private bool esAscendente = true;
        //para filtrar
        private bool? filtroActivo = null;
        private string? textoBuscar = null;

        public frmLibrosFisicos(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            dgvDatos.DataSource = _bindingSource;
        }

        private void frmLibrosFisicos_Load(object sender, EventArgs e)
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
                using (frmLibroFisicoAe frm = scope.ServiceProvider.GetRequiredService<frmLibroFisicoAe>())
                {
                    frm.Text = "Nuevo Libro Físico";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        RecargarGrilla();
                    }
                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var libroListDto = (LibroFisicoListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var libroServicio = scope.ServiceProvider
                        .GetRequiredService<ILibroFisicoServicio>();
                    var resultadoConsulta = libroServicio
                        .ObtenerParaEditar(libroListDto.ProductoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var libroEditDto = resultadoConsulta.Value;
                    using (frmLibroFisicoAe frm = scope.ServiceProvider
                        .GetRequiredService<frmLibroFisicoAe>())
                    {
                        frm.Text = "Editar Libro Físico";
                        frm.SetLibro(libroEditDto);
                        frm.ShowDialog();
                        if (frm.DataChanged)//si cambiaron los datos se recarga la grilla
                        {
                            RecargarGrilla();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var libroListDto = (LibroFisicoListDto)_bindingSource.Current;
            var dr = MessageBox.Show($"¿Desea borrar el libro {libroListDto.Titulo}?",
                "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                var libroServicio = scope.ServiceProvider
                        .GetRequiredService<ILibroFisicoServicio>();
                try
                {
                    var resultadoEliminacion = libroServicio
                        .Borrar(libroListDto.ProductoId);
                    if (resultadoEliminacion.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoEliminacion.Errors);
                        return;
                    }
                    MessageBox.Show("Registro eliminado satisfactoriamente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var libroServicio = scope.ServiceProvider
                    .GetRequiredService<ILibroFisicoServicio>();
                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = libroServicio
                        .ObtenerPaginado(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroActivo,
                            textoBuscar);

                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;

                    _estado.Actualizar(resultado.CantidadRegistros);

                    //si la página pedida ya no existe (ej: se borró el último registro) se vuelve a consultar
                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = libroServicio
                            .ObtenerPaginado(
                                _estado.PaginaActual,
                                _estado.RegistrosPorPagina,
                                campoOrdenar,
                                esAscendente,
                                filtroActivo,
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

        private void activosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = Color.Orange;
            RecargarGrilla();
        }

        private void noActivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = Color.Orange;
            RecargarGrilla();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            textoBuscar = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroActivo = null;
            textoBuscar = null;
            txtBuscar.Clear();
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = SystemColors.Control;
            RecargarGrilla();
        }

        private void dgvDatos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var campo = dgvDatos.Columns[e.ColumnIndex].DataPropertyName;
            if (campo == "Activo") return;
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
