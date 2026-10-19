using Microsoft.Extensions.DependencyInjection;

namespace LibreriaApp2026.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmEditoriales>())
            {
                frm.Text = "Lista de Editoriales";
                frm.ShowDialog();
            }
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmAutores>())
            {
                frm.Text = "Lista de Autores";
                frm.ShowDialog();
            }
        }

        private void btnTemas_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmTemas>())
            {
                frm.Text = "Lista de Temas";
                frm.ShowDialog();
            }
        }

        private void btnLibrosFisicos_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmLibrosFisicos>())
            {
                frm.Text = "Lista de Libros Físicos";
                frm.ShowDialog();
            }
        }

        private void btnLibrosDigitales_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmLibrosDigitales>())
            {
                frm.Text = "Lista de Libros Digitales";
                frm.ShowDialog();
            }
        }
    }
}
