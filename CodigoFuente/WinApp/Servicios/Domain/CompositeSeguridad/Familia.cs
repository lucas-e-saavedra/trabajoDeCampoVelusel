using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain.CompositeSeguridad
{
	#pragma warning disable 0659
	/// <summary>
	/// Esta clase se utiliza para representar una familia de permisos asociada que además estará vinculada al menú del sistema.
	/// </summary>
	public class Familia: PatenteFamilia{

		private List<PatenteFamilia> patenteFamilias = new List<PatenteFamilia>();

		/// <summary>
		/// Esta lista representa los permisos y familias de permisos que están contenidos dentro de esta familia
		/// </summary>
		public List<PatenteFamilia> ListadoHijos => patenteFamilias;

		/// <summary>
		/// Esta propiedad muestra la cantidad de permisos o familias de permisos que contiene el permiso actual
		/// </summary>
		public override int CantidadHijos => patenteFamilias.Count;

		/// <summary>
		/// Identificador unico que distingue a esta familia de permisos
		/// </summary>
		public Guid IdFamilia { get; set; }

		/// <summary>
		/// El contructor por defecto no asigna ningún valor por defecto a las propiedades del objeto
		/// </summary>
		public Familia()
		{
		}

		/// <summary>
		/// Este metodo se utiliza para agregar permisos o familias de permisos dentro del permiso actual
		/// </summary>
		/// <param name="component">Patente o Familia a agregar</param>
		public override void Agregar(PatenteFamilia component)
		{
			patenteFamilias.Add(component);
		}

		/// <summary>
		/// Este metodo se utiliza para quitar permisos o familias de permisos del permiso actual
		/// </summary>
		/// <param name="component">Patente o Familia a quitar</param>
		public override void Quitar(PatenteFamilia component)
		{
			patenteFamilias.Remove(component);
			//Verificar restricción de eliminación, al menos una patente/familia debería de existir
		}


		/// <summary>
		/// Se sobreescribió el comportamiento del método equal para poder realizar ordenamientos y comparaciones de este tipo de objetos
		/// </summary>
		/// <param name="obj">Objeto contra el cual se está comparando</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Familia familiaObj = (Familia)obj;
			return IdFamilia == familiaObj.IdFamilia;
		}
	}
}
