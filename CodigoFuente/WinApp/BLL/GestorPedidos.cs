using DAL;
using Dominio;
using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Este gestor se encarga de manejar la información de los pedidos 
    /// </summary>
    public class GestorPedidos
    {
        private readonly static GestorPedidos _instance = new GestorPedidos();

        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
        public static GestorPedidos Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorPedidos()
        {
            //Implent here the initialization of your singleton
        }

        /// <summary>
        /// Este método sirve para reflejar que el fabricante ya pasó este pedido a estado Planificado.
        /// </summary>
        /// <param name="unPedido">Instancia del objeto Pedido</param>
        public void AgendarPedido(Pedido unPedido)
        {
            if (unPedido.Estado != Pedido.EnumEstadoPedido.FORMULADO)
                throw new Exception("No está permitido agendar un pedido en este estado");

            Usuario usuario = GestorSesion.Current.usuarioActual;
            unPedido.Estado = Pedido.EnumEstadoPedido.PLANIFICADO;

            FabricaDAL.Current.ObtenerRepositorioDePedidos().Modificar(unPedido);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} ha agendado el pedido {unPedido.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

        /// <summary>
        /// Este método sirve para reflejar que el vendedor paso este pedido a estado Cancelado.
        /// </summary>
        /// <param name="unPedido">Instancia del objeto Pedido</param>
        public void CancelarPedido(Pedido unPedido) {
            if (unPedido.Estado != Pedido.EnumEstadoPedido.FORMULADO
                && unPedido.Estado != Pedido.EnumEstadoPedido.PLANIFICADO)
                throw new Exception("No está permitido cancelar un pedido en este estado");

            Usuario usuario = GestorSesion.Current.usuarioActual;
            unPedido.Estado = Pedido.EnumEstadoPedido.CANCELADO;

            FabricaDAL.Current.ObtenerRepositorioDePedidos().Modificar(unPedido);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} canceló el pedido {unPedido.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

        /// <summary>
        /// Este método sirve para reflejar que el pedido ya esta listo para ser retirado por el cliente o enviado a la tienda.
        /// </summary>
        /// <param name="unPedido">Instancia del objeto Pedido</param>
        public void CompletarPedido(Pedido unPedido)
        {
            if (unPedido.Estado != Pedido.EnumEstadoPedido.PLANIFICADO)
                throw new Exception("No está permitido cerrar un pedido en este estado");

            unPedido.Estado = Pedido.EnumEstadoPedido.LISTO;
            FabricaDAL.Current.ObtenerRepositorioDePedidos().Modificar(unPedido);
        }

        /// <summary>
        /// Este método sirve para reflejar que el pedido ya ha sido retirado por el cliente o enviado a la tienda.
        /// </summary>
        /// <param name="unPedido">Instancia del objeto Pedido</param>
        public void EntregarPedido(Pedido unPedido)
        {

            if (unPedido.Estado != Pedido.EnumEstadoPedido.LISTO)
                throw new Exception("No está permitido cerrar un pedido en este estado");

            unPedido.Estado = Pedido.EnumEstadoPedido.CERRADO;
            if (unPedido.Solicitante == null) {
                GestorStock.Current.ActualizarStockTiendOnline(unPedido);
            }

            Usuario usuario = GestorSesion.Current.usuarioActual;
            FabricaDAL.Current.ObtenerRepositorioDePedidos().Modificar(unPedido);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} entregó el pedido {unPedido.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

        /// <summary>
        /// Este método se utiliza para consultar el catálogo actual (muestra todos los productos que están disponibles para incluir en un pedido).
        /// </summary>
        /// <returns>Devuelve una colección de Productos</returns>
        public IEnumerable<Producto> ConsultarCatalogo() {
            List<Producto> productos = BLL.GestorFabricacion.Current.ListarProductos().ToList();
            List<Producto> productosActivos = productos.FindAll(item => item.DisponibleEnCatalogo);
            productosActivos.Sort((i, j) => i.Nombre.CompareTo(j.Nombre));
            return productosActivos;
        }

        /// <summary>
        /// Este método se utiliza para consultar todos los pedidos que están registrados en el sistema.
        /// </summary>
        /// <returns>Devuelve una colección de Pedidos</returns>
        public IEnumerable<Pedido> ListarPedidos() {
            return FabricaDAL.Current.ObtenerRepositorioDePedidos().Listar();
        }

        /// <summary>
        /// Este método se utiliza para consultar todos los pedidos que están registrados en el sistema y que coinciden con un estado en particular.
        /// </summary>
        /// <returns>Devuelve una colección de Pedidos</returns>
        public IEnumerable<Pedido> ListarPedidos(Pedido.EnumEstadoPedido estadoPedido) {
            return FabricaDAL.Current.ObtenerRepositorioDePedidos().Listar().Where(item => item.Estado == estadoPedido).ToList();
        }

        /// <summary>
        /// Este método sirve para agregar un nuevo pedido al sistema. El mismo debe contener al menos un producto en su lista de productos solicitados.
        /// </summary>
        /// <param name="unPedido">Instancia del objeto Pedido</param>
        public void RegistrarPedido(Pedido unPedido)
        {
            if (unPedido.Solicitante != null && !unPedido.Solicitante.Habilitado)
                throw new Exception("El cliente seleccionado no está habilitado para realizar un pedido");
            if (unPedido.Detalle == null || unPedido.Detalle.Count==0 || unPedido.Detalle.Max(item => item.Cantidad) == 0)
                throw new Exception("No está permitido crear un pedido vacío");

            Usuario usuario = GestorSesion.Current.usuarioActual;
            unPedido.Estado = Pedido.EnumEstadoPedido.FORMULADO;
            unPedido.Vendedor = usuario;
            
            FabricaDAL.Current.ObtenerRepositorioDePedidos().Agregar(unPedido);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} agregó el pedido {unPedido.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
    }
}
