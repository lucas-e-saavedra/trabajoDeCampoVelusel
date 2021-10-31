using Dominio;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp.Comprador
{
    public partial class FormConfigurarAlarmas : Form, IIdiomasObservador
    {
        Alarma configAlarma;
        public FormConfigurarAlarmas()
        {
            InitializeComponent();
        }
        private void FormConfigurarAlarmas_Load(object sender, EventArgs e)
        {
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarTraducciones();
            configAlarma = BLL.GestorStock.Current.ObtenerAlarmas(GestorSesion.Current.usuarioActual);
            inputDiasAlarmaStock.Value = configAlarma.DiasAlarmaStock;
            inputDiasAlarmaCompras.Value = configAlarma.DiasAlarmaCompras;

            btnTestAlarmas.Visible = GestorSesion.Current.TieneRolGerente();
        }
        private void FormConfigurarAlarmas_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            lblDiasAlarmaStock.Text = "Cantidad de dias de anticipación que desea controlar del stock para evitar bloqueos".Traducir();
            lblDiasAlarmaCompras.Text = "Cantidad de dias de anticipación que desea controlar estado de las compras para evitar bloqueos".Traducir();
            btnGrabar.Text = "Grabar".Traducir();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {
                configAlarma.DiasAlarmaStock = (int)inputDiasAlarmaStock.Value;
                configAlarma.DiasAlarmaCompras = (int)inputDiasAlarmaCompras.Value;
                BLL.GestorStock.Current.ConfigurarAlarmas(configAlarma);
                this.Close();
            } catch(Exception ex) { 
                ex.MostrarEnAlert(); 
            }
        }

        private void btnTestAlarmas_Click(object sender, EventArgs e)
        {
            BLL.GestorStock.Current.EnviarAlertas();
        }
    }
}
