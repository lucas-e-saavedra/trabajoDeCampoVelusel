using Dominio.CompositeProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class OrdenDeFabricacion
    {
        public Guid Id { get; set; }
        public Pedido pedido { get; set; }
        public DateTime FechaPlanificada { get; set; }
        public DateTime FechaEjecucion { get; set; }
        public EnumEstadoOrdenFabricacion Estado { get; set; }
        public Producto Objetivo { get; set; }
        public Producto Fabricados { get; set; }
        public Producto Aprobados { get; set; }
        public enum EnumEstadoOrdenFabricacion { FORMULADO, CANCELADO, AGENDADO, ENFABRICACION, FABRICADO, TERMINADO }
        public OrdenDeFabricacion OrdenDeFabricacionPosterior { get; set; }

        public OrdenDeFabricacion()
        {
            OrdenDeFabricacionPosterior = null;
        }

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
