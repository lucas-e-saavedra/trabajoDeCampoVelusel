
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
            this.lblReposoNecesario = new System.Windows.Forms.Label();
            this.textIngredientes = new System.Windows.Forms.RichTextBox();
            this.lblObjetivoOrdenFabricacion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnComenzar
            // 
            this.btnComenzar.Location = new System.Drawing.Point(181, 366);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(102, 23);
            this.btnComenzar.TabIndex = 13;
            this.btnComenzar.Text = "btnComenzar";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(91, 366);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
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
            // lblReposoNecesario
            // 
            this.lblReposoNecesario.AutoSize = true;
            this.lblReposoNecesario.Location = new System.Drawing.Point(12, 103);
            this.lblReposoNecesario.Name = "lblReposoNecesario";
            this.lblReposoNecesario.Size = new System.Drawing.Size(102, 13);
            this.lblReposoNecesario.TabIndex = 18;
            this.lblReposoNecesario.Text = "lblReposoNecesario";
            // 
            // textIngredientes
            // 
            this.textIngredientes.Location = new System.Drawing.Point(12, 128);
            this.textIngredientes.Name = "textIngredientes";
            this.textIngredientes.Size = new System.Drawing.Size(271, 232);
            this.textIngredientes.TabIndex = 19;
            this.textIngredientes.Text = "";
            // 
            // lblObjetivoOrdenFabricacion
            // 
            this.lblObjetivoOrdenFabricacion.AutoSize = true;
            this.lblObjetivoOrdenFabricacion.Location = new System.Drawing.Point(13, 79);
            this.lblObjetivoOrdenFabricacion.Name = "lblObjetivoOrdenFabricacion";
            this.lblObjetivoOrdenFabricacion.Size = new System.Drawing.Size(140, 13);
            this.lblObjetivoOrdenFabricacion.TabIndex = 20;
            this.lblObjetivoOrdenFabricacion.Text = "lblObjetivoOrdenFabricacion";
            // 
            // FormOrdenDeFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 401);
            this.Controls.Add(this.lblObjetivoOrdenFabricacion);
            this.Controls.Add(this.textIngredientes);
            this.Controls.Add(this.lblReposoNecesario);
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
        private System.Windows.Forms.Label lblReposoNecesario;
        private System.Windows.Forms.RichTextBox textIngredientes;
        private System.Windows.Forms.Label lblObjetivoOrdenFabricacion;
    }
}