using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Servicios.Domain.CompositeSeguridad.Usuario;

namespace Dominio
{
    public class Cliente
    {
		public Guid Id { get; set; }
		public string Nombre { get; set; }
		public EnumTipoDocumento TipoDocumento { get; set; }
		public string NroDocumento { get; set; }
		public string Email { get; set; }
		public string Telefono { get; set; }
		public bool Habilitado { get; set; }
        public int DatoVerificador { get; set; }

        public Cliente()
		{
			Habilitado = true;
		}
	}
}
