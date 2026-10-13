namespace LibreriaApp2026.Windows
{
    partial class frmEditorialAe
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
            txtPaisOrigen = new TextBox();
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
            txtNombre.Location = new Point(143, 25);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(314, 23);
            txtNombre.TabIndex = 1;
            //
            // label2
            //
            label2.AutoSize = true;
            label2.Location = new Point(45, 63);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 2;
            label2.Text = "País de origen:";
            //
            // txtPaisOrigen
            //
            txtPaisOrigen.Location = new Point(143, 60);
            txtPaisOrigen.MaxLength = 50;
            txtPaisOrigen.Name = "txtPaisOrigen";
            txtPaisOrigen.Size = new Size(314, 23);
            txtPaisOrigen.TabIndex = 3;
            //
            // errorProvider1
            //
            errorProvider1.ContainerControl = this;
            //
            // btnOK
            //
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(49, 138);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 5;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            //
            // btnCancelar
            //
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(382, 138);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 6;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            //
            // chkActivo
            //
            chkActivo.AutoSize = true;
            chkActivo.CheckAlign = ContentAlignment.MiddleRight;
            chkActivo.Location = new Point(45, 100);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(65, 19);
            chkActivo.TabIndex = 4;
            chkActivo.Text = "Activo?";
            chkActivo.UseVisualStyleBackColor = true;
            //
            // frmEditorialAe
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 234);
            Controls.Add(chkActivo);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(txtPaisOrigen);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            MaximumSize = new Size(536, 273);
            MinimumSize = new Size(536, 273);
            Name = "frmEditorialAe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmEditorialAe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtPaisOrigen;
        private ErrorProvider errorProvider1;
        private Button btnCancelar;
        private Button btnOK;
        private CheckBox chkActivo;
    }
}
