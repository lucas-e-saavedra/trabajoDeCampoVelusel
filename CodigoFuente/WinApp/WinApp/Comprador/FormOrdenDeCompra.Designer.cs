
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
            this.lblMaterialOrdenCompra = new System.Windows.Forms.Label();
            this.lblIdOrdenCompra = new System.Windows.Forms.Label();
            this.timeFechaEstimada = new System.Windows.Forms.DateTimePicker();
            this.inputCantidadComprados = new System.Windows.Forms.TextBox();
            this.lblCantidadOrdenCompra = new System.Windows.Forms.Label();
            this.lblFechaOrdenCompra = new System.Windows.Forms.Label();
            this.inputCantidadRecibidos = new System.Windows.Forms.TextBox();
            this.timeFechaRecepcion = new System.Windows.Forms.DateTimePicker();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkRecibido = new System.Windows.Forms.CheckBox();
            this.groupRecibido = new System.Windows.Forms.GroupBox();
            this.groupRecibido.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaterialOrdenCompra
            // 
            this.lblMaterialOrdenCompra.AutoSize = true;
            this.lblMaterialOrdenCompra.Location = new System.Drawing.Point(12, 35);
            this.lblMaterialOrdenCompra.Name = "lblMaterialOrdenCompra";
            this.lblMaterialOrdenCompra.Size = new System.Drawing.Size(119, 13);
            this.lblMaterialOrdenCompra.TabIndex = 16;
            this.lblMaterialOrdenCompra.Text = "lblMaterialOrdenCompra";
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
            // lblCantidadOrdenCompra
            // 
            this.lblCantidadOrdenCompra.AutoSize = true;
            this.lblCantidadOrdenCompra.Location = new System.Drawing.Point(12, 60);
            this.lblCantidadOrdenCompra.Name = "lblCantidadOrdenCompra";
            this.lblCantidadOrdenCompra.Size = new System.Drawing.Size(124, 13);
            this.lblCantidadOrdenCompra.TabIndex = 23;
            this.lblCantidadOrdenCompra.Text = "lblCantidadOrdenCompra";
            // 
            // lblFechaOrdenCompra
            // 
            this.lblFechaOrdenCompra.AutoSize = true;
            this.lblFechaOrdenCompra.Location = new System.Drawing.Point(12, 86);
            this.lblFechaOrdenCompra.Name = "lblFechaOrdenCompra";
            this.lblFechaOrdenCompra.Size = new System.Drawing.Size(112, 13);
            this.lblFechaOrdenCompra.TabIndex = 24;
            this.lblFechaOrdenCompra.Text = "lblFechaOrdenCompra";
            // 
            // inputCantidadRecibidos
            // 
            this.inputCantidadRecibidos.Location = new System.Drawing.Point(6, 42);
            this.inputCantidadRecibidos.Name = "inputCantidadRecibidos";
            this.inputCantidadRecibidos.Size = new System.Drawing.Size(100, 20);
            this.inputCantidadRecibidos.TabIndex = 26;
            // 
            // timeFechaRecepcion
            // 
            this.timeFechaRecepcion.Location = new System.Drawing.Point(6, 68);
            this.timeFechaRecepcion.Name = "timeFechaRecepcion";
            this.timeFechaRecepcion.Size = new System.Drawing.Size(200, 20);
            this.timeFechaRecepcion.TabIndex = 25;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(137, 329);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 27;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 329);
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
            this.groupRecibido.Controls.Add(this.chkRecibido);
            this.groupRecibido.Controls.Add(this.inputCantidadRecibidos);
            this.groupRecibido.Controls.Add(this.timeFechaRecepcion);
            this.groupRecibido.Location = new System.Drawing.Point(12, 176);
            this.groupRecibido.Name = "groupRecibido";
            this.groupRecibido.Size = new System.Drawing.Size(221, 100);
            this.groupRecibido.TabIndex = 30;
            this.groupRecibido.TabStop = false;
            this.groupRecibido.Text = "groupRecibido";
            // 
            // FormOrdenDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupRecibido);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblFechaOrdenCompra);
            this.Controls.Add(this.lblCantidadOrdenCompra);
            this.Controls.Add(this.inputCantidadComprados);
            this.Controls.Add(this.timeFechaEstimada);
            this.Controls.Add(this.lblMaterialOrdenCompra);
            this.Controls.Add(this.lblIdOrdenCompra);
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
        private System.Windows.Forms.Label lblMaterialOrdenCompra;
        private System.Windows.Forms.Label lblIdOrdenCompra;
        private System.Windows.Forms.DateTimePicker timeFechaEstimada;
        private System.Windows.Forms.TextBox inputCantidadComprados;
        private System.Windows.Forms.Label lblCantidadOrdenCompra;
        private System.Windows.Forms.Label lblFechaOrdenCompra;
        private System.Windows.Forms.TextBox inputCantidadRecibidos;
        private System.Windows.Forms.DateTimePicker timeFechaRecepcion;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.CheckBox chkRecibido;
        private System.Windows.Forms.GroupBox groupRecibido;
    }
}