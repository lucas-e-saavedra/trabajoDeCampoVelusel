using System;

namespace Dominio.CompositeProducto
{
	#pragma warning disable 0659, 0108
	/// <summary>
	/// Esta clase representa a cada material que tenemos que comprar para fabricar un producto
	/// </summary>
	public class Material: ProductoMaterial
    {
		/// <summary>
		/// Este método indica la cantidad de ingredientes distintos que se utilizan para fabricar un producto, pero en el caso de los materiales el resultado siempre es cero
		/// </summary>
		public override int CantidadIngredientes => 0;

		/// <summary>
		/// El constructor por defecto no asigna ninguna propiedad
		/// </summary>
		public Material()
		{

		}

		/// <summary>
		/// Este metodo se utiliza para clonar un producto o material cuando se necesita otra instancia igual a actual para poder modificarla sin alterar el objeto actual
		/// </summary>
		/// <returns>Devuelve una copia del objeto original</returns>
		public Material Copiar()
		{
			return (Material)this.MemberwiseClone();
		}

		/// <summary>
		/// Este método se utiliza para agregar materiales o productos a la plantilla de fabricación
		/// </summary>
		/// <param name="component">Material o producto a agregar</param>
		public override void Agregar(ProductoMaterial component)
		{
			throw new Exception("No se pueden agregar elementos en un material.");
		}

		/// <summary>
		/// Este método se utiliza para quitar materiales o productos de la plantilla de fabricación
		/// </summary>
		/// <param name="component">Material o producto a quitar</param>
		public override void Quitar(ProductoMaterial component)
		{
			throw new Exception("No se pueden quitar elementos de un material.");
		}

		/// <summary>
		/// Se sobreescribió el comportamiento del método equal para poder realizar ordenamientos y comparaciones de este tipo de objetos
		/// </summary>
		/// <param name="obj">Objeto contra el cual se está comparando</param>
		/// <returns>Devuelve True si considera que los objetos son iguales y devuelve False en caso contrario</returns>
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
