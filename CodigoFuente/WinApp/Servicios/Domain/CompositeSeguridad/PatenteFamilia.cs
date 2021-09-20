using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain.CompositeSeguridad
{
    public abstract class PatenteFamilia
    {
		public string Nombre { get; set; }

		public PatenteFamilia()
		{

		}

		/// 
		/// <param name="component"></param>
		public abstract void Agregar(PatenteFamilia component);

		/// 
		/// <param name="component"></param>
		public abstract void Quitar(PatenteFamilia component);

		public abstract int CantidadHijos { get; }

	}
}
