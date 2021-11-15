using Servicios.DAL;
using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Servicios.BLL
{
    /// <summary>
    /// Este gestor se encarga de manejar los usuarios que interactuan con el sistema y sus correspondientes permisos
    /// </summary>
    public class GestorUsuarios
    {
        #region Singleton
        private readonly static GestorUsuarios _instance = new GestorUsuarios();

        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
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

        /// <summary>
        /// Este método se utiliza para generar una nueva clave para un usuario y enviarsela por correo electrónico.
        /// </summary>
        /// <param name="guidUsuario">Id del usuario a quien se le blanqueará la clave</param>
        public void BlanquearClave(Guid guidUsuario) {
            if (guidUsuario == GestorSesion.Current.usuarioActual.IdUsuario)
                throw new Exception("No está permitido blanquear tu propia clave");

            string[] criterios = { "IdUsuario" };
            string[] valores = { guidUsuario.ToString() };
            Usuario unUsuario = FabricaDAL.Current.ObtenerRepositorioDeUsuarios().BuscarUno(criterios, valores);
            string nuevaClave = GestorSeguridad.Current.GenerarClaveAleatoria();
            string llave = ConfigurationManager.AppSettings["claveCifrado"];
            string claveEncriptada = GestorSeguridad.Current.Encriptar(nuevaClave, llave);
            unUsuario.Contrasenia = claveEncriptada;

            GestorNotificaciones.Current.EnviarMail(unUsuario.Email, "Bienvenido", "Tu nueva clave es: " + nuevaClave);
            FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Modificar(unUsuario);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Se blanqueó la clave del usuario: " + unUsuario.UsuarioLogin);
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

        /// <summary>
        /// Este método se utiliza para borrar una familia de permisos
        /// </summary>
        /// <param name="unaFamilia">Familia a borrar</param>
        public void BorrarFamila(Familia unaFamilia) {
            FabricaDAL.Current.ObtenerRepositorioDeFamilias().Borrar(unaFamilia);
        }

        /// <summary>
        /// Este método se utiliza para borrar un permiso
        /// </summary>
        /// <param name="unaPatente">Patente a borrar</param>
        public void BorrarPatente(Patente unaPatente) {
            FabricaDAL.Current.ObtenerRepositorioDePatentes().Borrar(unaPatente);
        }

        /// <summary>
        /// Este método se utiliza para borrar un usuario
        /// </summary>
        /// <param name="unUsuario">Usuario a borrar</param>
        public void BorrarUsuario(Usuario unUsuario)
        {
            FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Borrar(unUsuario);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Se eliminó el usuario: " + unUsuario.UsuarioLogin);
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

        /// <summary>
        /// Este método se utiliza para crear una familia de permisos
        /// </summary>
        /// <param name="unaFamilia">Familia a agregar</param>
        public void CrearFamilia(Familia unaFamilia) {
            FabricaDAL.Current.ObtenerRepositorioDeFamilias().Agregar(unaFamilia);
        }

        /// <summary>
        /// Este método se utiliza para crear un permiso
        /// </summary>
        /// <param name="unaPatente">Permiso a agregar</param>
        public void CrearPatente(Patente unaPatente) {
            FabricaDAL.Current.ObtenerRepositorioDePatentes().Agregar(unaPatente);
        }

        /// <summary>
        /// Este método se utiliza para crear un usuario
        /// </summary>
        /// <param name="unUsuario">Usuario a agregar</param>
        public void CrearUsuario(Usuario unUsuario) {
            try {
                unUsuario.IdUsuario = Guid.NewGuid();
                string nuevaClave = GestorSeguridad.Current.GenerarClaveAleatoria();
                string llave = ConfigurationManager.AppSettings["claveCifrado"];
                string claveEncriptada = GestorSeguridad.Current.Encriptar(nuevaClave, llave);
                unUsuario.Contrasenia = claveEncriptada;
                FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Agregar(unUsuario);
                GestorNotificaciones.Current.EnviarMail(unUsuario.Email, "Bienvenido", "Tu nueva clave es: " + nuevaClave);

                Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Se creó el usuario: " + unUsuario.UsuarioLogin);
                GestorHistorico.Current.RegistrarBitacora(unEvento);
            } catch (Exception ex) {
                unUsuario.IdUsuario = Guid.Empty;
                throw ex;
            }
        }

        /// <summary>
        /// Este método se utiliza para consultar todas las familias de permisos
        /// </summary>
        /// <returns>Lista de objetos Familia</returns>
        public IEnumerable<Familia> ListarFamilias() {
            return FabricaDAL.Current.ObtenerRepositorioDeFamilias().Listar();
        }

        /// <summary>
        /// Este método se utiliza para consultar todos los permisos y sus vistas asociadas
        /// </summary>
        /// <returns>Lista de objetos Patente</returns>
        public IEnumerable<Patente> ListarPatentes() {
            return FabricaDAL.Current.ObtenerRepositorioDePatentes().Listar();
        }

        /// <summary>
        /// Este método se utiliza para consultar todos los usuarios del sistema
        /// </summary>
        /// <returns>Lista de objetos Usuario</returns>
        public IEnumerable<Usuario> ListarUsuarios() {
            return FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Listar();
        }
        
        /// <summary>
        /// Este método se utiliza para modificar una familia de permisos
        /// </summary>
        /// <param name="unaFamilia">Familia a modificar</param>
        public void ModificarFamilia(Familia unaFamilia) {
            FabricaDAL.Current.ObtenerRepositorioDeFamilias().Modificar(unaFamilia);
        }

        /// <summary>
        /// Este método se utiliza para modificar un permiso
        /// </summary>
        /// <param name="unaPatente">Patente a modificar</param>
        public void ModificarPatente(Patente unaPatente)
        {
            FabricaDAL.Current.ObtenerRepositorioDePatentes().Modificar(unaPatente);
        }

        /// <summary>
        /// Este método se utiliza para modificar un usuario
        /// </summary>
        /// <param name="unUsuario">Usuario a modificar</param>
        public void ModificarUsuario(Usuario unUsuario) {
            FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Modificar(unUsuario);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Se modificó el usuario: " + unUsuario.UsuarioLogin);
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

    }
}
