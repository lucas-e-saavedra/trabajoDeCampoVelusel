using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Servicios.BLL
{
    public class GestorNotificaciones
    {
        #region Singleton
        private readonly static GestorNotificaciones _instance = new GestorNotificaciones();

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
