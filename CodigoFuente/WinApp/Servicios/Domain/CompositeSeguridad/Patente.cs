using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain.CompositeSeguridad
{
    public class Patente: PatenteFamilia
    {
		public Guid IdPatente { get; set; }

		public override int CantidadHijos => 0;

		public string Vista { get; set; }

		public Patente()
		{

		}

		//public Patente PatentePadre { get; set; }

		/// 
		/// <param name="component"></param>
		public override void Agregar(PatenteFamilia component)
		{
			throw new Exception("No se pueden agregar elementos en una patente.");
		}

		/// 
		/// <param name="component"></param>
		public override void Quitar(PatenteFamilia component)
		{
			throw new Exception("No se pueden quitar elementos en una patente.");
		}

	}
}
