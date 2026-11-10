namespace LibreriaApp2026.Windows
{
    partial class frmDetalleLibroDigital
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
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            lblAnio = new Label();
            txtAnio = new TextBox();
            lblEditorial = new Label();
            txtEditorial = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblFormato = new Label();
            txtFormato = new TextBox();
            lblTamanio = new Label();
            txtTamanio = new TextBox();
            lblUrl = new Label();
            txtUrl = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblAutores = new Label();
            lstAutores = new ListBox();
            lblTemas = new Label();
            lstTemas = new ListBox();
            chkActivo = new CheckBox();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(17, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(50, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(126, 20);
            txtTitulo.Margin = new Padding(3, 4, 3, 4);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.ReadOnly = true;
            txtTitulo.Size = new Size(537, 27);
            txtTitulo.TabIndex = 1;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Location = new Point(17, 67);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(44, 20);
            lblIsbn.TabIndex = 2;
            lblIsbn.Text = "ISBN:";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(126, 63);
            txtIsbn.Margin = new Padding(3, 4, 3, 4);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.ReadOnly = true;
            txtIsbn.Size = new Size(194, 27);
            txtIsbn.TabIndex = 3;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(366, 67);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(39, 20);
            lblAnio.TabIndex = 4;
            lblAnio.Text = "Año:";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(469, 63);
            txtAnio.Margin = new Padding(3, 4, 3, 4);
            txtAnio.Name = "txtAnio";
            txtAnio.ReadOnly = true;
            txtAnio.Size = new Size(194, 27);
            txtAnio.TabIndex = 5;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(17, 109);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(68, 20);
            lblEditorial.TabIndex = 6;
            lblEditorial.Text = "Editorial:";
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(126, 105);
            txtEditorial.Margin = new Padding(3, 4, 3, 4);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.ReadOnly = true;
            txtEditorial.Size = new Size(537, 27);
            txtEditorial.TabIndex = 7;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(17, 152);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 8;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(126, 148);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(194, 27);
            txtPrecio.TabIndex = 9;
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.Location = new Point(366, 152);
            lblFormato.Name = "lblFormato";
            lblFormato.Size = new Size(68, 20);
            lblFormato.TabIndex = 10;
            lblFormato.Text = "Formato:";
            // 
            // txtFormato
            // 
            txtFormato.Location = new Point(469, 148);
            txtFormato.Margin = new Padding(3, 4, 3, 4);
            txtFormato.Name = "txtFormato";
            txtFormato.ReadOnly = true;
            txtFormato.Size = new Size(194, 27);
            txtFormato.TabIndex = 11;
            // 
            // lblTamanio
            // 
            lblTamanio.AutoSize = true;
            lblTamanio.Location = new Point(17, 195);
            lblTamanio.Name = "lblTamanio";
            lblTamanio.Size = new Size(100, 20);
            lblTamanio.TabIndex = 12;
            lblTamanio.Text = "Tamaño (MB):";
            // 
            // txtTamanio
            // 
            txtTamanio.Location = new Point(126, 191);
            txtTamanio.Margin = new Padding(3, 4, 3, 4);
            txtTamanio.Name = "txtTamanio";
            txtTamanio.ReadOnly = true;
            txtTamanio.Size = new Size(194, 27);
            txtTamanio.TabIndex = 13;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(17, 237);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(102, 20);
            lblUrl.TabIndex = 14;
            lblUrl.Text = "URL descarga:";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(126, 233);
            txtUrl.Margin = new Padding(3, 4, 3, 4);
            txtUrl.Name = "txtUrl";
            txtUrl.ReadOnly = true;
            txtUrl.Size = new Size(537, 27);
            txtUrl.TabIndex = 15;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(17, 280);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(90, 20);
            lblDescripcion.TabIndex = 16;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(126, 276);
            txtDescripcion.Margin = new Padding(3, 4, 3, 4);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(537, 79);
            txtDescripcion.TabIndex = 17;
            // 
            // lblAutores
            // 
            lblAutores.AutoSize = true;
            lblAutores.Location = new Point(17, 373);
            lblAutores.Name = "lblAutores";
            lblAutores.Size = new Size(63, 20);
            lblAutores.TabIndex = 18;
            lblAutores.Text = "Autores:";
            // 
            // lstAutores
            // 
            lstAutores.FormattingEnabled = true;
            lstAutores.Location = new Point(17, 400);
            lstAutores.Margin = new Padding(3, 4, 3, 4);
            lstAutores.Name = "lstAutores";
            lstAutores.SelectionMode = SelectionMode.None;
            lstAutores.Size = new Size(297, 164);
            lstAutores.TabIndex = 19;
            // 
            // lblTemas
            // 
            lblTemas.AutoSize = true;
            lblTemas.Location = new Point(366, 373);
            lblTemas.Name = "lblTemas";
            lblTemas.Size = new Size(54, 20);
            lblTemas.TabIndex = 20;
            lblTemas.Text = "Temas:";
            // 
            // lstTemas
            // 
            lstTemas.FormattingEnabled = true;
            lstTemas.Location = new Point(366, 400);
            lstTemas.Margin = new Padding(3, 4, 3, 4);
            lstTemas.Name = "lstTemas";
            lstTemas.SelectionMode = SelectionMode.None;
            lstTemas.Size = new Size(297, 164);
            lstTemas.TabIndex = 21;
            // 
            // chkActivo
            // 
            chkActivo.AutoCheck = false;
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(17, 593);
            chkActivo.Margin = new Padding(3, 4, 3, 4);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(73, 24);
            chkActivo.TabIndex = 22;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Image = Properties.Resources.cancel_24px;
            btnCerrar.Location = new Point(577, 580);
            btnCerrar.Margin = new Padding(3, 4, 3, 4);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(86, 80);
            btnCerrar.TabIndex = 23;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmDetalleLibroDigital
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCerrar;
            ClientSize = new Size(686, 680);
            ControlBox = false;
            Controls.Add(btnCerrar);
            Controls.Add(chkActivo);
            Controls.Add(lstTemas);
            Controls.Add(lblTemas);
            Controls.Add(lstAutores);
            Controls.Add(lblAutores);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcion);
            Controls.Add(txtUrl);
            Controls.Add(lblUrl);
            Controls.Add(txtTamanio);
            Controls.Add(lblTamanio);
            Controls.Add(txtFormato);
            Controls.Add(lblFormato);
            Controls.Add(txtPrecio);
            Controls.Add(lblPrecio);
            Controls.Add(txtEditorial);
            Controls.Add(lblEditorial);
            Controls.Add(txtAnio);
            Controls.Add(lblAnio);
            Controls.Add(txtIsbn);
            Controls.Add(lblIsbn);
            Controls.Add(txtTitulo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDetalleLibroDigital";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Libro Digital";
            Load += frmDetalleLibroDigital_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblIsbn;
        private TextBox txtIsbn;
        private Label lblAnio;
        private TextBox txtAnio;
        private Label lblEditorial;
        private TextBox txtEditorial;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblFormato;
        private TextBox txtFormato;
        private Label lblTamanio;
        private TextBox txtTamanio;
        private Label lblUrl;
        private TextBox txtUrl;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblAutores;
        private ListBox lstAutores;
        private Label lblTemas;
        private ListBox lstTemas;
        private CheckBox chkActivo;
        private Button btnCerrar;
    }
}
