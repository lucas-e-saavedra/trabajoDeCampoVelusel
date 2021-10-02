using Dominio.CompositeProducto;
using System;
using System.Collections.Generic;

namespace Dominio
{
    public class PlantillaDeFabricacion
    {
        public Guid IdPlantilla { get; set; }
        public Dictionary<ProductoMaterial, float> Ingredientes { get; set; }
        public int ReposoNecesario;
    }
}
