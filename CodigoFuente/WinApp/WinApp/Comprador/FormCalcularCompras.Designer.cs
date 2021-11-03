
namespace WinApp.Comprador
{
    partial class FormCalcularCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalcularCompras));
            this.timeDesde = new System.Windows.Forms.DateTimePicker();
            this.timeHasta = new System.Windows.Forms.DateTimePicker();
            this.grillaMateriales = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grillaCompras = new System.Windows.Forms.DataGridView();
            this.FechaObjetivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Objetivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMaterialOrdenCompra = new System.Windows.Forms.Label();
            this.lblFechaPlanificada = new System.Windows.Forms.Label();
            this.timeOrdenCompra = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnGrabarOrdenes = new System.Windows.Forms.Button();
            this.lblExplicacion = new System.Windows.Forms.Label();
            this.grupoOrdenCompra = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMateriales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCompras)).BeginInit();
            this.grupoOrdenCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // timeDesde
            // 
            this.timeDesde.Location = new System.Drawing.Point(12, 43);
            this.timeDesde.Name = "timeDesde";
            this.timeDesde.Size = new System.Drawing.Size(200, 20);
            this.timeDesde.TabIndex = 1;
            this.timeDesde.ValueChanged += new System.EventHandler(this.timeDesde_ValueChanged);
            // 
            // timeHasta
            // 
            this.timeHasta.Location = new System.Drawing.Point(218, 43);
            this.timeHasta.Name = "timeHasta";
            this.timeHasta.Size = new System.Drawing.Size(200, 20);
            this.timeHasta.TabIndex = 2;
            this.timeHasta.ValueChanged += new System.EventHandler(this.timeHasta_ValueChanged);
            // 
            // grillaMateriales
            // 
            this.grillaMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaMateriales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Unidad,
            this.Nombre});
            this.grillaMateriales.Location = new System.Drawing.Point(12, 69);
            this.grillaMateriales.Name = "grillaMateriales";
            this.grillaMateriales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaMateriales.Size = new System.Drawing.Size(776, 148);
            this.grillaMateriales.TabIndex = 9;
            this.grillaMateriales.SelectionChanged += new System.EventHandler(this.grillaMateriales_SelectionChanged);
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 74;
            // 
            // Unidad
            // 
            this.Unidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Width = 66;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // grillaCompras
            // 
            this.grillaCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaObjetivo,
            this.Objetivo,
            this.Estado});
            this.grillaCompras.Location = new System.Drawing.Point(12, 241);
            this.grillaCompras.Name = "grillaCompras";
            this.grillaCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaCompras.Size = new System.Drawing.Size(383, 148);
            this.grillaCompras.TabIndex = 10;
            this.grillaCompras.SelectionChanged += new System.EventHandler(this.grillaCompras_SelectionChanged);
            // 
            // FechaObjetivo
            // 
            this.FechaObjetivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaObjetivo.DataPropertyName = "FechaObjetivo";
            this.FechaObjetivo.HeaderText = "FechaObjetivo";
            this.FechaObjetivo.Name = "FechaObjetivo";
            this.FechaObjetivo.ReadOnly = true;
            this.FechaObjetivo.Width = 101;
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
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 65;
            // 
            // lblMaterialOrdenCompra
            // 
            this.lblMaterialOrdenCompra.AutoSize = true;
            this.lblMaterialOrdenCompra.Location = new System.Drawing.Point(19, 26);
            this.lblMaterialOrdenCompra.Name = "lblMaterialOrdenCompra";
            this.lblMaterialOrdenCompra.Size = new System.Drawing.Size(119, 13);
            this.lblMaterialOrdenCompra.TabIndex = 12;
            this.lblMaterialOrdenCompra.Text = "lblMaterialOrdenCompra";
            // 
            // lblFechaPlanificada
            // 
            this.lblFechaPlanificada.AutoSize = true;
            this.lblFechaPlanificada.Location = new System.Drawing.Point(19, 63);
            this.lblFechaPlanificada.Name = "lblFechaPlanificada";
            this.lblFechaPlanificada.Size = new System.Drawing.Size(99, 13);
            this.lblFechaPlanificada.TabIndex = 13;
            this.lblFechaPlanificada.Text = "lblFechaPlanificada";
            // 
            // timeOrdenCompra
            // 
            this.timeOrdenCompra.Location = new System.Drawing.Point(22, 79);
            this.timeOrdenCompra.Name = "timeOrdenCompra";
            this.timeOrdenCompra.Size = new System.Drawing.Size(200, 20);
            this.timeOrdenCompra.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(419, 262);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "<<";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(419, 315);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(39, 23);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "X";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnGrabarOrdenes
            // 
            this.btnGrabarOrdenes.Location = new System.Drawing.Point(249, 395);
            this.btnGrabarOrdenes.Name = "btnGrabarOrdenes";
            this.btnGrabarOrdenes.Size = new System.Drawing.Size(146, 23);
            this.btnGrabarOrdenes.TabIndex = 17;
            this.btnGrabarOrdenes.Text = "btnGrabarOrdenes";
            this.btnGrabarOrdenes.UseVisualStyleBackColor = true;
            this.btnGrabarOrdenes.Click += new System.EventHandler(this.btnGrabarOrdenes_Click);
            // 
            // lblExplicacion
            // 
            this.lblExplicacion.AutoSize = true;
            this.lblExplicacion.Location = new System.Drawing.Point(13, 13);
            this.lblExplicacion.Name = "lblExplicacion";
            this.lblExplicacion.Size = new System.Drawing.Size(71, 13);
            this.lblExplicacion.TabIndex = 18;
            this.lblExplicacion.Text = "lblExplicacion";
            // 
            // grupoOrdenCompra
            // 
            this.grupoOrdenCompra.Controls.Add(this.lblMaterialOrdenCompra);
            this.grupoOrdenCompra.Controls.Add(this.lblFechaPlanificada);
            this.grupoOrdenCompra.Controls.Add(this.timeOrdenCompra);
            this.grupoOrdenCompra.Location = new System.Drawing.Point(492, 241);
            this.grupoOrdenCompra.Name = "grupoOrdenCompra";
            this.grupoOrdenCompra.Size = new System.Drawing.Size(296, 148);
            this.grupoOrdenCompra.TabIndex = 19;
            this.grupoOrdenCompra.TabStop = false;
            this.grupoOrdenCompra.Text = "groupBox1";
            // 
            // FormCalcularCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grupoOrdenCompra);
            this.Controls.Add(this.lblExplicacion);
            this.Controls.Add(this.btnGrabarOrdenes);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grillaCompras);
            this.Controls.Add(this.grillaMateriales);
            this.Controls.Add(this.timeHasta);
            this.Controls.Add(this.timeDesde);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalcularCompras";
            this.Text = "FormCalcularCompras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalcularCompras_FormClosing);
            this.Load += new System.EventHandler(this.FormCalcularCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaMateriales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCompras)).EndInit();
            this.grupoOrdenCompra.ResumeLayout(false);
            this.grupoOrdenCompra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker timeDesde;
        private System.Windows.Forms.DateTimePicker timeHasta;
        private System.Windows.Forms.DataGridView grillaMateriales;
        private System.Windows.Forms.DataGridView grillaCompras;
        private System.Windows.Forms.Label lblMaterialOrdenCompra;
        private System.Windows.Forms.Label lblFechaPlanificada;
        private System.Windows.Forms.DateTimePicker timeOrdenCompra;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnGrabarOrdenes;
        private System.Windows.Forms.Label lblExplicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaObjetivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Objetivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.GroupBox grupoOrdenCompra;
    }
}