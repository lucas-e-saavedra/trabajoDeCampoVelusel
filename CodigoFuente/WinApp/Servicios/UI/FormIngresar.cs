using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using Servicios.Extensions;
using System;
using System.Windows.Forms;

namespace WinApp
{
    public partial class FormIngresar : Form, IIdiomasObservador
    {
        public FormIngresar()
        {
            InitializeComponent();
        }
        private void Form_Login_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            //TODO: quitar esto
            inputUsuario.Text = "lucas.saavedra";
            inputContrasenia.Text = "yQZZX";
        }

        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            this.lblUsuario.Text = "Ingrese su usuario".Traducir();
            this.lblContrasenia.Text = "Ingrese su contraseña".Traducir();
            this.btnIngresar.Text = "Ingresar".Traducir();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario unUsuario = GestorUsuarios.Current.AutenticarUsuario(inputUsuario.Text, inputContrasenia.Text);
            if (unUsuario != null) {
                this.Close();
            } else {
                string advertencia = "El usuario y contraseña no coinciden".Traducir();
                MessageBox.Show(advertencia);
            }
        }
    }
}
