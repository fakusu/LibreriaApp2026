namespace LibreriaApp2026.Windows
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            toolStrip1 = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbDetalles = new ToolStripButton();
            tsbFacturar = new ToolStripButton();
            tsbAnular = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripDropDownButton();
            pendientesToolStripMenuItem = new ToolStripMenuItem();
            facturadasToolStripMenuItem = new ToolStripMenuItem();
            anuladasToolStripMenuItem = new ToolStripMenuItem();
            toolStripLabel1 = new ToolStripLabel();
            txtBuscar = new ToolStripTextBox();
            tsbBuscar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsbCerrar = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatos = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colFormaDePago = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            btnUltimo = new Button();
            btnSiguiente = new Button();
            btnAnterior = new Button();
            btnPrimero = new Button();
            lblPaginas = new Label();
            lblCantidad = new Label();
            label2 = new Label();
            label1 = new Label();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbDetalles, tsbFacturar, tsbAnular, toolStripSeparator1, tsbFiltrar, toolStripLabel1, txtBuscar, tsbBuscar, tsbActualizar, toolStripSeparator2, tsbCerrar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(914, 75);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = Properties.Resources.new_file_48px;
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(56, 72);
            tsbNuevo.Text = "&Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbDetalles
            // 
            tsbDetalles.Image = Properties.Resources.details_48px;
            tsbDetalles.ImageScaling = ToolStripItemImageScaling.None;
            tsbDetalles.ImageTransparentColor = Color.Magenta;
            tsbDetalles.Name = "tsbDetalles";
            tsbDetalles.Size = new Size(66, 72);
            tsbDetalles.Text = "&Detalles";
            tsbDetalles.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDetalles.Click += tsbDetalles_Click;
            // 
            // tsbFacturar
            // 
            tsbFacturar.Image = Properties.Resources.edit_file_48px;
            tsbFacturar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFacturar.ImageTransparentColor = Color.Magenta;
            tsbFacturar.Name = "tsbFacturar";
            tsbFacturar.Size = new Size(69, 72);
            tsbFacturar.Text = "&Facturar";
            tsbFacturar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbFacturar.Click += tsbFacturar_Click;
            // 
            // tsbAnular
            // 
            tsbAnular.Image = Properties.Resources.delete_file_48px;
            tsbAnular.ImageScaling = ToolStripItemImageScaling.None;
            tsbAnular.ImageTransparentColor = Color.Magenta;
            tsbAnular.Name = "tsbAnular";
            tsbAnular.Size = new Size(58, 72);
            tsbAnular.Text = "A&nular";
            tsbAnular.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbAnular.Click += tsbAnular_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 75);
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.DropDownItems.AddRange(new ToolStripItem[] { pendientesToolStripMenuItem, facturadasToolStripMenuItem, anuladasToolStripMenuItem });
            tsbFiltrar.Image = Properties.Resources.filled_filter_48px;
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(62, 72);
            tsbFiltrar.Text = "&Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // pendientesToolStripMenuItem
            // 
            pendientesToolStripMenuItem.Name = "pendientesToolStripMenuItem";
            pendientesToolStripMenuItem.Size = new Size(164, 26);
            pendientesToolStripMenuItem.Text = "Pendientes";
            pendientesToolStripMenuItem.Click += pendientesToolStripMenuItem_Click;
            // 
            // facturadasToolStripMenuItem
            // 
            facturadasToolStripMenuItem.Name = "facturadasToolStripMenuItem";
            facturadasToolStripMenuItem.Size = new Size(164, 26);
            facturadasToolStripMenuItem.Text = "Facturadas";
            facturadasToolStripMenuItem.Click += facturadasToolStripMenuItem_Click;
            // 
            // anuladasToolStripMenuItem
            // 
            anuladasToolStripMenuItem.Name = "anuladasToolStripMenuItem";
            anuladasToolStripMenuItem.Size = new Size(164, 26);
            anuladasToolStripMenuItem.Text = "Anuladas";
            anuladasToolStripMenuItem.Click += anuladasToolStripMenuItem_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(55, 72);
            toolStripLabel1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(171, 75);
            // 
            // tsbBuscar
            // 
            tsbBuscar.Image = Properties.Resources.search_property_48px;
            tsbBuscar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBuscar.ImageTransparentColor = Color.Magenta;
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new Size(56, 72);
            tsbBuscar.Text = "B&uscar";
            tsbBuscar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBuscar.Click += tsbBuscar_Click;
            // 
            // tsbActualizar
            // 
            tsbActualizar.Image = Properties.Resources.restart_48px;
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(79, 72);
            tsbActualizar.Text = "&Actualizar";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbActualizar.Click += tsbActualizar_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 75);
            // 
            // tsbCerrar
            // 
            tsbCerrar.Image = Properties.Resources.close_pane_48px;
            tsbCerrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbCerrar.ImageTransparentColor = Color.Magenta;
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(53, 72);
            tsbCerrar.Text = "&Cerrar";
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 75);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnUltimo);
            splitContainer1.Panel2.Controls.Add(btnSiguiente);
            splitContainer1.Panel2.Controls.Add(btnAnterior);
            splitContainer1.Panel2.Controls.Add(btnPrimero);
            splitContainer1.Panel2.Controls.Add(lblPaginas);
            splitContainer1.Panel2.Controls.Add(lblCantidad);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(914, 415);
            splitContainer1.SplitterDistance = 333;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // dgvDatos
            // 
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeColumns = false;
            dgvDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvDatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colId, colFecha, colCliente, colFormaDePago, colTotal, colEstado });
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.Margin = new Padding(3, 4, 3, 4);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.RowHeadersWidth = 51;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(914, 333);
            dgvDatos.TabIndex = 0;
            dgvDatos.CellDoubleClick += dgvDatos_CellDoubleClick;
            dgvDatos.ColumnHeaderMouseClick += dgvDatos_ColumnHeaderMouseClick;
            dataGridViewCellStyle2.Format = "g";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            // 
            // colId
            // 
            colId.DataPropertyName = "VentaId";
            colId.HeaderText = "N°";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Width = 70;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "FechaVenta";
            colFecha.DefaultCellStyle = dataGridViewCellStyle2;
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 6;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 150;
            // 
            // colCliente
            // 
            colCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCliente.DataPropertyName = "Cliente";
            colCliente.HeaderText = "Cliente";
            colCliente.MinimumWidth = 6;
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colFormaDePago
            // 
            colFormaDePago.DataPropertyName = "FormaDePago";
            colFormaDePago.HeaderText = "Forma de Pago";
            colFormaDePago.MinimumWidth = 6;
            colFormaDePago.Name = "colFormaDePago";
            colFormaDePago.ReadOnly = true;
            colFormaDePago.Width = 140;
            // 
            // colTotal
            // 
            colTotal.DataPropertyName = "ImporteTotal";
            colTotal.DefaultCellStyle = dataGridViewCellStyle3;
            colTotal.HeaderText = "Total";
            colTotal.MinimumWidth = 6;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 130;
            // 
            // colEstado
            // 
            colEstado.DataPropertyName = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 6;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.Width = 100;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.last_24px;
            btnUltimo.Location = new Point(792, 11);
            btnUltimo.Margin = new Padding(3, 4, 3, 4);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(47, 51);
            btnUltimo.TabIndex = 7;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.next_24px;
            btnSiguiente.Location = new Point(738, 11);
            btnSiguiente.Margin = new Padding(3, 4, 3, 4);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(47, 51);
            btnSiguiente.TabIndex = 8;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(685, 11);
            btnAnterior.Margin = new Padding(3, 4, 3, 4);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(47, 51);
            btnAnterior.TabIndex = 9;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(631, 11);
            btnPrimero.Margin = new Padding(3, 4, 3, 4);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(47, 51);
            btnPrimero.TabIndex = 10;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPaginas.Location = new Point(225, 39);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(18, 20);
            lblPaginas.TabIndex = 5;
            lblPaginas.Text = "0";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidad.Location = new Point(225, 11);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(18, 20);
            lblCantidad.TabIndex = 6;
            lblCantidad.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 39);
            label2.Name = "label2";
            label2.Size = new Size(147, 20);
            label2.TabIndex = 3;
            label2.Text = "Cantidad de Páginas:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 11);
            label1.Name = "label1";
            label1.Size = new Size(158, 20);
            label1.TabIndex = 4;
            label1.Text = "Cantidad de Registros:";
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 490);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVentas";
            Load += frmVentas_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbDetalles;
        private ToolStripButton tsbFacturar;
        private ToolStripButton tsbAnular;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton tsbFiltrar;
        private ToolStripMenuItem pendientesToolStripMenuItem;
        private ToolStripMenuItem facturadasToolStripMenuItem;
        private ToolStripMenuItem anuladasToolStripMenuItem;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox txtBuscar;
        private ToolStripButton tsbBuscar;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsbCerrar;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colFormaDePago;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colEstado;
        private Button btnUltimo;
        private Button btnSiguiente;
        private Button btnAnterior;
        private Button btnPrimero;
        private Label lblPaginas;
        private Label lblCantidad;
        private Label label2;
        private Label label1;
    }
}
