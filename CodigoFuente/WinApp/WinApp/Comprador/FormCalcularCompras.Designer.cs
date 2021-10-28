
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
            this.timeDesde = new System.Windows.Forms.DateTimePicker();
            this.timeHasta = new System.Windows.Forms.DateTimePicker();
            this.grillaMateriales = new System.Windows.Forms.DataGridView();
            this.grillaCompras = new System.Windows.Forms.DataGridView();
            this.lblIdOrdenCompra = new System.Windows.Forms.Label();
            this.lblMaterialOrdenCompra = new System.Windows.Forms.Label();
            this.lblCantidadOrdenCompra = new System.Windows.Forms.Label();
            this.timeOrdenCompra = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnGrabarOrdenes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaMateriales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // timeDesde
            // 
            this.timeDesde.Location = new System.Drawing.Point(12, 12);
            this.timeDesde.Name = "timeDesde";
            this.timeDesde.Size = new System.Drawing.Size(200, 20);
            this.timeDesde.TabIndex = 1;
            this.timeDesde.ValueChanged += new System.EventHandler(this.timeDesde_ValueChanged);
            // 
            // timeHasta
            // 
            this.timeHasta.Location = new System.Drawing.Point(218, 12);
            this.timeHasta.Name = "timeHasta";
            this.timeHasta.Size = new System.Drawing.Size(200, 20);
            this.timeHasta.TabIndex = 2;
            this.timeHasta.ValueChanged += new System.EventHandler(this.timeHasta_ValueChanged);
            // 
            // grillaMateriales
            // 
            this.grillaMateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaMateriales.Location = new System.Drawing.Point(12, 38);
            this.grillaMateriales.Name = "grillaMateriales";
            this.grillaMateriales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaMateriales.Size = new System.Drawing.Size(776, 148);
            this.grillaMateriales.TabIndex = 9;
            this.grillaMateriales.SelectionChanged += new System.EventHandler(this.grillaMateriales_SelectionChanged);
            // 
            // grillaCompras
            // 
            this.grillaCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaCompras.Location = new System.Drawing.Point(12, 210);
            this.grillaCompras.Name = "grillaCompras";
            this.grillaCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaCompras.Size = new System.Drawing.Size(383, 148);
            this.grillaCompras.TabIndex = 10;
            this.grillaCompras.SelectionChanged += new System.EventHandler(this.grillaCompras_SelectionChanged);
            // 
            // lblIdOrdenCompra
            // 
            this.lblIdOrdenCompra.AutoSize = true;
            this.lblIdOrdenCompra.Location = new System.Drawing.Point(482, 210);
            this.lblIdOrdenCompra.Name = "lblIdOrdenCompra";
            this.lblIdOrdenCompra.Size = new System.Drawing.Size(91, 13);
            this.lblIdOrdenCompra.TabIndex = 11;
            this.lblIdOrdenCompra.Text = "lblIdOrdenCompra";
            // 
            // lblMaterialOrdenCompra
            // 
            this.lblMaterialOrdenCompra.AutoSize = true;
            this.lblMaterialOrdenCompra.Location = new System.Drawing.Point(482, 236);
            this.lblMaterialOrdenCompra.Name = "lblMaterialOrdenCompra";
            this.lblMaterialOrdenCompra.Size = new System.Drawing.Size(119, 13);
            this.lblMaterialOrdenCompra.TabIndex = 12;
            this.lblMaterialOrdenCompra.Text = "lblMaterialOrdenCompra";
            // 
            // lblCantidadOrdenCompra
            // 
            this.lblCantidadOrdenCompra.AutoSize = true;
            this.lblCantidadOrdenCompra.Location = new System.Drawing.Point(485, 262);
            this.lblCantidadOrdenCompra.Name = "lblCantidadOrdenCompra";
            this.lblCantidadOrdenCompra.Size = new System.Drawing.Size(124, 13);
            this.lblCantidadOrdenCompra.TabIndex = 13;
            this.lblCantidadOrdenCompra.Text = "lblCantidadOrdenCompra";
            // 
            // timeOrdenCompra
            // 
            this.timeOrdenCompra.Location = new System.Drawing.Point(485, 287);
            this.timeOrdenCompra.Name = "timeOrdenCompra";
            this.timeOrdenCompra.Size = new System.Drawing.Size(200, 20);
            this.timeOrdenCompra.TabIndex = 14;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(419, 231);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "<<";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(419, 284);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(39, 23);
            this.btnRemove.TabIndex = 16;
            this.btnRemove.Text = "X";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnGrabarOrdenes
            // 
            this.btnGrabarOrdenes.Location = new System.Drawing.Point(143, 364);
            this.btnGrabarOrdenes.Name = "btnGrabarOrdenes";
            this.btnGrabarOrdenes.Size = new System.Drawing.Size(103, 23);
            this.btnGrabarOrdenes.TabIndex = 17;
            this.btnGrabarOrdenes.Text = "btnGrabarOrdenes";
            this.btnGrabarOrdenes.UseVisualStyleBackColor = true;
            this.btnGrabarOrdenes.Click += new System.EventHandler(this.btnGrabarOrdenes_Click);
            // 
            // FormCalcularCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGrabarOrdenes);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.timeOrdenCompra);
            this.Controls.Add(this.lblCantidadOrdenCompra);
            this.Controls.Add(this.lblMaterialOrdenCompra);
            this.Controls.Add(this.lblIdOrdenCompra);
            this.Controls.Add(this.grillaCompras);
            this.Controls.Add(this.grillaMateriales);
            this.Controls.Add(this.timeHasta);
            this.Controls.Add(this.timeDesde);
            this.Name = "FormCalcularCompras";
            this.Text = "FormCalcularCompras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalcularCompras_FormClosing);
            this.Load += new System.EventHandler(this.FormCalcularCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaMateriales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaCompras)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker timeDesde;
        private System.Windows.Forms.DateTimePicker timeHasta;
        private System.Windows.Forms.DataGridView grillaMateriales;
        private System.Windows.Forms.DataGridView grillaCompras;
        private System.Windows.Forms.Label lblIdOrdenCompra;
        private System.Windows.Forms.Label lblMaterialOrdenCompra;
        private System.Windows.Forms.Label lblCantidadOrdenCompra;
        private System.Windows.Forms.DateTimePicker timeOrdenCompra;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnGrabarOrdenes;
    }
}