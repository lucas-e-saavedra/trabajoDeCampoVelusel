using Servicios.Domain;
using System;
using System.Collections.Generic;
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
            return null;
        }
    }
}
