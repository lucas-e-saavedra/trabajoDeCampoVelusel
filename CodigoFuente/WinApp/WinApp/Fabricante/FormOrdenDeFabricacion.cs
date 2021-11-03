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

namespace WinApp.Fabricante
{
    public partial class FormOrdenDeFabricacion : Form, IIdiomasObservador
    {
        OrdenDeFabricacion ordenDeFabricacionSeleccionada;
        public FormOrdenDeFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            InitializeComponent();
            ordenDeFabricacionSeleccionada = unaOrdenDeFabricacion;
        }

        private void FormOrdenDeFabricacion_Load(object sender, EventArgs e)
        {
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarTraducciones();
        }

        private void FormOrdenDeFabricacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "Orden de fabricación".Traducir();
            btnComenzar.Text = "Comenzar fabricación".Traducir();
            btnCancelar.Text = "Cancelar".Traducir();


            lblIdOrdenFabricacion.Text = $"{"Identificador".Traducir()}: {ordenDeFabricacionSeleccionada.Id}";
            //string siguienteOF = ordenSeleccionada.OrdenDeFabricacionPosterior?.Id.ToString() ?? "ninguna".Traducir();
            //lblOFposterior.Text = $"{"Siguiente Orden de Fabricación".Traducir()} {siguienteOF}";
            lblFechaOrdenFabricacion.Text = $"{"Fecha planificada".Traducir()}: {ordenDeFabricacionSeleccionada.FechaPlanificada}";
            lblEstadoOrdenFabricacion.Text = $"{"Estado".Traducir()}: {ordenDeFabricacionSeleccionada.Estado}";
            lblObjetivoOrdenFabricacion.Text = $"{"Objetivo".Traducir()}:  {ordenDeFabricacionSeleccionada.Objetivo.Cantidad} ({ordenDeFabricacionSeleccionada.Objetivo.Unidad}) {ordenDeFabricacionSeleccionada.Objetivo.Nombre}";
            StringBuilder ingredientes = new StringBuilder();
            foreach (ProductoMaterial unIngrediente in ordenDeFabricacionSeleccionada.Objetivo.plantillaDeFabricacion.Ingredientes)
            {
                ProductoMaterial tmp = unIngrediente.Copiar();
                tmp.Cantidad = unIngrediente.Cantidad * ordenDeFabricacionSeleccionada.Objetivo.Cantidad;
                ingredientes.Append($"{unIngrediente} {tmp.Cantidad}\n");
            }
            textIngredientes.Text = ingredientes.ToString();
            lblReposoNecesario.Text = $"{"Horas de reposo necesarias".Traducir()}: {ordenDeFabricacionSeleccionada.Objetivo.plantillaDeFabricacion.ReposoNecesario}";

        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            try {
                BLL.GestorFabricacion.Current.ComenzarFabricacion(ordenDeFabricacionSeleccionada);
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                ex.MostrarEnAlert();
                FormReprogramarOrdenFabricacion form = new FormReprogramarOrdenFabricacion(ordenDeFabricacionSeleccionada);
                this.DialogResult = form.ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}