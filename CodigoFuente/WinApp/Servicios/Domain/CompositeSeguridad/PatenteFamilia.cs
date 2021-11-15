using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain.CompositeSeguridad
{
	/// <summary>
	/// Esta clase se utiliza para representar aspectos que tienen en común los permisos y las familias de permisos.
	/// </summary>
	public abstract class PatenteFamilia
    {
		/// <summary>
		/// Nombre del permiso
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// El contructor por defecto no asigna ningún valor por defecto a las propiedades del objeto
		/// </summary>
		public PatenteFamilia()
		{

		}

		
		/// <summary>
		/// Este metodo se utiliza para agregar permisos o familias de permisos dentro del permiso actual
		/// </summary>
		/// <param name="component">Patente o Familia a agregar</param>
		public abstract void Agregar(PatenteFamilia component);

		/// <summary>
		/// Este metodo se utiliza para quitar permisos o familias de permisos del permiso actual
		/// </summary>
		/// <param name="component">Patente o Familia a quitar</param>
		public abstract void Quitar(PatenteFamilia component);

		/// <summary>
		/// Esta propiedad muestra la cantidad de permisos o familias de permisos que contiene el permiso actual
		/// </summary>
		public abstract int CantidadHijos { get; }

	}
}
