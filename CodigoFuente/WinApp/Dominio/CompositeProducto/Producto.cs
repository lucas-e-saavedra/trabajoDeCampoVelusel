using System;
using System.Collections.Generic;

namespace Dominio.CompositeProducto
{
    public class Producto: ProductoMaterial{

		private List<ProductoMaterial> ingredientes = new List<ProductoMaterial>();

		//Retorno el listado de los ingredientes...
		public List<ProductoMaterial> Ingredientes => ingredientes;

		public override int CantidadIngredientes => ingredientes.Count;
		public string Descripcion { get; set; }
		public string Foto { get; set; }

		public PlantillaDeFabricacion plantillaDeFabricacion { get; set; }

		public Producto()
		{
		}

		public Producto(ProductoMaterial componentes)
		{
			ingredientes.Add(componentes);
		}

		/// 
		/// <param name="component"></param>
		public override void Agregar(ProductoMaterial component)
		{
			ingredientes.Add(component);
		}

		/// 
		/// <param name="component"></param>
		public override void Quitar(ProductoMaterial component)
		{
			ingredientes.Remove(component);
			//Verificar restricción de eliminación, al menos una patente/familia debería de existir
		}


		// override object.Equals
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Producto productoObj = (Producto)obj;
			return Id == productoObj.Id;
		}
	}
}
