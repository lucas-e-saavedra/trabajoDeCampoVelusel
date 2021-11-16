using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.CompositeProducto
{
	/// <summary>
	/// Esta enumeración sirve para parametrizar las distintas unidades de medida que se utilizan
	/// </summary>
	public enum Unidades
    {
		/// <summary>
		/// Unidades
		/// </summary>
		Un, 
		/// <summary>
		/// Gramos (peso)
		/// </summary>
		Gr, 
		/// <summary>
		/// Centímetros cúbicos (volumen)
		/// </summary>
		CC, 
		/// <summary>
		/// Centímetros (longitud)
		/// </summary>
		Cm
    }

	/// <summary>
	/// Esta clase se utiliza para representar aspectos que tienen en común los materiales y los productos.
	/// </summary>
	public abstract class ProductoMaterial
	{
		/// <summary>
		/// Identificador unico que distingue a cada producto o material
		/// </summary>
		public Guid Id { get; set; }
		
		/// <summary>
		/// Nombre con el que se reconoce a cada producto o material
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Unidad de medida que se utiliza para medir la cantidad de un producto o material
		/// </summary>
		public Unidades Unidad{ get; set; }

		/// <summary>
		/// Cantidad de un producto o material en el contexto actual
		/// </summary>
		public float Cantidad { get; set; }
		
		/// <summary>
		/// El constructor por defecto no asigna ninguna propiedad
		/// </summary>
		public ProductoMaterial()
		{

		}

		/// <summary>
		/// Este metodo se utiliza para clonar un producto o material cuando se necesita otra instancia igual a actual para poder modificarla sin alterar el objeto actual
		/// </summary>
		/// <returns>Devuelve una copia del objeto original</returns>
		public ProductoMaterial Copiar()
		{
			return (ProductoMaterial)this.MemberwiseClone();
		}

		/// <summary>
		/// Este método se utiliza para agregar materiales o productos a la plantilla de fabricación
		/// </summary>
		/// <param name="component">Material o producto a agregar</param>
		public abstract void Agregar(ProductoMaterial component);

		/// <summary>
		/// Este método se utiliza para quitar materiales o productos de la plantilla de fabricación
		/// </summary>
		/// <param name="component">Material o producto a quitar</param>
		public abstract void Quitar(ProductoMaterial component);

		/// <summary>
		/// Este método indica la cantidad de ingredientes distintos que se utilizan para fabricar un producto
		/// </summary>
		public abstract int CantidadIngredientes { get; }

		/// <summary>
		/// Descripción del objeto para fines visuales
		/// </summary>
		/// <returns>Devuelve un string con el nombre y la unidad en que se mide</returns>
        public override string ToString()
        {
            return $"{this.Nombre}({this.Unidad})";
        }
    }
}
