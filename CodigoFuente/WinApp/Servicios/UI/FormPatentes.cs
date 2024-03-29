﻿using Microsoft.VisualBasic;
using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
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

namespace Servicios.UI
{
#pragma warning disable 1591
    public partial class FormPatentes : Form, IIdiomasObservador
    {
        private Patente patenteSeleccionada = null;
        public FormPatentes()
        {
            InitializeComponent();
        }

        private void FormPatentes_Load(object sender, EventArgs e)
        {
            grillaPatentes.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            grillaPatentes.DataSource = GestorUsuarios.Current.ListarPatentes();
        }

        private void FormPatentes_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM Patentes".Traducir();
            btnAgregar.Text = "Agregar".Traducir();
            btnBorrar.Text = "Borrar".Traducir();
            btnModificar.Text = "Modificar".Traducir();

            Nombre.HeaderText= "Nombre".Traducir();
            Vista.HeaderText = "Vista".Traducir();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormPatente form = new FormPatente(new Patente());
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK) {
                grillaPatentes.DataSource = GestorUsuarios.Current.ListarPatentes();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), "Borrar".Traducir(), MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try {
                    GestorUsuarios.Current.BorrarPatente(patenteSeleccionada);
                    grillaPatentes.DataSource = null;
                    grillaPatentes.DataSource = GestorUsuarios.Current.ListarPatentes();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormPatente form = new FormPatente(patenteSeleccionada);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                grillaPatentes.DataSource = null;
                grillaPatentes.DataSource = GestorUsuarios.Current.ListarPatentes();
            }
        }

        private void grillaPatentes_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaPatentes.SelectedRows.Count > 0) {
                int index = grillaPatentes.SelectedRows[0].Index;
                IEnumerable<Patente> patentes = (IEnumerable<Patente>)grillaPatentes.DataSource;
                patenteSeleccionada = patentes.ElementAt(index);
            }
        }
    }
}
