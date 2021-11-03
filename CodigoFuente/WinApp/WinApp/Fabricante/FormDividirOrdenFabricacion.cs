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

namespace WinApp.Fabricante
{
    public partial class FormDividirOrdenFabricacion : Form, IIdiomasObservador
    {
        OrdenDeFabricacion ordenDeFabricacionSeleccionada;
        public FormDividirOrdenFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            InitializeComponent();
            ordenDeFabricacionSeleccionada = unaOrdenDeFabricacion;
        }
        private void FormDividirOrdenFabricacion_Load(object sender, EventArgs e)
        {
            dateReprogramacion.MinDate = DateTime.Today.AddDays(1);
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarTraducciones();
        }
        private void FormDividirOrdenFabricacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "Dividir orden de fabricación".Traducir();
            lblExplicarReprogramacion.Text = "Seleccione una fecha para completar el saldo restante de esta orden de fabricación".Traducir();
            btnGrabar.Text = "Grabar".Traducir();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {
                BLL.GestorFabricacion.Current.DividirFabricacion(ordenDeFabricacionSeleccionada, dateReprogramacion.SelectionStart);
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }
    }
}
