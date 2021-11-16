using Dominio.CompositeProducto;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
	/// Esta entidad representa los pedidos generados por los vendedores
	/// </summary>
	public class Pedido
    {
        /// <summary>
		/// Identificador unico que distingue a cada pedido
		/// </summary>
		public Guid Id { get; set; }

        /// <summary>
        /// Aqui está representado quien retirará el pedido, en caso de no tener solicitante es un pedido para abastecer la tienda online
        /// </summary>
        public Cliente Solicitante { get; set; }

        /// <summary>
        /// Aqui está representado quien es el vendedor que ingresó el pedido al sistema
        /// </summary>
        public Usuario Vendedor { get; set; }

        /// <summary>
        /// Estado en que se encuentra el pedido actualmente
        /// </summary>
        public EnumEstadoPedido Estado { get; set; }

        /// <summary>
        /// Lista de productos que se han solicitado
        /// </summary>
        public List<Producto> Detalle { get; set; }

        /// <summary>
        /// Esta enumeración sirve para parametrizar los estados del pedido
        /// </summary>
        public enum EnumEstadoPedido { 
            /// <summary>
            /// El pedido ha sido cancelado
            /// </summary>
            CANCELADO,
            /// <summary>
            /// El pedido ha sido ingresado por el vendedor, pero él fabricante aún no lo ha incluido en su agenda
            /// </summary>
            FORMULADO,
            /// <summary>
            /// El pedido ya ha sido analizado por el fabricante y ha agendado las ordenes de fabricación para poder cumplirlo
            /// </summary>
            PLANIFICADO,
            /// <summary>
            /// Todas las ordenes de fabricación han finalizado y el pedido está listo para ser retirado por el cliente
            /// </summary>
            LISTO,
            /// <summary>
            /// El pedido ya ha sido retirado por el cliente o ha sido puesto a disposición de la tienda online
            /// </summary>
            CERRADO
        }

        /// <summary>
        /// El contructor por defecto inicializa el detalle como una lista vacía, pero no asigna ni vendedor ni solicitante
        /// </summary>
        public Pedido() {
            Solicitante = null;
            Vendedor = null;
            Detalle = new List<Producto>();
        }
    }
}
