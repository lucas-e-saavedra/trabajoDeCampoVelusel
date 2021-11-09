
namespace WinApp.Vendedor
{
    partial class FormPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPedidos));
            this.grillaPedidos = new System.Windows.Forms.DataGridView();
            this.Solicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.inputFiltroDetalle = new System.Windows.Forms.TextBox();
            this.lblFiltroDetalle = new System.Windows.Forms.Label();
            this.lblFiltroSolicitante = new System.Windows.Forms.Label();
            this.inputFiltroSolicitante = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaPedidos
            // 
            this.grillaPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Solicitante,
            this.Vendedor,
            this.Estado,
            this.Detalle});
            this.grillaPedidos.Location = new System.Drawing.Point(12, 32);
            this.grillaPedidos.Name = "grillaPedidos";
            this.grillaPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaPedidos.Size = new System.Drawing.Size(776, 353);
            this.grillaPedidos.TabIndex = 8;
            this.grillaPedidos.SelectionChanged += new System.EventHandler(this.grillaPedidos_SelectionChanged);
            // 
            // Solicitante
            // 
            this.Solicitante.DataPropertyName = "DescSolicitante";
            this.Solicitante.HeaderText = "Solicitante";
            this.Solicitante.Name = "Solicitante";
            this.Solicitante.ReadOnly = true;
            // 
            // Vendedor
            // 
            this.Vendedor.DataPropertyName = "DescVendedor";
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Detalle
            // 
            this.Detalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Detalle.DataPropertyName = "DescDetalle";
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Width = 65;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(12, 391);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(93, 391);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 10;
            this.btnCerrar.Text = "btnCerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // inputFiltroDetalle
            // 
            this.inputFiltroDetalle.Location = new System.Drawing.Point(378, 6);
            this.inputFiltroDetalle.Name = "inputFiltroDetalle";
            this.inputFiltroDetalle.Size = new System.Drawing.Size(100, 20);
            this.inputFiltroDetalle.TabIndex = 20;
            this.inputFiltroDetalle.TextChanged += new System.EventHandler(this.inputFiltroDetalle_TextChanged);
            // 
            // lblFiltroDetalle
            // 
            this.lblFiltroDetalle.AutoSize = true;
            this.lblFiltroDetalle.Location = new System.Drawing.Point(267, 9);
            this.lblFiltroDetalle.Name = "lblFiltroDetalle";
            this.lblFiltroDetalle.Size = new System.Drawing.Size(72, 13);
            this.lblFiltroDetalle.TabIndex = 19;
            this.lblFiltroDetalle.Text = "lblFiltroDetalle";
            // 
            // lblFiltroSolicitante
            // 
            this.lblFiltroSolicitante.AutoSize = true;
            this.lblFiltroSolicitante.Location = new System.Drawing.Point(12, 9);
            this.lblFiltroSolicitante.Name = "lblFiltroSolicitante";
            this.lblFiltroSolicitante.Size = new System.Drawing.Size(88, 13);
            this.lblFiltroSolicitante.TabIndex = 18;
            this.lblFiltroSolicitante.Text = "lblFiltroSolicitante";
            // 
            // inputFiltroSolicitante
            // 
            this.inputFiltroSolicitante.Location = new System.Drawing.Point(130, 6);
            this.inputFiltroSolicitante.Name = "inputFiltroSolicitante";
            this.inputFiltroSolicitante.Size = new System.Drawing.Size(100, 20);
            this.inputFiltroSolicitante.TabIndex = 17;
            this.inputFiltroSolicitante.TextChanged += new System.EventHandler(this.inputFiltroSolicitante_TextChanged);
            // 
            // FormPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.inputFiltroDetalle);
            this.Controls.Add(this.lblFiltroDetalle);
            this.Controls.Add(this.lblFiltroSolicitante);
            this.Controls.Add(this.inputFiltroSolicitante);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grillaPedidos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPedidos";
            this.Text = "FormPedidos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPedidos_FormClosing);
            this.Load += new System.EventHandler(this.FormPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaPedidos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Solicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.TextBox inputFiltroDetalle;
        private System.Windows.Forms.Label lblFiltroDetalle;
        private System.Windows.Forms.Label lblFiltroSolicitante;
        private System.Windows.Forms.TextBox inputFiltroSolicitante;
    }
}