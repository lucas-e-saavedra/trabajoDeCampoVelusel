using Dominio.CompositeProducto;
using System;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class ProductoAdapter
    {
        #region Singleton
        private readonly static ProductoAdapter _instance = new ProductoAdapter();

        public static ProductoAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private ProductoAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public Producto Adapt(object[] values)
        {
            Unidades unidad = (Unidades)Enum.Parse(typeof(Unidades), values[2].ToString());
            return new Producto()
            {
                Id = Guid.Parse(values[0].ToString()),
                Nombre = values[1].ToString(),
                Unidad = unidad,
                Descripcion = values[3].ToString(),
                Foto = values[4].ToString()
            };
        }

    }
}
