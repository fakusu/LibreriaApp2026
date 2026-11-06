namespace LibreriaApp2026.Windows
{
    partial class frmDetalleLibroFisico
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
            lblStock = new Label();
            txtStock = new TextBox();
            lblPaginas = new Label();
            txtPaginas = new TextBox();
            lblPeso = new Label();
            txtPeso = new TextBox();
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
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(320, 114);
            lblStock.Name = "lblStock";
            lblStock.TabIndex = 10;
            lblStock.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(410, 111);
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(170, 23);
            txtStock.TabIndex = 11;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(15, 146);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.TabIndex = 12;
            lblPaginas.Text = "Páginas:";
            // 
            // txtPaginas
            // 
            txtPaginas.Location = new Point(110, 143);
            txtPaginas.Name = "txtPaginas";
            txtPaginas.ReadOnly = true;
            txtPaginas.Size = new Size(170, 23);
            txtPaginas.TabIndex = 13;
            // 
            // lblPeso
            // 
            lblPeso.AutoSize = true;
            lblPeso.Location = new Point(320, 146);
            lblPeso.Name = "lblPeso";
            lblPeso.TabIndex = 14;
            lblPeso.Text = "Peso (g):";
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(410, 143);
            txtPeso.Name = "txtPeso";
            txtPeso.ReadOnly = true;
            txtPeso.Size = new Size(170, 23);
            txtPeso.TabIndex = 15;
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
            // frmDetalleLibroFisico
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
            Controls.Add(txtPeso);
            Controls.Add(lblPeso);
            Controls.Add(txtPaginas);
            Controls.Add(lblPaginas);
            Controls.Add(txtStock);
            Controls.Add(lblStock);
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
            Name = "frmDetalleLibroFisico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detalle de Libro Físico";
            Load += frmDetalleLibroFisico_Load;
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
        private Label lblStock;
        private TextBox txtStock;
        private Label lblPaginas;
        private TextBox txtPaginas;
        private Label lblPeso;
        private TextBox txtPeso;
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
