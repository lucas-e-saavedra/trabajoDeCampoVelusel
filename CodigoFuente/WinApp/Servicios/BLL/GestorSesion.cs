using Servicios.DAL;
using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System.Configuration;
using System.Linq;

namespace Servicios.BLL
{
    /// <summary>
    /// Este gestor se encarga de manejar la sesión actual del sistema
    /// </summary>
    public class GestorSesion
    {
        /// <summary>
        /// Este es el usuario que está utilizando actualmente el sistema.
        /// </summary>
        public Usuario usuarioActual { get; private set; }
        
        #region Singleton
        private readonly static GestorSesion _instance = new GestorSesion();

        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
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

        /// <summary>
        /// Este método sirve para validar las credenciales del usuario que está intentando ingresar al sistema, además en caso afirmativo asigna a dicho usuario como quien está usando el sistema.
        /// </summary>
        /// <param name="usuario">Nombre de usuario que utiliza para ingresar</param>
        /// <param name="contrasenia">Contraseña del usuario</param>
        /// <returns>Devuelve True si el usuario y la contraseña coinciden con alguno de los usuarios del sistema, devuelve False si los datos no coinciden</returns>
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

        /// <summary>
        /// Este método sirve para cerrar sesión y quitar el usuario actual.
        /// </summary>
        public void CerrarSesion()
        {
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Ha cerrado sesión el usuario: " + usuarioActual.UsuarioLogin);
            GestorHistorico.Current.RegistrarBitacora(unEvento);
            usuarioActual = null;
        }

        /// <summary>
        /// Este metodo sirve para saber si el usuario actual del sistema contiene dentro de sus permisos asignados al permiso de Gerente
        /// </summary>
        /// <returns>Devuelve True si contiene dicho permiso y devuelve False en caso contrario</returns>
        public bool TieneRolGerente() {
            string permisoEspecial = ConfigurationManager.AppSettings["nombrePermisoEspecial"];
            PatenteFamilia rta = usuarioActual.Permisos.Find(item => item.Nombre == permisoEspecial);
            return rta != null;
        }
    }
}
