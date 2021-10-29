
namespace WinApp.Fabricante
{
    partial class FormOrdenDeFabricacion
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
            this.btnComenzar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblIdOrdenFabricacion = new System.Windows.Forms.Label();
            this.lblFechaOrdenFabricacion = new System.Windows.Forms.Label();
            this.lblEstadoOrdenFabricacion = new System.Windows.Forms.Label();
            this.lblIngredientesOrdenFabricacion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnComenzar
            // 
            this.btnComenzar.Location = new System.Drawing.Point(12, 310);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(102, 23);
            this.btnComenzar.TabIndex = 13;
            this.btnComenzar.Text = "btnComenzar";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 351);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblIdOrdenFabricacion
            // 
            this.lblIdOrdenFabricacion.AutoSize = true;
            this.lblIdOrdenFabricacion.Location = new System.Drawing.Point(13, 13);
            this.lblIdOrdenFabricacion.Name = "lblIdOrdenFabricacion";
            this.lblIdOrdenFabricacion.Size = new System.Drawing.Size(110, 13);
            this.lblIdOrdenFabricacion.TabIndex = 15;
            this.lblIdOrdenFabricacion.Text = "lblIdOrdenFabricacion";
            // 
            // lblFechaOrdenFabricacion
            // 
            this.lblFechaOrdenFabricacion.AutoSize = true;
            this.lblFechaOrdenFabricacion.Location = new System.Drawing.Point(13, 35);
            this.lblFechaOrdenFabricacion.Name = "lblFechaOrdenFabricacion";
            this.lblFechaOrdenFabricacion.Size = new System.Drawing.Size(131, 13);
            this.lblFechaOrdenFabricacion.TabIndex = 16;
            this.lblFechaOrdenFabricacion.Text = "lblFechaOrdenFabricacion";
            // 
            // lblEstadoOrdenFabricacion
            // 
            this.lblEstadoOrdenFabricacion.AutoSize = true;
            this.lblEstadoOrdenFabricacion.Location = new System.Drawing.Point(13, 57);
            this.lblEstadoOrdenFabricacion.Name = "lblEstadoOrdenFabricacion";
            this.lblEstadoOrdenFabricacion.Size = new System.Drawing.Size(134, 13);
            this.lblEstadoOrdenFabricacion.TabIndex = 17;
            this.lblEstadoOrdenFabricacion.Text = "lblEstadoOrdenFabricacion";
            // 
            // lblIngredientesOrdenFabricacion
            // 
            this.lblIngredientesOrdenFabricacion.AutoSize = true;
            this.lblIngredientesOrdenFabricacion.Location = new System.Drawing.Point(13, 79);
            this.lblIngredientesOrdenFabricacion.Name = "lblIngredientesOrdenFabricacion";
            this.lblIngredientesOrdenFabricacion.Size = new System.Drawing.Size(159, 13);
            this.lblIngredientesOrdenFabricacion.TabIndex = 18;
            this.lblIngredientesOrdenFabricacion.Text = "lblIngredientesOrdenFabricacion";
            // 
            // FormOrdenDeFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblIngredientesOrdenFabricacion);
            this.Controls.Add(this.lblEstadoOrdenFabricacion);
            this.Controls.Add(this.lblFechaOrdenFabricacion);
            this.Controls.Add(this.lblIdOrdenFabricacion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnComenzar);
            this.Name = "FormOrdenDeFabricacion";
            this.Text = "FormOrdenDeFabricacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrdenDeFabricacion_FormClosing);
            this.Load += new System.EventHandler(this.FormOrdenDeFabricacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblIdOrdenFabricacion;
        private System.Windows.Forms.Label lblFechaOrdenFabricacion;
        private System.Windows.Forms.Label lblEstadoOrdenFabricacion;
        private System.Windows.Forms.Label lblIngredientesOrdenFabricacion;
    }
}