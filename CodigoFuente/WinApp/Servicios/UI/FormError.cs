using Servicios.BLL;
using Servicios.Domain;
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
            lblFecha.Text = errorSeleccionado.timestamp;
            lblClase.Text = errorSeleccionado.clase;
            lblDescripcion.Text = errorSeleccionado.descripcion;
            richTextBox1.Text = errorSeleccionado.detalle;

        }
    }
}
