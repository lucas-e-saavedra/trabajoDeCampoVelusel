using Dominio.CompositeProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	/// <summary>
	/// Esta entidad representa al deposito donde se guarda el stock
	/// </summary>
	public class Almacen
    {
		/// <summary>
		/// Identificador unico que distingue a cada almacén
		/// </summary>
		public Guid Id { get; set; }
		
		/// <summary>
		/// Nombre con el que se reconoce al almacén
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Lista de todo el inventario actual que está almacenado dentro de él
		/// </summary>
		public List<ProductoMaterial> Stock { get; set; }
	}
}
