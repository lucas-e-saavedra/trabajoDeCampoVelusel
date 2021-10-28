using Dominio.CompositeProducto;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class OrdenDeCompra
    {
        public Guid Id { get; set; }
        public Usuario solicitante { get; set; }
        public EnumEstadoOrdenCompra Estado { get; set; }
        public Material Objetivo { get; set; }
        public DateTime FechaObjetivo { get; set; }
        public Material Comprados { get; set; }
        public DateTime FechaEstimadaRecepcion { get; set; }
        public Material Recibidos { get; set; }
        public DateTime FechaRealRecepcion { get; set; }

        public enum EnumEstadoOrdenCompra { FORMULADO, CANCELADO, COMPRADO, RECIBIDO }

        public OrdenDeCompra()
        {
        }

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
