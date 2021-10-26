using BLL;
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

namespace WinApp.Vendedor
{
    public partial class FormPedido : Form, IIdiomasObservador
    {
        Pedido pedidoActual;
        Producto detalleAquitar;

        public FormPedido()
        {
            InitializeComponent();
            pedidoActual = new Pedido();
        }

        private void FormPedido_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
        }

        private void FormPedido_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);

        }

        public void ActualizarTraducciones()
        {
            btnGrabar.Text = "Grabar".Traducir();
            if (pedidoActual.Solicitante == null)
                btnSeleccionarCliente.Text = "Seleccionar cliente".Traducir();
            else
                btnSeleccionarCliente.Text = pedidoActual.Solicitante.Nombre;
        }

        private void btnSeleccionarCliente_Click(object sender, EventArgs e)
        {
            try {
                FormClientes form = new FormClientes();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Cliente unCliente = form.clienteSeleccionado;
                    pedidoActual.Solicitante = unCliente;
                    ActualizarTraducciones();
                }
            }
            catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }

        private void grillaDetalle_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaDetalle.SelectedRows.Count > 0)
            {
                int index = grillaDetalle.SelectedRows[0].Index;
                IEnumerable<Producto> items = (IEnumerable<Producto>)grillaDetalle.DataSource;
                detalleAquitar = items.ElementAt(index);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            pedidoActual.Detalle.Remove(detalleAquitar);
            grillaDetalle.DataSource = null;
            grillaDetalle.DataSource = pedidoActual.Detalle;
            detalleAquitar = null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                FormCatalogo form = new FormCatalogo();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if(!pedidoActual.Detalle.Contains(form.productoSeleccionado))
                        pedidoActual.Detalle.Add(form.productoSeleccionado);
                    grillaDetalle.DataSource = null;
                    grillaDetalle.DataSource = pedidoActual.Detalle;
                }
            }
            catch (Exception ex)
            {
                ex.MostrarEnAlert();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                pedidoActual.Id = Guid.NewGuid();
                List<Producto> items = (List<Producto>)grillaDetalle.DataSource;
                pedidoActual.Detalle = items;
                BLL.GestorPedidos.Current.RegistrarPedido(pedidoActual);

                pedidoActual = new Pedido(); 
                grillaDetalle.DataSource = null;
                detalleAquitar = null;
                ActualizarTraducciones();
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }

        }
    }
}
