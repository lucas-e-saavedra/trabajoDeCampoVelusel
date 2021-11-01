
namespace WinApp.Fabricante
{
    partial class FormOrdenesDeFabricacion
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
            this.grillaOrdenesFabricacion = new System.Windows.Forms.DataGridView();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPlanificada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Objetivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaEjecucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fabricados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aprobados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaOrdenesFabricacion)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaOrdenesFabricacion
            // 
            this.grillaOrdenesFabricacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaOrdenesFabricacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Estado,
            this.FechaPlanificada,
            this.Objetivo,
            this.FechaEjecucion,
            this.Fabricados,
            this.Aprobados});
            this.grillaOrdenesFabricacion.Location = new System.Drawing.Point(12, 12);
            this.grillaOrdenesFabricacion.Name = "grillaOrdenesFabricacion";
            this.grillaOrdenesFabricacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaOrdenesFabricacion.Size = new System.Drawing.Size(776, 367);
            this.grillaOrdenesFabricacion.TabIndex = 11;
            this.grillaOrdenesFabricacion.SelectionChanged += new System.EventHandler(this.grillaOrdenesFabricacion_SelectionChanged);
            // 
            // btnComenzar
            // 
            this.btnComenzar.Location = new System.Drawing.Point(12, 385);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(117, 23);
            this.btnComenzar.TabIndex = 12;
            this.btnComenzar.Text = "btnComenzar";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(135, 385);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(117, 23);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "btnCerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(258, 385);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(102, 23);
            this.btnTerminar.TabIndex = 14;
            this.btnTerminar.Text = "btnTerminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
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
            // FechaPlanificada
            // 
            this.FechaPlanificada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaPlanificada.DataPropertyName = "FechaPlanificada";
            this.FechaPlanificada.HeaderText = "Fecha planificada";
            this.FechaPlanificada.Name = "FechaPlanificada";
            this.FechaPlanificada.ReadOnly = true;
            this.FechaPlanificada.Width = 106;
            // 
            // Objetivo
            // 
            this.Objetivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Objetivo.DataPropertyName = "DescObjetivo";
            this.Objetivo.HeaderText = "Objetivo";
            this.Objetivo.Name = "Objetivo";
            this.Objetivo.ReadOnly = true;
            this.Objetivo.Width = 71;
            // 
            // FechaEjecucion
            // 
            this.FechaEjecucion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FechaEjecucion.DataPropertyName = "FechaEjecucion";
            this.FechaEjecucion.HeaderText = "Fecha ejecución";
            this.FechaEjecucion.Name = "FechaEjecucion";
            this.FechaEjecucion.ReadOnly = true;
            this.FechaEjecucion.Width = 102;
            // 
            // Fabricados
            // 
            this.Fabricados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fabricados.DataPropertyName = "DescFabricados";
            this.Fabricados.HeaderText = "Fabricados";
            this.Fabricados.Name = "Fabricados";
            this.Fabricados.ReadOnly = true;
            this.Fabricados.Width = 84;
            // 
            // Aprobados
            // 
            this.Aprobados.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Aprobados.DataPropertyName = "DescAprobados";
            this.Aprobados.HeaderText = "Aprobados";
            this.Aprobados.Name = "Aprobados";
            this.Aprobados.ReadOnly = true;
            this.Aprobados.Width = 83;
            // 
            // FormOrdenesDeFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnComenzar);
            this.Controls.Add(this.grillaOrdenesFabricacion);
            this.Name = "FormOrdenesDeFabricacion";
            this.Text = "FormOrdenesDeFabricacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOrdenesDeFabricacion_FormClosing);
            this.Load += new System.EventHandler(this.FormOrdenesDeFabricacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaOrdenesFabricacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaOrdenesFabricacion;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPlanificada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Objetivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaEjecucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fabricados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aprobados;
    }
}