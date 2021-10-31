using Dominio;
using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Dominio.Pedido;

namespace WinApp.Vendedor
{
    public partial class FormPedidos : Form, IIdiomasObservador
    {
        Pedido pedidoSeleccionado;
        public FormPedidos()
        {
            InitializeComponent();
        }

        private void FormPedidos_Load(object sender, EventArgs e)
        {
            grillaPedidos.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarGrilla();
        }
        private void FormPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "ABM Clientes".Traducir();
            btnCancelar.Text = "Cancelar pedido".Traducir();
        }
        private void ActualizarGrilla() {
            grillaPedidos.DataSource = null;
            IEnumerable<Pedido> pedidos = BLL.GestorPedidos.Current.ListarPedidos().Where(item => item.Estado!=EnumEstadoPedido.CANCELADO && item.Estado != EnumEstadoPedido.CERRADO).OrderBy(item => item.Estado);
            List<VistaPedido> pedidosVista = pedidos.Select(item => new VistaPedido(item)).ToList();
            grillaPedidos.DataSource = pedidosVista;
            btnCancelar.Enabled = pedidoSeleccionado?.Estado == EnumEstadoPedido.FORMULADO || pedidoSeleccionado?.Estado == EnumEstadoPedido.PLANIFICADO;
            btnCerrar.Enabled = pedidoSeleccionado?.Estado == EnumEstadoPedido.LISTO;
        }

        private void grillaPedidos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaPedidos.SelectedRows.Count > 0)
            {
                int index = grillaPedidos.SelectedRows[0].Index;
                IEnumerable<Pedido> pedidos = (IEnumerable<Pedido>)grillaPedidos.DataSource;
                pedidoSeleccionado = pedidos.ElementAt(index);
                btnCancelar.Enabled = pedidoSeleccionado.Estado == EnumEstadoPedido.FORMULADO || pedidoSeleccionado.Estado == EnumEstadoPedido.PLANIFICADO;
                btnCerrar.Enabled = pedidoSeleccionado.Estado == EnumEstadoPedido.LISTO;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try {
                BLL.GestorPedidos.Current.CancelarPedido(pedidoSeleccionado);
                ActualizarGrilla();
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try {
                BLL.GestorPedidos.Current.EntregarPedido(pedidoSeleccionado);
                ActualizarGrilla();
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }
    }

    class VistaPedido: Pedido {

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

        private string DetalleToString() {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Producto unProducto in this.Detalle) {
                stringBuilder.Append($"{unProducto.Cantidad}({unProducto.Unidad}) {unProducto.Nombre}, ");
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            return stringBuilder.ToString();
        }
    }
}
