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
using static Dominio.OrdenDeCompra;

namespace BLL
{
    /// <summary>
    /// Este gestor se encarga de manejar la información de las compras de materiales
    /// </summary>
    public sealed class GestorCompras
    {
        private readonly static GestorCompras _instance = new GestorCompras();

        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
        public static GestorCompras Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorCompras()
        {
            //Implent here the initialization of your singleton
        }

        /// <summary>
        /// Este método calcula cuantos materiales faltan comprar teniendo en cuenta la cantidad que se necesita, las compras ya planificadas y el stock actual
        /// </summary>
        /// <param name="necesarios">Recibe una colección de Materiales necesarios</param>
        /// <param name="comprados">Recibe una colección de Materiales que ya han sido comprados</param>
        /// <param name="enStock">Recibe una colección de Materiales que hay en el inventario</param>
        /// <returns>Devuelve una lista de los materiales que faltan comprar y la cantidad de cada uno de ellos</returns>
        public List<Material> CalcularMaterialesAComprar(IEnumerable<Material> necesarios, IEnumerable<Material> comprados, IEnumerable<Material> enStock) {
            List<Material> materialesAComprar = new List<Material>();
            foreach(Material unMaterial in necesarios){
                Material materialEnStock = enStock.FirstOrDefault(item => item.Id == unMaterial.Id);
                float cantidadEnStock = materialEnStock?.Cantidad ?? 0;
                Material materialComprado = comprados.FirstOrDefault(item => item.Id == unMaterial.Id);
                float cantidadComprada = materialComprado?.Cantidad ?? 0;
                float cantidadAComprar = unMaterial.Cantidad - cantidadEnStock - cantidadComprada;
                if(cantidadAComprar > 0){
                    unMaterial.Cantidad = cantidadAComprar;
                    materialesAComprar.Add(unMaterial);
                }
            }
            return materialesAComprar;
        }

        /// <summary>
        /// Este método calcula todos los materiales que se van a comprar en un rango de fechas
        /// </summary>
        /// <param name="desde">Fecha de inicio</param>
        /// <param name="hasta">Fecha de fin</param>
        /// <returns>Devuelve una lista agrupada por cada material y la cantidad que ya ha sido comprada de cada uno de ellos</returns>
        public List<Material> CalcularMaterialesComprados(DateTime desde, DateTime hasta) {
            //TODO: el estado todavía no lo puedo filtrar por ahora puse las no canceladas
            List<OrdenDeCompra> todas = ConsultarOrdenesDeCompra();
            List<OrdenDeCompra> compradas = todas.Where(item => item.Estado != EnumEstadoOrdenCompra.CANCELADO).ToList();
            List<OrdenDeCompra> enFecha = todas.Where(item => item.FechaObjetivo >= desde && item.FechaObjetivo < hasta).ToList();
            List<OrdenDeCompra> fechaYestado = compradas.Intersect(enFecha).ToList();
            return CalcularMaterialesComprados(fechaYestado);
        }
        private List<Material> CalcularMaterialesComprados(IEnumerable<OrdenDeCompra> ordenesDeCompra) {
            List<Material> materiales = new List<Material>();
            foreach (OrdenDeCompra oc in ordenesDeCompra)
            {
                Material unMaterial = (Material)oc.Objetivo;
                if (!materiales.Any(item => item.Id == unMaterial.Id))
                {
                    Material nuevoMaterial = unMaterial.Copiar();
                    nuevoMaterial.Cantidad = 0;
                    materiales.Add(nuevoMaterial);
                }
                float cantidadAagregar = oc.Objetivo.Cantidad;
                Material materialActual = materiales.First(item => item.Id == unMaterial.Id);
                materialActual.Cantidad += cantidadAagregar;
            }
            return materiales;
        }

