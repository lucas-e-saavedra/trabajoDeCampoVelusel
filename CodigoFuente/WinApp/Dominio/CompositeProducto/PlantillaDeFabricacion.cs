using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.CompositeProducto
{
    /// <summary>
	/// Esta clase representa la hoja de especificaciones que crea el diseñador
	/// </summary>
	public class PlantillaDeFabricacion
    {
        /// <summary>
		/// Identificador unico que distingue a cada plantilla de fabricación
		/// </summary>
		public Guid IdPlantilla { get; set; }
        
        /// <summary>
        /// Lista de materiales o productos y las cantidades de cada uno que se necesita para fabricar una unidad del producto
        /// </summary>
        public List<ProductoMaterial> Ingredientes { get; set; }
        
        /// <summary>
        /// Cantidad de horas que se debe dejar reposar el producto luego de fabricarlo
        /// </summary>
        public int ReposoNecesario;

        /// <summary>
        /// El constructor por defecto inicialida la lista de ingredientes vacía
        /// </summary>
        public PlantillaDeFabricacion()
        {
            Ingredientes = new List<ProductoMaterial>();
        }
    }
}
