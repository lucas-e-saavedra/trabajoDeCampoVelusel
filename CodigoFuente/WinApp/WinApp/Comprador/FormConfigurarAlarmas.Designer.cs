
namespace WinApp.Comprador
{
    partial class FormConfigurarAlarmas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigurarAlarmas));
            this.lblDiasAlarmaStock = new System.Windows.Forms.Label();
            this.inputDiasAlarmaStock = new System.Windows.Forms.NumericUpDown();
            this.inputDiasAlarmaCompras = new System.Windows.Forms.NumericUpDown();
            this.lblDiasAlarmaCompras = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnTestAlarmas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputDiasAlarmaStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDiasAlarmaCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDiasAlarmaStock
            // 
            this.lblDiasAlarmaStock.AutoSize = true;
            this.lblDiasAlarmaStock.Location = new System.Drawing.Point(13, 13);
            this.lblDiasAlarmaStock.Name = "lblDiasAlarmaStock";
            this.lblDiasAlarmaStock.Size = new System.Drawing.Size(98, 13);
            this.lblDiasAlarmaStock.TabIndex = 0;
            this.lblDiasAlarmaStock.Text = "lblDiasAlarmaStock";
            // 
            // inputDiasAlarmaStock
            // 
            this.inputDiasAlarmaStock.Location = new System.Drawing.Point(12, 29);
            this.inputDiasAlarmaStock.Name = "inputDiasAlarmaStock";
            this.inputDiasAlarmaStock.Size = new System.Drawing.Size(120, 20);
            this.inputDiasAlarmaStock.TabIndex = 1;
            // 
            // inputDiasAlarmaCompras
            // 
            this.inputDiasAlarmaCompras.Location = new System.Drawing.Point(15, 94);
            this.inputDiasAlarmaCompras.Name = "inputDiasAlarmaCompras";
            this.inputDiasAlarmaCompras.Size = new System.Drawing.Size(120, 20);
            this.inputDiasAlarmaCompras.TabIndex = 3;
            // 
            // lblDiasAlarmaCompras
            // 
            this.lblDiasAlarmaCompras.AutoSize = true;
            this.lblDiasAlarmaCompras.Location = new System.Drawing.Point(12, 78);
            this.lblDiasAlarmaCompras.Name = "lblDiasAlarmaCompras";
            this.lblDiasAlarmaCompras.Size = new System.Drawing.Size(111, 13);
            this.lblDiasAlarmaCompras.TabIndex = 2;
            this.lblDiasAlarmaCompras.Text = "lblDiasAlarmaCompras";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(61, 167);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnTestAlarmas
            // 
            this.btnTestAlarmas.Location = new System.Drawing.Point(61, 257);
            this.btnTestAlarmas.Name = "btnTestAlarmas";
            this.btnTestAlarmas.Size = new System.Drawing.Size(75, 23);
            this.btnTestAlarmas.TabIndex = 5;
            this.btnTestAlarmas.Text = "btnTestAlarmas";
            this.btnTestAlarmas.UseVisualStyleBackColor = true;
            this.btnTestAlarmas.Click += new System.EventHandler(this.btnTestAlarmas_Click);
            // 
            // FormConfigurarAlarmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTestAlarmas);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.inputDiasAlarmaCompras);
            this.Controls.Add(this.lblDiasAlarmaCompras);
            this.Controls.Add(this.inputDiasAlarmaStock);
            this.Controls.Add(this.lblDiasAlarmaStock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConfigurarAlarmas";
            this.Text = "FormConfigurarAlarmas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfigurarAlarmas_FormClosing);
            this.Load += new System.EventHandler(this.FormConfigurarAlarmas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputDiasAlarmaStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDiasAlarmaCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDiasAlarmaStock;
        private System.Windows.Forms.NumericUpDown inputDiasAlarmaStock;
        private System.Windows.Forms.NumericUpDown inputDiasAlarmaCompras;
        private System.Windows.Forms.Label lblDiasAlarmaCompras;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnTestAlarmas;
    }
}