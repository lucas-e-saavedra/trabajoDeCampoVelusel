using Servicios.BLL;
using Servicios.Domain;
using Servicios.Extensions;
using System;
using System.Windows.Forms;

namespace Servicios.UI
{
#pragma warning disable 1591
    public partial class FormError : Form, IIdiomasObservador
    {
        Error errorSeleccionado;
        public FormError(Error unError)
        {
            InitializeComponent();
            errorSeleccionado = unError;
        }

        private void FormError_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
        }

        private void FormError_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "Ver detalle".Traducir();
            lblFecha.Text = errorSeleccionado.timestamp;
            lblClase.Text = errorSeleccionado.clase;
            lblDescripcion.Text = errorSeleccionado.descripcion;
            richTextBox1.Text = errorSeleccionado.detalle;

        }
    }
}
