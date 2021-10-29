using Dominio;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinApp.Fabricante
{
    public partial class FormAnalizarPedidos : Form, IIdiomasObservador
    {
        Pedido pedidoSeleccionado;
        OrdenDeFabricacion ordenSeleccionada;
        public FormAnalizarPedidos()
        {
            InitializeComponent();
        }
        private void FormAnalizarPedidos_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            grillaPedidos.DataSource = BLL.GestorPedidos.Current.ListarPedidos(Pedido.EnumEstadoPedido.FORMULADO);
            timeOrdenFabricacion.MinDate = DateTime.Today.AddDays(1);
        }

        private void FormAnalizarPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            boxOrdenFabricacion.Text = "Orden de fabricación".Traducir();
            btnSaveAllOrders.Text = "Agendar pedido".Traducir();
        }
        private void grillaPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaPedidos.SelectedRows.Count > 0)
            {
                int index = grillaPedidos.SelectedRows[0].Index;
                IEnumerable<Pedido> pedidos = (IEnumerable<Pedido>)grillaPedidos.DataSource;
                pedidoSeleccionado = pedidos.ElementAt(index);
                grillaOrdenesFabricacion.DataSource = BLL.GestorFabricacion.Current.AnalizarPedido(pedidoSeleccionado);
            }
        }

        private void grillaOrdenesFabricacion_SelectionChanged(object sender, EventArgs e)
        {
            if (ordenSeleccionada != null)
                ordenSeleccionada.fecha = timeOrdenFabricacion.Value;


            if (grillaOrdenesFabricacion.SelectedRows.Count > 0)
            {
                int index = grillaOrdenesFabricacion.SelectedRows[0].Index;
                IEnumerable<OrdenDeFabricacion> ordenes = (IEnumerable<OrdenDeFabricacion>)grillaOrdenesFabricacion.DataSource;
                ordenSeleccionada = ordenes.ElementAt(index);

                lblIdOrdenFabricacion.Text = ordenSeleccionada.Id.ToString();
                lblOFposterior.Text = $"{ordenSeleccionada.OrdenDeFabricacionPosterior?.Id}";
                if (ordenSeleccionada.fecha!=null && ordenSeleccionada.fecha>DateTime.MinValue)
                    timeOrdenFabricacion.Value = ordenSeleccionada.fecha;
                lblObjetivoOrdenFabricacion.Text = $"{ordenSeleccionada.Objetivo.Cantidad} ({ordenSeleccionada.Objetivo.Unidad}) {ordenSeleccionada.Objetivo.Nombre}";
            }
        }

        private void btnSaveAllOrders_Click(object sender, EventArgs e)
        {
            if (ordenSeleccionada != null)
                ordenSeleccionada.fecha = timeOrdenFabricacion.Value;

            IEnumerable<OrdenDeFabricacion> ordenes = (IEnumerable<OrdenDeFabricacion>)grillaOrdenesFabricacion.DataSource;
            bool resultado = BLL.GestorFabricacion.Current.VerificarDependenciaOrdenesDeFabricacion(ordenes);
            if (resultado) {
                grillaOrdenesFabricacion.DataSource = null;
                grillaPedidos.DataSource = BLL.GestorPedidos.Current.ListarPedidos(Pedido.EnumEstadoPedido.FORMULADO);                
            } else
                MessageBox.Show($"resultado: {resultado}");
        }
    }
}
