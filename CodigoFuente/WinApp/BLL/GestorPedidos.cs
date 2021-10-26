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

        public void CancelarPedido(Pedido unPedido) { 
        }
        public void CerrarPedido(Pedido unPedido)
        {
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
        public IEnumerable<Pedido> ListarPedidos2() { return null; }
        public void RegistrarPedido(Pedido unPedido)
        {
            if(unPedido.Detalle.Count==0 || unPedido.Detalle.Max(item => item.Cantidad) == 0)
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
