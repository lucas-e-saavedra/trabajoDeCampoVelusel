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

            
            Patente otraPatente = new Patente() {
                IdPatente = Guid.NewGuid(),
                Nombre = "Patente F1",
                Vista = "Vista F1"
            };
            GestorUsuarios.Current.CrearPatente(otraPatente);
            otraPatente.Nombre = "Patente F2";
            otraPatente.Vista = "Vista F2";
            GestorUsuarios.Current.ModificarPatente(otraPatente);
            
            Patente segundaPatente = new Patente()
            {
                IdPatente = Guid.NewGuid(),
                Nombre = "Patente G2",
                Vista = "Vista G2"
            };
            GestorUsuarios.Current.CrearPatente(segundaPatente);

            Familia otraFamilia = new Familia() {
                IdFamilia = Guid.NewGuid(),
                Nombre = "Familia C"
            };
            otraFamilia.ListadoHijos.Add(otraPatente);
            otraFamilia.ListadoHijos.Add(segundaPatente);
            GestorUsuarios.Current.CrearFamilia(otraFamilia);
            Patente segundaPatenteB = new Patente()
            {
                IdPatente = Guid.NewGuid(),
                Nombre = "Patente G3",
                Vista = "Vista G3"
            };
            GestorUsuarios.Current.CrearPatente(segundaPatenteB);
            otraFamilia.ListadoHijos.RemoveAt(0);
            otraFamilia.ListadoHijos.Add(segundaPatenteB);
            GestorUsuarios.Current.ModificarFamilia(otraFamilia);

            Patente terceraPatente = new Patente()
            {
                IdPatente = Guid.NewGuid(),
                Nombre = "Patente H2",
                Vista = "Vista H2"
            };
            GestorUsuarios.Current.CrearPatente(terceraPatente);
            Familia segundaFamilia = new Familia()
            {
                IdFamilia = Guid.NewGuid(),
                Nombre = "Familia D"
            };
            segundaFamilia.ListadoHijos.Add(terceraPatente);
            segundaFamilia.ListadoHijos.Add(otraFamilia);
            GestorUsuarios.Current.CrearFamilia(segundaFamilia);
            Familia terceraFamilia = new Familia()
            {
                IdFamilia = Guid.NewGuid(),
                Nombre = "Familia E"
            };
            GestorUsuarios.Current.CrearFamilia(terceraFamilia);
            segundaFamilia.ListadoHijos.Add(terceraFamilia);
            GestorUsuarios.Current.ModificarFamilia(segundaFamilia);

            Usuario unUsuario = new Usuario()
            {
                IdUsuario = Guid.NewGuid(),
                UsuarioLogin = "dakota",
                Contrasenia = "clave",
                Nombre = "dakota, la mamá de duke",
                Email = "dakota@yopmail.com",
                TipoDocumento = Usuario.EnumTipoDocumento.DNI,
                NroDocumento = "123456789"
            };
            unUsuario.Permisos.Add(segundaFamilia); //familia d
            unUsuario.Permisos.Add(otraPatente); //patente f2
            GestorUsuarios.Current.CrearUsuario(unUsuario);

            unUsuario.Permisos.Clear();
            unUsuario.Nombre = "dakota es una perra chancha";
            unUsuario.Permisos.Add(terceraFamilia); //familia e
            unUsuario.Permisos.Add(terceraPatente); //patente h2
            GestorUsuarios.Current.ModificarUsuario(unUsuario);




            GestorUsuarios.Current.BorrarUsuario(unUsuario);
            GestorUsuarios.Current.BorrarFamila(segundaFamilia);
            GestorUsuarios.Current.BorrarFamila(otraFamilia);
            GestorUsuarios.Current.BorrarFamila(terceraFamilia);

            GestorUsuarios.Current.BorrarPatente(otraPatente);
            GestorUsuarios.Current.BorrarPatente(segundaPatente);
            GestorUsuarios.Current.BorrarPatente(segundaPatenteB);
            GestorUsuarios.Current.BorrarPatente(terceraPatente);

            //Usuario otroUsuario = GestorUsuarios.Current.AutenticarUsuario("dakota", "r3Q8O");
            //GestorUsuarios.Current.BlanquearClave(Guid.Parse("364e80c3-386f-4af7-9000-2e8e3138b79d"));
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
