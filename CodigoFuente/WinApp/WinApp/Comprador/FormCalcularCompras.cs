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
    public partial class FormCalcularCompras : Form, IIdiomasObservador
    {
        OrdenDeCompra unaOrdenDeCompra;
        public FormCalcularCompras()
        {
            InitializeComponent();
        }

        private void FormCalcularCompras_Load(object sender, EventArgs e)
        {
            grillaMateriales.AutoGenerateColumns = false;
            grillaCompras.AutoGenerateColumns = false;
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarTraducciones();
            timeDesde.MinDate = DateTime.Today.AddDays(1);
            grillaCompras.DataSource = new List<OrdenDeCompra>();
        }

        private void FormCalcularCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "Calcular compras".Traducir();
            lblExplicacion.Text = "Analizar las órdenes de fabricacion entre estas fechas para calcular las compras sugeridas".Traducir();
            btnGrabarOrdenes.Text = "Grabar órdenes de compra".Traducir();
            grupoOrdenCompra.Text = "Orden de compra".Traducir();
            lblMaterialOrdenCompra.Text = "Descripción del objetivo de la compra".Traducir();
            lblFechaPlanificada.Text = "Fecha planificada para efectuar la compra".Traducir();
        }

        private void timeDesde_ValueChanged(object sender, EventArgs e)
        {
            timeHasta.MinDate = timeDesde.Value;
            actualizarGrillaMateriales();
        }

        private void timeHasta_ValueChanged(object sender, EventArgs e)
        {
            actualizarGrillaMateriales();
        }
        private void actualizarGrillaMateriales() {
            grillaMateriales.DataSource = null;
            IEnumerable<Material> materiales = BLL.GestorCompras.Current.CalcularMaterialesNecesarios(timeDesde.Value, timeHasta.Value);
            grillaMateriales.DataSource = materiales;
        }

        private void grillaMateriales_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaMateriales.SelectedRows.Count > 0) {
                int index = grillaMateriales.SelectedRows[0].Index;
                IEnumerable<Material> materiales = (IEnumerable<Material>)grillaMateriales.DataSource;
                Material materialSeleccionado = materiales.ElementAt(index);

                List<OrdenDeCompra> compras = (List<OrdenDeCompra>)grillaCompras.DataSource;
                if (compras == null) {
                    compras = new List<OrdenDeCompra>();
                }
                unaOrdenDeCompra = compras.FirstOrDefault(item => item.Objetivo.Id == materialSeleccionado.Id);
                if(unaOrdenDeCompra == null) {
                    unaOrdenDeCompra = BLL.GestorCompras.Current.CrearOrdenDeCompra(DateTime.Today, materialSeleccionado);
                    mostrarOrdenDeCompra();
                }
            }
        }

        private void grillaCompras_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaCompras.SelectedRows.Count > 0) {
                int index = grillaCompras.SelectedRows[0].Index;
                List<OrdenDeCompra> compras = (List<OrdenDeCompra>)grillaCompras.DataSource;
                unaOrdenDeCompra = compras.ElementAt(index);
                mostrarOrdenDeCompra();
            }
        }
        private void mostrarOrdenDeCompra()
        {
            lblMaterialOrdenCompra.Text = $"{unaOrdenDeCompra.Objetivo.Cantidad} ({unaOrdenDeCompra.Objetivo.Unidad}) {unaOrdenDeCompra.Objetivo.Nombre}";
            if (unaOrdenDeCompra.FechaObjetivo != DateTime.MinValue);
              timeOrdenCompra.Value = unaOrdenDeCompra.FechaObjetivo;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            unaOrdenDeCompra.FechaObjetivo = timeOrdenCompra.Value;

            List<OrdenDeCompra> compras = (List<OrdenDeCompra>)grillaCompras.DataSource;
            OrdenDeCompra ordenDeCompraSimilar = compras.FirstOrDefault(item => item.Id == unaOrdenDeCompra.Id);
            if(ordenDeCompraSimilar == null){
                compras.Add(unaOrdenDeCompra);
            }
            grillaCompras.DataSource = null;
            grillaCompras.DataSource = compras;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            List<OrdenDeCompra> compras = (List<OrdenDeCompra>)grillaCompras.DataSource;
            unaOrdenDeCompra = compras.FirstOrDefault(item => item.Id == unaOrdenDeCompra.Id);
            if (unaOrdenDeCompra != null) {
                compras.RemoveAll(item => item.Id == unaOrdenDeCompra.Id);
                grillaCompras.DataSource = null;
                grillaCompras.DataSource = compras;
            }
        }

        private void btnGrabarOrdenes_Click(object sender, EventArgs e)
        {
            try {
                List<OrdenDeCompra> compras = (List<OrdenDeCompra>)grillaCompras.DataSource;
                BLL.GestorCompras.Current.GrabarOrdenesDeCompraSugeridas(timeDesde.Value, compras);

                grillaCompras.DataSource = null;
                grillaCompras.DataSource = new List<OrdenDeCompra>();
                actualizarGrillaMateriales();
            } catch (Exception ex){
                ex.MostrarEnAlert();
            }
        }

    }
}
