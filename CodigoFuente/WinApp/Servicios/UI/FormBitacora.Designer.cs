
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
            this.timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputFiltroCategoria = new System.Windows.Forms.TextBox();
            this.lblFiltroCategoria = new System.Windows.Forms.Label();
            this.lblFiltroMensaje = new System.Windows.Forms.Label();
            this.inputFiltroMensaje = new System.Windows.Forms.TextBox();
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
            this.grillaBitacora.Location = new System.Drawing.Point(12, 32);
            this.grillaBitacora.MultiSelect = false;
            this.grillaBitacora.Name = "grillaBitacora";
            this.grillaBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaBitacora.Size = new System.Drawing.Size(776, 376);
            this.grillaBitacora.TabIndex = 0;
            // 
            // timestamp
            // 
            this.timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timestamp.DataPropertyName = "timestamp";
            this.timestamp.HeaderText = "timestamp";
            this.timestamp.Name = "timestamp";
            this.timestamp.ReadOnly = true;
            this.timestamp.Width = 79;
            // 
            // categoria
            // 
            this.categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.categoria.DataPropertyName = "categoria";
            this.categoria.HeaderText = "categoria";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            this.categoria.Width = 76;
            // 
            // mensaje
            // 
            this.mensaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.mensaje.DataPropertyName = "mensaje";
            this.mensaje.HeaderText = "mensaje";
            this.mensaje.Name = "mensaje";
            this.mensaje.ReadOnly = true;
            this.mensaje.Width = 71;
            // 
            // inputFiltroCategoria
            // 
            this.inputFiltroCategoria.Location = new System.Drawing.Point(120, 6);
            this.inputFiltroCategoria.Name = "inputFiltroCategoria";
            this.inputFiltroCategoria.Size = new System.Drawing.Size(100, 20);
            this.inputFiltroCategoria.TabIndex = 3;
            this.inputFiltroCategoria.TextChanged += new System.EventHandler(this.inputFiltroCategoria_TextChanged);
            // 
            // lblFiltroCategoria
            // 
            this.lblFiltroCategoria.AutoSize = true;
            this.lblFiltroCategoria.Location = new System.Drawing.Point(12, 9);
            this.lblFiltroCategoria.Name = "lblFiltroCategoria";
            this.lblFiltroCategoria.Size = new System.Drawing.Size(84, 13);
            this.lblFiltroCategoria.TabIndex = 4;
            this.lblFiltroCategoria.Text = "lblFiltroCategoria";
            // 
            // lblFiltroMensaje
            // 
            this.lblFiltroMensaje.AutoSize = true;
            this.lblFiltroMensaje.Location = new System.Drawing.Point(253, 9);
            this.lblFiltroMensaje.Name = "lblFiltroMensaje";
            this.lblFiltroMensaje.Size = new System.Drawing.Size(79, 13);
            this.lblFiltroMensaje.TabIndex = 5;
            this.lblFiltroMensaje.Text = "lblFiltroMensaje";
            // 
            // inputFiltroMensaje
            // 
            this.inputFiltroMensaje.Location = new System.Drawing.Point(356, 6);
            this.inputFiltroMensaje.Name = "inputFiltroMensaje";
            this.inputFiltroMensaje.Size = new System.Drawing.Size(100, 20);
            this.inputFiltroMensaje.TabIndex = 6;
            this.inputFiltroMensaje.TextChanged += new System.EventHandler(this.inputFiltroMensaje_TextChanged);
            // 
            // FormBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.inputFiltroMensaje);
            this.Controls.Add(this.lblFiltroMensaje);
            this.Controls.Add(this.lblFiltroCategoria);
            this.Controls.Add(this.inputFiltroCategoria);
            this.Controls.Add(this.grillaBitacora);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBitacora";
            this.Text = "FormBitacora";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBitacora_FormClosing);
            this.Load += new System.EventHandler(this.FormBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaBitacora;
        private System.Windows.Forms.TextBox inputFiltroCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensaje;
        private System.Windows.Forms.Label lblFiltroCategoria;
        private System.Windows.Forms.Label lblFiltroMensaje;
        private System.Windows.Forms.TextBox inputFiltroMensaje;
    }
}