namespace LibreriaApp2026.Windows
{
    partial class frmAgregarProductoVenta
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvProductos = new DataGridView();
            colTitulo = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colEditorial = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            label2 = new Label();
            txtProducto = new TextBox();
            label3 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            nudCantidad = new NumericUpDown();
            label5 = new Label();
            txtSubtotal = new TextBox();
            lblStock = new Label();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 29);
            label1.Name = "label1";
            label1.Text = "Buscar (título o ISBN):";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(200, 25);
            txtBuscar.Margin = new Padding(3, 4, 3, 4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(380, 27);
            txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(595, 21);
            btnBuscar.Margin = new Padding(3, 4, 3, 4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 35);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colTitulo, colTipo, colEditorial, colPrecio, colStock });
            dgvProductos.Location = new Point(25, 70);
            dgvProductos.Margin = new Padding(3, 4, 3, 4);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(750, 300);
            dgvProductos.TabIndex = 3;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            dgvProductos.CellDoubleClick += dgvProductos_CellDoubleClick;
            // 
            // colTitulo
            // 
            colTitulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTitulo.DataPropertyName = "Titulo";
            colTitulo.HeaderText = "Título";
            colTitulo.MinimumWidth = 6;
            colTitulo.Name = "colTitulo";
            colTitulo.ReadOnly = true;
            // 
            // colTipo
            // 
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 6;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            colTipo.Width = 120;
            // 
            // colEditorial
            // 
            colEditorial.DataPropertyName = "Editorial";
            colEditorial.HeaderText = "Editorial";
            colEditorial.MinimumWidth = 6;
            colEditorial.Name = "colEditorial";
            colEditorial.ReadOnly = true;
            colEditorial.Width = 150;
            // 
            // colPrecio
            // 
            colPrecio.DataPropertyName = "Precio";
            colPrecio.DefaultCellStyle = dataGridViewCellStyle2;
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 6;
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Width = 110;
            // 
            // colStock
            // 
            colStock.DataPropertyName = "Stock";
            colStock.DefaultCellStyle = dataGridViewCellStyle3;
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 6;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            colStock.Width = 70;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 389);
            label2.Name = "label2";
            label2.Text = "Producto:";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(130, 385);
            txtProducto.Margin = new Padding(3, 4, 3, 4);
            txtProducto.Name = "txtProducto";
            txtProducto.ReadOnly = true;
            txtProducto.Size = new Size(450, 27);
            txtProducto.TabIndex = 4;
            txtProducto.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 432);
            label3.Name = "label3";
            label3.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(130, 428);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(150, 27);
            txtPrecio.TabIndex = 5;
            txtPrecio.TabStop = false;
            txtPrecio.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(300, 432);
            label4.Name = "label4";
            label4.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(380, 428);
            nudCantidad.Margin = new Padding(3, 4, 3, 4);
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(90, 27);
            nudCantidad.TabIndex = 6;
            nudCantidad.TextAlign = HorizontalAlignment.Right;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(490, 432);
            label5.Name = "label5";
            label5.Text = "Subtotal:";
            // 
            // txtSubtotal
            // 
            txtSubtotal.Location = new Point(565, 428);
            txtSubtotal.Margin = new Padding(3, 4, 3, 4);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(150, 27);
            txtSubtotal.TabIndex = 7;
            txtSubtotal.TabStop = false;
            txtSubtotal.TextAlign = HorizontalAlignment.Right;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(130, 465);
            lblStock.Name = "lblStock";
            lblStock.Text = "";
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(30, 500);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(86, 80);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(689, 500);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 80);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAgregarProductoVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            ControlBox = false;
            Margin = new Padding(3, 4, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agregar producto a la venta";
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(lblStock);
            Controls.Add(txtSubtotal);
            Controls.Add(label5);
            Controls.Add(nudCantidad);
            Controls.Add(label4);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(txtProducto);
            Controls.Add(label2);
            Controls.Add(dgvProductos);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            Name = "frmAgregarProductoVenta";
            Load += frmAgregarProductoVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colTitulo;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colEditorial;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colStock;
        private Label label2;
        private TextBox txtProducto;
        private Label label3;
        private TextBox txtPrecio;
        private Label label4;
        private NumericUpDown nudCantidad;
        private Label label5;
        private TextBox txtSubtotal;
        private Label lblStock;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
