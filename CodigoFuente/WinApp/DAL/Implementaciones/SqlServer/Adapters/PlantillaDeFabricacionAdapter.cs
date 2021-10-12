using Dominio.CompositeProducto;
using System;
using System.Collections.Generic;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class PlantillaDeFabricacionAdapter
    {
        #region Singleton
        private readonly static PlantillaDeFabricacionAdapter _instance = new PlantillaDeFabricacionAdapter();

        public static PlantillaDeFabricacionAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private PlantillaDeFabricacionAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public PlantillaDeFabricacion Adapt(object[] values)
        {
            string guidPlantilla = values[0].ToString();
            PlantillaDeFabricacion unaPlantillaDeFabricacion = new PlantillaDeFabricacion()
            {
                IdPlantilla = Guid.Parse(guidPlantilla),
                ReposoNecesario = Int16.Parse(values[1].ToString())
            };
            List<Material> materialesRelacionadas = FabricaDAL.Current.ObtenerProductoMaterialRelacion().Obtener(unaPlantillaDeFabricacion);
            foreach (var item in materialesRelacionadas)
            {
                unaPlantillaDeFabricacion.Ingredientes.Add(item);
            }
            /*TODO: faltan los subproductos
            List<Producto> subproductosRelacionadas = FabricaDAL.Current.ObtenerProductoProductoRelacion().Obtener(unaPlantillaDeFabricacion);
            foreach (var item in subproductosRelacionadas)
            {
                unaPlantillaDeFabricacion.Ingredientes.Add(item, 0);
            }*/
            return unaPlantillaDeFabricacion;
        }

    }
}
