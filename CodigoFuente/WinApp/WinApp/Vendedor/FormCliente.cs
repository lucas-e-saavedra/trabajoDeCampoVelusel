using Dominio;
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

namespace WinApp.Vendedor
{
    public partial class FormCliente : Form, IIdiomasObservador
    {
        Cliente clienteActual;
        public FormCliente(Cliente unCliente)
        {
            InitializeComponent();
            clienteActual = unCliente;
        }
        private void FormCliente_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);

            List<KeyValuePair<string, string>> lstTiposDocumento = new List<KeyValuePair<string, string>>();
            Array tipos = Enum.GetValues(typeof(Usuario.EnumTipoDocumento));
            foreach (Usuario.EnumTipoDocumento tipo in tipos)
            {
                lstTiposDocumento.Add(new KeyValuePair<string, string>(tipo.ToString(), ((int)tipo).ToString()));
            }
            comboDocumento.DataSource = lstTiposDocumento;
            comboDocumento.DisplayMember = "Key";
            comboDocumento.ValueMember = "Value";

            inputNombre.Text = clienteActual.Nombre;
            comboDocumento.SelectedValue = ((int)clienteActual.TipoDocumento).ToString();
            inputDocumento.Text = clienteActual.NroDocumento;
            inputEmail.Text = clienteActual.Email;
            inputTelefono.Text = clienteActual.Telefono;
            chkHabilitado.Checked = clienteActual.Habilitado;

            chkHabilitado.Visible = GestorSesion.Current.TieneRolGerente();
        }

        private void FormCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "ABM Clientes".Traducir();
            lblNombre.Text = "Nombre".Traducir();
            lblDocumento.Text = "Documento".Traducir();
            lblEmail.Text = "Email".Traducir();
            lblTelefono.Text = "Teléfono".Traducir();
            chkHabilitado.Text = "Habilitado para comprar".Traducir();
            btnGrabar.Text = clienteActual.Id == Guid.Empty ? "Agregar".Traducir() : "Modificar".Traducir();
            btnCancelar.Text = "Cancelar".Traducir();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {
                clienteActual.Nombre = inputNombre.Text;                
                KeyValuePair<string, string> itemSeleccionado = (KeyValuePair<string, string>)comboDocumento.SelectedItem;
                Usuario.EnumTipoDocumento tipoDocumento = (Usuario.EnumTipoDocumento)Enum.Parse(typeof(Usuario.EnumTipoDocumento), itemSeleccionado.Value);
                clienteActual.TipoDocumento = tipoDocumento;
                clienteActual.NroDocumento = inputDocumento.Text;
                clienteActual.Email = inputEmail.Text;
                clienteActual.Telefono = inputTelefono.Text;
                clienteActual.Habilitado = chkHabilitado.Checked;

                if (clienteActual.Id == Guid.Empty) {
                    clienteActual.Id = Guid.NewGuid();
                    BLL.GestorClientes.Current.CrearCliente(clienteActual);
                    this.DialogResult = DialogResult.OK;
                } else {
                    BLL.GestorClientes.Current.ModificarCliente(clienteActual);
                    this.DialogResult = DialogResult.OK;
                }
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
