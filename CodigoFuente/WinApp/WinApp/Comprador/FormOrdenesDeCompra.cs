using Dominio;
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
            grillaOrdenesDeCompra.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarGrilla();
        }
        private void FormOrdenesDeCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "Ordenes de compra".Traducir();
            btnRevertir.Text = "Revertir orden de compra".Traducir();
            btnModificar.Text = "Modificar".Traducir();

            DescSolicitante.HeaderText = "Solicitante".Traducir();
            Estado.HeaderText = "Estado".Traducir();
            DescObjetivo.HeaderText = "Objetivo".Traducir();
            FechaObjetivo.HeaderText = "Fecha planificada".Traducir();
            DescComprados.HeaderText = "Comprados".Traducir();
            FechaEstimadaRecepcion.HeaderText = "Fecha estimada recepción".Traducir();
            DescRecibidos.HeaderText = "Recibidos".Traducir();
            FechaRealRecepcion.HeaderText = "Fecha real recepción".Traducir();

        }
        private void ActualizarGrilla() {
            grillaOrdenesDeCompra.DataSource = null;
            IEnumerable<OrdenDeCompra> ordenesDeCompra = BLL.GestorCompras.Current.ConsultarOrdenesDeCompra();
            List<VistaOrdenDeCompra> vistasOC = ordenesDeCompra.OrderBy(item => item.FechaObjetivo).Select(item => new VistaOrdenDeCompra(item)).ToList();
            grillaOrdenesDeCompra.DataSource = vistasOC;
        }

        private void grillaOrdenesDeCompra_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaOrdenesDeCompra.SelectedRows.Count > 0)
            {
                int index = grillaOrdenesDeCompra.SelectedRows[0].Index;
                IEnumerable<OrdenDeCompra> ordenes = (IEnumerable<OrdenDeCompra>)grillaOrdenesDeCompra.DataSource;
                unaOrdenDeCompra = ordenes.ElementAt(index);
            }
        }

        private void btnRevertir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), "Revertir orden de compra".Traducir(), MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try {
                    BLL.GestorCompras.Current.RevertirOrdenDeCompra(unaOrdenDeCompra);
                    ActualizarGrilla();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormOrdenDeCompra form = new FormOrdenDeCompra(unaOrdenDeCompra);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK) {
                ActualizarGrilla();
            }
        }
    }

    class VistaOrdenDeCompra: OrdenDeCompra
    {
        public VistaOrdenDeCompra(OrdenDeCompra item)
        {
            this.Id = item.Id;
            this.solicitante = item.solicitante;
            this.Estado = item.Estado;
            this.Objetivo = item.Objetivo;
            this.FechaObjetivo = item.FechaObjetivo;
            this.Comprados = item.Comprados;
            this.FechaEstimadaRecepcion = item.FechaEstimadaRecepcion;
            this.Recibidos = item.Recibidos;
            this.FechaRealRecepcion = item.FechaRealRecepcion;

        }
        public string DescSolicitante => solicitante.UsuarioLogin;
        public string DescObjetivo => DescMaterial(Objetivo);
        public string DescComprados => DescMaterial(Comprados);
        public string DescRecibidos => DescMaterial(Recibidos);

        private string DescMaterial(Material unMaterial)
        {
            return $"{unMaterial.Cantidad} ({unMaterial.Unidad}) {unMaterial.Nombre}";
        }
    }
}
