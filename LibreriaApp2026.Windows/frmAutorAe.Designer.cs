namespace LibreriaApp2026.Windows
{
    partial class frmAutorAe
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
            txtNombre = new TextBox();
            label2 = new Label();
            txtApellido = new TextBox();
            label3 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            label4 = new Label();
            txtNacionalidad = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            btnOK = new Button();
            btnCancelar = new Button();
            chkActivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // label1
            //
            label1.AutoSize = true;
            label1.Location = new Point(45, 28);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(173, 25);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(284, 23);
            txtNombre.TabIndex = 1;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(45, 63);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido:";
            //
            // txtApellido
            //
            txtApellido.Location = new Point(173, 60);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(284, 23);
            txtApellido.TabIndex = 3;
            //
            // label3
            //
            label3.AutoSize = true;
            label3.Location = new Point(45, 98);
            label3.Name = "label3";
            label3.Size = new Size(122, 15);
            label3.TabIndex = 4;
            label3.Text = "Fecha de nacimiento:";
            //
            // dtpFechaNacimiento
            //
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(173, 95);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(140, 23);
            dtpFechaNacimiento.TabIndex = 5;
            //
            // label4
            //
            label4.AutoSize = true;
            label4.Location = new Point(45, 133);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 6;
            label4.Text = "Nacionalidad:";
            //
            // txtNacionalidad
            //
            txtNacionalidad.Location = new Point(173, 130);
            txtNacionalidad.MaxLength = 50;
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(284, 23);
            txtNacionalidad.TabIndex = 7;
            //
            // errorProvider1
            //
            errorProvider1.ContainerControl = this;
            //
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Location = new Point(45, 168);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(65, 19);
            chkActivo.TabIndex = 8;
            chkActivo.Text = "Activo?";
            chkActivo.UseVisualStyleBackColor = true;
            //
            // btnOK
            //
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(49, 205);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 9;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            //
            // btnCancelar
            //
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(382, 205);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // frmAutorAe
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 290);
            Controls.Add(chkActivo);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtNacionalidad);
            Controls.Add(label4);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(label3);
            Controls.Add(txtApellido);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAutorAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAutorAe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtApellido;
        private Label label3;
        private DateTimePicker dtpFechaNacimiento;
        private Label label4;
        private TextBox txtNacionalidad;
        private ErrorProvider errorProvider1;
        private Button btnCancelar;
        private Button btnOK;
        private CheckBox chkActivo;
    }
}
