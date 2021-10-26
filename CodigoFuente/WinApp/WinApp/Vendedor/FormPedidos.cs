using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Windows.Forms;

namespace WinApp.Vendedor
{
    public partial class FormPedidos : Form, IIdiomasObservador
    {
        public FormPedidos()
        {
            InitializeComponent();
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            grillaPedidos.DataSource = BLL.GestorPedidos.Current.ListarPedidos();


        }
        private void FormPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "ABM Clientes".Traducir();
        }

    }
}
