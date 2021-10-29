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
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            grillaProductos.DataSource = BLL.GestorFabricacion.Current.ListarProductos();
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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormProducto form = new FormProducto(new Producto());
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                grillaProductos.DataSource = BLL.GestorFabricacion.Current.ListarProductos();
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), "Borrar".Traducir(), MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    BLL.GestorFabricacion.Current.BorrarProducto(productoSeleccionado);
                    grillaProductos.DataSource = BLL.GestorFabricacion.Current.ListarProductos();
                    productoSeleccionado = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormProducto form = new FormProducto(productoSeleccionado);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                grillaProductos.DataSource = BLL.GestorFabricacion.Current.ListarProductos();
            }

        }

        private void grillaProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaProductos.SelectedRows.Count > 0)
            {
                int index = grillaProductos.SelectedRows[0].Index;
                IEnumerable<Producto> productos = (IEnumerable<Producto>)grillaProductos.DataSource;
                productoSeleccionado = productos.ElementAt(index);
            }

        }
    }
}
