
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
            ((System.ComponentModel.ISupportInitialize)(this.grillaOrdenesDeCompra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(328, 374);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "btnModificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnRevertir
            // 
            this.btnRevertir.Location = new System.Drawing.Point(174, 374);
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
            this.grillaOrdenesDeCompra.Location = new System.Drawing.Point(12, 12);
            this.grillaOrdenesDeCompra.Name = "grillaOrdenesDeCompra";
            this.grillaOrdenesDeCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaOrdenesDeCompra.Size = new System.Drawing.Size(402, 213);
            this.grillaOrdenesDeCompra.TabIndex = 7;
            this.grillaOrdenesDeCompra.SelectionChanged += new System.EventHandler(this.grillaOrdenesDeCompra_SelectionChanged);
            // 
            // FormOrdenesDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}