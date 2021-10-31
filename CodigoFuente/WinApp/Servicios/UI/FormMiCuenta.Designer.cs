
namespace Servicios.UI
{
    partial class FormMiCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMiCuenta));
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.inputContrasenia = new System.Windows.Forms.TextBox();
            this.inputRepetirContrasenia = new System.Windows.Forms.TextBox();
            this.lblRepetirContrasenia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputEmail
            // 
            this.inputEmail.Location = new System.Drawing.Point(12, 122);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(214, 20);
            this.inputEmail.TabIndex = 27;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 106);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 13);
            this.lblEmail.TabIndex = 32;
            this.lblEmail.Text = "lblEmail";
            // 
            // inputNombre
            // 
            this.inputNombre.Location = new System.Drawing.Point(12, 74);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(214, 20);
            this.inputNombre.TabIndex = 26;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 58);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 31;
            this.lblNombre.Text = "lblNombre";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(59, 273);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // inputUsuario
            // 
            this.inputUsuario.Enabled = false;
            this.inputUsuario.Location = new System.Drawing.Point(12, 25);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.Size = new System.Drawing.Size(214, 20);
            this.inputUsuario.TabIndex = 25;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(13, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(53, 13);
            this.lblUsuario.TabIndex = 30;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(151, 273);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 28;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Location = new System.Drawing.Point(12, 154);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(73, 13);
            this.lblContrasenia.TabIndex = 33;
            this.lblContrasenia.Text = "lblContrasenia";
            // 
            // inputContrasenia
            // 
            this.inputContrasenia.Location = new System.Drawing.Point(12, 170);
            this.inputContrasenia.Name = "inputContrasenia";
            this.inputContrasenia.Size = new System.Drawing.Size(214, 20);
            this.inputContrasenia.TabIndex = 34;
            this.inputContrasenia.UseSystemPasswordChar = true;
            // 
            // inputRepetirContrasenia
            // 
            this.inputRepetirContrasenia.Location = new System.Drawing.Point(12, 218);
            this.inputRepetirContrasenia.Name = "inputRepetirContrasenia";
            this.inputRepetirContrasenia.Size = new System.Drawing.Size(214, 20);
            this.inputRepetirContrasenia.TabIndex = 36;
            this.inputRepetirContrasenia.UseSystemPasswordChar = true;
            // 
            // lblRepetirContrasenia
            // 
            this.lblRepetirContrasenia.AutoSize = true;
            this.lblRepetirContrasenia.Location = new System.Drawing.Point(12, 202);
            this.lblRepetirContrasenia.Name = "lblRepetirContrasenia";
            this.lblRepetirContrasenia.Size = new System.Drawing.Size(107, 13);
            this.lblRepetirContrasenia.TabIndex = 35;
            this.lblRepetirContrasenia.Text = "lblRepetirContrasenia";
            // 
            // FormMiCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.inputRepetirContrasenia);
            this.Controls.Add(this.lblRepetirContrasenia);
            this.Controls.Add(this.inputContrasenia);
            this.Controls.Add(this.lblContrasenia);
            this.Controls.Add(this.inputEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnGrabar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMiCuenta";
            this.Text = "FormMiCuenta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMiCuenta_FormClosing);
            this.Load += new System.EventHandler(this.FormMiCuenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.TextBox inputContrasenia;
        private System.Windows.Forms.TextBox inputRepetirContrasenia;
        private System.Windows.Forms.Label lblRepetirContrasenia;
    }
}