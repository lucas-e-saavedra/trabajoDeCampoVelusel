using Dominio;
using Microsoft.VisualBasic;
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
using static Dominio.OrdenDeFabricacion;

namespace WinApp.Fabricante
{
    public partial class FormOrdenesDeFabricacion : Form, IIdiomasObservador
    {
        OrdenDeFabricacion ordenSeleccionada;
        public FormOrdenesDeFabricacion()
        {
            InitializeComponent();
        }

        private void FormOrdenesDeFabricacion_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarGrillaOrdenesDeFabricacion();
        }
        private void FormOrdenesDeFabricacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            //boxOrdenFabricacion.Text = "Orden de fabricación".Traducir();
            //btnSaveAllOrders.Text = "Agendar pedido".Traducir();
        }
        private void ActualizarGrillaOrdenesDeFabricacion(){
            grillaOrdenesFabricacion.DataSource = null;
            IEnumerable<OrdenDeFabricacion> todas = BLL.GestorFabricacion.Current.ListarOrdenesDeFabricacion();
            List<OrdenDeFabricacion> disponibles = todas.Where(item => item.Estado != EnumEstadoOrdenFabricacion.TERMINADO && item.Estado != EnumEstadoOrdenFabricacion.CANCELADO).ToList();
            grillaOrdenesFabricacion.DataSource = disponibles;
        }
        private void grillaOrdenesFabricacion_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaOrdenesFabricacion.SelectedRows.Count > 0)
            {
                int index = grillaOrdenesFabricacion.SelectedRows[0].Index;
                IEnumerable<OrdenDeFabricacion> ordenes = (IEnumerable<OrdenDeFabricacion>)grillaOrdenesFabricacion.DataSource;
                ordenSeleccionada = ordenes.ElementAt(index);

                btnComenzar.Enabled = ordenSeleccionada.Estado == EnumEstadoOrdenFabricacion.AGENDADO;
                btnCerrar.Enabled = ordenSeleccionada.Estado == EnumEstadoOrdenFabricacion.ENFABRICACION;
                btnTerminar.Enabled = ordenSeleccionada.Estado == EnumEstadoOrdenFabricacion.FABRICADO;
            }
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            FormOrdenDeFabricacion form = new FormOrdenDeFabricacion(ordenSeleccionada);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK){
                ActualizarGrillaOrdenesDeFabricacion();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try {
                string titulo = $"{"Cerrar fabricación".Traducir()} {ordenSeleccionada.Objetivo.Nombre}";
                string pregunta = "¿Cuántas unidades logró fabricar?".Traducir();
                string cantidad = Interaction.InputBox(pregunta, titulo);
                float cantidadFabricada = float.Parse(cantidad);
                ordenSeleccionada.Fabricados.Cantidad = cantidadFabricada;
                BLL.GestorFabricacion.Current.CerrarFabricacion(ordenSeleccionada);
                ActualizarGrillaOrdenesDeFabricacion();
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = $"{"Terminar fabricación".Traducir()} {ordenSeleccionada.Objetivo.Nombre}";
                string pregunta = "¿Cuántas unidades cumplen con la calidad requerida?".Traducir();
                string cantidad = Interaction.InputBox(pregunta, titulo);
                float cantidadFabricada = float.Parse(cantidad);
                ordenSeleccionada.Aprobados.Cantidad = cantidadFabricada;
                BLL.GestorFabricacion.Current.VerificarFinOrdenDeFabricacion(ordenSeleccionada);
                ActualizarGrillaOrdenesDeFabricacion();
            }
            catch (Exception ex)
            {
                ex.MostrarEnAlert();
            }
        }
    }
}