namespace LibreriaApp2026.Windows
{
    partial class frmClienteAe
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
            txtDocumento = new TextBox();
            label4 = new Label();
            txtTelefono = new TextBox();
            label5 = new Label();
            txtEmail = new TextBox();
            grpDomicilio = new GroupBox();
            label6 = new Label();
            txtCalle = new TextBox();
            label7 = new Label();
            txtNumero = new TextBox();
            label8 = new Label();
            txtLocalidad = new TextBox();
            label9 = new Label();
            txtCodigoPostal = new TextBox();
            label10 = new Label();
            txtProvincia = new TextBox();
            chkActivo = new CheckBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            grpDomicilio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 34);
            label1.Name = "label1";
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 30);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.MaxLength = 50;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(190, 27);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(345, 34);
            label2.Name = "label2";
            label2.Text = "Apellido:";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(430, 30);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.MaxLength = 50;
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(190, 27);
            txtApellido.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 79);
            label3.Name = "label3";
            label3.Text = "Documento:";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(130, 75);
            txtDocumento.Margin = new Padding(3, 4, 3, 4);
            txtDocumento.MaxLength = 8;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(190, 27);
            txtDocumento.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(345, 79);
            label4.Name = "label4";
            label4.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(430, 75);
            txtTelefono.Margin = new Padding(3, 4, 3, 4);
            txtTelefono.MaxLength = 30;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(190, 27);
            txtTelefono.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 124);
            label5.Name = "label5";
            label5.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(130, 120);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(490, 27);
            txtEmail.TabIndex = 5;
            // 
            // grpDomicilio
            // 
            grpDomicilio.Controls.Add(label6);
            grpDomicilio.Controls.Add(txtCalle);
            grpDomicilio.Controls.Add(label7);
            grpDomicilio.Controls.Add(txtNumero);
            grpDomicilio.Controls.Add(label8);
            grpDomicilio.Controls.Add(txtLocalidad);
            grpDomicilio.Controls.Add(label9);
            grpDomicilio.Controls.Add(txtCodigoPostal);
            grpDomicilio.Controls.Add(label10);
            grpDomicilio.Controls.Add(txtProvincia);
            grpDomicilio.Location = new Point(30, 165);
            grpDomicilio.Margin = new Padding(3, 4, 3, 4);
            grpDomicilio.Name = "grpDomicilio";
            grpDomicilio.Padding = new Padding(3, 4, 3, 4);
            grpDomicilio.Size = new Size(590, 150);
            grpDomicilio.TabIndex = 6;
            grpDomicilio.TabStop = false;
            grpDomicilio.Text = "Domicilio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 34);
            label6.Name = "label6";
            label6.Text = "Calle:";
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(100, 30);
            txtCalle.Margin = new Padding(3, 4, 3, 4);
            txtCalle.MaxLength = 100;
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(270, 27);
            txtCalle.TabIndex = 0;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(390, 34);
            label7.Name = "label7";
            label7.Text = "Número:";
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(465, 30);
            txtNumero.Margin = new Padding(3, 4, 3, 4);
            txtNumero.MaxLength = 20;
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(105, 27);
            txtNumero.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 75);
            label8.Name = "label8";
            label8.Text = "Localidad:";
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(100, 71);
            txtLocalidad.Margin = new Padding(3, 4, 3, 4);
            txtLocalidad.MaxLength = 100;
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(270, 27);
            txtLocalidad.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(375, 75);
            label9.Name = "label9";
            label9.Text = "Cód. Postal:";
            // 
            // txtCodigoPostal
            // 
            txtCodigoPostal.Location = new Point(465, 71);
            txtCodigoPostal.Margin = new Padding(3, 4, 3, 4);
            txtCodigoPostal.MaxLength = 10;
            txtCodigoPostal.Name = "txtCodigoPostal";
            txtCodigoPostal.Size = new Size(105, 27);
            txtCodigoPostal.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 116);
            label10.Name = "label10";
            label10.Text = "Provincia:";
            // 
            // txtProvincia
            // 
            txtProvincia.Location = new Point(100, 112);
            txtProvincia.Margin = new Padding(3, 4, 3, 4);
            txtProvincia.MaxLength = 100;
            txtProvincia.Name = "txtProvincia";
            txtProvincia.Size = new Size(270, 27);
            txtProvincia.TabIndex = 4;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Location = new Point(30, 330);
            chkActivo.Margin = new Padding(3, 4, 3, 4);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(80, 24);
            chkActivo.TabIndex = 7;
            chkActivo.Text = "Activo?";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(35, 372);
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
            btnCancelar.Location = new Point(534, 372);
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
            // frmClienteAe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 472);
            ControlBox = false;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(670, 519);
            MinimumSize = new Size(670, 519);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmClienteAe";
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(chkActivo);
            Controls.Add(grpDomicilio);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Controls.Add(txtTelefono);
            Controls.Add(label4);
            Controls.Add(txtDocumento);
            Controls.Add(label3);
            Controls.Add(txtApellido);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "frmClienteAe";
            grpDomicilio.ResumeLayout(false);
            grpDomicilio.PerformLayout();
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
        private TextBox txtDocumento;
        private Label label4;
        private TextBox txtTelefono;
        private Label label5;
        private TextBox txtEmail;
        private GroupBox grpDomicilio;
        private Label label6;
        private TextBox txtCalle;
        private Label label7;
        private TextBox txtNumero;
        private Label label8;
        private TextBox txtLocalidad;
        private Label label9;
        private TextBox txtCodigoPostal;
        private Label label10;
        private TextBox txtProvincia;
        private CheckBox chkActivo;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}
