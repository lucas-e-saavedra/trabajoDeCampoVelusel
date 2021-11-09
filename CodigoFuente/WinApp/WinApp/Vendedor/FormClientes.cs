using Servicios.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Servicios.Extensions;
using Servicios.Domain.CompositeSeguridad;

namespace WinApp.Vendedor
{
    public partial class FormClientes : Form, IIdiomasObservador
    {
        IEnumerable<Cliente> clientes;
        public Cliente clienteSeleccionado = null;
        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            grillaClientes.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarGrilla();
        }
        private void FormClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "ABM Clientes".Traducir();
            btnSeleccionar.Text = "Seleccionar".Traducir();
            btnNoSeleccionar.Text = "Ninguno".Traducir();
            btnAgregar.Text = "Agregar".Traducir();
            btnHabilitar.Text = "Habilitar".Traducir();
            btnModificar.Text = "Modificar".Traducir();

            TipoDocumento.HeaderText = "Tipo Documento".Traducir();
            NroDocumento.HeaderText = "Documento".Traducir();
            Nombre.HeaderText = "Nombre".Traducir();
            Email.HeaderText = "Email".Traducir();
            Telefono.HeaderText = "Teléfono".Traducir();
            Habilitado.HeaderText = "Habilitado para comprar".Traducir();
            lblFiltroDocumento.Text = "Filtrar por documento".Traducir();
            lblFiltroNombre.Text = "Filtrar por nombre".Traducir();
            lblFiltroEmail.Text = "Filtrar por email".Traducir();
        }
        private void ActualizarGrilla()
        {
            grillaClientes.DataSource = null;
            clientes = BLL.GestorClientes.Current.ListarClientes();
            FiltrarGrilla();
            btnSeleccionar.Visible = this.Modal;
            btnNoSeleccionar.Visible = this.Modal;
            btnAgregar.Visible = !this.Modal;
            btnModificar.Visible = !this.Modal;
            btnHabilitar.Visible = !this.Modal && GestorSesion.Current.TieneRolGerente();
        }
        private void FiltrarGrilla() {
            IEnumerable<Cliente> clientesFiltrados = clientes.ToList();
            if (inputFiltroDocumento.Text.Length > 0)
                clientesFiltrados = clientesFiltrados.Where(item => item.NroDocumento.ToString().ToLower().Contains(inputFiltroDocumento.Text.ToLower())).ToList();
            if (inputFiltroNombre.Text.Length > 0)
                clientesFiltrados = clientesFiltrados.Where(item => item.Nombre.ToString().ToLower().Contains(inputFiltroNombre.Text.ToLower())).ToList();
            if (inputFiltroEmail.Text.Length > 0)
                clientesFiltrados = clientesFiltrados.Where(item => item.Email.ToString().ToLower().Contains(inputFiltroEmail.Text.ToLower())).ToList();
            grillaClientes.DataSource = clientesFiltrados;
        }
        private void grillaClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaClientes.SelectedRows.Count > 0)
            {
                int index = grillaClientes.SelectedRows[0].Index;
                IEnumerable<Cliente> clientes = (IEnumerable<Cliente>)grillaClientes.DataSource;
                clienteSeleccionado = clientes.ElementAt(index);
                if (clienteSeleccionado.Habilitado) {
                    btnHabilitar.Text = "Deshabilitar".Traducir();
                } else {
                    btnHabilitar.Text = "Habilitar".Traducir();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormCliente form = new FormCliente(new Cliente());
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK){
                ActualizarGrilla();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormCliente form = new FormCliente(clienteSeleccionado);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK) {
                ActualizarGrilla();
            }
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), btnHabilitar.Text, MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try {
                    clienteSeleccionado.Habilitado = !clienteSeleccionado.Habilitado;
                    BLL.GestorClientes.Current.ModificarCliente(clienteSeleccionado);
                    ActualizarGrilla();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnNoSeleccionar_Click(object sender, EventArgs e)
        {
            clienteSeleccionado = null;
            this.DialogResult = DialogResult.OK;
        }

        private void inputFiltroDocumento_TextChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void inputFiltroNombre_TextChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }

        private void inputFiltroEmail_TextChanged(object sender, EventArgs e)
        {
            FiltrarGrilla();
        }
    }
}
