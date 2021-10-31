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
    public class GestorPedidos
    {
        private readonly static GestorPedidos _instance = new GestorPedidos();

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
        //TODO: este metodo falta en el enterprise architect
        public void AgendarPedido(Pedido unPedido)
        {
            if (unPedido.Estado != Pedido.EnumEstadoPedido.FORMULADO)
                throw new Exception("No está permitido agendar un pedido en este estado");

            Usuario usuario = GestorSesion.Current.usuarioActual;
            unPedido.Estado = Pedido.EnumEstadoPedido.PLANIFICADO;

            FabricaDAL.Current.ObtenerRepositorioDePedidos().Modificar(unPedido);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} canceló el pedido {unPedido.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
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
        public void CompletarPedido(Pedido unPedido)
        {
            if (unPedido.Estado != Pedido.EnumEstadoPedido.PLANIFICADO)
                throw new Exception("No está permitido cerrar un pedido en este estado");

            unPedido.Estado = Pedido.EnumEstadoPedido.LISTO;
            FabricaDAL.Current.ObtenerRepositorioDePedidos().Modificar(unPedido);

            if (unPedido.Solicitante == null) {
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(unPedido.Detalle);

                throw new Exception($"El pedido no se pudo exportar:\n{output}");
            }
        }
        public void EntregarPedido(Pedido unPedido)
        {

            if (unPedido.Estado != Pedido.EnumEstadoPedido.LISTO)
                throw new Exception("No está permitido cerrar un pedido en este estado");

            unPedido.Estado = Pedido.EnumEstadoPedido.CERRADO;
            
            Usuario usuario = GestorSesion.Current.usuarioActual;
            FabricaDAL.Current.ObtenerRepositorioDePedidos().Modificar(unPedido);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} canceló el pedido {unPedido.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        public IEnumerable<Producto> ConsultarCatalogo() {
            List<Producto> productos = BLL.GestorFabricacion.Current.ListarProductos().ToList();
            List<Producto> productosActivos = productos.FindAll(item => item.DisponibleEnCatalogo);
            productosActivos.Sort((i, j) => i.Nombre.CompareTo(j.Nombre));
            return productosActivos;
        }
        public IEnumerable<Pedido> ListarPedidos() {
            return FabricaDAL.Current.ObtenerRepositorioDePedidos().Listar();
        }
        public IEnumerable<Pedido> ListarPedidos(Pedido.EnumEstadoPedido estadoPedido) {
            return FabricaDAL.Current.ObtenerRepositorioDePedidos().Listar().Where(item => item.Estado == estadoPedido).ToList();
        }
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
