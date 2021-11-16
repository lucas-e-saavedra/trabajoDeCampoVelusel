using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Servicios.Domain.CompositeSeguridad.Usuario;

namespace Dominio
{
	/// <summary>
	/// Esta entidad representa a los clientes que hacen pedidos a demanda, en especial al por mayor
	/// </summary>
	public class Cliente
    {
		/// <summary>
		/// Identificador unico que distingue a cada cliente
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Nombre y apellido o razón social del cliente
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Tipo de documento que utiliza el cliente para identificarse
		/// </summary>
		public EnumTipoDocumento TipoDocumento { get; set; }

		/// <summary>
		/// Número de documento que utiliza el cliente para identificarse
		/// </summary>
		public string NroDocumento { get; set; }

		/// <summary>
		/// Dirección de correo electronico que el cliente informó como medio de contacto
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Número de telefono que el cliente informó como medio de contacto
		/// </summary>
		public string Telefono { get; set; }

		/// <summary>
		/// Este atributo indica si el cliente está habilitado para realizar pedidos
		/// </summary>
		public bool Habilitado { get; set; }

		/// <summary>
		/// Dato utilizado para verificar si los datos que están persistidos han sido alterados por fuera del sistema
		/// </summary>
		public int DatoVerificador { get; set; }

		/// <summary>
		/// El contructor por defecto marca al cliente como habilitado
		/// </summary>
		public Cliente()
		{
			Habilitado = true;
		}
	}
}
