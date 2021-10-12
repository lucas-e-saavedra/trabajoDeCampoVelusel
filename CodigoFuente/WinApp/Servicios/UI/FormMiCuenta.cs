using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios.UI
{
    public partial class FormMiCuenta : Form, IIdiomasObservador
    {
        Usuario usuarioActual;
        public FormMiCuenta()
        {
            InitializeComponent();
            usuarioActual = GestorSesion.Current.usuarioActual;
        }

        private void FormMiCuenta_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            inputUsuario.Text = usuarioActual.UsuarioLogin;
            inputNombre.Text = usuarioActual.Nombre;
            inputEmail.Text = usuarioActual.Email;

        }

        private void FormMiCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "Mis datos".Traducir();
            lblUsuario.Text = "Usuario".Traducir();
            lblNombre.Text = "Nombre".Traducir();
            lblEmail.Text = "Email".Traducir();
            lblContrasenia.Text = "Contraseña".Traducir();
            lblRepetirContrasenia.Text = "Repetir contraseña".Traducir();
            btnGrabar.Text = "Modificar".Traducir();
            btnCancelar.Text = "Cancelar".Traducir();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            usuarioActual.UsuarioLogin = inputUsuario.Text;
            usuarioActual.Nombre = inputNombre.Text;
            usuarioActual.Email = inputEmail.Text;
            
            if (inputContrasenia.Text != inputRepetirContrasenia.Text) {
                MessageBox.Show("Las contraseñas no coinciden".Traducir());
                return;
            } else if (inputContrasenia.Text.Length > 0) {
                string nuevaClave = inputContrasenia.Text;
                string llave = ConfigurationManager.AppSettings["claveCifrado"];
                string claveEncriptada = GestorSeguridad.Current.Encriptar(nuevaClave, llave);
                usuarioActual.Contrasenia = claveEncriptada;
            }
            GestorUsuarios.Current.ModificarUsuario(usuarioActual);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
