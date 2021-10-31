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
    public partial class FormOrdenDeCompra : Form, IIdiomasObservador
    {
        OrdenDeCompra ordenDeCompraSeleccionada;
        public FormOrdenDeCompra(OrdenDeCompra unaOrdenDeCompra)
        {
            InitializeComponent();
            ordenDeCompraSeleccionada = unaOrdenDeCompra;
        }

        private void FormOrdenDeCompra_Load(object sender, EventArgs e)
        {
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarTraducciones();

            lblIdOrdenCompra.Text = ordenDeCompraSeleccionada.Id.ToString();
            lblMaterialOrdenCompra.Text = ordenDeCompraSeleccionada.Objetivo.ToString();
            lblCantidadOrdenCompra.Text = ordenDeCompraSeleccionada.Objetivo.Cantidad.ToString();
            lblFechaOrdenCompra.Text = ordenDeCompraSeleccionada.FechaObjetivo.ToString();
            inputCantidadComprados.Text = "";
            timeFechaEstimada.Value = DateTime.Today;
            inputCantidadRecibidos.Enabled = chkRecibido.Checked;
            timeFechaRecepcion.Enabled = chkRecibido.Checked;

            if(ordenDeCompraSeleccionada.Comprados.Cantidad > 0) {
                inputCantidadComprados.Text = ordenDeCompraSeleccionada.Comprados.Cantidad.ToString();
                timeFechaEstimada.Value = ordenDeCompraSeleccionada.FechaEstimadaRecepcion;
            }
            

        }
        private void FormOrdenDeCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {
                ordenDeCompraSeleccionada.Comprados.Cantidad = float.Parse(inputCantidadComprados.Text);
                ordenDeCompraSeleccionada.FechaEstimadaRecepcion = timeFechaEstimada.Value;
                BLL.GestorCompras.Current.ComprarOrdenDeComprar(ordenDeCompraSeleccionada);
                if (chkRecibido.Checked) {
                    ordenDeCompraSeleccionada.Recibidos.Cantidad = float.Parse(inputCantidadRecibidos.Text);
                    ordenDeCompraSeleccionada.FechaRealRecepcion = timeFechaRecepcion.Value;
                    BLL.GestorCompras.Current.RecibirOrdenDeCompra(ordenDeCompraSeleccionada);
                }
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void chkRecibido_CheckedChanged(object sender, EventArgs e)
        {
            inputCantidadRecibidos.Enabled = chkRecibido.Checked;
            timeFechaRecepcion.Enabled = chkRecibido.Checked;
        }
    }
}
