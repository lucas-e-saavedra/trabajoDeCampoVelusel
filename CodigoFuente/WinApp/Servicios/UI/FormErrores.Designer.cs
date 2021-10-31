
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
            this.fechaYhora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDetalle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grillaErrores)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaErrores
            // 
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
            this.grillaErrores.Location = new System.Drawing.Point(12, 12);
            this.grillaErrores.Name = "grillaErrores";
            this.grillaErrores.Size = new System.Drawing.Size(761, 368);
            this.grillaErrores.TabIndex = 0;
            this.grillaErrores.SelectionChanged += new System.EventHandler(this.grillaErrores_SelectionChanged);
            // 
            // fechaYhora
            // 
            this.fechaYhora.DataPropertyName = "timestamp";
            this.fechaYhora.HeaderText = "fechaYhora";
            this.fechaYhora.Name = "fechaYhora";
            this.fechaYhora.ReadOnly = true;
            // 
            // clase
            // 
            this.clase.DataPropertyName = "clase";
            this.clase.HeaderText = "clase";
            this.clase.Name = "clase";
            this.clase.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
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
            // FormErrores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 411);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.grillaErrores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormErrores";
            this.Text = "FormErrores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormErrores_FormClosing);
            this.Load += new System.EventHandler(this.FormErrores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaErrores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaErrores;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaYhora;
        private System.Windows.Forms.DataGridViewTextBoxColumn clase;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.Button btnDetalle;
    }
}