        /// <summary>
        /// Este método calcula todos los materiales que se van necesitar para cumplir con las ordenes de fabricación que estan agendadas en un rango de fechas
        /// </summary>
        /// <param name="desde">Fecha de inicio</param>
        /// <param name="hasta">Fecha de fin</param>
        /// <returns>Devuelve una lista agrupada por cada material y la cantidad necesaria cada uno de ellos</returns>
        public List<Material> CalcularMaterialesNecesarios(DateTime desde, DateTime hasta) {
            List<OrdenDeFabricacion> todas = GestorFabricacion.Current.ListarOrdenesDeFabricacion().ToList();
            List<OrdenDeFabricacion> agendadas = todas.Where(item => item.Estado == OrdenDeFabricacion.EnumEstadoOrdenFabricacion.AGENDADO).ToList();
            List<OrdenDeFabricacion> enFecha = todas.Where(item => item.FechaPlanificada >= DateTime.Today && item.FechaPlanificada < hasta).ToList();
            List<OrdenDeFabricacion> fechaYestado = agendadas.Intersect(enFecha).ToList();
            List<Material> materialesNecesarios = CalcularMaterialesNecesarios(fechaYestado);
            List<Material> materialesComprados = CalcularMaterialesComprados(DateTime.Today, desde);
            List<ProductoMaterial> stock = GestorStock.Current.ObtenerMaterialesActuales();

            IEnumerable<ProductoMaterial> x = stock.Where(item => item is Material);
            IEnumerable<Material> y = x.Select(item => (Material)item);
            List<Material> materialesEnStock = y.ToList();
            List<Material> materialesAcomprar = CalcularMaterialesAComprar(materialesNecesarios, materialesComprados, materialesEnStock);
            return materialesAcomprar;
        }
        private List<Material> CalcularMaterialesNecesarios(IEnumerable<OrdenDeFabricacion> ordenesDeFabricacion) {
            List<Material> materiales = new List<Material>();
            foreach (OrdenDeFabricacion of in ordenesDeFabricacion)
            {
                foreach (ProductoMaterial unIngrediente in of.Objetivo.plantillaDeFabricacion.Ingredientes)
                {
                    if (unIngrediente is Material)
                    {
                        Material unMaterial = (Material)unIngrediente;
                        if (!materiales.Any(item => item.Id == unMaterial.Id))
                        {
                            Material nuevoMaterial = unMaterial.Copiar();
                            nuevoMaterial.Cantidad = 0;
                            materiales.Add(nuevoMaterial);
                        }
                        float cantidadAagregar = unMaterial.Cantidad * of.Objetivo.Cantidad;
                        Material materialActual = materiales.First(item => item.Id == unMaterial.Id);
                        materialActual.Cantidad += cantidadAagregar;
                    }
                }
            }
            return materiales;
        }

