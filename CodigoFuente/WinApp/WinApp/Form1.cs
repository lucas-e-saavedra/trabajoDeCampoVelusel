using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Servicios.Domain;
using Servicios.Extensions;
using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using System.Linq;

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
            //Usuario unUsuario = GestorUsuarios.Current.AutenticarUsuario("", "");
            IEnumerable<Patente> patentes = GestorUsuarios.Current.ListarPatentes();
            IEnumerable<Familia> familias = GestorUsuarios.Current.ListarFamilias();
            IEnumerable<Usuario> usuarios = GestorUsuarios.Current.ListarUsuarios();


            /*Patente nuevaPatente = new Patente() {
                IdPatente = Guid.NewGuid(),
                Nombre = "Patente "+letra,
                Vista = "Vista "+letra
            };
            GestorUsuarios.Current.CrearPatente(nuevaPatente);


            Familia unaFamilia = new Familia() {
                IdFamilia = Guid.NewGuid(),
                Nombre = "Familia "+letra
            };
            unaFamilia.ListadoHijos.Add(nuevaPatente);
            unaFamilia.ListadoHijos.AddRange(familias);//.First(item=>item.Nombre== "Rol Ventas"));
            GestorUsuarios.Current.CrearFamilia(unaFamilia);*/

            string letra = "E";
            Usuario unUsuario = new Usuario() {
                IdUsuario = Guid.NewGuid(),
                Nombre = "Usuario "+letra
            };
            unUsuario.Permisos.Add(patentes.First(item => item.Nombre == "Patente A"));
            unUsuario.Permisos.Add(familias.First(item => item.Nombre == "Rol Ventas" ));
            GestorUsuarios.Current.CrearUsuario(unUsuario);

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
