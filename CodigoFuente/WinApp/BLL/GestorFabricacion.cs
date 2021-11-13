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
using static Dominio.OrdenDeFabricacion;

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

        /// <summary>
        /// Este método cambia el estado de la orden de fabricación a FABRICADO, registra cual fue el momento en que se ejecutó e indica si es necesario crear mas ordenes de fabricación si el resultado no fue suficiente.
        /// </summary>
        /// <param name="unaOrdenDeFabricacion">Este parametro recibe la orden de fabriación a modificar</param>
        /// <returns>Devuelve VERDADERO si hay que agregar una nueva orden de fabricación posterior a esta y devuelve FALSO si no es necesario crear nuevas órdenes de fabricación</returns>
        public bool CerrarFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            unaOrdenDeFabricacion.Estado = EnumEstadoOrdenFabricacion.FABRICADO;
            unaOrdenDeFabricacion.FechaEjecucion = DateTime.Now;
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Modificar(unaOrdenDeFabricacion);
            Usuario usuario = GestorSesion.Current.usuarioActual;
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} terminó de fabricar la orden de fabricacion {unaOrdenDeFabricacion.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);

            return unaOrdenDeFabricacion.Fabricados.Cantidad < unaOrdenDeFabricacion.Objetivo.Cantidad;
        }
        public void ComenzarFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            List<ProductoMaterial> stock = GestorStock.Current.ObtenerMaterialesActuales();
            foreach (ProductoMaterial unIngrediente in unaOrdenDeFabricacion.Objetivo.plantillaDeFabricacion.Ingredientes) {
                ProductoMaterial tmp = unIngrediente.Copiar();
                tmp.Cantidad = unIngrediente.Cantidad * unaOrdenDeFabricacion.Objetivo.Cantidad;
                ProductoMaterial itemStock = stock.FirstOrDefault(item => item.Id == tmp.Id);
                if (itemStock == null || itemStock.Cantidad < tmp.Cantidad){
                    Evento errorEvento = new Evento(Evento.CategoriaEvento.ERROR, $"No se pudo inciar la fabricación de la orden de fabricacion {unaOrdenDeFabricacion.Id} por falta de {tmp}");
                    GestorHistorico.Current.RegistrarBitacora(errorEvento);
                    throw new Exception($"No hay suficiente stock de {tmp}");
                }
            }
            unaOrdenDeFabricacion.Estado = EnumEstadoOrdenFabricacion.ENFABRICACION;
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Modificar(unaOrdenDeFabricacion);

            foreach (ProductoMaterial unIngrediente in unaOrdenDeFabricacion.Objetivo.plantillaDeFabricacion.Ingredientes)
            {
                ProductoMaterial tmp = unIngrediente.Copiar();
                tmp.Cantidad = (-1) * unIngrediente.Cantidad * unaOrdenDeFabricacion.Objetivo.Cantidad;
                GestorStock.Current.ActualizarStock(tmp);                
            }
            Usuario usuario = GestorSesion.Current.usuarioActual;
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} comenzó a fabricar la orden de fabricacion {unaOrdenDeFabricacion.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        public void ReprogramarFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            if (unaOrdenDeFabricacion.Estado != EnumEstadoOrdenFabricacion.FORMULADO && unaOrdenDeFabricacion.Estado != EnumEstadoOrdenFabricacion.AGENDADO)
                throw new Exception("No está permitido reprogramar una orden de fabricacion en este estado");
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Modificar(unaOrdenDeFabricacion);
            Usuario usuario = GestorSesion.Current.usuarioActual;
            Evento unEvento = new Evento(Evento.CategoriaEvento.ADVERTENCIA, $"El usuario {usuario.UsuarioLogin} ha reprogramado la orden de fabricacion {unaOrdenDeFabricacion.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        public void DividirFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion, DateTime fechaSeleccionada)
        {
            OrdenDeFabricacion nuevaOrdenDeFabricacion = null;
            Producto nuevoObjetivo;
            switch (unaOrdenDeFabricacion.Estado) {
                case EnumEstadoOrdenFabricacion.CANCELADO:
                case EnumEstadoOrdenFabricacion.FORMULADO:
                case EnumEstadoOrdenFabricacion.AGENDADO:
                case EnumEstadoOrdenFabricacion.ENFABRICACION:
                    throw new Exception("No está permitido dividir una orden de fabricacion en este estado");
                case EnumEstadoOrdenFabricacion.FABRICADO:
                    nuevoObjetivo = unaOrdenDeFabricacion.Objetivo.Copiar();
                    nuevoObjetivo.Cantidad = unaOrdenDeFabricacion.Objetivo.Cantidad - unaOrdenDeFabricacion.Fabricados.Cantidad;
                    nuevaOrdenDeFabricacion = new OrdenDeFabricacion(unaOrdenDeFabricacion.OrdenDeFabricacionPosterior, unaOrdenDeFabricacion.pedido, nuevoObjetivo);
                    break;
                case EnumEstadoOrdenFabricacion.TERMINADO:
                    nuevoObjetivo = unaOrdenDeFabricacion.Fabricados.Copiar();
                    nuevoObjetivo.Cantidad = unaOrdenDeFabricacion.Fabricados.Cantidad - unaOrdenDeFabricacion.Aprobados.Cantidad;
                    nuevaOrdenDeFabricacion = new OrdenDeFabricacion(unaOrdenDeFabricacion.OrdenDeFabricacionPosterior, unaOrdenDeFabricacion.pedido, nuevoObjetivo);
                    break;
            }
            nuevaOrdenDeFabricacion.FechaPlanificada = fechaSeleccionada;
            CrearOrdenDeFabricacion(nuevaOrdenDeFabricacion);

            unaOrdenDeFabricacion.OrdenDeFabricacionPosterior = nuevaOrdenDeFabricacion;
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Modificar(unaOrdenDeFabricacion);
        }
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
            if (ordenesDeFabricacion.Any(item => item.FechaPlanificada < DateTime.Today))
                return false;
            foreach (OrdenDeFabricacion orden in ordenesDeFabricacion) {
                if (orden.OrdenDeFabricacionPosterior != null) {
                    DateTime finEstimadoConReposo = orden.FechaPlanificada.AddHours(orden.Objetivo.plantillaDeFabricacion.ReposoNecesario);
                    if (finEstimadoConReposo > orden.OrdenDeFabricacionPosterior.FechaPlanificada)
                        return false;
                }
            }

            IEnumerable<OrdenDeFabricacion> ordenesAgrabar = ordenesDeFabricacion.OrderByDescending(item => item.FechaPlanificada);

            foreach (OrdenDeFabricacion orden in ordenesAgrabar) {
                CrearOrdenDeFabricacion(orden);
            }
            GestorPedidos.Current.AgendarPedido(ordenesAgrabar.FirstOrDefault().pedido);

            return true;
        }

        public void VerificarAvancePedido(Pedido unPedido)
        {
            IEnumerable<OrdenDeFabricacion> todas = FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Listar();
            List<OrdenDeFabricacion> ofPedido = todas.Where(item => item.pedido.Id == unPedido.Id).ToList();
            bool todasTerminadas = ofPedido.All(item => item.Estado == EnumEstadoOrdenFabricacion.TERMINADO);
            if(todasTerminadas)
                GestorPedidos.Current.CompletarPedido(unPedido);
        }

        /// <summary>
        /// Este método cambia el estado de la orden de fabricación a TERMINADO e indica si es necesario crear mas ordenes de fabricación si el resultado no fue suficiente.
        /// </summary>
        /// <param name="unaOrdenDeFabricacion">Este parametro recibe la orden de fabriación a modificar</param>
        /// <returns>Devuelve VERDADERO si hay que agregar una nueva orden de fabricación posterior a esta y devuelve FALSO si no es necesario crear nuevas órdenes de fabricación</returns>
        public bool TerminarOrdenDeFabricacion(OrdenDeFabricacion unaOrdenDeFabricacion)
        {
            DateTime reposoMinimo = unaOrdenDeFabricacion.FechaEjecucion.AddHours(unaOrdenDeFabricacion.Objetivo.plantillaDeFabricacion.ReposoNecesario);
            if (DateTime.Now < reposoMinimo) {
                throw new Exception("El producto aún no ha cumplido con el tiempo minimo de reposo sugerido");
            }
            GestorStock.Current.ActualizarStock(unaOrdenDeFabricacion.Aprobados);
            unaOrdenDeFabricacion.Estado = EnumEstadoOrdenFabricacion.TERMINADO;
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeFabricacion().Modificar(unaOrdenDeFabricacion);
            Usuario usuario = GestorSesion.Current.usuarioActual;
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} finalizó la orden de fabricacion {unaOrdenDeFabricacion.Id} y agregó {unaOrdenDeFabricacion.Aprobados.Cantidad} {unaOrdenDeFabricacion.Aprobados} al inventario");
            GestorHistorico.Current.RegistrarBitacora(unEvento);

            bool necesitaDividirOF = unaOrdenDeFabricacion.Aprobados.Cantidad < unaOrdenDeFabricacion.Fabricados.Cantidad;
            if(!necesitaDividirOF)
                VerificarAvancePedido(unaOrdenDeFabricacion.pedido);
            return necesitaDividirOF;
        }

    }

}
