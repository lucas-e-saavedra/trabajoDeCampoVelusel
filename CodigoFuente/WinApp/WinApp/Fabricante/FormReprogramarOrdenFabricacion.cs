using Dominio;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Windows.Forms;

namespace WinApp.Fabricante
{
    public partial class FormReprogramarOrdenFabricacion : Form, IIdiomasObservador
    {
        OrdenDeFabricacion ordenDeFabricacionSeleccionada;
        public FormReprogramarOrdenFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            InitializeComponent();
            ordenDeFabricacionSeleccionada = unaOrdenDeFabricacion;
        }

        private void FormReprogramarOrdenFabricacion_Load(object sender, EventArgs e)
        {
            dateReprogramacion.MinDate = DateTime.Today.AddDays(1);
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarTraducciones();
        }

        private void FormReprogramarOrdenFabricacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            lblExplicarReprogramacion.Text = "Seleccione una nueva fecha para volver a agendar esta orden de fabricación".Traducir();
            btnGrabar.Text = "Modificar".Traducir();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {
                ordenDeFabricacionSeleccionada.FechaPlanificada = dateReprogramacion.SelectionStart;
                BLL.GestorFabricacion.Current.ReprogramarFabricacion(ordenDeFabricacionSeleccionada);
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }
    }
}
