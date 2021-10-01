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
    public partial class FormFamilia : Form, IIdiomasObservador
    {
        Familia familiaActual;
        PatenteFamilia hijoAagregar = null;
        PatenteFamilia hijoAquitar = null;
        public FormFamilia(Familia unaFamilia)
        {
            InitializeComponent();
            familiaActual = unaFamilia;
        }

        private void FormFamilia_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
          
            inputNombre.Text = familiaActual.Nombre;
            grillaHijos.DataSource = familiaActual.ListadoHijos;
            List<PatenteFamilia> disponibles = new List<PatenteFamilia>();
            disponibles.AddRange(GestorUsuarios.Current.ListarFamilias());
            disponibles.AddRange(GestorUsuarios.Current.ListarPatentes());
            familiaActual.ListadoHijos.ForEach(item => disponibles.Remove(item));
            grillaDisponibles.DataSource = disponibles;
        }
        private void FormFamilia_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            lblNombre.Text = "Nombre".Traducir();
            lblHijos.Text = "Hijos".Traducir();
            lblDisponibles.Text = "Disponibles".Traducir();
            btnGrabar.Text = familiaActual.IdFamilia == Guid.Empty ? "Agregar".Traducir() : "Modificar".Traducir();
            btnCancelar.Text = "Cancelar".Traducir();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            familiaActual.Nombre = inputNombre.Text;
            if (familiaActual.IdFamilia == Guid.Empty)
            {
                familiaActual.IdFamilia = Guid.NewGuid();
                GestorUsuarios.Current.CrearFamilia(familiaActual);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                GestorUsuarios.Current.ModificarFamilia(familiaActual);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void grillaHijos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaHijos.SelectedRows.Count > 0)
            {
                int index = grillaHijos.SelectedRows[0].Index;
                IEnumerable<PatenteFamilia> items = (IEnumerable<PatenteFamilia>)grillaHijos.DataSource;
                hijoAquitar = items.ElementAt(index);
            }
        }

        private void grillaDisponibles_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaDisponibles.SelectedRows.Count > 0)
            {
                int index = grillaDisponibles.SelectedRows[0].Index;
                IEnumerable<PatenteFamilia> items = (IEnumerable<PatenteFamilia>)grillaDisponibles.DataSource;
                hijoAagregar = items.ElementAt(index);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            familiaActual.ListadoHijos.Add(hijoAagregar);
            grillaHijos.DataSource = null;
            grillaHijos.DataSource = familiaActual.ListadoHijos;

            List<PatenteFamilia> items = (List<PatenteFamilia>)grillaDisponibles.DataSource;
            items.Remove(hijoAagregar);
            grillaDisponibles.DataSource = null;
            grillaDisponibles.DataSource = items;
            hijoAagregar = null;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            familiaActual.ListadoHijos.Remove(hijoAquitar);
            grillaHijos.DataSource = null;
            grillaHijos.DataSource = familiaActual.ListadoHijos;
            
            List<PatenteFamilia> items = (List<PatenteFamilia>)grillaDisponibles.DataSource;
            items.Add(hijoAquitar);
            grillaDisponibles.DataSource = null;
            grillaDisponibles.DataSource = items;
            hijoAquitar = null;
        }
    }
}
