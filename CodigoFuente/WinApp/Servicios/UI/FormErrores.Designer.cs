
namespace Servicios.UI
{
    partial class FormErrores
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormErrores));
            this.grillaErrores = new System.Windows.Forms.DataGridView();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.inputFiltroDescripcion = new System.Windows.Forms.TextBox();
            this.lblFiltroDescripcion = new System.Windows.Forms.Label();
            this.lblFiltroClase = new System.Windows.Forms.Label();
            this.inputFiltroClase = new System.Windows.Forms.TextBox();
            this.fechaYhora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaErrores
            // 
            this.grillaErrores.AllowUserToAddRows = false;
            this.grillaErrores.AllowUserToDeleteRows = false;
            this.grillaErrores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaErrores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grillaErrores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaErrores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaYhora,
            this.clase,
            this.descripcion});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grillaErrores.DefaultCellStyle = dataGridViewCellStyle1;
            this.grillaErrores.Location = new System.Drawing.Point(12, 32);
            this.grillaErrores.MultiSelect = false;
            this.grillaErrores.Name = "grillaErrores";
            this.grillaErrores.ReadOnly = true;
            this.grillaErrores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaErrores.Size = new System.Drawing.Size(761, 348);
            this.grillaErrores.TabIndex = 0;
            this.grillaErrores.SelectionChanged += new System.EventHandler(this.grillaErrores_SelectionChanged);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Location = new System.Drawing.Point(12, 386);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnDetalle.TabIndex = 1;
            this.btnDetalle.Text = "btnDetalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // inputFiltroDescripcion
            // 
            this.inputFiltroDescripcion.Location = new System.Drawing.Point(374, 6);
            this.inputFiltroDescripcion.Name = "inputFiltroDescripcion";
            this.inputFiltroDescripcion.Size = new System.Drawing.Size(100, 20);
            this.inputFiltroDescripcion.TabIndex = 10;
            this.inputFiltroDescripcion.TextChanged += new System.EventHandler(this.inputFiltroDescripcion_TextChanged);
            // 
            // lblFiltroDescripcion
            // 
            this.lblFiltroDescripcion.AutoSize = true;
            this.lblFiltroDescripcion.Location = new System.Drawing.Point(253, 9);
            this.lblFiltroDescripcion.Name = "lblFiltroDescripcion";
            this.lblFiltroDescripcion.Size = new System.Drawing.Size(95, 13);
            this.lblFiltroDescripcion.TabIndex = 9;
            this.lblFiltroDescripcion.Text = "lblFiltroDescripcion";
            // 
            // lblFiltroClase
            // 
            this.lblFiltroClase.AutoSize = true;
            this.lblFiltroClase.Location = new System.Drawing.Point(12, 9);
            this.lblFiltroClase.Name = "lblFiltroClase";
            this.lblFiltroClase.Size = new System.Drawing.Size(65, 13);
            this.lblFiltroClase.TabIndex = 8;
            this.lblFiltroClase.Text = "lblFiltroClase";
            // 
            // inputFiltroClase
            // 
            this.inputFiltroClase.Location = new System.Drawing.Point(120, 6);
            this.inputFiltroClase.Name = "inputFiltroClase";
            this.inputFiltroClase.Size = new System.Drawing.Size(100, 20);
            this.inputFiltroClase.TabIndex = 7;
            this.inputFiltroClase.TextChanged += new System.EventHandler(this.inputFiltroClase_TextChanged);
            // 
            // fechaYhora
            // 
            this.fechaYhora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fechaYhora.DataPropertyName = "timestamp";
            this.fechaYhora.HeaderText = "fechaYhora";
            this.fechaYhora.Name = "fechaYhora";
            this.fechaYhora.ReadOnly = true;
            this.fechaYhora.Width = 87;
            // 
            // clase
            // 
            this.clase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clase.DataPropertyName = "clase";
            this.clase.HeaderText = "clase";
            this.clase.Name = "clase";
            this.clase.ReadOnly = true;
            this.clase.Width = 57;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // FormErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 411);
            this.Controls.Add(this.inputFiltroDescripcion);
            this.Controls.Add(this.lblFiltroDescripcion);
            this.Controls.Add(this.lblFiltroClase);
            this.Controls.Add(this.inputFiltroClase);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.grillaErrores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormErrores";
            this.Text = "FormErrores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormErrores_FormClosing);
            this.Load += new System.EventHandler(this.FormErrores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaErrores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaErrores;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.TextBox inputFiltroDescripcion;
        private System.Windows.Forms.Label lblFiltroDescripcion;
        private System.Windows.Forms.Label lblFiltroClase;
        private System.Windows.Forms.TextBox inputFiltroClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaYhora;
        private System.Windows.Forms.DataGridViewTextBoxColumn clase;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}