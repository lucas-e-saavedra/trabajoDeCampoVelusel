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
            Guid idProducto = Guid.Parse(values[0].ToString());
            string[] criterios = { };
            string[] valores = { values[0].ToString() };
            PlantillaDeFabricacion unaPlantillaDeFabricacion = FabricaDAL.Current.ObtenerRepositorioDePlantillasDeFabricacion().BuscarUno(criterios, valores);
            Unidades unidad = (Unidades)Enum.Parse(typeof(Unidades), values[2].ToString());
            return new Producto()
            {
                Id = idProducto,
                Nombre = values[1].ToString(),
                Unidad = unidad,
                Descripcion = values[3].ToString(),
                Foto = values[4].ToString(),
                DisponibleEnCatalogo = Boolean.Parse(values[5].ToString()),
                plantillaDeFabricacion = unaPlantillaDeFabricacion
            };
        }

    }
}
