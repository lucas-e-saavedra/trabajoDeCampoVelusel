using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.CompositeProducto
{
    public class PlantillaDeFabricacion
    {
        public Guid IdPlantilla { get; set; }
        public Dictionary<ProductoMaterial, float> Ingredientes { get; set; }
        public int ReposoNecesario;

        public PlantillaDeFabricacion()
        {
            Ingredientes = new Dictionary<ProductoMaterial, float>();
        }
    }
}
