namespace LibreriaApp2026.Windows
{
    partial class frmPrincipal
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
            panelTop = new Panel();
            lblFecha = new Label();
            label2 = new Label();
            btnSalir = new Button();
            label1 = new Label();
            panelMenu = new Panel();
            btnLibrosDigitales = new Button();
            btnLibrosFisicos = new Button();
            btnTemas = new Button();
            btnAutores = new Button();
            btnEditoriales = new Button();
            panelContent = new Panel();
            label4 = new Label();
            label3 = new Label();
            panelTop.SuspendLayout();
            panelMenu.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            //
            // panelTop
            //
            panelTop.Controls.Add(lblFecha);
            panelTop.Controls.Add(label2);
            panelTop.Controls.Add(btnSalir);
            panelTop.Controls.Add(label1);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(949, 74);
            panelTop.TabIndex = 0;
            //
            // lblFecha
            //
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(575, 25);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(73, 15);
            lblFecha.TabIndex = 2;
            lblFecha.Text = "01/01/2026";
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(528, 25);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "Fecha:";
            //
            // btnSalir
            //
            btnSalir.Location = new Point(852, 24);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 29);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(28, 19);
            label1.Name = "label1";
            label1.Size = new Size(160, 30);
            label1.TabIndex = 0;
            label1.Text = "Librería 2026";
            //
            // panelMenu
            //
            panelMenu.Controls.Add(btnLibrosDigitales);
            panelMenu.Controls.Add(btnLibrosFisicos);
            panelMenu.Controls.Add(btnTemas);
            panelMenu.Controls.Add(btnAutores);
            panelMenu.Controls.Add(btnEditoriales);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 74);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(238, 465);
            panelMenu.TabIndex = 2;
            //
            // btnLibrosDigitales
            //
            btnLibrosDigitales.Location = new Point(37, 200);
            btnLibrosDigitales.Name = "btnLibrosDigitales";
            btnLibrosDigitales.Size = new Size(171, 37);
            btnLibrosDigitales.TabIndex = 4;
            btnLibrosDigitales.Text = "Libros Digitales";
            btnLibrosDigitales.UseVisualStyleBackColor = true;
            btnLibrosDigitales.Click += btnLibrosDigitales_Click;
            //
            // btnLibrosFisicos
            //
            btnLibrosFisicos.Location = new Point(37, 157);
            btnLibrosFisicos.Name = "btnLibrosFisicos";
            btnLibrosFisicos.Size = new Size(171, 37);
            btnLibrosFisicos.TabIndex = 3;
            btnLibrosFisicos.Text = "Libros Físicos";
            btnLibrosFisicos.UseVisualStyleBackColor = true;
            btnLibrosFisicos.Click += btnLibrosFisicos_Click;
            //
            // btnTemas
            //
            btnTemas.Location = new Point(37, 114);
            btnTemas.Name = "btnTemas";
            btnTemas.Size = new Size(171, 37);
            btnTemas.TabIndex = 2;
            btnTemas.Text = "Temas";
            btnTemas.UseVisualStyleBackColor = true;
            btnTemas.Click += btnTemas_Click;
            //
            // btnAutores
            //
            btnAutores.Location = new Point(37, 71);
            btnAutores.Name = "btnAutores";
            btnAutores.Size = new Size(171, 37);
            btnAutores.TabIndex = 1;
            btnAutores.Text = "Autores";
            btnAutores.UseVisualStyleBackColor = true;
            btnAutores.Click += btnAutores_Click;
            //
            // btnEditoriales
            //
            btnEditoriales.Location = new Point(37, 28);
            btnEditoriales.Name = "btnEditoriales";
            btnEditoriales.Size = new Size(171, 37);
            btnEditoriales.TabIndex = 0;
            btnEditoriales.Text = "Editoriales";
            btnEditoriales.UseVisualStyleBackColor = true;
            btnEditoriales.Click += btnEditoriales_Click;
            //
            // panelContent
            //
            panelContent.Controls.Add(label4);
            panelContent.Controls.Add(label3);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(238, 74);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(711, 465);
            panelContent.TabIndex = 3;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(203, 131);
            label4.Name = "label4";
            label4.Size = new Size(263, 15);
            label4.TabIndex = 0;
            label4.Text = "Seleccione una opción del menú para comenzar.";
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(231, 94);
            label3.Name = "label3";
            label3.Size = new Size(170, 15);
            label3.TabIndex = 0;
            label3.Text = "Sistema de Gestión de Librería";
            //
            // frmPrincipal
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 539);
            Controls.Add(panelContent);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Librería 2026";
            Load += frmPrincipal_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label label1;
        private Label lblFecha;
        private Label label2;
        private Button btnSalir;
        private Panel panelMenu;
        private Button btnEditoriales;
        private Button btnAutores;
        private Button btnTemas;
        private Button btnLibrosFisicos;
        private Button btnLibrosDigitales;
        private Panel panelContent;
        private Label label4;
        private Label label3;
    }
}
