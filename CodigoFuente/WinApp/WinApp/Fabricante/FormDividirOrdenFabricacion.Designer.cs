
namespace WinApp.Fabricante
{
    partial class FormDividirOrdenFabricacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDividirOrdenFabricacion));
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dateReprogramacion = new System.Windows.Forms.MonthCalendar();
            this.lblExplicarReprogramacion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(135, 210);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // dateReprogramacion
            // 
            this.dateReprogramacion.Location = new System.Drawing.Point(18, 36);
            this.dateReprogramacion.Name = "dateReprogramacion";
            this.dateReprogramacion.TabIndex = 4;
            // 
            // lblExplicarReprogramacion
            // 
            this.lblExplicarReprogramacion.AutoSize = true;
            this.lblExplicarReprogramacion.Location = new System.Drawing.Point(15, 14);
            this.lblExplicarReprogramacion.Name = "lblExplicarReprogramacion";
            this.lblExplicarReprogramacion.Size = new System.Drawing.Size(132, 13);
            this.lblExplicarReprogramacion.TabIndex = 3;
            this.lblExplicarReprogramacion.Text = "lblExplicarReprogramacion";
            // 
            // FormDividirOrdenFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 244);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dateReprogramacion);
            this.Controls.Add(this.lblExplicarReprogramacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDividirOrdenFabricacion";
            this.Text = "FormDividirOrdenFabricacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDividirOrdenFabricacion_FormClosing);
            this.Load += new System.EventHandler(this.FormDividirOrdenFabricacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.MonthCalendar dateReprogramacion;
        private System.Windows.Forms.Label lblExplicarReprogramacion;
    }
}