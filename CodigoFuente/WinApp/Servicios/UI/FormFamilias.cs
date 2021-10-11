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
    public partial class FormFamilias : Form, IIdiomasObservador
    {
        private Familia familiaSeleccionada = null;
        public FormFamilias()
        {
            InitializeComponent();
        }

        private void FormFamilias_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            grillaFamilias.DataSource = GestorUsuarios.Current.ListarFamilias();
        }

        private void FormFamilias_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM Familias".Traducir();
            btnAgregar.Text = "Agregar".Traducir();
            btnBorrar.Text = "Borrar".Traducir();
            btnModificar.Text = "Modificar".Traducir();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormFamilia form = new FormFamilia(new Familia());
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                grillaFamilias.DataSource = GestorUsuarios.Current.ListarFamilias();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), "Borrar".Traducir(), MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    GestorUsuarios.Current.BorrarFamila(familiaSeleccionada);
                    grillaFamilias.DataSource = GestorUsuarios.Current.ListarFamilias();
                    familiaSeleccionada = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormFamilia form = new FormFamilia(familiaSeleccionada);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                grillaFamilias.DataSource = GestorUsuarios.Current.ListarFamilias();
            }
        }

        private void grillaFamilias_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaFamilias.SelectedRows.Count > 0)
            {
                int index = grillaFamilias.SelectedRows[0].Index;
                IEnumerable<Familia> familias = (IEnumerable<Familia>)grillaFamilias.DataSource;
                familiaSeleccionada = familias.ElementAt(index);
            }
        }
    }
}
