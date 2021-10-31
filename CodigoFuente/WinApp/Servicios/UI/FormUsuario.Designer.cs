
namespace Servicios.UI
{
    partial class FormUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuario));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.inputUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.grillaDisponibles = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblPermisos = new System.Windows.Forms.Label();
            this.grillaPermisos = new System.Windows.Forms.DataGridView();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.inputDocumento = new System.Windows.Forms.TextBox();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.comboDocumento = new System.Windows.Forms.ComboBox();
            this.Nombre_P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadHijos_P = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadHijos_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(396, 345);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // inputUsuario
            // 
            this.inputUsuario.Location = new System.Drawing.Point(15, 25);
            this.inputUsuario.Name = "inputUsuario";
            this.inputUsuario.Size = new System.Drawing.Size(214, 20);
            this.inputUsuario.TabIndex = 0;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(12, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(53, 13);
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Text = "lblUsuario";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(477, 345);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Location = new System.Drawing.Point(312, 170);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(71, 13);
            this.lblDisponibles.TabIndex = 21;
            this.lblDisponibles.Text = "lblDisponibles";
            // 
            // grillaDisponibles
            // 
            this.grillaDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre_D,
            this.CantidadHijos_D});
            this.grillaDisponibles.Location = new System.Drawing.Point(312, 189);
            this.grillaDisponibles.Name = "grillaDisponibles";
            this.grillaDisponibles.Size = new System.Drawing.Size(240, 150);
            this.grillaDisponibles.TabIndex = 20;
            this.grillaDisponibles.SelectionChanged += new System.EventHandler(this.grillaDisponibles_SelectionChanged);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(262, 274);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(44, 23);
            this.btnQuitar.TabIndex = 19;
            this.btnQuitar.Text = ">>";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(262, 224);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(44, 23);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Text = "<<";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblPermisos
            // 
            this.lblPermisos.AutoSize = true;
            this.lblPermisos.Location = new System.Drawing.Point(15, 173);
            this.lblPermisos.Name = "lblPermisos";
            this.lblPermisos.Size = new System.Drawing.Size(59, 13);
            this.lblPermisos.TabIndex = 17;
            this.lblPermisos.Text = "lblPermisos";
            // 
            // grillaPermisos
            // 
            this.grillaPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre_P,
            this.CantidadHijos_P});
            this.grillaPermisos.Location = new System.Drawing.Point(15, 189);
            this.grillaPermisos.Name = "grillaPermisos";
            this.grillaPermisos.Size = new System.Drawing.Size(240, 150);
            this.grillaPermisos.TabIndex = 16;
            this.grillaPermisos.SelectionChanged += new System.EventHandler(this.grillaPermisos_SelectionChanged);
            // 
            // inputNombre
            // 
            this.inputNombre.Location = new System.Drawing.Point(15, 64);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(214, 20);
            this.inputNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 48);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 22;
            this.lblNombre.Text = "lblNombre";
            // 
            // inputEmail
            // 
            this.inputEmail.Location = new System.Drawing.Point(15, 103);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(214, 20);
            this.inputEmail.TabIndex = 2;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(12, 87);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(42, 13);
            this.lblEmail.TabIndex = 24;
            this.lblEmail.Text = "lblEmail";
            // 
            // inputDocumento
            // 
            this.inputDocumento.Location = new System.Drawing.Point(98, 143);
            this.inputDocumento.Name = "inputDocumento";
            this.inputDocumento.Size = new System.Drawing.Size(131, 20);
            this.inputDocumento.TabIndex = 4;
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(12, 126);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(72, 13);
            this.lblDocumento.TabIndex = 26;
            this.lblDocumento.Text = "lblDocumento";
            // 
            // comboDocumento
            // 
            this.comboDocumento.FormattingEnabled = true;
            this.comboDocumento.Location = new System.Drawing.Point(15, 143);
            this.comboDocumento.Name = "comboDocumento";
            this.comboDocumento.Size = new System.Drawing.Size(77, 21);
            this.comboDocumento.TabIndex = 3;
            // 
            // Nombre_P
            // 
            this.Nombre_P.DataPropertyName = "Nombre";
            this.Nombre_P.HeaderText = "Nombre";
            this.Nombre_P.Name = "Nombre_P";
            this.Nombre_P.ReadOnly = true;
            // 
            // CantidadHijos_P
            // 
            this.CantidadHijos_P.DataPropertyName = "CantidadHijos";
            this.CantidadHijos_P.HeaderText = "(Sub)Permisos";
            this.CantidadHijos_P.Name = "CantidadHijos_P";
            this.CantidadHijos_P.ReadOnly = true;
            // 
            // Nombre_D
            // 
            this.Nombre_D.DataPropertyName = "Nombre";
            this.Nombre_D.HeaderText = "Nombre";
            this.Nombre_D.Name = "Nombre_D";
            // 
            // CantidadHijos_D
            // 
            this.CantidadHijos_D.DataPropertyName = "CantidadHijos";
            this.CantidadHijos_D.HeaderText = "(Sub)Permisos";
            this.CantidadHijos_D.Name = "CantidadHijos_D";
            this.CantidadHijos_D.ReadOnly = true;
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 412);
            this.Controls.Add(this.comboDocumento);
            this.Controls.Add(this.inputDocumento);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.inputEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblDisponibles);
            this.Controls.Add(this.grillaDisponibles);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblPermisos);
            this.Controls.Add(this.grillaPermisos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.inputUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnGrabar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUsuario";
            this.Text = "FormUsuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUsuario_FormClosing);
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox inputUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.DataGridView grillaDisponibles;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblPermisos;
        private System.Windows.Forms.DataGridView grillaPermisos;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox inputEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox inputDocumento;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.ComboBox comboDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_P;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadHijos_P;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadHijos_D;
    }
}