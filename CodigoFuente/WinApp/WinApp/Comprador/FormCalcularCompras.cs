using Dominio;
using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp.Comprador
{
    public partial class FormCalcularCompras : Form, IIdiomasObservador
    {
        BindingList<OrdenDeCompra> nuevasOC = new BindingList<OrdenDeCompra>();
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
            nuevasOC.Clear();
            grillaCompras.DataSource = nuevasOC;
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

            Cantidad.HeaderText = "Cantidad".Traducir();
            Unidad.HeaderText = "Unidad de medida".Traducir();
            Nombre.HeaderText = "Nombre".Traducir();

            FechaObjetivo.HeaderText = "Fecha planificada".Traducir();
            Objetivo.HeaderText = "Objetivo".Traducir();
            Estado.HeaderText = "Estado".Traducir();

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

                unaOrdenDeCompra = nuevasOC.FirstOrDefault(item => item.Objetivo.Id == materialSeleccionado.Id);
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
                unaOrdenDeCompra = nuevasOC.ElementAt(index);
                mostrarOrdenDeCompra();
            }
        }
        private void mostrarOrdenDeCompra()
        {
            lblMaterialOrdenCompra.Text = $"{unaOrdenDeCompra.Objetivo?.Cantidad} ({unaOrdenDeCompra.Objetivo?.Unidad}) {unaOrdenDeCompra.Objetivo?.Nombre}";
            if (unaOrdenDeCompra.FechaObjetivo != DateTime.MinValue)
              timeOrdenCompra.Value = unaOrdenDeCompra.FechaObjetivo;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            unaOrdenDeCompra.FechaObjetivo = timeOrdenCompra.Value;

            OrdenDeCompra ordenDeCompraSimilar = nuevasOC.FirstOrDefault(item => item.Id == unaOrdenDeCompra.Id);
            if(ordenDeCompraSimilar == null){
                nuevasOC.Add(unaOrdenDeCompra);
            }
            grillaCompras.DataSource = null;
            grillaCompras.DataSource = nuevasOC;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            unaOrdenDeCompra = nuevasOC.FirstOrDefault(item => item.Id == unaOrdenDeCompra.Id);
            int indexToDelete = nuevasOC.IndexOf(unaOrdenDeCompra);
            if (unaOrdenDeCompra != null && indexToDelete > -1) {
                nuevasOC.Remove(unaOrdenDeCompra);
                grillaCompras.DataSource = null;
                grillaCompras.DataSource = nuevasOC;
            }
        }

        private void btnGrabarOrdenes_Click(object sender, EventArgs e)
        {
            try {
                BLL.GestorCompras.Current.GrabarOrdenesDeCompraSugeridas(timeDesde.Value, nuevasOC);
                nuevasOC.Clear();
                grillaCompras.DataSource = null;
                grillaCompras.DataSource = nuevasOC;
                actualizarGrillaMateriales();
            } catch (Exception ex){
                ex.MostrarEnAlert();
            }
        }

    }
}
