
namespace WindowsService
{
    partial class ServicioDiarioVelusel
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventosSistema = new System.Diagnostics.EventLog();
            ((System.ComponentModel.ISupportInitialize)(this.eventosSistema)).BeginInit();
            // 
            // eventosSistema
            // 
            this.eventosSistema.Log = "Application";
            // 
            // ServicioDiarioVelusel
            // 
            this.ServiceName = "ServicioDiarioVelusel";
            ((System.ComponentModel.ISupportInitialize)(this.eventosSistema)).EndInit();

        }

        #endregion

        private System.Diagnostics.EventLog eventosSistema;
    }
}
