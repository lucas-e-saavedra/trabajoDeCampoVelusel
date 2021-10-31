using Servicios.DAL;
using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;

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
        public void BorrarFamila(Familia unaFamilia) {
            FabricaDAL.Current.ObtenerRepositorioDeFamilias().Borrar(unaFamilia);
        }
        public void BorrarPatente(Patente unaPatente) {
            FabricaDAL.Current.ObtenerRepositorioDePatentes().Borrar(unaPatente);
        }
        public void BorrarUsuario(Usuario unUsuario)
        {
            FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Borrar(unUsuario);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Se eliminó el usuario: " + unUsuario.UsuarioLogin);
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        public void CrearFamilia(Familia unaFamilia) {
            FabricaDAL.Current.ObtenerRepositorioDeFamilias().Agregar(unaFamilia);
        }
        public void CrearPatente(Patente unaPatente) {
            FabricaDAL.Current.ObtenerRepositorioDePatentes().Agregar(unaPatente);
        }
        public void CrearUsuario(Usuario usuario) {
            try {
                usuario.IdUsuario = Guid.NewGuid();
                string nuevaClave = GestorSeguridad.Current.GenerarClaveAleatoria();
                string llave = ConfigurationManager.AppSettings["claveCifrado"];
                string claveEncriptada = GestorSeguridad.Current.Encriptar(nuevaClave, llave);
                usuario.Contrasenia = claveEncriptada;
                FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Agregar(usuario);
                GestorNotificaciones.Current.EnviarMail(usuario.Email, "Bienvenido", "Tu nueva clave es: " + nuevaClave);

                Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Se creó el usuario: " + usuario.UsuarioLogin);
                GestorHistorico.Current.RegistrarBitacora(unEvento);
            } catch (Exception ex) {
                usuario.IdUsuario = Guid.Empty;
                throw ex;
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
        public void ModificarFamilia(Familia unaFamilia) {
            FabricaDAL.Current.ObtenerRepositorioDeFamilias().Modificar(unaFamilia);
        }
        public void ModificarPatente(Patente unaPatente)
        {
            FabricaDAL.Current.ObtenerRepositorioDePatentes().Modificar(unaPatente);
        }
        public void ModificarUsuario(Usuario unUsuario) {
            FabricaDAL.Current.ObtenerRepositorioDeUsuarios().Modificar(unUsuario);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, "Se modificó el usuario: " + unUsuario.UsuarioLogin);
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

    }
}
