
namespace WinApp.Comprador
{
    partial class FormOrdenDeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrdenDeCompra));
            this.lblObjetivoOrdenCompra = new System.Windows.Forms.Label();
            this.lblIdOrdenCompra = new System.Windows.Forms.Label();
            this.timeFechaEstimada = new System.Windows.Forms.DateTimePicker();
            this.inputCantidadComprados = new System.Windows.Forms.TextBox();
            this.lblFechaOrdenCompra = new System.Windows.Forms.Label();
            this.inputCantidadRecibidos = new System.Windows.Forms.TextBox();
            this.timeFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkRecibido = new System.Windows.Forms.CheckBox();
            this.groupRecibido = new System.Windows.Forms.GroupBox();
            this.lblCantidadRecibida = new System.Windows.Forms.Label();
            this.lblCantidadComprada = new System.Windows.Forms.Label();
            this.groupRecibido.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblObjetivoOrdenCompra
            // 
            this.lblObjetivoOrdenCompra.AutoSize = true;
            this.lblObjetivoOrdenCompra.Location = new System.Drawing.Point(12, 35);
            this.lblObjetivoOrdenCompra.Name = "lblObjetivoOrdenCompra";
            this.lblObjetivoOrdenCompra.Size = new System.Drawing.Size(121, 13);
            this.lblObjetivoOrdenCompra.TabIndex = 16;
            this.lblObjetivoOrdenCompra.Text = "lblObjetivoOrdenCompra";
            // 
            // lblIdOrdenCompra
            // 
            this.lblIdOrdenCompra.AutoSize = true;
            this.lblIdOrdenCompra.Location = new System.Drawing.Point(12, 9);
            this.lblIdOrdenCompra.Name = "lblIdOrdenCompra";
            this.lblIdOrdenCompra.Size = new System.Drawing.Size(91, 13);
            this.lblIdOrdenCompra.TabIndex = 15;
            this.lblIdOrdenCompra.Text = "lblIdOrdenCompra";
            // 
            // timeFechaEstimada
            // 
            this.timeFechaEstimada.Location = new System.Drawing.Point(12, 138);
            this.timeFechaEstimada.Name = "timeFechaEstimada";
            this.timeFechaEstimada.Size = new System.Drawing.Size(200, 20);
            this.timeFechaEstimada.TabIndex = 20;
            // 
            // inputCantidadComprados
            // 
            this.inputCantidadComprados.Location = new System.Drawing.Point(12, 112);
            this.inputCantidadComprados.Name = "inputCantidadComprados";
            this.inputCantidadComprados.Size = new System.Drawing.Size(100, 20);
            this.inputCantidadComprados.TabIndex = 22;
            // 
            // lblFechaOrdenCompra
            // 
            this.lblFechaOrdenCompra.AutoSize = true;
            this.lblFechaOrdenCompra.Location = new System.Drawing.Point(12, 59);
            this.lblFechaOrdenCompra.Name = "lblFechaOrdenCompra";
            this.lblFechaOrdenCompra.Size = new System.Drawing.Size(112, 13);
            this.lblFechaOrdenCompra.TabIndex = 24;
            this.lblFechaOrdenCompra.Text = "lblFechaOrdenCompra";
            // 
            // inputCantidadRecibidos
            // 
            this.inputCantidadRecibidos.Location = new System.Drawing.Point(6, 55);
            this.inputCantidadRecibidos.Name = "inputCantidadRecibidos";
            this.inputCantidadRecibidos.Size = new System.Drawing.Size(100, 20);
            this.inputCantidadRecibidos.TabIndex = 26;
            // 
            // timeFechaRecepcion
            // 
            this.timeFechaRecepcion.Location = new System.Drawing.Point(6, 81);
            this.timeFechaRecepcion.Name = "timeFechaRecepcion";
            this.timeFechaRecepcion.Size = new System.Drawing.Size(200, 20);
            this.timeFechaRecepcion.TabIndex = 25;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(211, 307);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 27;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(130, 307);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chkRecibido
            // 
            this.chkRecibido.AutoSize = true;
            this.chkRecibido.Location = new System.Drawing.Point(6, 19);
            this.chkRecibido.Name = "chkRecibido";
            this.chkRecibido.Size = new System.Drawing.Size(86, 17);
            this.chkRecibido.TabIndex = 29;
            this.chkRecibido.Text = "chkRecibido";
            this.chkRecibido.UseVisualStyleBackColor = true;
            this.chkRecibido.CheckedChanged += new System.EventHandler(this.chkRecibido_CheckedChanged);
            // 
            // groupRecibido
            // 
            this.groupRecibido.Controls.Add(this.lblCantidadRecibida);
            this.groupRecibido.Controls.Add(this.chkRecibido);
            this.groupRecibido.Controls.Add(this.inputCantidadRecibidos);
            this.groupRecibido.Controls.Add(this.timeFechaRecepcion);
            this.groupRecibido.Location = new System.Drawing.Point(12, 176);
            this.groupRecibido.Name = "groupRecibido";
            this.groupRecibido.Size = new System.Drawing.Size(274, 113);
            this.groupRecibido.TabIndex = 30;
            this.groupRecibido.TabStop = false;
            this.groupRecibido.Text = "groupRecibido";
            // 
            // lblCantidadRecibida
            // 
            this.lblCantidadRecibida.AutoSize = true;
            this.lblCantidadRecibida.Location = new System.Drawing.Point(6, 39);
            this.lblCantidadRecibida.Name = "lblCantidadRecibida";
            this.lblCantidadRecibida.Size = new System.Drawing.Size(101, 13);
            this.lblCantidadRecibida.TabIndex = 32;
            this.lblCantidadRecibida.Text = "lblCantidadRecibida";
            // 
            // lblCantidadComprada
            // 
            this.lblCantidadComprada.AutoSize = true;
            this.lblCantidadComprada.Location = new System.Drawing.Point(12, 96);
            this.lblCantidadComprada.Name = "lblCantidadComprada";
            this.lblCantidadComprada.Size = new System.Drawing.Size(107, 13);
            this.lblCantidadComprada.TabIndex = 31;
            this.lblCantidadComprada.Text = "lblCantidadComprada";
            // 
            // FormOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 358);
            this.Controls.Add(this.lblCantidadComprada);
            this.Controls.Add(this.groupRecibido);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblFechaOrdenCompra);
            this.Controls.Add(this.inputCantidadComprados);
            this.Controls.Add(this.timeFechaEstimada);
            this.Controls.Add(this.lblObjetivoOrdenCompra);
            this.Controls.Add(this.lblIdOrdenCompra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOrdenDeCompra";
            this.Text = "FormOrdenDeCompra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrdenDeCompra_FormClosing);
            this.Load += new System.EventHandler(this.FormOrdenDeCompra_Load);
            this.groupRecibido.ResumeLayout(false);
            this.groupRecibido.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblObjetivoOrdenCompra;
        private System.Windows.Forms.Label lblIdOrdenCompra;
        private System.Windows.Forms.DateTimePicker timeFechaEstimada;
        private System.Windows.Forms.TextBox inputCantidadComprados;
        private System.Windows.Forms.Label lblFechaOrdenCompra;
        private System.Windows.Forms.TextBox inputCantidadRecibidos;
        private System.Windows.Forms.DateTimePicker timeFechaRecepcion;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkRecibido;
        private System.Windows.Forms.GroupBox groupRecibido;
        private System.Windows.Forms.Label lblCantidadComprada;
        private System.Windows.Forms.Label lblCantidadRecibida;
    }
}