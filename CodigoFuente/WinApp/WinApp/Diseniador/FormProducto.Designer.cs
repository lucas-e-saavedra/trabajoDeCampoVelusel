
namespace WinApp.Diseniador
{
    partial class FormProducto
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.inputNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.comboUnidad = new System.Windows.Forms.ComboBox();
            this.checkCatalogo = new System.Windows.Forms.CheckBox();
            this.lblDisponibles = new System.Windows.Forms.Label();
            this.grillaDisponibles = new System.Windows.Forms.DataGridView();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblIngredientes = new System.Windows.Forms.Label();
            this.inputReposo = new System.Windows.Forms.TextBox();
            this.lblReposo = new System.Windows.Forms.Label();
            this.grillaIngredientes = new System.Windows.Forms.DataGridView();
            this.inputDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.inputFotoUrl = new System.Windows.Forms.TextBox();
            this.lblFotoUrl = new System.Windows.Forms.Label();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grillaDisponibles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaIngredientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(499, 445);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblUnidad
            // 
            this.lblUnidad.AutoSize = true;
            this.lblUnidad.Location = new System.Drawing.Point(12, 48);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(51, 13);
            this.lblUnidad.TabIndex = 9;
            this.lblUnidad.Text = "lblUnidad";
            // 
            // inputNombre
            // 
            this.inputNombre.Location = new System.Drawing.Point(15, 25);
            this.inputNombre.Name = "inputNombre";
            this.inputNombre.Size = new System.Drawing.Size(214, 20);
            this.inputNombre.TabIndex = 8;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 9);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "lblNombre";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(580, 445);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 6;
            this.btnGrabar.Text = "btnGrabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // comboUnidad
            // 
            this.comboUnidad.FormattingEnabled = true;
            this.comboUnidad.Location = new System.Drawing.Point(15, 64);
            this.comboUnidad.Name = "comboUnidad";
            this.comboUnidad.Size = new System.Drawing.Size(217, 21);
            this.comboUnidad.TabIndex = 12;
            // 
            // checkCatalogo
            // 
            this.checkCatalogo.AutoSize = true;
            this.checkCatalogo.Location = new System.Drawing.Point(15, 91);
            this.checkCatalogo.Name = "checkCatalogo";
            this.checkCatalogo.Size = new System.Drawing.Size(98, 17);
            this.checkCatalogo.TabIndex = 13;
            this.checkCatalogo.Text = "checkCatalogo";
            this.checkCatalogo.UseVisualStyleBackColor = true;
            // 
            // lblDisponibles
            // 
            this.lblDisponibles.AutoSize = true;
            this.lblDisponibles.Location = new System.Drawing.Point(397, 122);
            this.lblDisponibles.Name = "lblDisponibles";
            this.lblDisponibles.Size = new System.Drawing.Size(71, 13);
            this.lblDisponibles.TabIndex = 27;
            this.lblDisponibles.Text = "lblDisponibles";
            // 
            // grillaDisponibles
            // 
            this.grillaDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaDisponibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Unidad_D,
            this.Nombre_D});
            this.grillaDisponibles.Location = new System.Drawing.Point(389, 138);
            this.grillaDisponibles.Name = "grillaDisponibles";
            this.grillaDisponibles.Size = new System.Drawing.Size(266, 150);
            this.grillaDisponibles.TabIndex = 26;
            this.grillaDisponibles.SelectionChanged += new System.EventHandler(this.grillaDisponibles_SelectionChanged);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(339, 235);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(44, 23);
            this.btnQuitar.TabIndex = 25;
            this.btnQuitar.Text = ">>";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(339, 173);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(44, 23);
            this.btnAgregar.TabIndex = 24;
            this.btnAgregar.Text = "<<";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblIngredientes
            // 
            this.lblIngredientes.AutoSize = true;
            this.lblIngredientes.Location = new System.Drawing.Point(15, 122);
            this.lblIngredientes.Name = "lblIngredientes";
            this.lblIngredientes.Size = new System.Drawing.Size(75, 13);
            this.lblIngredientes.TabIndex = 23;
            this.lblIngredientes.Text = "lblIngredientes";
            // 
            // inputReposo
            // 
            this.inputReposo.Location = new System.Drawing.Point(15, 398);
            this.inputReposo.Name = "inputReposo";
            this.inputReposo.Size = new System.Drawing.Size(182, 20);
            this.inputReposo.TabIndex = 29;
            // 
            // lblReposo
            // 
            this.lblReposo.AutoSize = true;
            this.lblReposo.Location = new System.Drawing.Point(15, 382);
            this.lblReposo.Name = "lblReposo";
            this.lblReposo.Size = new System.Drawing.Size(54, 13);
            this.lblReposo.TabIndex = 28;
            this.lblReposo.Text = "lblReposo";
            // 
            // grillaIngredientes
            // 
            this.grillaIngredientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaIngredientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Unidad,
            this.Nombre});
            this.grillaIngredientes.Location = new System.Drawing.Point(12, 138);
            this.grillaIngredientes.MultiSelect = false;
            this.grillaIngredientes.Name = "grillaIngredientes";
            this.grillaIngredientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grillaIngredientes.Size = new System.Drawing.Size(321, 150);
            this.grillaIngredientes.TabIndex = 30;
            this.grillaIngredientes.SelectionChanged += new System.EventHandler(this.grillaIngredientes_SelectionChanged);
            // 
            // inputDescripcion
            // 
            this.inputDescripcion.Location = new System.Drawing.Point(15, 315);
            this.inputDescripcion.MaxLength = 999;
            this.inputDescripcion.Multiline = true;
            this.inputDescripcion.Name = "inputDescripcion";
            this.inputDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputDescripcion.Size = new System.Drawing.Size(640, 64);
            this.inputDescripcion.TabIndex = 32;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 299);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(73, 13);
            this.lblDescripcion.TabIndex = 31;
            this.lblDescripcion.Text = "lblDescripcion";
            // 
            // inputFotoUrl
            // 
            this.inputFotoUrl.Location = new System.Drawing.Point(224, 398);
            this.inputFotoUrl.Name = "inputFotoUrl";
            this.inputFotoUrl.Size = new System.Drawing.Size(431, 20);
            this.inputFotoUrl.TabIndex = 34;
            // 
            // lblFotoUrl
            // 
            this.lblFotoUrl.AutoSize = true;
            this.lblFotoUrl.Location = new System.Drawing.Point(221, 382);
            this.lblFotoUrl.Name = "lblFotoUrl";
            this.lblFotoUrl.Size = new System.Drawing.Size(51, 13);
            this.lblFotoUrl.TabIndex = 33;
            this.lblFotoUrl.Text = "lblFotoUrl";
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 74;
            // 
            // Unidad
            // 
            this.Unidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Width = 66;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // Unidad_D
            // 
            this.Unidad_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Unidad_D.DataPropertyName = "Unidad";
            this.Unidad_D.HeaderText = "Unidad";
            this.Unidad_D.Name = "Unidad_D";
            this.Unidad_D.ReadOnly = true;
            this.Unidad_D.Width = 66;
            // 
            // Nombre_D
            // 
            this.Nombre_D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nombre_D.DataPropertyName = "Nombre";
            this.Nombre_D.HeaderText = "Nombre";
            this.Nombre_D.Name = "Nombre_D";
            this.Nombre_D.ReadOnly = true;
            this.Nombre_D.Width = 69;
            // 
            // FormProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 474);
            this.Controls.Add(this.inputFotoUrl);
            this.Controls.Add(this.lblFotoUrl);
            this.Controls.Add(this.inputDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.grillaIngredientes);
            this.Controls.Add(this.inputReposo);
            this.Controls.Add(this.lblReposo);
            this.Controls.Add(this.lblDisponibles);
            this.Controls.Add(this.grillaDisponibles);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.lblIngredientes);
            this.Controls.Add(this.checkCatalogo);
            this.Controls.Add(this.comboUnidad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.inputNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnGrabar);
            this.Name = "FormProducto";
            this.Text = "Material";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProducto_FormClosing);
            this.Load += new System.EventHandler(this.FormProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grillaDisponibles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grillaIngredientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.TextBox inputNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.ComboBox comboUnidad;
        private System.Windows.Forms.CheckBox checkCatalogo;
        private System.Windows.Forms.Label lblDisponibles;
        private System.Windows.Forms.DataGridView grillaDisponibles;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblIngredientes;
        private System.Windows.Forms.TextBox inputReposo;
        private System.Windows.Forms.Label lblReposo;
        private System.Windows.Forms.DataGridView grillaIngredientes;
        private System.Windows.Forms.TextBox inputDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox inputFotoUrl;
        private System.Windows.Forms.Label lblFotoUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad_D;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_D;
    }
}