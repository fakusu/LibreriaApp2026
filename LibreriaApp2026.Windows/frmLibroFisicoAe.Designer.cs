namespace LibreriaApp2026.Windows
{
    partial class frmLibroFisicoAe
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
            label1 = new Label();
            txtTitulo = new TextBox();
            label2 = new Label();
            txtDescripcion = new TextBox();
            label3 = new Label();
            txtISBN = new TextBox();
            label4 = new Label();
            cboEditorial = new ComboBox();
            label5 = new Label();
            nudAnio = new NumericUpDown();
            label6 = new Label();
            nudPrecio = new NumericUpDown();
            label7 = new Label();
            nudStock = new NumericUpDown();
            label8 = new Label();
            nudPaginas = new NumericUpDown();
            label9 = new Label();
            nudPeso = new NumericUpDown();
            chkActivo = new CheckBox();
            errorProvider1 = new ErrorProvider(components);
            btnOK = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPaginas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPeso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(45, 28);
            label1.Name = "label1";
            label1.TabIndex = 0;
            label1.Text = "Título:";
            //
            // txtTitulo
            //
            txtTitulo.Location = new Point(173, 25);
            txtTitulo.MaxLength = 150;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(400, 23);
            txtTitulo.TabIndex = 1;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(45, 63);
            label2.Name = "label2";
            label2.TabIndex = 2;
            label2.Text = "Descripción:";
            //
            // txtDescripcion
            //
            txtDescripcion.Location = new Point(173, 60);
            txtDescripcion.MaxLength = 500;
            txtDescripcion.Multiline = true;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(400, 63);
            txtDescripcion.TabIndex = 3;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(45, 138);
            label3.Name = "label3";
            label3.TabIndex = 4;
            label3.Text = "ISBN:";
            //
            // txtISBN
            //
            txtISBN.Location = new Point(173, 135);
            txtISBN.MaxLength = 13;
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(150, 23);
            txtISBN.TabIndex = 5;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(45, 173);
            label4.Name = "label4";
            label4.TabIndex = 6;
            label4.Text = "Editorial:";
            //
            // cboEditorial
            //
            cboEditorial.Location = new Point(173, 170);
            cboEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEditorial.FormattingEnabled = true;
            cboEditorial.Name = "cboEditorial";
            cboEditorial.Size = new Size(250, 23);
            cboEditorial.TabIndex = 7;
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(45, 208);
            label5.Name = "label5";
            label5.TabIndex = 8;
            label5.Text = "Año de publicación:";
            //
            // nudAnio
            //
            nudAnio.Location = new Point(173, 205);
            nudAnio.Minimum = new decimal(new int[] { 1450, 0, 0, 0 });
            nudAnio.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            nudAnio.Name = "nudAnio";
            nudAnio.Size = new Size(90, 23);
            nudAnio.TabIndex = 9;
            //
            // label6
            //
            label6.AutoSize = true;
            label6.Location = new Point(45, 243);
            label6.Name = "label6";
            label6.TabIndex = 10;
            label6.Text = "Precio:";
            //
            // nudPrecio
            //
            nudPrecio.Location = new Point(173, 240);
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPrecio.ThousandsSeparator = true;
            nudPrecio.TextAlign = HorizontalAlignment.Right;
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(120, 23);
            nudPrecio.TabIndex = 11;
            //
            // label7
            //
            label7.AutoSize = true;
            label7.Location = new Point(45, 278);
            label7.Name = "label7";
            label7.TabIndex = 12;
            label7.Text = "Stock:";
            //
            // nudStock
            //
            nudStock.Location = new Point(173, 275);
            nudStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudStock.TextAlign = HorizontalAlignment.Right;
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(90, 23);
            nudStock.TabIndex = 13;
            //
            // label8
            //
            label8.AutoSize = true;
            label8.Location = new Point(45, 313);
            label8.Name = "label8";
            label8.TabIndex = 14;
            label8.Text = "Cantidad de páginas:";
            //
            // nudPaginas
            //
            nudPaginas.Location = new Point(173, 310);
            nudPaginas.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudPaginas.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPaginas.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudPaginas.TextAlign = HorizontalAlignment.Right;
            nudPaginas.Name = "nudPaginas";
            nudPaginas.Size = new Size(90, 23);
            nudPaginas.TabIndex = 15;
            //
            // label9
            //
            label9.AutoSize = true;
            label9.Location = new Point(45, 348);
            label9.Name = "label9";
            label9.TabIndex = 16;
            label9.Text = "Peso (gramos):";
            //
            // nudPeso
            //
            nudPeso.Location = new Point(173, 345);
            nudPeso.Maximum = new decimal(new int[] { 20000, 0, 0, 0 });
            nudPeso.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPeso.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudPeso.TextAlign = HorizontalAlignment.Right;
            nudPeso.Name = "nudPeso";
            nudPeso.Size = new Size(90, 23);
            nudPeso.TabIndex = 17;
            //
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Location = new Point(45, 380);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(65, 19);
            chkActivo.TabIndex = 18;
            chkActivo.Text = "Activo?";
            chkActivo.UseVisualStyleBackColor = true;
            //
            // errorProvider1
            //
            errorProvider1.ContainerControl = this;
            //
            // btnOK
            //
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(49, 417);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 19;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            //
            // btnCancelar
            //
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(498, 417);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 20;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // frmLibroFisicoAe
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 502);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(chkActivo);
            Controls.Add(nudPeso);
            Controls.Add(label9);
            Controls.Add(nudPaginas);
            Controls.Add(label8);
            Controls.Add(nudStock);
            Controls.Add(label7);
            Controls.Add(nudPrecio);
            Controls.Add(label6);
            Controls.Add(nudAnio);
            Controls.Add(label5);
            Controls.Add(cboEditorial);
            Controls.Add(label4);
            Controls.Add(txtISBN);
            Controls.Add(label3);
            Controls.Add(txtDescripcion);
            Controls.Add(label2);
            Controls.Add(txtTitulo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLibroFisicoAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLibroFisicoAe";
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPaginas).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPeso).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTitulo;
        private Label label2;
        private TextBox txtDescripcion;
        private Label label3;
        private TextBox txtISBN;
        private Label label4;
        private ComboBox cboEditorial;
        private Label label5;
        private NumericUpDown nudAnio;
        private Label label6;
        private NumericUpDown nudPrecio;
        private Label label7;
        private NumericUpDown nudStock;
        private Label label8;
        private NumericUpDown nudPaginas;
        private Label label9;
        private NumericUpDown nudPeso;
        private CheckBox chkActivo;
        private ErrorProvider errorProvider1;
        private Button btnOK;
        private Button btnCancelar;
    }
}
