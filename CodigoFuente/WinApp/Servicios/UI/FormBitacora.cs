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
#pragma warning disable 1591
    public partial class FormBitacora : Form, IIdiomasObservador
    {
        IEnumerable<Evento> bitacora;
        public FormBitacora()
        {
            InitializeComponent();
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            grillaBitacora.AutoGenerateColumns = false;
            GestorIdiomas.Current.SuscribirObservador(this);
            bitacora = GestorHistorico.Current.ListarBitacora();
            ActualizarTraducciones();
            ActualizarGrilla();
        }
        private void FormBitacora_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "Ver bitácora".Traducir();
            timestamp.HeaderText = "Fecha y hora".Traducir();
            categoria.HeaderText = "Categoría".Traducir();
            mensaje.HeaderText = "Mensaje".Traducir();
            lblFiltroCategoria.Text = "Filtrar por categoría".Traducir();
            lblFiltroMensaje.Text = "Filtrar por mensaje".Traducir();
        }
        private void ActualizarGrilla() {
            List<Evento> bitacoraFiltrada = bitacora.ToList();
            if (inputFiltroCategoria.Text.Length > 0)
                bitacoraFiltrada = bitacoraFiltrada.Where(item => item.categoria.ToString().ToLower().Contains(inputFiltroCategoria.Text.ToLower())).ToList();
            if (inputFiltroMensaje.Text.Length > 0)
                bitacoraFiltrada = bitacoraFiltrada.Where(item => item.mensaje.ToLower().Contains(inputFiltroMensaje.Text.ToLower())).ToList();

            bitacoraFiltrada.Reverse();
            grillaBitacora.DataSource = bitacoraFiltrada;
        }
        private void inputFiltroCategoria_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void inputFiltroMensaje_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
