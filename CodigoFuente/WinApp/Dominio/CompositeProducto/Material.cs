using System;

namespace Dominio.CompositeProducto
{
    public class Material: ProductoMaterial
    {
		public override int CantidadIngredientes => 0;

		public Material()
		{

		}

		/// 
		/// <param name="component"></param>
		public override void Agregar(ProductoMaterial component)
		{
			throw new Exception("No se pueden agregar elementos en un material.");
		}

		/// 
		/// <param name="component"></param>
		public override void Quitar(ProductoMaterial component)
		{
			throw new Exception("No se pueden quitar elementos de un material.");
		}

		// override object.Equals
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Material materialObj = (Material)obj;
			return Id == materialObj.Id;
		}
	}
}
