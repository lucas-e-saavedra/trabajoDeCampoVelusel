
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
            ((System.ComponentModel.ISupportInitialize)(this.grillaOrdenesFabricacion)).BeginInit();
            this.SuspendLayout();
            // 
            // grillaOrdenesFabricacion
            // 
            this.grillaOrdenesFabricacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaOrdenesFabricacion.Location = new System.Drawing.Point(12, 12);
            this.grillaOrdenesFabricacion.Name = "grillaOrdenesFabricacion";
            this.grillaOrdenesFabricacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaOrdenesFabricacion.Size = new System.Drawing.Size(776, 161);
            this.grillaOrdenesFabricacion.TabIndex = 11;
            this.grillaOrdenesFabricacion.SelectionChanged += new System.EventHandler(this.grillaOrdenesFabricacion_SelectionChanged);
            // 
            // btnComenzar
            // 
            this.btnComenzar.Location = new System.Drawing.Point(13, 214);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(102, 23);
            this.btnComenzar.TabIndex = 12;
            this.btnComenzar.Text = "btnComenzar";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(121, 214);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(102, 23);
            this.btnCerrar.TabIndex = 13;
            this.btnCerrar.Text = "btnCerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(229, 214);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(102, 23);
            this.btnTerminar.TabIndex = 14;
            this.btnTerminar.Text = "btnTerminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // FormOrdenesDeFabricacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}