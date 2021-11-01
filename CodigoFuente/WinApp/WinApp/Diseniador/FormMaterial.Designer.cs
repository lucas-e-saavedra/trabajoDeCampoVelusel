
namespace WinApp.Diseniador
{
    partial class FormMaterial
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.comboUnidad = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(73, 135);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(12, 70);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(51, 13);
            this.lblUnidad.TabIndex = 9;
            this.lblUnidad.Text = "lblUnidad";
            // 
            // inputNombre
            // 
            this.inputNombre.Location = new System.Drawing.Point(12, 25);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(217, 20);
            this.inputNombre.TabIndex = 8;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "lblNombre";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(154, 135);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // comboUnidad
            // 
            this.comboUnidad.FormattingEnabled = true;
            this.comboUnidad.Location = new System.Drawing.Point(12, 86);
            this.comboUnidad.Name = "comboUnidad";
            this.comboUnidad.Size = new System.Drawing.Size(217, 21);
            this.comboUnidad.TabIndex = 12;
            // 
            // FormMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 173);
            this.Controls.Add(this.comboUnidad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnGrabar);
            this.Name = "FormMaterial";
            this.Text = "Material";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMaterial_FormClosing);
            this.Load += new System.EventHandler(this.FormMaterial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox comboUnidad;
    }
}