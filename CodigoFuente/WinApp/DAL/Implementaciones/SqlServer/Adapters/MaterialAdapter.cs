using Dominio.CompositeProducto;
using System;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class MaterialAdapter
    {
        #region Singleton
        private readonly static MaterialAdapter _instance = new MaterialAdapter();

        public static MaterialAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private MaterialAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public Material Adapt(object[] values)
        {
            Unidades unidad = (Unidades)Enum.Parse(typeof(Unidades), values[2].ToString());
            return new Material()
            {
                Id = Guid.Parse(values[0].ToString()),
                Nombre = values[1].ToString(),
                Unidad = unidad
            };
        }

    }
}
