using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
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
    public partial class FormPatente : Form, IIdiomasObservador
    {
        Patente patenteActual;
        public FormPatente(Patente unaPatente)
        {
            InitializeComponent();
            patenteActual = unaPatente;
        }

        private void FormPatente_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            if (patenteActual != null) {
                inputNombre.Text = patenteActual.Nombre;
                inputVista.Text = patenteActual.Vista;
            }
        }

        private void FormPatente_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM Patentes".Traducir();
            lblNombre.Text = "Nombre".Traducir();
            lblVista.Text = "Vista".Traducir();
            btnGrabar.Text = patenteActual.IdPatente == Guid.Empty ? "Agregar".Traducir() : "Modificar".Traducir();
            btnCancelar.Text = "Cancelar".Traducir();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            patenteActual.Nombre = inputNombre.Text;
            patenteActual.Vista = inputVista.Text;
            if (patenteActual.IdPatente == Guid.Empty) {
                patenteActual.IdPatente = Guid.NewGuid();
                GestorUsuarios.Current.CrearPatente(patenteActual);
                this.DialogResult = DialogResult.OK;
            } else {
                GestorUsuarios.Current.ModificarPatente(patenteActual);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
