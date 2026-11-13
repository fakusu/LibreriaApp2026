namespace LibreriaApp2026.Windows
{
    partial class frmDetalleVenta
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            txtVentaId = new TextBox();
            label2 = new Label();
            txtFecha = new TextBox();
            label3 = new Label();
            txtEstado = new TextBox();
            label4 = new Label();
            txtCliente = new TextBox();
            label5 = new Label();
            txtDocumento = new TextBox();
            label6 = new Label();
            txtDomicilio = new TextBox();
            label7 = new Label();
            txtFormaDePago = new TextBox();
            dgvDetalle = new DataGridView();
            colProducto = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            label8 = new Label();
            txtTotal = new TextBox();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
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
            label1.Text = "Venta N°:";
            // 
            // txtVentaId
            // 
            txtVentaId.Location = new Point(140, 25);
            txtVentaId.Margin = new Padding(3, 4, 3, 4);
            txtVentaId.Name = "txtVentaId";
            txtVentaId.ReadOnly = true;
            txtVentaId.Size = new Size(120, 27);
            txtVentaId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(290, 29);
            label2.Name = "label2";
            label2.Text = "Fecha:";
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(350, 25);
            txtFecha.Margin = new Padding(3, 4, 3, 4);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(180, 27);
            txtFecha.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(555, 29);
            label3.Name = "label3";
            label3.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.Location = new Point(620, 25);
            txtEstado.Margin = new Padding(3, 4, 3, 4);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(150, 27);
            txtEstado.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 72);
            label4.Name = "label4";
            label4.Text = "Cliente:";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(140, 68);
            txtCliente.Margin = new Padding(3, 4, 3, 4);
            txtCliente.Name = "txtCliente";
            txtCliente.ReadOnly = true;
            txtCliente.Size = new Size(390, 27);
            txtCliente.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(555, 72);
            label5.Name = "label5";
            label5.Text = "Documento:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(650, 68);
            txtDocumento.Margin = new Padding(3, 4, 3, 4);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.ReadOnly = true;
            txtDocumento.Size = new Size(120, 27);
            txtDocumento.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 115);
            label6.Name = "label6";
            label6.Text = "Domicilio:";
            // 
            // txtDomicilio
            // 
            txtDomicilio.Location = new Point(140, 111);
            txtDomicilio.Margin = new Padding(3, 4, 3, 4);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.ReadOnly = true;
            txtDomicilio.Size = new Size(630, 27);
            txtDomicilio.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 158);
            label7.Name = "label7";
            label7.Text = "Forma de pago:";
            // 
            // txtFormaDePago
            // 
            txtFormaDePago.Location = new Point(140, 154);
            txtFormaDePago.Margin = new Padding(3, 4, 3, 4);
            txtFormaDePago.Name = "txtFormaDePago";
            txtFormaDePago.ReadOnly = true;
            txtFormaDePago.Size = new Size(250, 27);
            txtFormaDePago.TabIndex = 7;
            // 
            // dgvDetalle
            // 
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { colProducto, colTipo, colCantidad, colPrecio, colSubtotal });
            dgvDetalle.Location = new Point(25, 200);
            dgvDetalle.Margin = new Padding(3, 4, 3, 4);
            dgvDetalle.MultiSelect = false;
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.RowHeadersWidth = 51;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(745, 260);
            dgvDetalle.TabIndex = 8;
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
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label8.Location = new Point(540, 477);
            label8.Name = "label8";
            label8.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(610, 473);
            txtTotal.Margin = new Padding(3, 4, 3, 4);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(160, 27);
            txtTotal.TabIndex = 9;
            txtTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTotal.TextAlign = HorizontalAlignment.Right;
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.close_pane_48px;
            btnCerrar.Location = new Point(684, 520);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(86, 95);
            btnCerrar.TabIndex = 10;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 635);
            ControlBox = false;
            Margin = new Padding(3, 4, 3, 4);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de la venta";
            Controls.Add(btnCerrar);
            Controls.Add(txtTotal);
            Controls.Add(label8);
            Controls.Add(dgvDetalle);
            Controls.Add(txtFormaDePago);
            Controls.Add(label7);
            Controls.Add(txtDomicilio);
            Controls.Add(label6);
            Controls.Add(txtDocumento);
            Controls.Add(label5);
            Controls.Add(txtCliente);
            Controls.Add(label4);
            Controls.Add(txtEstado);
            Controls.Add(label3);
            Controls.Add(txtFecha);
            Controls.Add(label2);
            Controls.Add(txtVentaId);
            Controls.Add(label1);
            Name = "frmDetalleVenta";
            Load += frmDetalleVenta_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtVentaId;
        private Label label2;
        private TextBox txtFecha;
        private Label label3;
        private TextBox txtEstado;
        private Label label4;
        private TextBox txtCliente;
        private Label label5;
        private TextBox txtDocumento;
        private Label label6;
        private TextBox txtDomicilio;
        private Label label7;
        private TextBox txtFormaDePago;
        private DataGridView dgvDetalle;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colSubtotal;
        private Label label8;
        private TextBox txtTotal;
        private Button btnCerrar;
    }
}
