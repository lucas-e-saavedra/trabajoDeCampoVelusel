using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using Servicios.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinApp
{
#pragma warning disable 1591
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
        }

        private void Form_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "Ingresar".Traducir();
            this.lblUsuario.Text = "Ingrese su usuario".Traducir();
            this.lblContrasenia.Text = "Ingrese su contraseña".Traducir();
            this.btnIngresar.Text = "Ingresar".Traducir();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try {
                if (GestorSesion.Current.AutenticarUsuario(inputUsuario.Text, inputContrasenia.Text)) {
                    this.DialogResult = DialogResult.OK;
                } else {
                    string advertencia = "El usuario y contraseña no coinciden".Traducir();
                    MessageBox.Show(advertencia);
                }
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }

        private void inputContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13){
                btnIngresar_Click(sender, e);
            }
        }
    }
}
