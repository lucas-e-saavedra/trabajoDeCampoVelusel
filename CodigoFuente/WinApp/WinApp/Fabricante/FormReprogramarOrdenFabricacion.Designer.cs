
namespace WinApp.Fabricante
{
    partial class FormReprogramarOrdenFabricacion
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
            this.lblExplicarReprogramacion = new System.Windows.Forms.Label();
            this.dateReprogramacion = new System.Windows.Forms.MonthCalendar();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblExplicarReprogramacion
            // 
            this.lblExplicarReprogramacion.AutoSize = true;
            this.lblExplicarReprogramacion.Location = new System.Drawing.Point(12, 9);
            this.lblExplicarReprogramacion.Name = "lblExplicarReprogramacion";
            this.lblExplicarReprogramacion.Size = new System.Drawing.Size(132, 13);
            this.lblExplicarReprogramacion.TabIndex = 0;
            this.lblExplicarReprogramacion.Text = "lblExplicarReprogramacion";
            // 
            // dateReprogramacion
            // 
            this.dateReprogramacion.Location = new System.Drawing.Point(15, 31);
            this.dateReprogramacion.Name = "dateReprogramacion";
            this.dateReprogramacion.TabIndex = 1;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(132, 205);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // FormReprogramarOrdenFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 243);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.dateReprogramacion);
            this.Controls.Add(this.lblExplicarReprogramacion);
            this.Name = "FormReprogramarOrdenFabricacion";
            this.Text = "FormReprogramarOrdenFabricacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormReprogramarOrdenFabricacion_FormClosing);
            this.Load += new System.EventHandler(this.FormReprogramarOrdenFabricacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExplicarReprogramacion;
        private System.Windows.Forms.MonthCalendar dateReprogramacion;
        private System.Windows.Forms.Button btnGrabar;
    }
}