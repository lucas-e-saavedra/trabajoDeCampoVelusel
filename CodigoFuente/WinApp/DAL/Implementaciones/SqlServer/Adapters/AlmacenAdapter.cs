using Dominio;
using Dominio.CompositeProducto;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using static Dominio.Pedido;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class AlmacenAdapter
    {
        #region Singleton
        private readonly static AlmacenAdapter _instance = new AlmacenAdapter();

        public static AlmacenAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private AlmacenAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public Almacen Adapt(object[] values)
        {
            Guid idProducto = Guid.Parse(values[0].ToString());
            Almacen unAlmacen = new Almacen()
            {
                Id = idProducto,
                Nombre = values[1].ToString(),
                Stock = new List<ProductoMaterial>()
            };

            unAlmacen.Stock.AddRange(FabricaDAL.Current.ObtenerAlmacenProductoRelacion().Obtener(unAlmacen));
            unAlmacen.Stock.AddRange(FabricaDAL.Current.ObtenerAlmacenMaterialRelacion().Obtener(unAlmacen));
            return unAlmacen;
        }

    }
}