        /// <summary>
        /// Este método registra que se ha efectuado la compra de lo que se solicitó en una orden de compra
        /// </summary>
        /// <param name="unaOrdenDeCompra">Orden de compra que se va a modificar</param>
        public void ComprarOrdenDeComprar(OrdenDeCompra unaOrdenDeCompra) {
            if(unaOrdenDeCompra.Comprados.Cantidad < unaOrdenDeCompra.Objetivo.Cantidad)
                throw new Exception("No está permitido registrar una compra por menos cantidad de la solicitada");
            unaOrdenDeCompra.Estado = EnumEstadoOrdenCompra.COMPRADO;

            Usuario usuario = GestorSesion.Current.usuarioActual;
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeCompra().Modificar(unaOrdenDeCompra);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} concretó la compra solicitada en la orden de compra {unaOrdenDeCompra.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

        /// <summary>
        /// Este método muestra todas las ordenes de compra que se encuentran activas (puede ser porque todavía no se compraron, o porque se compraron pero todavía no se recibieron)
        /// </summary>
        /// <returns>Devuelve una lista de OrdenDeCompra</returns>
        public List<OrdenDeCompra> ConsultarOrdenesDeCompra() {
            List<OrdenDeCompra> todas = FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeCompra().Listar().ToList();
            return todas.Where(item => item.Estado == EnumEstadoOrdenCompra.FORMULADO || item.Estado == EnumEstadoOrdenCompra.COMPRADO).ToList();
        }

        /// <summary>
        /// Este método graba una nueva orden de compra y la guarda en estado Formulado
        /// </summary>
        /// <param name="unaOrdenDeCompra">Orden de compra que se va a agregar</param>
        public void CrearOrdenDeCompra(OrdenDeCompra unaOrdenDeCompra) {
            if (unaOrdenDeCompra.Objetivo == null || unaOrdenDeCompra.Objetivo.Id == Guid.Empty)
                throw new Exception("No está permitido crear una orden de compra sin un material");
            if (unaOrdenDeCompra.Objetivo.Cantidad == 0)
                throw new Exception("No está permitido crear una orden de compra de cantidad cero");

            Usuario usuario = GestorSesion.Current.usuarioActual;
            unaOrdenDeCompra.Estado = EnumEstadoOrdenCompra.FORMULADO;
            unaOrdenDeCompra.solicitante = usuario;

            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeCompra().Agregar(unaOrdenDeCompra);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} agregó la orden de compra {unaOrdenDeCompra.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        
        /// <summary>
        /// Genera un nuevo objeto orden de compra según un objetivo de fecha y material.
        /// </summary>
        /// <param name="fechaObjetivo">Fecha limite en la que se necesita que se complete la compra</param>
        /// <param name="materialSolicitado">Material y cantidad minima que se necesita</param>
        /// <returns>Devuelve un objeto OrdenDeCompra</returns>
        public OrdenDeCompra CrearOrdenDeCompra(DateTime fechaObjetivo, Material materialSolicitado) {
            OrdenDeCompra unaOrdenDeCompra = new OrdenDeCompra(materialSolicitado);
            unaOrdenDeCompra.Id = Guid.NewGuid();
            unaOrdenDeCompra.FechaObjetivo = fechaObjetivo;

            return unaOrdenDeCompra;
        }

        /// <summary>
        /// Este método graba una lista de ordenes de compra para que se puedan elaborar todas las ordenes de fabricación desde una fecha puntual
        /// </summary>
        /// <param name="desde">Fecha de inicio del intervalo de fabricación</param>
        /// <param name="ordenesDeCompra">Lista de ordenes de compra sugeridas</param>
        public void GrabarOrdenesDeCompraSugeridas(DateTime desde, IEnumerable<OrdenDeCompra> ordenesDeCompra) {
            if (ordenesDeCompra.Any(item => item.FechaObjetivo < DateTime.Today))
                throw new Exception("No está permitido crear ordenes de compra con fecha anterior a hoy");
            if (ordenesDeCompra.Any(item => item.FechaObjetivo >= desde))
                throw new Exception("Todas las ordenes de compra deben tener como objetivo fechas que sean anteriores al inicio del intervalo que se está analizando");
            foreach (OrdenDeCompra unaOrdenDeCompra in ordenesDeCompra){
                CrearOrdenDeCompra(unaOrdenDeCompra);
            }
        }

        /// <summary>
        /// Este método registra que se ha recibido los materiales que se compraron segun lo que se solicitó en una orden de compra
        /// </summary>
        /// <param name="unaOrdenDeCompra">Orden de compra que se va a modificar</param>
        public void RecibirOrdenDeCompra(OrdenDeCompra unaOrdenDeCompra) {
            unaOrdenDeCompra.Estado = EnumEstadoOrdenCompra.RECIBIDO;
            Usuario usuario = GestorSesion.Current.usuarioActual;
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeCompra().Modificar(unaOrdenDeCompra);
            GestorStock.Current.ActualizarStock(unaOrdenDeCompra.Recibidos);

            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} recibió los materiales solicitados en la orden de compra {unaOrdenDeCompra.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        
        /// <summary>
        /// Este método registra que la orden de compra ha retrocedido a un estado anterior        
        /// </summary>
        /// <param name="unaOrdenDeCompra">Orden de compra que se va a modificar</param>
        public void RevertirOrdenDeCompra(OrdenDeCompra unaOrdenDeCompra) {
            EnumEstadoOrdenCompra estadoAnterior = unaOrdenDeCompra.Estado;
            switch (unaOrdenDeCompra.Estado){
                case EnumEstadoOrdenCompra.CANCELADO:
                    throw new Exception("No se puede revertir una orden de compra que ya se encuentra cancelada");
                case EnumEstadoOrdenCompra.FORMULADO:
                    unaOrdenDeCompra.Estado = EnumEstadoOrdenCompra.CANCELADO;                    
                    break;
                case EnumEstadoOrdenCompra.COMPRADO:
                    unaOrdenDeCompra.Estado = EnumEstadoOrdenCompra.FORMULADO;
                    break;
                case EnumEstadoOrdenCompra.RECIBIDO:
                    throw new Exception("No se puede revertir una orden de compra que ya se encuentra recibida");
            }
            unaOrdenDeCompra.FechaEstimadaRecepcion = DateTime.MinValue;
            unaOrdenDeCompra.Comprados.Cantidad = 0;
            unaOrdenDeCompra.FechaRealRecepcion = DateTime.MinValue;
            unaOrdenDeCompra.Recibidos.Cantidad = 0;

            Usuario usuario = GestorSesion.Current.usuarioActual;
            
            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeCompra().Modificar(unaOrdenDeCompra);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} revirtió la orden de compra {unaOrdenDeCompra.Id} de {estadoAnterior} a {unaOrdenDeCompra.Estado}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
    }
}
