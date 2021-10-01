using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.ImplementacionDAL.SqlServer.Adapter
{
    class FamiliaAdapter
    {
        #region Singleton
        private readonly static FamiliaAdapter _instance = new FamiliaAdapter();

        public static FamiliaAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private FamiliaAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        //public Familia Adapt(object[] values, int level)
        public Familia Adapt(object[] values)
        {
            //Adapter primitivos -> Hidratación -> Niveles
            //Nivel 0
            Familia familia = new Familia();
            familia.IdFamilia = Guid.Parse(values[0].ToString());
            familia.Nombre = values[1].ToString();

            //Vemos si hay patentes para mi familia?
            List<Patente> patentesRelacionadas = FabricaDAL.Current.ObtenerFamiliaPatenteRelacion().Obtener(familia);

            foreach (var item in patentesRelacionadas)
            {
                familia.Agregar(item);
            }

            //Nivel 1 Nivel 2
            //familia.Add(Familia->Familia)

            List<Familia> familiasRelacionadas = FabricaDAL.Current.ObtenerFamiliaFamiliaRelacion().Obtener(familia);

            foreach (var item in familiasRelacionadas)
            {
                familia.Agregar(item);
            }

            return familia;
        }

    }
}
