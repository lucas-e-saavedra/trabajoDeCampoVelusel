
namespace Servicios.UI
{
    partial class FormPatente
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
            this.btnGrabar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.lblVista = new System.Windows.Forms.Label();
            this.inputVista = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(154, 135);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 0;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "lblNombre";
            // 
            // inputNombre
            // 
            this.inputNombre.Location = new System.Drawing.Point(15, 25);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(214, 20);
            this.inputNombre.TabIndex = 2;
            // 
            // lblVista
            // 
            this.lblVista.AutoSize = true;
            this.lblVista.Location = new System.Drawing.Point(12, 70);
            this.lblVista.Name = "lblVista";
            this.lblVista.Size = new System.Drawing.Size(40, 13);
            this.lblVista.TabIndex = 3;
            this.lblVista.Text = "lblVista";
            // 
            // inputVista
            // 
            this.inputVista.Location = new System.Drawing.Point(15, 86);
            this.inputVista.Name = "inputVista";
            this.inputVista.Size = new System.Drawing.Size(214, 20);
            this.inputVista.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(154, 164);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormPatente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 197);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.inputVista);
            this.Controls.Add(this.lblVista);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnGrabar);
            this.Name = "FormPatente";
            this.Text = "FormPatente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPatente_FormClosing);
            this.Load += new System.EventHandler(this.FormPatente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Label lblVista;
        private System.Windows.Forms.TextBox inputVista;
        private System.Windows.Forms.Button btnCancelar;
    }
}