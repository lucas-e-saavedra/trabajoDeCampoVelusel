
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
            this.btnTestBackup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputDiasAlarmaStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDiasAlarmaCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDiasAlarmaStock
            // 
            this.lblDiasAlarmaStock.AutoSize = true;
            this.lblDiasAlarmaStock.Location = new System.Drawing.Point(17, 16);
            this.lblDiasAlarmaStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiasAlarmaStock.Name = "lblDiasAlarmaStock";
            this.lblDiasAlarmaStock.Size = new System.Drawing.Size(127, 16);
            this.lblDiasAlarmaStock.TabIndex = 0;
            this.lblDiasAlarmaStock.Text = "lblDiasAlarmaStock";
            // 
            // inputDiasAlarmaStock
            // 
            this.inputDiasAlarmaStock.Location = new System.Drawing.Point(16, 36);
            this.inputDiasAlarmaStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputDiasAlarmaStock.Name = "inputDiasAlarmaStock";
            this.inputDiasAlarmaStock.Size = new System.Drawing.Size(160, 22);
            this.inputDiasAlarmaStock.TabIndex = 1;
            // 
            // inputDiasAlarmaCompras
            // 
            this.inputDiasAlarmaCompras.Location = new System.Drawing.Point(20, 116);
            this.inputDiasAlarmaCompras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputDiasAlarmaCompras.Name = "inputDiasAlarmaCompras";
            this.inputDiasAlarmaCompras.Size = new System.Drawing.Size(160, 22);
            this.inputDiasAlarmaCompras.TabIndex = 3;
            // 
            // lblDiasAlarmaCompras
            // 
            this.lblDiasAlarmaCompras.AutoSize = true;
            this.lblDiasAlarmaCompras.Location = new System.Drawing.Point(16, 96);
            this.lblDiasAlarmaCompras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiasAlarmaCompras.Name = "lblDiasAlarmaCompras";
            this.lblDiasAlarmaCompras.Size = new System.Drawing.Size(148, 16);
            this.lblDiasAlarmaCompras.TabIndex = 2;
            this.lblDiasAlarmaCompras.Text = "lblDiasAlarmaCompras";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(81, 206);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(100, 28);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnTestAlarmas
            // 
            this.btnTestAlarmas.Location = new System.Drawing.Point(81, 316);
            this.btnTestAlarmas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTestAlarmas.Name = "btnTestAlarmas";
            this.btnTestAlarmas.Size = new System.Drawing.Size(100, 28);
            this.btnTestAlarmas.TabIndex = 5;
            this.btnTestAlarmas.Text = "btnTestAlarmas";
            this.btnTestAlarmas.UseVisualStyleBackColor = true;
            this.btnTestAlarmas.Click += new System.EventHandler(this.btnTestAlarmas_Click);
            // 
            // btnTestBackup
            // 
            this.btnTestBackup.Location = new System.Drawing.Point(81, 379);
            this.btnTestBackup.Margin = new System.Windows.Forms.Padding(4);
            this.btnTestBackup.Name = "btnTestBackup";
            this.btnTestBackup.Size = new System.Drawing.Size(100, 28);
            this.btnTestBackup.TabIndex = 6;
            this.btnTestBackup.Text = "btnTestBackup";
            this.btnTestBackup.UseVisualStyleBackColor = true;
            this.btnTestBackup.Click += new System.EventHandler(this.btnTestBackup_Click);
            // 
            // FormConfigurarAlarmas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnTestBackup);
            this.Controls.Add(this.btnTestAlarmas);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.inputDiasAlarmaCompras);
            this.Controls.Add(this.lblDiasAlarmaCompras);
            this.Controls.Add(this.inputDiasAlarmaStock);
            this.Controls.Add(this.lblDiasAlarmaStock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button btnTestBackup;
    }
}