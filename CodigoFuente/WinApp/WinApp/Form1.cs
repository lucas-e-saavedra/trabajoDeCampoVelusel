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
            IEnumerable<Patente> patentes = GestorUsuarios.Current.ListarPatentes();
            IEnumerable<Familia> familias = GestorUsuarios.Current.ListarFamilias();
            IEnumerable<Usuario> usuarios = GestorUsuarios.Current.ListarUsuarios();

            
            /*Patente nuevaPatente1 = new Patente() {
                IdPatente = Guid.NewGuid(),
                Nombre = "Patente A1",
                Vista = "Vista A1"
            };
            GestorUsuarios.Current.CrearPatente(nuevaPatente1);
            Patente nuevaPatente2 = new Patente()
            {
                IdPatente = Guid.NewGuid(),
                Nombre = "Patente A2",
                Vista = "Vista A2"
            };
            GestorUsuarios.Current.CrearPatente(nuevaPatente2);

            Familia unaFamilia = new Familia() {
                IdFamilia = Guid.NewGuid(),
                Nombre = "Familia A"
            };
            unaFamilia.ListadoHijos.Add(nuevaPatente1);
            unaFamilia.ListadoHijos.Add(nuevaPatente2);
            GestorUsuarios.Current.CrearFamilia(unaFamilia);
            
            Usuario unUsuario = new Usuario() {
                IdUsuario = Guid.NewGuid(),
                UsuarioLogin = "dakota",
                Contrasenia = "clave",
                Nombre = "dakota, la mamá de duke",
                Email = "dakota@yopmail.com",
                TipoDocumento = Usuario.EnumTipoDocumento.DNI,
                NroDocumento = "123456789"
            };
            unUsuario.Permisos.Add(unaFamilia);
            GestorUsuarios.Current.CrearUsuario(unUsuario);*/
            Usuario otroUsuario = GestorUsuarios.Current.AutenticarUsuario("dakota", "r3Q8O");
            GestorUsuarios.Current.BlanquearClave(Guid.Parse("364e80c3-386f-4af7-9000-2e8e3138b79d"));
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
