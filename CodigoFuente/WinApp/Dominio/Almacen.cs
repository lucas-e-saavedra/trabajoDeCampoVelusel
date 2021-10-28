using Dominio.CompositeProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	public class Almacen
    {
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public List<ProductoMaterial> Stock { get; set; }
	}
}
