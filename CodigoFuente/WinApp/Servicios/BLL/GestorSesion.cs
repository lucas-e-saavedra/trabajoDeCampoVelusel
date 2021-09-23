using Servicios.DAL;
using Servicios.Domain.CompositeSeguridad;
using System.Configuration;
using System.Linq;

namespace Servicios.BLL
{
    public class GestorSesion
    {
        public Usuario usuarioActual { get; private set; }
        
        #region Singleton
        private readonly static GestorSesion _instance = new GestorSesion();

        public static GestorSesion Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorSesion()
        { }
        #endregion

        public bool AutenticarUsuario(string usuario, string contrasenia)
        {
            //usuarioActual = GestorUsuarios.Current.ListarUsuarios().First();
            //return true;

            string llave = ConfigurationManager.AppSettings["claveCifrado"];
            string contraseniaEncriptada = GestorSeguridad.Current.Encriptar(contrasenia, llave);
            string[] criterios = { "Usuario", "Contrasenia" };
            string[] valores = { usuario, contraseniaEncriptada };
            usuarioActual = FabricaDAL.Current.ObtenerRepositorioDeUsuarios().BuscarUno(criterios, valores);
            return usuarioActual != null;
        }

        public void CerrarSesion()
        {
            usuarioActual = null;
        }
    }
}
