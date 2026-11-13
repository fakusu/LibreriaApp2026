namespace LibreriaApp2026.Windows
{
    partial class frmVentaAe
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            cboClientes = new ComboBox();
            label2 = new Label();
            cboFormasDePago = new ComboBox();
            label3 = new Label();
            txtFecha = new TextBox();
            label4 = new Label();
            txtEstado = new TextBox();
            grpDomicilio = new GroupBox();
            label5 = new Label();
            txtDireccion = new TextBox();
            label6 = new Label();
            txtLocalidad = new TextBox();
            label7 = new Label();
            txtProvincia = new TextBox();
            label8 = new Label();
            txtCodigoPostal = new TextBox();
            dgvDetalle = new DataGridView();
            colProducto = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            btnAgregarProducto = new Button();
            btnEditarCantidad = new Button();
            btnQuitarProducto = new Button();
            label9 = new Label();
            txtTotal = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            grpDomicilio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 29);
            label1.Name = "label1";
            label1.Text = "Cliente:";
            // 
            // cboClientes
            // 
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.FormattingEnabled = true;
            cboClientes.Location = new Point(145, 25);
            cboClientes.Margin = new Padding(3, 4, 3, 4);
            cboClientes.Name = "cboClientes";
            cboClientes.Size = new Size(360, 28);
            cboClientes.TabIndex = 1;
            cboClientes.SelectedIndexChanged += cboClientes_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 72);
            label2.Name = "label2";
            label2.Text = "Forma de pago:";
            // 
            // cboFormasDePago
            // 
            cboFormasDePago.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormasDePago.FormattingEnabled = true;
            cboFormasDePago.Location = new Point(145, 68);
            cboFormasDePago.Margin = new Padding(3, 4, 3, 4);
            cboFormasDePago.Name = "cboFormasDePago";
            cboFormasDePago.Size = new Size(220, 28);
            cboFormasDePago.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(540, 29);
            label3.Name = "label3";
            label3.Text = "Fecha:";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(610, 25);
            txtFecha.Margin = new Padding(3, 4, 3, 4);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(160, 27);
            txtFecha.TabIndex = 3;
            txtFecha.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(540, 72);
            label4.Name = "label4";
            label4.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(610, 68);
            txtEstado.Margin = new Padding(3, 4, 3, 4);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(160, 27);
            txtEstado.TabIndex = 4;
            txtEstado.TabStop = false;
            // 
            // grpDomicilio
            // 
            grpDomicilio.Controls.Add(label5);
            grpDomicilio.Controls.Add(txtDireccion);
            grpDomicilio.Controls.Add(label6);
            grpDomicilio.Controls.Add(txtLocalidad);
            grpDomicilio.Controls.Add(label7);
            grpDomicilio.Controls.Add(txtProvincia);
            grpDomicilio.Controls.Add(label8);
            grpDomicilio.Controls.Add(txtCodigoPostal);
            grpDomicilio.Location = new Point(25, 110);
            grpDomicilio.Margin = new Padding(3, 4, 3, 4);
            grpDomicilio.Name = "grpDomicilio";
            grpDomicilio.Padding = new Padding(3, 4, 3, 4);
            grpDomicilio.Size = new Size(745, 110);
            grpDomicilio.TabIndex = 5;
            grpDomicilio.TabStop = false;
            grpDomicilio.Text = "Domicilio de entrega";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 34);
            label5.Name = "label5";
            label5.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(100, 30);
            txtDireccion.Margin = new Padding(3, 4, 3, 4);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.ReadOnly = true;
            txtDireccion.Size = new Size(300, 27);
            txtDireccion.TabIndex = 0;
            txtDireccion.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(420, 34);
            label6.Name = "label6";
            label6.Text = "Localidad:";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(500, 30);
            txtLocalidad.Margin = new Padding(3, 4, 3, 4);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.ReadOnly = true;
            txtLocalidad.Size = new Size(225, 27);
            txtLocalidad.TabIndex = 1;
            txtLocalidad.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 72);
            label7.Name = "label7";
            label7.Text = "Provincia:";
            // 
            // txtProvincia
            // 
            txtProvincia.Location = new Point(100, 68);
            txtProvincia.Margin = new Padding(3, 4, 3, 4);
            txtProvincia.Name = "txtProvincia";
            txtProvincia.ReadOnly = true;
            txtProvincia.Size = new Size(300, 27);
            txtProvincia.TabIndex = 2;
            txtProvincia.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(410, 72);
            label8.Name = "label8";
            label8.Text = "Cód. Postal:";
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(500, 68);
            txtCodigoPostal.Margin = new Padding(3, 4, 3, 4);
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.ReadOnly = true;
            txtCodigoPostal.Size = new Size(225, 27);
            txtCodigoPostal.TabIndex = 3;
            txtCodigoPostal.TabStop = false;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { colProducto, colTipo, colCantidad, colPrecio, colSubtotal });
            dgvDetalle.Location = new Point(25, 235);
            dgvDetalle.Margin = new Padding(3, 4, 3, 4);
            dgvDetalle.MultiSelect = false;
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(600, 260);
            dgvDetalle.TabIndex = 6;
            // 
            // colProducto
            // 
            colProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProducto.DataPropertyName = "Producto";
            colProducto.HeaderText = "Producto";
            colProducto.MinimumWidth = 6;
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
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
            // colCantidad
            // 
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.DefaultCellStyle = dataGridViewCellStyle2;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 6;
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 85;
            // 
            // colPrecio
            // 
            colPrecio.DataPropertyName = "PrecioUnitario";
            colPrecio.DefaultCellStyle = dataGridViewCellStyle3;
            colPrecio.HeaderText = "Precio Unit.";
            colPrecio.MinimumWidth = 6;
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Width = 110;
            // 
            // colSubtotal
            // 
            colSubtotal.DataPropertyName = "Subtotal";
            colSubtotal.DefaultCellStyle = dataGridViewCellStyle4;
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.MinimumWidth = 6;
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            colSubtotal.Width = 110;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(640, 235);
            btnAgregarProducto.Margin = new Padding(3, 4, 3, 4);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(130, 50);
            btnAgregarProducto.TabIndex = 7;
            btnAgregarProducto.Text = "Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnEditarCantidad
            // 
            btnEditarCantidad.Location = new Point(640, 293);
            btnEditarCantidad.Margin = new Padding(3, 4, 3, 4);
            btnEditarCantidad.Name = "btnEditarCantidad";
            btnEditarCantidad.Size = new Size(130, 50);
            btnEditarCantidad.TabIndex = 8;
            btnEditarCantidad.Text = "Editar cantidad";
            btnEditarCantidad.UseVisualStyleBackColor = true;
            btnEditarCantidad.Click += btnEditarCantidad_Click;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.Location = new Point(640, 351);
            btnQuitarProducto.Margin = new Padding(3, 4, 3, 4);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(130, 50);
            btnQuitarProducto.TabIndex = 9;
            btnQuitarProducto.Text = "Quitar producto";
            btnQuitarProducto.UseVisualStyleBackColor = true;
            btnQuitarProducto.Click += btnQuitarProducto_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label9.Location = new Point(395, 512);
            label9.Name = "label9";
            label9.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(465, 508);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(160, 27);
            txtTotal.TabIndex = 10;
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.TabStop = false;
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(30, 555);
            btnOK.Margin = new Padding(3, 4, 3, 4);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(86, 80);
            btnOK.TabIndex = 11;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(684, 555);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 80);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmVentaAe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 655);
            ControlBox = false;
            Margin = new Padding(3, 4, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmVentaAe";
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtTotal);
            Controls.Add(label9);
            Controls.Add(btnQuitarProducto);
            Controls.Add(btnEditarCantidad);
            Controls.Add(btnAgregarProducto);
            Controls.Add(dgvDetalle);
            Controls.Add(grpDomicilio);
            Controls.Add(txtEstado);
            Controls.Add(label4);
            Controls.Add(txtFecha);
            Controls.Add(label3);
            Controls.Add(cboFormasDePago);
            Controls.Add(label2);
            Controls.Add(cboClientes);
            Controls.Add(label1);
            Name = "frmVentaAe";
            Load += frmVentaAe_Load;
            grpDomicilio.ResumeLayout(false);
            grpDomicilio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboClientes;
        private Label label2;
        private ComboBox cboFormasDePago;
        private Label label3;
        private TextBox txtFecha;
        private Label label4;
        private TextBox txtEstado;
        private GroupBox grpDomicilio;
        private Label label5;
        private TextBox txtDireccion;
        private Label label6;
        private TextBox txtLocalidad;
        private Label label7;
        private TextBox txtProvincia;
        private Label label8;
        private TextBox txtCodigoPostal;
        private DataGridView dgvDetalle;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colSubtotal;
        private Button btnAgregarProducto;
        private Button btnEditarCantidad;
        private Button btnQuitarProducto;
        private Label label9;
        private TextBox txtTotal;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
