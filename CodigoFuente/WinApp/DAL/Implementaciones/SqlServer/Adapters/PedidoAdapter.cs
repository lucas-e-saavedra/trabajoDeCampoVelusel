using Dominio;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Linq;
using static Dominio.Pedido;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class PedidoAdapter
    {
        #region Singleton
        private readonly static PedidoAdapter _instance = new PedidoAdapter();

        public static PedidoAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private PedidoAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public Pedido Adapt(object[] values)
        {
            Guid idProducto = Guid.Parse(values[0].ToString());
            EnumEstadoPedido estado = (EnumEstadoPedido)Enum.Parse(typeof(EnumEstadoPedido), values[1].ToString());
            Cliente unCliente = null;
            if (values[2] != DBNull.Value) { 
                string[] criterios = { };
                string[] valoresCliente = { values[2].ToString() };
                unCliente = FabricaDAL.Current.ObtenerRepositorioDeClientes().BuscarUno(criterios, valoresCliente);
            }
            Guid guidVendedor = Guid.Parse(values[3].ToString());
            Usuario vendedor = Servicios.BLL.GestorUsuarios.Current.ListarUsuarios().ToList().FirstOrDefault(item => item.IdUsuario == guidVendedor);

            Pedido unPedido = new Pedido()
            {
                Id = idProducto,
                Estado = estado,
                Solicitante = unCliente,
                Vendedor = vendedor
            };

            unPedido.Detalle = FabricaDAL.Current.ObtenerPedidoProductoRelacion().Obtener(unPedido);
            return unPedido;
        }

    }
}
