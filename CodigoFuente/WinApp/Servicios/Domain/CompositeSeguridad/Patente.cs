using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain.CompositeSeguridad
{
	#pragma warning disable 0659
	/// <summary>
	/// Esta clase se utiliza para representar un permiso asociada a una vista en particular que además estará vinculada al menú del sistema. No es obligatorio generar permisos para vistas que son invocadas por otras vistas.
	/// </summary>
	public class Patente: PatenteFamilia
    {
		/// <summary>
		/// Identificador unico que distingue a esta patente
		/// </summary>
		public Guid IdPatente { get; set; }

		/// <summary>
		/// Por restricciones de diseño todas las patentes no pueden tener hijos
		/// </summary>
		public override int CantidadHijos => 0;

		/// <summary>
		/// Nombre completo del formulario que utilizará como vista, incluido su espacio de nombres.
		/// </summary>
		public string Vista { get; set; }

		/// <summary>
		/// El contructor por defecto no asigna ningún valor por defecto a las propiedades del objeto
		/// </summary>
		public Patente()
		{

		}

		/// <summary>
		/// Por restricciones de diseño todas las patentes no pueden tener hijos
		/// </summary>
		public override void Agregar(PatenteFamilia component)
		{
			throw new Exception("No se pueden agregar elementos en una patente.");
		}

		/// <summary>
		/// Por restricciones de diseño todas las patentes no pueden tener hijos
		/// </summary>
		public override void Quitar(PatenteFamilia component)
		{
			throw new Exception("No se pueden quitar elementos en una patente.");
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

			Patente patenteObj = (Patente)obj;
			return IdPatente == patenteObj.IdPatente;
		}
	}
}
