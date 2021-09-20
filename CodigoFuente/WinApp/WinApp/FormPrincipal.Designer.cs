
namespace WinApp
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuNavegacion = new System.Windows.Forms.MenuStrip();
            this.accesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNavegacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuNavegacion
            // 
            this.menuNavegacion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accesosToolStripMenuItem});
            this.menuNavegacion.Location = new System.Drawing.Point(0, 0);
            this.menuNavegacion.Name = "menuNavegacion";
            this.menuNavegacion.Size = new System.Drawing.Size(800, 24);
            this.menuNavegacion.TabIndex = 1;
            this.menuNavegacion.Text = "menuStrip1";
            // 
            // accesosToolStripMenuItem
            // 
            this.accesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.familiasToolStripMenuItem,
            this.patentesToolStripMenuItem});
            this.accesosToolStripMenuItem.Name = "accesosToolStripMenuItem";
            this.accesosToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.accesosToolStripMenuItem.Text = "Accesos";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // familiasToolStripMenuItem
            // 
            this.familiasToolStripMenuItem.Name = "familiasToolStripMenuItem";
            this.familiasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.familiasToolStripMenuItem.Text = "Familias";
            this.familiasToolStripMenuItem.Click += new System.EventHandler(this.familiasToolStripMenuItem_Click);
            // 
            // patentesToolStripMenuItem
            // 
            this.patentesToolStripMenuItem.Name = "patentesToolStripMenuItem";
            this.patentesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.patentesToolStripMenuItem.Text = "Patentes";
            this.patentesToolStripMenuItem.Click += new System.EventHandler(this.patentesToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuNavegacion);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuNavegacion;
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuNavegacion.ResumeLayout(false);
            this.menuNavegacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuNavegacion;
        private System.Windows.Forms.ToolStripMenuItem accesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patentesToolStripMenuItem;
    }
}

