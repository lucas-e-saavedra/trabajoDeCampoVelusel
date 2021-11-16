using Dominio.CompositeProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    /// <summary>
	/// Esta entidad representa las ordenes de fabricación que guían al fabricante en su tarea diaria
	/// </summary>
	public class OrdenDeFabricacion
    {
        /// <summary>
		/// Identificador unico que distingue a cada orden de fabricación
		/// </summary>
		public Guid Id { get; set; }

        /// <summary>
        /// Aqui está representado cual es el pedido por el que se ha originado esta orden de fabricación
        /// </summary>
        public Pedido pedido { get; set; }

        /// <summary>
        /// Esta es la fecha en la cual se desea comenzar la ejecución de esta orden de fabricación
        /// </summary>
        public DateTime FechaPlanificada { get; set; }

        /// <summary>
        /// Esta es la fecha y hora en la cual se terminó la fabricación del producto
        /// </summary>
        public DateTime FechaEjecucion { get; set; }

        /// <summary>
        /// Estado en que se encuentra la orden de fabricación actualmente
        /// </summary>
        public EnumEstadoOrdenFabricacion Estado { get; set; }

        /// <summary>
        /// Aqui está representado cual es el producto que hay que elaborar y la cantidad que solicitada
        /// </summary>
        public Producto Objetivo { get; set; }

        /// <summary>
        /// Aqui está representado cual es el producto que hay que se fabricó y la cantidad que se obtuvo al final de la tarea
        /// </summary>
        public Producto Fabricados { get; set; }

        /// <summary>
        /// Aqui está representado cual es el producto que hay que se fabricó y la cantidad que se verificó que están correctos luego del tiempo de reposo minimo.
        /// </summary>
        public Producto Aprobados { get; set; }

        /// <summary>
        /// Esta enumeración sirve para parametrizar los estados del pedido
        /// </summary>
        public enum EnumEstadoOrdenFabricacion { 
            /// <summary>
            /// Este es el estado inicial de la orden de fabricación
            /// </summary>
            FORMULADO, 
            /// <summary>
            /// La orden de fabricación ha sido cancelada
            /// </summary>
            CANCELADO, 
            /// <summary>
            /// La orden de fabricación ya está programada en la agenda del fabricante
            /// </summary>
            AGENDADO,
            /// <summary>
            /// La orden de fabricación ya está siento elaborada por el fabricante
            /// </summary>
            ENFABRICACION,
            /// <summary>
            /// El fabricante ya finalizó la ejecucion de la orden de fabricación y ahora solo resta esperar que se cumpla el tiempo de reposo
            /// </summary>
            FABRICADO,
            /// <summary>
            /// La orden de fabricación ya finalizó y ademas ya cumplió con el tiempo de reposo
            /// </summary>
            TERMINADO
        }

        /// <summary>
        /// Aqui está representado si es que hay alguna orden de fabriación que depende de esta.
        /// </summary>
        public OrdenDeFabricacion OrdenDeFabricacionPosterior { get; set; }

        /// <summary>
        /// El contructor por defecto no asigna ninguna propiedad
        /// </summary>
        public OrdenDeFabricacion()
        {
            OrdenDeFabricacionPosterior = null;
        }

        /// <summary>
        /// Este constructor se utiliza cuando se crea una orden de fabricación basandose en un pedido
        /// </summary>
        /// <param name="ofPosterior">Orden de fabricación posterior si es que corresponde</param>
        /// <param name="unPedido">Pedido que originó esta orden de fabricacion</param>
        /// <param name="objetivo">Cantidad requerida del objetivo</param>
        public OrdenDeFabricacion(OrdenDeFabricacion ofPosterior, Pedido unPedido, Producto objetivo)
        {
            Id = Guid.NewGuid();
            pedido = unPedido;
            OrdenDeFabricacionPosterior = ofPosterior;
            Estado = EnumEstadoOrdenFabricacion.FORMULADO;
            Objetivo = objetivo;
            Fabricados = objetivo.Copiar();
            Fabricados.Cantidad = 0;
            Aprobados = objetivo.Copiar();
            Aprobados.Cantidad = 0; ;
        }
    }
}
