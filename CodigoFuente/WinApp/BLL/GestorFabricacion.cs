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

    public sealed class GestorFabricacion
    {
        private readonly static GestorFabricacion _instance = new GestorFabricacion();

        public static GestorFabricacion Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorFabricacion()
        {
            //Implent here the initialization of your singleton
        }

        public List<OrdenDeFabricacion> AnalizarPedido(Pedido unPedido)
        {
            List<OrdenDeFabricacion> ordenesDeFabricacion = new List<OrdenDeFabricacion>();
            unPedido.Detalle.ForEach(
                item => CrearOrdenesDeFabricacion(ordenesDeFabricacion, unPedido, item, null)
                );
            return ordenesDeFabricacion;
        }
        
        public void BorrarMaterial(Material unMaterial)
        {
            FabricaDAL.Current.ObtenerRepositorioDeMateriales().Borrar(unMaterial);
        }
        public void BorrarProducto(Producto unProducto)
        {
            FabricaDAL.Current.ObtenerRepositorioDeProductos().Borrar(unProducto);
        }
        public void CerrarFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
        }
        public void ComenzarFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
        }
        //TODO: este metodo falta agregarlo al enterprise architect
        private void CrearOrdenesDeFabricacion(List<OrdenDeFabricacion> ofs, Pedido unPedido, Producto unProducto, OrdenDeFabricacion ofPosterior)
        {
            OrdenDeFabricacion nuevaOF = new OrdenDeFabricacion(ofPosterior, unPedido, unProducto);
            ofs.Add(nuevaOF);

            foreach (ProductoMaterial ingr in unProducto.plantillaDeFabricacion.Ingredientes)
            {
                if (ingr is Producto)
                {
                    Producto subproducto = ((Producto)ingr).Copiar();
                    subproducto.Cantidad = subproducto.Cantidad * unProducto.Cantidad;
                    CrearOrdenesDeFabricacion(ofs, unPedido, subproducto, nuevaOF);
                }
            }
        }
        public void CrearOrdenDeFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion) {
            if (unaOrdenDeFabricacion.pedido.Id == Guid.Empty)
                throw new Exception("No está permitido crear una orden de fabricación sin un pedido");
            if (unaOrdenDeFabricacion.Objetivo.Id == Guid.Empty || unaOrdenDeFabricacion.Objetivo.Cantidad == 0)
                throw new Exception("No está permitido crear una orden de fabricación sin un objetivo");

            Usuario usuario = GestorSesion.Current.usuarioActual;
            unaOrdenDeFabricacion.Estado = OrdenDeFabricacion.EnumEstadoOrdenFabricacion.AGENDADO;
            
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Agregar(unaOrdenDeFabricacion);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} agregó la orden de fabricacion {unaOrdenDeFabricacion.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        public OrdenDeFabricacion DetalleOrdenDeFabricacion(Guid idOrdenFabricacion)
        {
            return null;
        }
        public Producto DetalleProducto(Guid idProducto)
        {
            return null;
        }
        public IEnumerable<Material> ListarMateriales()
        {
            return FabricaDAL.Current.ObtenerRepositorioDeMateriales().Listar();
        }
        public IEnumerable<OrdenDeFabricacion> ListarOrdenesDeFabricacion()
        {
            return FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Listar();
        }
        public IEnumerable<OrdenDeFabricacion> ListarOrdenesDeFabricacion(DateTime desde, DateTime hasta)
        {
            return null;
        }
        public IEnumerable<Producto> ListarProductos()
        {
            return FabricaDAL.Current.ObtenerRepositorioDeProductos().Listar();
        }
        public void ModificarMaterial(Material unMaterial)
        {
            FabricaDAL.Current.ObtenerRepositorioDeMateriales().Modificar(unMaterial);
        }
        public void ModificarOrdenFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            if (unaOrdenDeFabricacion.Objetivo.Id == Guid.Empty || unaOrdenDeFabricacion.Objetivo.Cantidad == 0)
                throw new Exception("No está permitido modificar una orden de fabricación sin un objetivo");

            Usuario usuario = GestorSesion.Current.usuarioActual;
            unaOrdenDeFabricacion.Estado = OrdenDeFabricacion.EnumEstadoOrdenFabricacion.FORMULADO;

            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Modificar(unaOrdenDeFabricacion);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} modificó la orden de fabricacion {unaOrdenDeFabricacion.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        public void ModificarProducto(Producto unProducto)
        {
            FabricaDAL.Current.ObtenerRepositorioDeProductos().Modificar(unProducto);
        }
        public void RegistrarMaterial(Material unMaterial)
        {
            FabricaDAL.Current.ObtenerRepositorioDeMateriales().Agregar(unMaterial);
        }
        public void RegistrarProducto(Producto unProducto)
        {
            FabricaDAL.Current.ObtenerRepositorioDeProductos().Agregar(unProducto);
        }
        public bool VerificarDependenciaOrdenesDeFabricacion(IEnumerable<OrdenDeFabricacion> ordenesDeFabricacion)
        {
            if (ordenesDeFabricacion.Any(item => item.fecha < DateTime.Today))
                return false;
            foreach (OrdenDeFabricacion orden in ordenesDeFabricacion) {
                if (orden.OrdenDeFabricacionPosterior != null) {
                    DateTime finishedProduct = orden.fecha.AddHours(orden.Objetivo.plantillaDeFabricacion.ReposoNecesario);
                    if (finishedProduct > orden.OrdenDeFabricacionPosterior.fecha)
                        return false;
                }
            }

            IEnumerable<OrdenDeFabricacion> ordenesAgrabar = ordenesDeFabricacion.OrderByDescending(item => item.fecha);

            foreach (OrdenDeFabricacion orden in ordenesAgrabar) {
                CrearOrdenDeFabricacion(orden);
            }
            GestorPedidos.Current.AgendarPedido(ordenesAgrabar.FirstOrDefault().pedido);

            return true;
        }
        public bool VerificarAvancePedido(Pedido unPedido)
        {
            return false;
        }
        public bool VerificarFinOrdenDeFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            return false;
        }

    }

}
