using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Servicios.Domain;
using Servicios.Extensions;
using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Usuario unUsuario = GestorUsuarios.Current.AutenticarUsuario("", "");
            IEnumerable<Usuario> usuarios = GestorUsuarios.Current.ListarUsuarios();

            button1.Text = "Holaaaa".Traducir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Evento unEvento = new Evento();
            unEvento.fechaYhora = DateTime.Now;
            unEvento.categoria = Evento.CategoriaEvento.DEPURACION;
            unEvento.mensaje = "Este es un mensaje de prueba";
            GestorHistorico.Current.RegistrarBitacora(unEvento);

            IEnumerable<Evento> bitacora = GestorHistorico.Current.ListarBitacora();


            try {
                int x = 0;
                int y = 3 / x;
            } catch (Exception ex) {
                ex.RegistrarError();
            }
            IEnumerable<Error> errores = GestorHistorico.Current.ListarErrores();

            button1.Text = "Chau".Traducir();
        }
    }
}
