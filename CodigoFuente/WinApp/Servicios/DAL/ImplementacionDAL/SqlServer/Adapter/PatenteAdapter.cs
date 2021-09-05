using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.ImplementacionDAL.SqlServer.Adapter
{
    class PatenteAdapter
    {
        #region Singleton
        private readonly static PatenteAdapter _instance = new PatenteAdapter();

        public static PatenteAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private PatenteAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public Patente Adapt(object[] values)
        {
            return new Patente()
            {
                IdPatente = Guid.Parse(values[0].ToString()),
                Nombre = values[1].ToString(),
                Vista = values[2].ToString()
            };
        }

    }
}
