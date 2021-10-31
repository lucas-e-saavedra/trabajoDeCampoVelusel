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
    public partial class FormErrores : Form, IIdiomasObservador
    {
        Error errorSeleccionado = null;
        public FormErrores()
        {
            InitializeComponent();
        }

        private void FormErrores_Load(object sender, EventArgs e)
        {
            grillaErrores.AutoGenerateColumns = false;
            GestorIdiomas.Current.SuscribirObservador(this);
            IEnumerable<Error> errores = GestorHistorico.Current.ListarErrores();
            grillaErrores.DataSource = errores.Reverse().ToList();
            ActualizarTraducciones();
        }
        private void FormErrores_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "Ver errores".Traducir();
            btnDetalle.Enabled = errorSeleccionado != null;
            btnDetalle.Text = "Ver detalle".Traducir();
        }
        private void grillaErrores_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaErrores.SelectedRows.Count > 0)
            {
                int index = grillaErrores.SelectedRows[0].Index;
                IEnumerable<Error> errores = (IEnumerable<Error>)grillaErrores.DataSource;
                errorSeleccionado = errores.ElementAt(index);
                btnDetalle.Enabled = errorSeleccionado != null;
            }
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            FormError form = new FormError(errorSeleccionado);
            form.ShowDialog();
        }
    }
}
