using System;
using System.Collections.Generic;

namespace Dominio.CompositeProducto
{
    public class Producto: ProductoMaterial{
		//Retorno el listado de los ingredientes...
		public override int CantidadIngredientes => plantillaDeFabricacion.Ingredientes.Count;
		public string Descripcion { get; set; }
		public string Foto { get; set; }
		public bool DisponibleEnCatalogo { get; set; }

		public PlantillaDeFabricacion plantillaDeFabricacion { get; set; }

		public Producto()
		{
			plantillaDeFabricacion = new PlantillaDeFabricacion();
			plantillaDeFabricacion.IdPlantilla = Guid.NewGuid();
		}

		public Producto Copiar() {
			return (Producto)this.MemberwiseClone();
		}

		public Producto(PlantillaDeFabricacion receta)
		{
			plantillaDeFabricacion = receta;
		}

		/// 
		/// <param name="component"></param>
		public override void Agregar(ProductoMaterial component)
		{
			plantillaDeFabricacion.Ingredientes.Add(component);
		}

		/// 
		/// <param name="component"></param>
		public override void Quitar(ProductoMaterial component)
		{
			plantillaDeFabricacion.Ingredientes.Remove(component);
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
