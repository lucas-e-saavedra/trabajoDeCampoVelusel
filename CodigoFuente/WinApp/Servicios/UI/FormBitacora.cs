using Servicios.BLL;
using Servicios.Domain;
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

namespace Servicios.UI
{
    public partial class FormBitacora : Form, IIdiomasObservador
    {
        Evento eventoSeleccionado;
        public FormBitacora()
        {
            InitializeComponent();
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            grillaBitacora.AutoGenerateColumns = false;
            GestorIdiomas.Current.SuscribirObservador(this);
            IEnumerable<Evento> bitacora = GestorHistorico.Current.ListarBitacora();
            grillaBitacora.DataSource = bitacora.Reverse().ToList();
        }
        private void FormBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "Ver bitácora".Traducir();
            btnDetalle.Enabled = eventoSeleccionado != null;
            btnDetalle.Text = "Ver detalle".Traducir();
        }
        private void grillaBitacora_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaBitacora.SelectedRows.Count > 0)
            {
                int index = grillaBitacora.SelectedRows[0].Index;
                IEnumerable<Evento> eventos = (IEnumerable<Evento>)grillaBitacora.DataSource;
                eventoSeleccionado = eventos.ElementAt(index);
                btnDetalle.Enabled = eventoSeleccionado != null;
            }
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {
        }
    }
}
