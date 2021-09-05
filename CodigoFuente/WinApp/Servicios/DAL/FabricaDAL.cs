using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        #endregion

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
            string conString = ConfigurationManager.ConnectionStrings["SLConString"].ConnectionString;
            return new ImplementacionDAL.SqlServer.UsuarioRepositorio(conString);
        }
        public IRepositorioGenerico<Patente> ObtenerRepositorioDePatentes()
        {
            string conString = ConfigurationManager.ConnectionStrings["SLConString"].ConnectionString;
            return new ImplementacionDAL.SqlServer.PatenteRepositorio(conString);
        }
        public IRepositorioGenerico<Familia> ObtenerRepositorioDeFamilias()
        {
            string conString = ConfigurationManager.ConnectionStrings["SLConString"].ConnectionString;
            return new ImplementacionDAL.SqlServer.FamiliaRepositorio(conString);
        }
    }
}
