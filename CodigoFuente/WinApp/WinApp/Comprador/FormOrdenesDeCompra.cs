using Dominio;
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

namespace WinApp.Comprador
{
    public partial class FormOrdenesDeCompra : Form, IIdiomasObservador
    {
        OrdenDeCompra unaOrdenDeCompra;
        public FormOrdenesDeCompra()
        {
            InitializeComponent();
        }
        private void FormOrdenesDeCompra_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            grillaOrdenesDeCompra.DataSource = BLL.GestorCompras.Current.ConsultarOrdenesDeCompra();
        }
        private void FormOrdenesDeCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            btnRevertir.Text = "Revertir orden de compra".Traducir();
            btnModificar.Text = "Modificar".Traducir();
        }

        private void grillaOrdenesDeCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaOrdenesDeCompra.SelectedRows.Count > 0)
            {
                int index = grillaOrdenesDeCompra.SelectedRows[0].Index;
                List<OrdenDeCompra> compras = (List<OrdenDeCompra>)grillaOrdenesDeCompra.DataSource;
                unaOrdenDeCompra = compras.ElementAt(index);
            }
        }

        private void btnRevertir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), "Revertir orden de compra".Traducir(), MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    BLL.GestorCompras.Current.RevertirOrdenDeCompra(unaOrdenDeCompra);
                    grillaOrdenesDeCompra.DataSource = null;
                    grillaOrdenesDeCompra.DataSource = BLL.GestorCompras.Current.ConsultarOrdenesDeCompra();
                    unaOrdenDeCompra = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormOrdenDeCompra form = new FormOrdenDeCompra(unaOrdenDeCompra);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK) {
                grillaOrdenesDeCompra.DataSource = null;
                grillaOrdenesDeCompra.DataSource = BLL.GestorCompras.Current.ConsultarOrdenesDeCompra();
            }
        }
    }
}
