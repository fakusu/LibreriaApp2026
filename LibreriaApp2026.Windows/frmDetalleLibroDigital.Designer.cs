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
            lblTitulo.Location = new Point(15, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(110, 15);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.ReadOnly = true;
            txtTitulo.Size = new Size(470, 23);
            txtTitulo.TabIndex = 1;
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Location = new Point(15, 50);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.TabIndex = 2;
            lblIsbn.Text = "ISBN:";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(110, 47);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.ReadOnly = true;
            txtIsbn.Size = new Size(170, 23);
            txtIsbn.TabIndex = 3;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Location = new Point(320, 50);
            lblAnio.Name = "lblAnio";
            lblAnio.TabIndex = 4;
            lblAnio.Text = "Año:";
            // 
            // txtAnio
            // 
            txtAnio.Location = new Point(410, 47);
            txtAnio.Name = "txtAnio";
            txtAnio.ReadOnly = true;
            txtAnio.Size = new Size(170, 23);
            txtAnio.TabIndex = 5;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(15, 82);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.TabIndex = 6;
            lblEditorial.Text = "Editorial:";
            // 
            // txtEditorial
            // 
            txtEditorial.Location = new Point(110, 79);
            txtEditorial.Name = "txtEditorial";
            txtEditorial.ReadOnly = true;
            txtEditorial.Size = new Size(470, 23);
            txtEditorial.TabIndex = 7;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(15, 114);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.TabIndex = 8;
            lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(110, 111);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.ReadOnly = true;
            txtPrecio.Size = new Size(170, 23);
            txtPrecio.TabIndex = 9;
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.Location = new Point(320, 114);
            lblFormato.Name = "lblFormato";
            lblFormato.TabIndex = 10;
            lblFormato.Text = "Formato:";
            // 
            // txtFormato
            // 
            txtFormato.Location = new Point(410, 111);
            txtFormato.Name = "txtFormato";
            txtFormato.ReadOnly = true;
            txtFormato.Size = new Size(170, 23);
            txtFormato.TabIndex = 11;
            // 
            // lblTamanio
            // 
            lblTamanio.AutoSize = true;
            lblTamanio.Location = new Point(15, 146);
            lblTamanio.Name = "lblTamanio";
            lblTamanio.TabIndex = 12;
            lblTamanio.Text = "Tamaño (MB):";
            // 
            // txtTamanio
            // 
            txtTamanio.Location = new Point(110, 143);
            txtTamanio.Name = "txtTamanio";
            txtTamanio.ReadOnly = true;
            txtTamanio.Size = new Size(170, 23);
            txtTamanio.TabIndex = 13;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(15, 178);
            lblUrl.Name = "lblUrl";
            lblUrl.TabIndex = 14;
            lblUrl.Text = "URL descarga:";
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(110, 175);
            txtUrl.Name = "txtUrl";
            txtUrl.ReadOnly = true;
            txtUrl.Size = new Size(470, 23);
            txtUrl.TabIndex = 15;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(15, 210);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.TabIndex = 16;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(110, 207);
            txtDescripcion.Multiline = true;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(470, 60);
            txtDescripcion.TabIndex = 17;
            // 
            // lblAutores
            // 
            lblAutores.AutoSize = true;
            lblAutores.Location = new Point(15, 280);
            lblAutores.Name = "lblAutores";
            lblAutores.TabIndex = 18;
            lblAutores.Text = "Autores:";
            // 
            // lstAutores
            // 
            lstAutores.FormattingEnabled = true;
            lstAutores.Location = new Point(15, 300);
            lstAutores.Name = "lstAutores";
            lstAutores.SelectionMode = SelectionMode.None;
            lstAutores.Size = new Size(260, 124);
            lstAutores.TabIndex = 19;
            // 
            // lblTemas
            // 
            lblTemas.AutoSize = true;
            lblTemas.Location = new Point(320, 280);
            lblTemas.Name = "lblTemas";
            lblTemas.TabIndex = 20;
            lblTemas.Text = "Temas:";
            // 
            // lstTemas
            // 
            lstTemas.FormattingEnabled = true;
            lstTemas.Location = new Point(320, 300);
            lstTemas.Name = "lstTemas";
            lstTemas.SelectionMode = SelectionMode.None;
            lstTemas.Size = new Size(260, 124);
            lstTemas.TabIndex = 21;
            // 
            // chkActivo
            // 
            chkActivo.AutoCheck = false;
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(15, 445);
            chkActivo.Name = "chkActivo";
            chkActivo.TabIndex = 22;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.DialogResult = DialogResult.Cancel;
            btnCerrar.Image = Properties.Resources.cancel_24px;
            btnCerrar.Location = new Point(505, 435);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 60);
            btnCerrar.TabIndex = 23;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmDetalleLibroDigital
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCerrar;
            ClientSize = new Size(600, 510);
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
