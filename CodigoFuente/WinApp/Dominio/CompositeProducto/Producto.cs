using System;
using System.Collections.Generic;

namespace Dominio.CompositeProducto
{
	#pragma warning disable 0659, 0108
	/// <summary>
	/// Esta clase representa a cada producto o subproducto que elabora nuestra fábrica
	/// </summary>
	public class Producto: ProductoMaterial{
		/// <summary>
		/// Este método indica la cantidad de ingredientes distintos que se utilizan para fabricar este producto
		/// </summary>
		public override int CantidadIngredientes => plantillaDeFabricacion.Ingredientes.Count;
		
		/// <summary>
		/// Descripción que provee el diseñador aclarando aspectos importantes del producto
		/// </summary>
		public string Descripcion { get; set; }
		
		/// <summary>
		/// Url de la imagen que se muestra como ilustración en el catálogo
		/// </summary>
		public string Foto { get; set; }
		
		/// <summary>
		/// Este atributo indica si el producto está disponible para la venta o no
		/// </summary>
		public bool DisponibleEnCatalogo { get; set; }

		/// <summary>
		/// Aqui están representadas las especificaciones que dió el diseñador para fabricar el producto
		/// </summary>
		public PlantillaDeFabricacion plantillaDeFabricacion { get; set; }

		/// <summary>
		/// El constructor por defecto crea una plantilla de fabricación vacía
		/// </summary>
		public Producto()
		{
			plantillaDeFabricacion = new PlantillaDeFabricacion();
			plantillaDeFabricacion.IdPlantilla = Guid.NewGuid();
		}

		/// <summary>
		/// Este metodo se utiliza para clonar un producto o material cuando se necesita otra instancia igual a actual para poder modificarla sin alterar el objeto actual
		/// </summary>
		/// <returns>Devuelve una copia del objeto original</returns>
		public Producto Copiar() {
			return (Producto)this.MemberwiseClone();
		}

		/// <summary>
		/// Este método se utiliza para agregar materiales o productos a la plantilla de fabricación
		/// </summary>
		/// <param name="component">Material o producto a agregar</param>
		public override void Agregar(ProductoMaterial component)
		{
			plantillaDeFabricacion.Ingredientes.Add(component);
		}

		/// <summary>
		/// Este método se utiliza para quitar materiales o productos de la plantilla de fabricación
		/// </summary>
		/// <param name="component">Material o producto a quitar</param>
		public override void Quitar(ProductoMaterial component)
		{
			plantillaDeFabricacion.Ingredientes.Remove(component);
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

			Producto productoObj = (Producto)obj;
			return Id == productoObj.Id;
		}
	}
}
