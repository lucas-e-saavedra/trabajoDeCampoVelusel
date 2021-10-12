using Servicios.DAL;
using Servicios.Domain;
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
            string llave = ConfigurationManager.AppSettings["claveCifrado"];
            string contraseniaEncriptada = GestorSeguridad.Current.Encriptar(contrasenia, llave);
            string[] criterios = { "Usuario", "Contrasenia" };
            string[] valores = { usuario, contraseniaEncriptada };
            usuarioActual = FabricaDAL.Current.ObtenerRepositorioDeUsuarios().BuscarUno(criterios, valores);

            if(usuarioActual != null) {
                Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Ha iniciado sesión el usuario: " + usuarioActual.UsuarioLogin);
                GestorHistorico.Current.RegistrarBitacora(unEvento);
            }
            return usuarioActual != null;
        }
        public void CerrarSesion()
        {
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Ha cerrado sesión el usuario: " + usuarioActual.UsuarioLogin);
            GestorHistorico.Current.RegistrarBitacora(unEvento);
            usuarioActual = null;
        }
        public bool TieneRolGerente() {
            string permisoEspecial = ConfigurationManager.AppSettings["nombrePermisoEspecial"];
            PatenteFamilia rta = usuarioActual.Permisos.Find(item => item.Nombre == permisoEspecial);
            return rta != null;
        }
    }
}
