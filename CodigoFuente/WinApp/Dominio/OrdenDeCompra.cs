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
	/// Esta entidad representa las ordenes de compra para aprovisionar materiales
	/// </summary>
	public class OrdenDeCompra
    {
        /// <summary>
		/// Identificador unico que distingue a cada orden de compra
		/// </summary>
		public Guid Id { get; set; }

        /// <summary>
        /// Aqui está representado quien es el comprador que creó esta orden de compra
        /// </summary>
        public Usuario solicitante { get; set; }

        /// <summary>
        /// Estado en que se encuentra la orden de compra actualmente
        /// </summary>
        public EnumEstadoOrdenCompra Estado { get; set; }

        /// <summary>
        /// Aqui está representado cual es el material que hay que comprar y la cantidad minima que se necesita
        /// </summary>
        public Material Objetivo { get; set; }
        
        /// <summary>
        /// Esta es la fecha en la cual se desea tener los materiales en el inventario
        /// </summary>
        public DateTime FechaObjetivo { get; set; }

        /// <summary>
        /// Aqui está representado cual es el material que se ha comprado y la cantidad que se compró
        /// </summary>
        public Material Comprados { get; set; }
        
        /// <summary>
        /// Esta es la fecha en la cual el proveedor nos ha informado que puede entregarnos el material
        /// </summary>
        public DateTime FechaEstimadaRecepcion { get; set; }

        /// <summary>
        /// Aqui está representado cual es el material que se ha comprado y la cantidad real que se recibió 
        /// </summary>
        public Material Recibidos { get; set; }
        
        /// <summary>
        /// Esta es la fecha real en la que se recibió el material e ingresó al stock
        /// </summary>
        public DateTime FechaRealRecepcion { get; set; }

        /// <summary>
        /// Esta enumeración sirve para parametrizar los estados del pedido
        /// </summary>
        public enum EnumEstadoOrdenCompra {
            /// <summary>
            /// La orden de compra ha sido creada por el comprador, pero aún no se ha concretado la compra
            /// </summary>
            FORMULADO,
            /// <summary>
            /// La orden de compra ha sido cancelada
            /// </summary>
            CANCELADO,
            /// <summary>
            /// La orden de compra ya ha sido encargada al proveedor, pero aún no se ha recibido el material
            /// </summary>
            COMPRADO,
            /// <summary>
            /// La orden de compra ya ha llegado a su fin, se recibió el material y ya ingresó al stock
            /// </summary>
            RECIBIDO
        }

        /// <summary>
        /// El contructor por defecto no asigna ninguna propiedad
        /// </summary>
        public OrdenDeCompra()
        {
        }

        /// <summary>
        /// Este constructor recibe un material como objetivo, genera el identificador y asigna el estado formulado
        /// </summary>
        /// <param name="materialSolicitado">Este parametro indica que material y cantidad minima se necesita</param>
        public OrdenDeCompra(Material materialSolicitado)
        {
            Id = Guid.NewGuid();
            Estado = EnumEstadoOrdenCompra.FORMULADO;
            Objetivo = materialSolicitado;
            Comprados = materialSolicitado.Copiar();
            Comprados.Cantidad = 0;
            Recibidos = materialSolicitado.Copiar();
            Recibidos.Cantidad = 0;
        }
    }
}
