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
    public partial class FormProductos : Form, IIdiomasObservador
    {
        private Producto productoSeleccionado = null;

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            grillaProductos.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarGrilla();
        }

        private void FormProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM Productos".Traducir();
            btnAgregar.Text = "Agregar".Traducir();
            btnBorrar.Text = "Borrar".Traducir();
            btnModificar.Text = "Modificar".Traducir();

            Nombre.HeaderText = "Nombre".Traducir();
            Unidad.HeaderText = "Unidad de medida".Traducir();
            DisponibleEnCatalogo.HeaderText = "Mostrar en el catálogo".Traducir();
            Descripcion.HeaderText = "Descripción".Traducir();
            CantidadIngredientes.HeaderText = "Ingredientes".Traducir();
        }
        private void ActualizarGrilla() {
            grillaProductos.DataSource = null;
            IEnumerable<Producto> productosOrdenados = BLL.GestorFabricacion.Current.ListarProductos().OrderBy(item => item.Nombre).OrderByDescending(item => item.DisponibleEnCatalogo);
            grillaProductos.DataSource = productosOrdenados.ToList();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormProducto form = new FormProducto(new Producto());
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
                    BLL.GestorFabricacion.Current.BorrarProducto(productoSeleccionado); 
                    ActualizarGrilla();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormProducto form = new FormProducto(productoSeleccionado);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK) {
                ActualizarGrilla();
            }
        }

        private void grillaProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaProductos.SelectedRows.Count > 0) {
                int index = grillaProductos.SelectedRows[0].Index;
                IEnumerable<Producto> productos = (IEnumerable<Producto>)grillaProductos.DataSource;
                productoSeleccionado = productos.ElementAt(index);
            }

        }
    }
}
