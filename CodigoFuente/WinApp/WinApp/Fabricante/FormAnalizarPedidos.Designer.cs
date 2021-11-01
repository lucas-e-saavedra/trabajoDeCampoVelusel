
namespace WinApp.Fabricante
{
    partial class FormAnalizarPedidos
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
            this.btnSaveAllOrders = new System.Windows.Forms.Button();
            this.grillaPedidos = new System.Windows.Forms.DataGridView();
            this.Solicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grillaOrdenesFabricacion = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_OF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Objetivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxOrdenFabricacion = new System.Windows.Forms.GroupBox();
            this.lblOFposterior = new System.Windows.Forms.Label();
            this.lblObjetivoOrdenFabricacion = new System.Windows.Forms.Label();
            this.timeOrdenFabricacion = new System.Windows.Forms.DateTimePicker();
            this.lblIdOrdenFabricacion = new System.Windows.Forms.Label();
            this.lblReposoNecesario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaOrdenesFabricacion)).BeginInit();
            this.boxOrdenFabricacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveAllOrders
            // 
            this.btnSaveAllOrders.Location = new System.Drawing.Point(319, 296);
            this.btnSaveAllOrders.Name = "btnSaveAllOrders";
            this.btnSaveAllOrders.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAllOrders.TabIndex = 0;
            this.btnSaveAllOrders.Text = "btnSaveAllOrders";
            this.btnSaveAllOrders.UseVisualStyleBackColor = true;
            this.btnSaveAllOrders.Click += new System.EventHandler(this.btnSaveAllOrders_Click);
            // 
            // grillaPedidos
            // 
            this.grillaPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPedidos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Solicitante,
            this.Vendedor,
            this.Estado,
            this.Detalle});
            this.grillaPedidos.Location = new System.Drawing.Point(12, 12);
            this.grillaPedidos.Name = "grillaPedidos";
            this.grillaPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaPedidos.Size = new System.Drawing.Size(776, 130);
            this.grillaPedidos.TabIndex = 9;
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
            // grillaOrdenesFabricacion
            // 
            this.grillaOrdenesFabricacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaOrdenesFabricacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Estado_OF,
            this.Objetivo});
            this.grillaOrdenesFabricacion.Location = new System.Drawing.Point(12, 160);
            this.grillaOrdenesFabricacion.Name = "grillaOrdenesFabricacion";
            this.grillaOrdenesFabricacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaOrdenesFabricacion.Size = new System.Drawing.Size(382, 130);
            this.grillaOrdenesFabricacion.TabIndex = 10;
            this.grillaOrdenesFabricacion.SelectionChanged += new System.EventHandler(this.grillaOrdenesFabricacion_SelectionChanged);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fecha.DataPropertyName = "FechaPlanificada";
            this.Fecha.HeaderText = "Fecha planificada";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 106;
            // 
            // Estado_OF
            // 
            this.Estado_OF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Estado_OF.DataPropertyName = "Estado";
            this.Estado_OF.HeaderText = "Estado";
            this.Estado_OF.Name = "Estado_OF";
            this.Estado_OF.ReadOnly = true;
            this.Estado_OF.Width = 65;
            // 
            // Objetivo
            // 
            this.Objetivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Objetivo.DataPropertyName = "Objetivo";
            this.Objetivo.HeaderText = "Objetivo";
            this.Objetivo.Name = "Objetivo";
            this.Objetivo.ReadOnly = true;
            this.Objetivo.Width = 71;
            // 
            // boxOrdenFabricacion
            // 
            this.boxOrdenFabricacion.Controls.Add(this.lblReposoNecesario);
            this.boxOrdenFabricacion.Controls.Add(this.lblOFposterior);
            this.boxOrdenFabricacion.Controls.Add(this.lblObjetivoOrdenFabricacion);
            this.boxOrdenFabricacion.Controls.Add(this.timeOrdenFabricacion);
            this.boxOrdenFabricacion.Controls.Add(this.lblIdOrdenFabricacion);
            this.boxOrdenFabricacion.Location = new System.Drawing.Point(401, 160);
            this.boxOrdenFabricacion.Name = "boxOrdenFabricacion";
            this.boxOrdenFabricacion.Size = new System.Drawing.Size(387, 130);
            this.boxOrdenFabricacion.TabIndex = 11;
            this.boxOrdenFabricacion.TabStop = false;
            this.boxOrdenFabricacion.Text = "boxOrdenFabricacion";
            // 
            // lblOFposterior
            // 
            this.lblOFposterior.AutoSize = true;
            this.lblOFposterior.Location = new System.Drawing.Point(7, 59);
            this.lblOFposterior.Name = "lblOFposterior";
            this.lblOFposterior.Size = new System.Drawing.Size(71, 13);
            this.lblOFposterior.TabIndex = 3;
            this.lblOFposterior.Text = "lblOFposterior";
            // 
            // lblObjetivoOrdenFabricacion
            // 
            this.lblObjetivoOrdenFabricacion.AutoSize = true;
            this.lblObjetivoOrdenFabricacion.Location = new System.Drawing.Point(7, 81);
            this.lblObjetivoOrdenFabricacion.Name = "lblObjetivoOrdenFabricacion";
            this.lblObjetivoOrdenFabricacion.Size = new System.Drawing.Size(140, 13);
            this.lblObjetivoOrdenFabricacion.TabIndex = 2;
            this.lblObjetivoOrdenFabricacion.Text = "lblObjetivoOrdenFabricacion";
            // 
            // timeOrdenFabricacion
            // 
            this.timeOrdenFabricacion.Location = new System.Drawing.Point(6, 36);
            this.timeOrdenFabricacion.Name = "timeOrdenFabricacion";
            this.timeOrdenFabricacion.Size = new System.Drawing.Size(200, 20);
            this.timeOrdenFabricacion.TabIndex = 1;
            this.timeOrdenFabricacion.ValueChanged += new System.EventHandler(this.timeOrdenFabricacion_ValueChanged);
            // 
            // lblIdOrdenFabricacion
            // 
            this.lblIdOrdenFabricacion.AutoSize = true;
            this.lblIdOrdenFabricacion.Location = new System.Drawing.Point(7, 20);
            this.lblIdOrdenFabricacion.Name = "lblIdOrdenFabricacion";
            this.lblIdOrdenFabricacion.Size = new System.Drawing.Size(110, 13);
            this.lblIdOrdenFabricacion.TabIndex = 0;
            this.lblIdOrdenFabricacion.Text = "lblIdOrdenFabricacion";
            // 
            // lblReposoNecesario
            // 
            this.lblReposoNecesario.AutoSize = true;
            this.lblReposoNecesario.Location = new System.Drawing.Point(7, 104);
            this.lblReposoNecesario.Name = "lblReposoNecesario";
            this.lblReposoNecesario.Size = new System.Drawing.Size(102, 13);
            this.lblReposoNecesario.TabIndex = 4;
            this.lblReposoNecesario.Text = "lblReposoNecesario";
            // 
            // FormAnalizarPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.boxOrdenFabricacion);
            this.Controls.Add(this.grillaOrdenesFabricacion);
            this.Controls.Add(this.grillaPedidos);
            this.Controls.Add(this.btnSaveAllOrders);
            this.Name = "FormAnalizarPedidos";
            this.Text = "FormAnalizarPedidos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAnalizarPedidos_FormClosing);
            this.Load += new System.EventHandler(this.FormAnalizarPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaOrdenesFabricacion)).EndInit();
            this.boxOrdenFabricacion.ResumeLayout(false);
            this.boxOrdenFabricacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveAllOrders;
        private System.Windows.Forms.DataGridView grillaPedidos;
        private System.Windows.Forms.DataGridView grillaOrdenesFabricacion;
        private System.Windows.Forms.GroupBox boxOrdenFabricacion;
        private System.Windows.Forms.DateTimePicker timeOrdenFabricacion;
        private System.Windows.Forms.Label lblIdOrdenFabricacion;
        private System.Windows.Forms.Label lblObjetivoOrdenFabricacion;
        private System.Windows.Forms.Label lblOFposterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn Solicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_OF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Objetivo;
        private System.Windows.Forms.Label lblReposoNecesario;
    }
}