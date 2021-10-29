﻿using Dominio;
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
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);

            lblIdOrdenFabricacion.Text = ordenDeFabricacionSeleccionada.Id.ToString();
            lblFechaOrdenFabricacion.Text = ordenDeFabricacionSeleccionada.fecha.ToString();
            lblEstadoOrdenFabricacion.Text = ordenDeFabricacionSeleccionada.Estado.ToString();
            StringBuilder ingredientes = new StringBuilder();
            foreach(ProductoMaterial unIngrediente in ordenDeFabricacionSeleccionada.Objetivo.plantillaDeFabricacion.Ingredientes){
                ProductoMaterial tmp = unIngrediente.Copiar();
                tmp.Cantidad = unIngrediente.Cantidad * ordenDeFabricacionSeleccionada.Objetivo.Cantidad;
                ingredientes.Append($"{unIngrediente} {tmp.Cantidad}\n");
            }
            lblIngredientesOrdenFabricacion.Text = ingredientes.ToString();
        }

        private void FormOrdenDeFabricacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            try {
                BLL.GestorFabricacion.Current.ComenzarFabricacion(ordenDeFabricacionSeleccionada);

                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}