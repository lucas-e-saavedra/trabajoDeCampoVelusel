using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System.Configuration;
using Servicios.DAL.Contratos;

namespace Servicios.DAL
{
    class FabricaDAL
    {
        #region Singleton
        private readonly static FabricaDAL _instance = new FabricaDAL();

        public static FabricaDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private FabricaDAL()
        {
            bbddSeguridad = ConfigurationManager.ConnectionStrings["SLConString"].ConnectionString;
        }
        #endregion
        private string bbddSeguridad;


        public IRepositorioGenerico<Evento> ObtenerRepositorioDeEventos()
        {
            return new ImplementacionDAL.TXT.DALEvento("bitacora.txt");
        }

        public IRepositorioGenerico<Error> ObtenerRepositorioDeErrores()
        {
            return new ImplementacionDAL.TXT.DALError("errores.txt");
        }

        public IRepositorioGenerico<string> ObtenerRepositorioDeTraducciones(string codigoIdioma)
        {
            return new ImplementacionDAL.TXT.DALTraductor(@"I18n\idioma."+codigoIdioma);
        }

        public IRepositorioGenerico<Usuario> ObtenerRepositorioDeUsuarios()
        {
            return new ImplementacionDAL.SqlServer.UsuarioRepositorio(bbddSeguridad);
        }
        public IRepositorioGenerico<Patente> ObtenerRepositorioDePatentes()
        {
            return new ImplementacionDAL.SqlServer.PatenteRepositorio(bbddSeguridad);
        }
        public IRepositorioGenerico<Familia> ObtenerRepositorioDeFamilias()
        {
            return new ImplementacionDAL.SqlServer.FamiliaRepositorio(bbddSeguridad);
        }

        public IRelacionGenerica<Usuario, Patente> ObtenerUsuarioPatenteRelacion()
        {
            return new ImplementacionDAL.SqlServer.UsuarioPatenteRelacion(bbddSeguridad);
        }
        public IRelacionGenerica<Usuario, Familia> ObtenerUsuarioFamiliaRelacion() {
            return new ImplementacionDAL.SqlServer.UsuarioFamiliaRelacion(bbddSeguridad);
        }
        public IRelacionGenerica<Familia, Patente> ObtenerFamiliaPatenteRelacion()
        {
            return new ImplementacionDAL.SqlServer.FamiliaPatenteRelacion(bbddSeguridad);
        }
        public IRelacionGenerica<Familia, Familia> ObtenerFamiliaFamiliaRelacion()
        {
            return new ImplementacionDAL.SqlServer.FamiliaFamiliaRelacion(bbddSeguridad);
        }

        
    }
}
