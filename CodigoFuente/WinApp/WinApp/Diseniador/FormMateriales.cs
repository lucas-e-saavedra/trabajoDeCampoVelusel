using Dominio.CompositeProducto;
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

namespace WinApp.Diseniador
{
    public partial class FormMateriales : Form, IIdiomasObservador
    {
        private Material materialSeleccionado = null;
        public FormMateriales()
        {
            InitializeComponent();
        }

        private void Materiales_Load(object sender, EventArgs e)
        {
            grillaMateriales.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarGrilla();
        }

        private void Materiales_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM Materiales".Traducir();
            btnAgregar.Text = "Agregar".Traducir();
            btnBorrar.Text = "Borrar".Traducir();
            btnModificar.Text = "Modificar".Traducir();
        }
        private void ActualizarGrilla() {
            grillaMateriales.DataSource = null;
            IEnumerable<Material> materialesOrdenados = BLL.GestorFabricacion.Current.ListarMateriales().OrderBy(item => item.Nombre);
            grillaMateriales.DataSource = materialesOrdenados.ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormMaterial form = new FormMaterial(new Material());
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK) {
                ActualizarGrilla();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), "Borrar".Traducir(), MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes) {
                try {
                    BLL.GestorFabricacion.Current.BorrarMaterial(materialSeleccionado);
                    ActualizarGrilla();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormMaterial form = new FormMaterial(materialSeleccionado);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK) {
                ActualizarGrilla();
            }
        }

        private void grillaMateriales_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaMateriales.SelectedRows.Count > 0)
            {
                int index = grillaMateriales.SelectedRows[0].Index;
                IEnumerable<Material> materiales = (IEnumerable<Material>)grillaMateriales.DataSource;
                materialSeleccionado = materiales.ElementAt(index);
            }
        }
    }
}
