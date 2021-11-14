
namespace WinApp.Vendedor
{
    partial class FormCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCliente));
            this.comboDocumento = new System.Windows.Forms.ComboBox();
            this.inputDocumento = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.inputTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // comboDocumento
            // 
            this.comboDocumento.FormattingEnabled = true;
            this.comboDocumento.Location = new System.Drawing.Point(20, 87);
            this.comboDocumento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboDocumento.Name = "comboDocumento";
            this.comboDocumento.Size = new System.Drawing.Size(101, 24);
            this.comboDocumento.TabIndex = 2;
            // 
            // inputDocumento
            // 
            this.inputDocumento.Location = new System.Drawing.Point(131, 87);
            this.inputDocumento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputDocumento.Name = "inputDocumento";
            this.inputDocumento.Size = new System.Drawing.Size(204, 22);
            this.inputDocumento.TabIndex = 3;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(16, 66);
            this.lblDocumento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(91, 16);
            this.lblDocumento.TabIndex = 37;
            this.lblDocumento.Text = "lblDocumento";
            // 
            // inputEmail
            // 
            this.inputEmail.Location = new System.Drawing.Point(20, 139);
            this.inputEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(315, 22);
            this.inputEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(16, 119);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 16);
            this.lblEmail.TabIndex = 36;
            this.lblEmail.Text = "lblEmail";
            // 
            // inputNombre
            // 
            this.inputNombre.Location = new System.Drawing.Point(20, 34);
            this.inputNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(315, 22);
            this.inputNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(16, 15);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(71, 16);
            this.lblNombre.TabIndex = 35;
            this.lblNombre.Text = "lblNombre";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(128, 279);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // inputTelefono
            // 
            this.inputTelefono.Location = new System.Drawing.Point(20, 190);
            this.inputTelefono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputTelefono.Name = "inputTelefono";
            this.inputTelefono.Size = new System.Drawing.Size(315, 22);
            this.inputTelefono.TabIndex = 5;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(16, 170);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(76, 16);
            this.lblTelefono.TabIndex = 34;
            this.lblTelefono.Text = "lblTelefono";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(236, 279);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 28);
            this.btnGrabar.TabIndex = 7;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(20, 234);
            this.chkHabilitado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(110, 20);
            this.chkHabilitado.TabIndex = 6;
            this.chkHabilitado.Text = "chkHabilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 324);
            this.Controls.Add(this.chkHabilitado);
            this.Controls.Add(this.comboDocumento);
            this.Controls.Add(this.inputDocumento);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.inputEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.inputTelefono);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.btnGrabar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCliente";
            this.Text = "FormCliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCliente_FormClosing);
            this.Load += new System.EventHandler(this.FormCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDocumento;
        private System.Windows.Forms.TextBox inputDocumento;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox inputEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox inputTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.CheckBox chkHabilitado;
    }
}