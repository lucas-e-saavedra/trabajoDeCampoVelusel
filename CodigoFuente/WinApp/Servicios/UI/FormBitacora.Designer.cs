
namespace Servicios.UI
{
    partial class FormBitacora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBitacora));
            this.grillaBitacora = new System.Windows.Forms.DataGridView();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaBitacora
            // 
            this.grillaBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillaBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaBitacora.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timestamp,
            this.categoria,
            this.mensaje});
            this.grillaBitacora.Location = new System.Drawing.Point(13, 13);
            this.grillaBitacora.Name = "grillaBitacora";
            this.grillaBitacora.Size = new System.Drawing.Size(759, 367);
            this.grillaBitacora.TabIndex = 0;
            this.grillaBitacora.SelectionChanged += new System.EventHandler(this.grillaBitacora_SelectionChanged);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Location = new System.Drawing.Point(13, 386);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(75, 23);
            this.btnDetalle.TabIndex = 2;
            this.btnDetalle.Text = "btnDetalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Visible = false;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // timestamp
            // 
            this.timestamp.DataPropertyName = "timestamp";
            this.timestamp.HeaderText = "timestamp";
            this.timestamp.Name = "timestamp";
            this.timestamp.ReadOnly = true;
            // 
            // categoria
            // 
            this.categoria.DataPropertyName = "categoria";
            this.categoria.HeaderText = "categoria";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            // 
            // mensaje
            // 
            this.mensaje.DataPropertyName = "mensaje";
            this.mensaje.HeaderText = "mensaje";
            this.mensaje.Name = "mensaje";
            this.mensaje.ReadOnly = true;
            // 
            // FormBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.grillaBitacora);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBitacora";
            this.Text = "FormBitacora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBitacora_FormClosing);
            this.Load += new System.EventHandler(this.FormBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaBitacora;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensaje;
    }
}