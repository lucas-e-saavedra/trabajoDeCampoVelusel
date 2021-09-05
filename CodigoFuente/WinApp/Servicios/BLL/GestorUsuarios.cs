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
            Usuario unUsuario = new Usuario();
            unUsuario.Nombre= "bla";
            unUsuario.Contraseña = "bla";
            Familia unaFamilia = new Familia() { IdFamilia=Guid.NewGuid(), Nombre="Familia A" };
            unaFamilia.Agregar(new Patente() { IdPatente = Guid.NewGuid(), Nombre = "A1", Vista = "" });
            unaFamilia.Agregar(new Patente() { IdPatente = Guid.NewGuid(), Nombre = "A2", Vista = "" });
            unUsuario.Permisos.Add(unaFamilia);
            unUsuario.Permisos.Add(new Patente() { IdPatente = Guid.NewGuid(), Nombre = "B", Vista = "" });
            unUsuario.Permisos.Add(new Patente() { IdPatente = Guid.NewGuid(), Nombre = "C", Vista = "" });

            return unUsuario;
        }
        public void BlanquearClave(string usuario) { }
        public void BorrarFamila(string usuario) { }
        public void BorrarPermiso(string usuario) { }
        public void CrearFamilia(string usuario) { }
        public void CrearPermiso(string usuario) { }
        public void CrearUsuario(string usuario) { }
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
