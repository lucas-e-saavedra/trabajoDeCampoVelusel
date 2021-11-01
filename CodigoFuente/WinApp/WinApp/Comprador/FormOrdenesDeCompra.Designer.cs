
namespace WinApp.Comprador
{
    partial class FormOrdenesDeCompra
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
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnRevertir = new System.Windows.Forms.Button();
            this.grillaOrdenesDeCompra = new System.Windows.Forms.DataGridView();
            this.DescSolicitante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescObjetivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaObjetivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescComprados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEstimadaRecepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescRecibidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaRealRecepcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaOrdenesDeCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(713, 386);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnRevertir
            // 
            this.btnRevertir.Location = new System.Drawing.Point(632, 386);
            this.btnRevertir.Name = "btnRevertir";
            this.btnRevertir.Size = new System.Drawing.Size(75, 23);
            this.btnRevertir.TabIndex = 8;
            this.btnRevertir.Text = "btnRevertir";
            this.btnRevertir.UseVisualStyleBackColor = true;
            this.btnRevertir.Click += new System.EventHandler(this.btnRevertir_Click);
            // 
            // grillaOrdenesDeCompra
            // 
            this.grillaOrdenesDeCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaOrdenesDeCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DescSolicitante,
            this.Estado,
            this.DescObjetivo,
            this.FechaObjetivo,
            this.DescComprados,
            this.FechaEstimadaRecepcion,
            this.DescRecibidos,
            this.FechaRealRecepcion});
            this.grillaOrdenesDeCompra.Location = new System.Drawing.Point(12, 12);
            this.grillaOrdenesDeCompra.Name = "grillaOrdenesDeCompra";
            this.grillaOrdenesDeCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaOrdenesDeCompra.Size = new System.Drawing.Size(776, 368);
            this.grillaOrdenesDeCompra.TabIndex = 7;
            this.grillaOrdenesDeCompra.SelectionChanged += new System.EventHandler(this.grillaOrdenesDeCompra_SelectionChanged);
            // 
            // DescSolicitante
            // 
            this.DescSolicitante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DescSolicitante.DataPropertyName = "DescSolicitante";
            this.DescSolicitante.HeaderText = "Solicitante";
            this.DescSolicitante.Name = "DescSolicitante";
            this.DescSolicitante.ReadOnly = true;
            this.DescSolicitante.Width = 81;
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
            // DescObjetivo
            // 
            this.DescObjetivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DescObjetivo.DataPropertyName = "DescObjetivo";
            this.DescObjetivo.HeaderText = "Objetivo";
            this.DescObjetivo.Name = "DescObjetivo";
            this.DescObjetivo.ReadOnly = true;
            this.DescObjetivo.Width = 71;
            // 
            // FechaObjetivo
            // 
            this.FechaObjetivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaObjetivo.DataPropertyName = "FechaObjetivo";
            this.FechaObjetivo.HeaderText = "Fecha planeada";
            this.FechaObjetivo.Name = "FechaObjetivo";
            this.FechaObjetivo.ReadOnly = true;
            // 
            // DescComprados
            // 
            this.DescComprados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DescComprados.DataPropertyName = "DescComprados";
            this.DescComprados.HeaderText = "Comprados";
            this.DescComprados.Name = "DescComprados";
            this.DescComprados.ReadOnly = true;
            this.DescComprados.Width = 85;
            // 
            // FechaEstimadaRecepcion
            // 
            this.FechaEstimadaRecepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaEstimadaRecepcion.DataPropertyName = "FechaEstimadaRecepcion";
            this.FechaEstimadaRecepcion.HeaderText = "Recepcion estimada";
            this.FechaEstimadaRecepcion.Name = "FechaEstimadaRecepcion";
            this.FechaEstimadaRecepcion.ReadOnly = true;
            this.FechaEstimadaRecepcion.Width = 118;
            // 
            // DescRecibidos
            // 
            this.DescRecibidos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DescRecibidos.DataPropertyName = "DescRecibidos";
            this.DescRecibidos.HeaderText = "Recibidos";
            this.DescRecibidos.Name = "DescRecibidos";
            this.DescRecibidos.ReadOnly = true;
            this.DescRecibidos.Width = 79;
            // 
            // FechaRealRecepcion
            // 
            this.FechaRealRecepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaRealRecepcion.DataPropertyName = "FechaRealRecepcion";
            this.FechaRealRecepcion.HeaderText = "Recepcion real";
            this.FechaRealRecepcion.Name = "FechaRealRecepcion";
            this.FechaRealRecepcion.ReadOnly = true;
            this.FechaRealRecepcion.Width = 96;
            // 
            // FormOrdenesDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 421);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnRevertir);
            this.Controls.Add(this.grillaOrdenesDeCompra);
            this.Name = "FormOrdenesDeCompra";
            this.Text = "FormOrdenesDeCompra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrdenesDeCompra_FormClosing);
            this.Load += new System.EventHandler(this.FormOrdenesDeCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaOrdenesDeCompra)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnRevertir;
        private System.Windows.Forms.DataGridView grillaOrdenesDeCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescSolicitante;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescObjetivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaObjetivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescComprados;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEstimadaRecepcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescRecibidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRealRecepcion;
    }
}