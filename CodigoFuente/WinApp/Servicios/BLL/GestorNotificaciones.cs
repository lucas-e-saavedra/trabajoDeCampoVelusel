using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Servicios.BLL
{
    /// <summary>
    /// Este gestor se encarga de enviar notificaciones a traves de canales externos al sistema
    /// </summary>
    public class GestorNotificaciones
    {
        #region Singleton
        private readonly static GestorNotificaciones _instance = new GestorNotificaciones();

        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
        public static GestorNotificaciones Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorNotificaciones()
        { }
        #endregion

        /// <summary>
        /// Este metodo envía en forma sincronica un mail utilizando la casilla de correo que se especificó en el app.settings
        /// </summary>
        /// <param name="destinatario">Dirección de correo electronico a la que se le enviará el correo</param>
        /// <param name="titulo">Asunto del correo que se va a enviar</param>
        /// <param name="contenido">Aqui va el cuerpo del mensaje a enviar</param>
        /// <returns>Devuelve True si se envió el correo y devuelve False si falló el envío</returns>
        public bool EnviarMail(string destinatario, string titulo, string contenido)
        {
            bool result = false;
            string miCuenta = ConfigurationManager.AppSettings["emailQueEnviaContrasenias"];
            string miClave = ConfigurationManager.AppSettings["claveQueEnviaContrasenias"];
            string emailHost = ConfigurationManager.AppSettings["hostQueEnviaContrasenias"];
            int emailPort = int.Parse(ConfigurationManager.AppSettings["puertoQueEnviaContrasenias"]);

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
                try {
                    smtp.Send(email);
                    result = true;
                } catch (Exception ex) {
                    throw new Exception("No se pudo enviar el email", ex.InnerException);
                } finally {
                    smtp.Dispose();
                }
            }
            return result;
        }
    }
}
