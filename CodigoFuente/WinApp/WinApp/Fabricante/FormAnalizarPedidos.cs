using Dominio;
using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
            grillaPedidos.AutoGenerateColumns = false;
            grillaOrdenesFabricacion.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            timeOrdenFabricacion.MinDate = DateTime.Today.AddDays(1);
            ActualizarGrillaPedidos();
        }

        private void FormAnalizarPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "Analizar pedido".Traducir();
            boxOrdenFabricacion.Text = "Orden de fabricación".Traducir();
            btnSaveAllOrders.Text = "Agendar pedido".Traducir();

            Solicitante.HeaderText = "Solicitante".Traducir();
            Vendedor.HeaderText = "Vendedor".Traducir();
            Estado.HeaderText = "Estado".Traducir();
            Detalle.HeaderText = "Detalle".Traducir();

            Fecha.HeaderText = "Fecha planificada".Traducir();
            Estado_OF.HeaderText = "Estado".Traducir();
            Objetivo.HeaderText = "Objetivo".Traducir();
        }
        private void ActualizarGrillaPedidos() {
            grillaPedidos.DataSource = null;
            IEnumerable<Pedido> pedidos = BLL.GestorPedidos.Current.ListarPedidos(Pedido.EnumEstadoPedido.FORMULADO).OrderBy(item => item.Estado);
            List<VistaPedido> pedidosVista = pedidos.Select(item => new VistaPedido(item)).ToList();
            grillaPedidos.DataSource = pedidosVista;
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
            if (grillaOrdenesFabricacion.SelectedRows.Count > 0)
            {
                int index = grillaOrdenesFabricacion.SelectedRows[0].Index;
                IEnumerable<OrdenDeFabricacion> ordenes = (IEnumerable<OrdenDeFabricacion>)grillaOrdenesFabricacion.DataSource;
                ordenSeleccionada = ordenes.ElementAt(index);

                lblIdOrdenFabricacion.Text = $"{"Identificador".Traducir()}: {ordenSeleccionada.Id}" ;
                string siguienteOF = ordenSeleccionada.OrdenDeFabricacionPosterior?.Id.ToString() ?? "ninguna".Traducir();
                lblOFposterior.Text = $"{"Siguiente Orden de Fabricación".Traducir()} {siguienteOF}";
                if (ordenSeleccionada.FechaPlanificada!=null && ordenSeleccionada.FechaPlanificada>DateTime.MinValue)
                    timeOrdenFabricacion.Value = ordenSeleccionada.FechaPlanificada;
                lblObjetivoOrdenFabricacion.Text = $"{ordenSeleccionada.Objetivo.Cantidad} ({ordenSeleccionada.Objetivo.Unidad}) {ordenSeleccionada.Objetivo.Nombre}";
                lblReposoNecesario.Text = $"{"Horas de reposo necesarias".Traducir()}: {ordenSeleccionada.Objetivo.plantillaDeFabricacion.ReposoNecesario}";
            }
        }
        private void timeOrdenFabricacion_ValueChanged(object sender, EventArgs e)
        {
            if (ordenSeleccionada != null) {
                ordenSeleccionada.FechaPlanificada = timeOrdenFabricacion.Value;
                grillaOrdenesFabricacion.Refresh();
            }
        }
        private void btnSaveAllOrders_Click(object sender, EventArgs e)
        {
            if (ordenSeleccionada != null)
                ordenSeleccionada.FechaPlanificada = timeOrdenFabricacion.Value;

            IEnumerable<OrdenDeFabricacion> ordenes = (IEnumerable<OrdenDeFabricacion>)grillaOrdenesFabricacion.DataSource;
            bool resultado = BLL.GestorFabricacion.Current.VerificarDependenciaOrdenesDeFabricacion(ordenes);
            if (resultado) {
                grillaOrdenesFabricacion.DataSource = null;
                ActualizarGrillaPedidos();
            } else
                MessageBox.Show("Por favor verifique la concordancia de las fechas planificadas".Traducir());
        }
    }
    class VistaPedido : Pedido
    {

        public VistaPedido(Pedido item)
        {
            this.Id = item.Id;
            this.Solicitante = item.Solicitante;
            this.Vendedor = item.Vendedor;
            this.Estado = item.Estado;
            this.Detalle = item.Detalle;
        }

        public string DescSolicitante { get { return this.Solicitante?.Nombre; } }
        public string DescVendedor { get { return this.Vendedor.UsuarioLogin; } }
        public string DescDetalle { get { return DetalleToString(); } }

        private string DetalleToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Producto unProducto in this.Detalle)
            {
                stringBuilder.Append($"{unProducto.Cantidad}({unProducto.Unidad}) {unProducto.Nombre}, ");
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            return stringBuilder.ToString();
        }
    }

}
