namespace LibreriaApp2026.Windows
{
    partial class frmLibroDigitalAe
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
            lblAutores = new Label();
            txtBuscarAutores = new TextBox();
            clbAutores = new CheckedListBox();
            lblCantidadAutores = new Label();
            chkSoloAutores = new CheckBox();
            lblTemas = new Label();
            txtBuscarTemas = new TextBox();
            clbTemas = new CheckedListBox();
            lblCantidadTemas = new Label();
            chkSoloTemas = new CheckBox();
            label5 = new Label();
            nudAnio = new NumericUpDown();
            label6 = new Label();
            nudPrecio = new NumericUpDown();
            label8 = new Label();
            cboFormato = new ComboBox();
            label9 = new Label();
            nudTamanio = new NumericUpDown();
            label10 = new Label();
            txtUrlDescarga = new TextBox();
            chkActivo = new CheckBox();
            errorProvider1 = new ErrorProvider(components);
            btnOK = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTamanio).BeginInit();
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
            // label8
            //
            label8.AutoSize = true;
            label8.Location = new Point(45, 278);
            label8.Name = "label8";
            label8.TabIndex = 12;
            label8.Text = "Formato:";
            //
            // cboFormato
            //
            cboFormato.Location = new Point(173, 275);
            cboFormato.FormattingEnabled = true;
            cboFormato.MaxLength = 10;
            cboFormato.Items.AddRange(new object[] { "PDF", "EPUB", "MOBI", "AZW3" });
            cboFormato.Name = "cboFormato";
            cboFormato.Size = new Size(120, 23);
            cboFormato.TabIndex = 13;
            //
            // label9
            //
            label9.AutoSize = true;
            label9.Location = new Point(45, 313);
            label9.Name = "label9";
            label9.TabIndex = 14;
            label9.Text = "Tamaño (MB):";
            //
            // nudTamanio
            //
            nudTamanio.Location = new Point(173, 310);
            nudTamanio.DecimalPlaces = 2;
            nudTamanio.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudTamanio.TextAlign = HorizontalAlignment.Right;
            nudTamanio.Name = "nudTamanio";
            nudTamanio.Size = new Size(90, 23);
            nudTamanio.TabIndex = 15;
            //
            // label10
            //
            label10.AutoSize = true;
            label10.Location = new Point(45, 348);
            label10.Name = "label10";
            label10.TabIndex = 16;
            label10.Text = "URL de descarga:";
            //
            // txtUrlDescarga
            //
            txtUrlDescarga.Location = new Point(173, 345);
            txtUrlDescarga.MaxLength = 300;
            txtUrlDescarga.Name = "txtUrlDescarga";
            txtUrlDescarga.Size = new Size(400, 23);
            txtUrlDescarga.TabIndex = 17;
            //
            // lblAutores
            //
            lblAutores.AutoSize = true;
            lblAutores.Location = new Point(610, 28);
            lblAutores.Name = "lblAutores";
            lblAutores.TabIndex = 18;
            lblAutores.Text = "Autores:";
            //
            // txtBuscarAutores
            //
            txtBuscarAutores.Location = new Point(610, 48);
            txtBuscarAutores.Name = "txtBuscarAutores";
            txtBuscarAutores.PlaceholderText = "Buscar autor…";
            txtBuscarAutores.Size = new Size(280, 23);
            txtBuscarAutores.TabIndex = 19;
            //
            // clbAutores
            //
            clbAutores.CheckOnClick = true;
            clbAutores.FormattingEnabled = true;
            clbAutores.Location = new Point(610, 75);
            clbAutores.Name = "clbAutores";
            clbAutores.Size = new Size(280, 112);
            clbAutores.TabIndex = 20;
            //
            // lblCantidadAutores
            //
            lblCantidadAutores.AutoSize = true;
            lblCantidadAutores.Location = new Point(610, 190);
            lblCantidadAutores.Name = "lblCantidadAutores";
            lblCantidadAutores.TabIndex = 21;
            lblCantidadAutores.Text = "0 seleccionados";
            //
            // chkSoloAutores
            //
            chkSoloAutores.AutoSize = true;
            chkSoloAutores.Location = new Point(740, 189);
            chkSoloAutores.Name = "chkSoloAutores";
            chkSoloAutores.TabIndex = 22;
            chkSoloAutores.Text = "Ver solo seleccionados";
            chkSoloAutores.UseVisualStyleBackColor = true;
            //
            // lblTemas
            //
            lblTemas.AutoSize = true;
            lblTemas.Location = new Point(610, 220);
            lblTemas.Name = "lblTemas";
            lblTemas.TabIndex = 23;
            lblTemas.Text = "Temas:";
            //
            // txtBuscarTemas
            //
            txtBuscarTemas.Location = new Point(610, 240);
            txtBuscarTemas.Name = "txtBuscarTemas";
            txtBuscarTemas.PlaceholderText = "Buscar tema…";
            txtBuscarTemas.Size = new Size(280, 23);
            txtBuscarTemas.TabIndex = 24;
            //
            // clbTemas
            //
            clbTemas.CheckOnClick = true;
            clbTemas.FormattingEnabled = true;
            clbTemas.Location = new Point(610, 267);
            clbTemas.Name = "clbTemas";
            clbTemas.Size = new Size(280, 112);
            clbTemas.TabIndex = 25;
            //
            // lblCantidadTemas
            //
            lblCantidadTemas.AutoSize = true;
            lblCantidadTemas.Location = new Point(610, 382);
            lblCantidadTemas.Name = "lblCantidadTemas";
            lblCantidadTemas.TabIndex = 26;
            lblCantidadTemas.Text = "0 seleccionados";
            //
            // chkSoloTemas
            //
            chkSoloTemas.AutoSize = true;
            chkSoloTemas.Location = new Point(740, 381);
            chkSoloTemas.Name = "chkSoloTemas";
            chkSoloTemas.TabIndex = 27;
            chkSoloTemas.Text = "Ver solo seleccionados";
            chkSoloTemas.UseVisualStyleBackColor = true;
            //
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Location = new Point(45, 380);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(65, 19);
            chkActivo.TabIndex = 28;
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
            btnOK.TabIndex = 29;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            //
            // btnCancelar
            //
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(815, 417);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 30;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // frmLibroDigitalAe
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 502);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(chkActivo);
            Controls.Add(txtUrlDescarga);
            Controls.Add(label10);
            Controls.Add(nudTamanio);
            Controls.Add(label9);
            Controls.Add(cboFormato);
            Controls.Add(label8);
            Controls.Add(nudPrecio);
            Controls.Add(label6);
            Controls.Add(nudAnio);
            Controls.Add(label5);
            Controls.Add(chkSoloTemas);
            Controls.Add(lblCantidadTemas);
            Controls.Add(clbTemas);
            Controls.Add(txtBuscarTemas);
            Controls.Add(lblTemas);
            Controls.Add(chkSoloAutores);
            Controls.Add(lblCantidadAutores);
            Controls.Add(clbAutores);
            Controls.Add(txtBuscarAutores);
            Controls.Add(lblAutores);
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
            Name = "frmLibroDigitalAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmLibroDigitalAe";
            ((System.ComponentModel.ISupportInitialize)nudAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTamanio).EndInit();
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
        private Label lblAutores;
        private TextBox txtBuscarAutores;
        private CheckedListBox clbAutores;
        private Label lblCantidadAutores;
        private CheckBox chkSoloAutores;
        private Label lblTemas;
        private TextBox txtBuscarTemas;
        private CheckedListBox clbTemas;
        private Label lblCantidadTemas;
        private CheckBox chkSoloTemas;
        private Label label5;
        private NumericUpDown nudAnio;
        private Label label6;
        private NumericUpDown nudPrecio;
        private Label label8;
        private ComboBox cboFormato;
        private Label label9;
        private NumericUpDown nudTamanio;
        private Label label10;
        private TextBox txtUrlDescarga;
        private CheckBox chkActivo;
        private ErrorProvider errorProvider1;
        private Button btnOK;
        private Button btnCancelar;
    }
}
