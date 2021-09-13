using Servicios.DAL;
using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.BLL
{
    public class GestorUsuarios
    {
        #region Singleton
        private readonly static GestorUsuarios _instance = new GestorUsuarios();

        public static GestorUsuarios Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorUsuarios()
        { }
        #endregion

        public Usuario AutenticarUsuario(string usuario, string clave) {
            string claveEncriptada = GestorSeguridad.Current.Encriptar(clave);
            return FabricaDAL.Current.ObtenerRepositorioDeUsuarios().BuscarUno("Usuario¿Contrasenia", usuario+"¿"+claveEncriptada);
        }
        public void BlanquearClave(Guid guidUsuario) {
            Usuario unUsuario = FabricaDAL.Current.ObtenerRepositorioDeUsuarios().BuscarUno("IdUsuario", guidUsuario.ToString());
            string nuevaClave = GestorSeguridad.Current.GenerarClaveAleatoria();
            string claveEncriptada = GestorSeguridad.Current.Encriptar(nuevaClave);
            unUsuario.Contrasenia = claveEncriptada;

            EnviarContrasenia(unUsuario.Email, "Bienvenido", "Tu nueva clave es: " + nuevaClave);
            FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Modificar(unUsuario);
        }
        public void BorrarFamila(string usuario) { }
        public void BorrarPermiso(string usuario) { }
        public void CrearFamilia(Familia unaFamilia) {
            FabricaDAL.Current.ObtenerRepositorioDeFamilias().Agregar(unaFamilia);
        }
        public void CrearPatente(Patente unaPatente) {
            FabricaDAL.Current.ObtenerRepositorioDePatentes().Agregar(unaPatente);
        }
        public void CrearUsuario(Usuario usuario) {
            string nuevaClave = GestorSeguridad.Current.GenerarClaveAleatoria();
            string claveEncriptada = GestorSeguridad.Current.Encriptar(nuevaClave);
            usuario.Contrasenia = claveEncriptada;
            FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Agregar(usuario);
            EnviarContrasenia(usuario.Email, "Bienvenido", "Tu nueva clave es: " + nuevaClave);
        }

        private void EnviarContrasenia(string destinatario, string titulo, string contenido)
        {
            string miCuenta = "tiendademascotasnarizotas@gmail.com";
            string miClave = "perr0pulgoso";
            string emailHost = "smtp.gmail.com";
            int emailPort = 587;      

            using (MailMessage email = new MailMessage(miCuenta, destinatario))
            {
                email.Subject = titulo;
                email.Body = contenido;
                email.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient(emailHost, emailPort);
                smtp.EnableSsl = true;
                NetworkCredential credential = new NetworkCredential(miCuenta, miClave);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credential;
                try
                {
                    smtp.Send(email);
                }
                catch (Exception ex)
                {
                    throw new Exception("No se pudo enviar el email", ex.InnerException);
                }
                finally
                {
                    smtp.Dispose();
                }
            }
        }
        public IEnumerable<Familia> ListarFamilias() {
            return FabricaDAL.Current.ObtenerRepositorioDeFamilias().Listar();
        }
        public IEnumerable<Patente> ListarPatentes() {
            return FabricaDAL.Current.ObtenerRepositorioDePatentes().Listar();
        }
        public IEnumerable<Usuario> ListarUsuarios() {
            return FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Listar();
        }
        public void ModificarFamilia(string usuario) { }
        public void ModificarPermiso(string usuario) { }
        public void ModificarUsuario(string usuario) { }

    }
}
