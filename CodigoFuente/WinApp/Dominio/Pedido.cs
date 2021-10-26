using Dominio.CompositeProducto;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Cliente Solicitante { get; set; }
        public Usuario Vendedor { get; set; }
        public EnumEstadoPedido Estado { get; set; }
        public List<Producto> Detalle { get; set; }
        public enum EnumEstadoPedido { FORMULADO, CANCELADO, PLANIFICADO, LISTO, CERRADO }

        public Pedido() {
            Solicitante = null;
            Vendedor = null;
            //Detalle = new Dictionary<Producto, int>();
            Detalle = new List<Producto>();
        }
    }
}
