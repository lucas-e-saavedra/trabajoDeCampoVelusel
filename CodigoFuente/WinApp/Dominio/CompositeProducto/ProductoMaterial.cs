using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.CompositeProducto
{
	public enum Unidades
    {
		Un, Gr, CC, Cm
    }
	public abstract class ProductoMaterial
	{
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public Unidades Unidad{ get; set; }
		public int Cantidad { get; set; }
		public ProductoMaterial()
		{

		}

		/// 
		/// <param name="component"></param>
		public abstract void Agregar(ProductoMaterial component);

		/// 
		/// <param name="component"></param>
		public abstract void Quitar(ProductoMaterial component);

		public abstract int CantidadIngredientes { get; }

	}
}
