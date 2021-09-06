using Servicios.DAL;
using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void BlanquearClave(string usuario) { }
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
            //TODO: enviar la nuevaClave por email
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
