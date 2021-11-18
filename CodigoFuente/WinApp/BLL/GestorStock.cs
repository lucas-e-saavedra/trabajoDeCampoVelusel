using DAL;
using Dominio;
using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Este gestor se encarga de manejar el stock del deposito
    /// </summary>
    public sealed class GestorStock
    {
        private readonly static GestorStock _instance = new GestorStock();
        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
        public static GestorStock Current
        {
            get
            {
                return _instance;
            }
        }
        Almacen unAlmacen;
        private GestorStock()
        {
            //Esto ahora lo hago así porque solo preveo tener un almacén,
            //cuando se agreguen mas almacenes tendré q acomodarlo
            unAlmacen = FabricaDAL.Current.ObtenerRepositorioDeAlmacenes().Listar().FirstOrDefault();
            if(unAlmacen == null){
                unAlmacen = new Almacen() {
                    Id = Guid.NewGuid(),
                    Nombre = "Almacen principal",
                    Stock = new List<ProductoMaterial>()
                };
                FabricaDAL.Current.ObtenerRepositorioDeAlmacenes().Agregar(unAlmacen);
            }
        }

        /// <summary>
        /// Este metodo sirve para actualizar el stock del deposito
        /// </summary>
        /// <param name="diferencia">Instancia del producto o material del cual vamos a modificar su cantidad y la cantidad que hay que incrementar o reducir</param>
        public void ActualizarStock(ProductoMaterial diferencia) {
            ProductoMaterial unProductoMaterial = unAlmacen.Stock.FirstOrDefault(item => item.Id == diferencia.Id);
            if (unProductoMaterial != null) {
                unProductoMaterial.Cantidad += diferencia.Cantidad;
                if (unProductoMaterial.Cantidad < 0)
                    throw new Exception("No es posible tener stock negativo");
            } else {
                if (diferencia.Cantidad < 0)
                    throw new Exception("No es posible tener stock negativo");
                unAlmacen.Stock.Add(diferencia);
            }
            FabricaDAL.Current.ObtenerRepositorioDeAlmacenes().Modificar(unAlmacen);
        }
        
        /// <summary>
        /// Este método lo vamos a usar para actualizar las publicaciones de la tienda en linea (por ahora provisoriamente escribe la info en un txt)
        /// </summary>
        /// <param name="unPedido">Instancia del pedido interno que generó el vendedor</param>
        public void ActualizarStockTiendOnline(Pedido unPedido){
            //TODO: acá hay que investigar como interactuar con distinas apis de tiendas en linea
            FabricaDAL.Current.ObtenerExpotadorDePedidos().Agregar(unPedido);
        }

        /// <summary>
        /// Este metodo es el que se va a invocar diariamente, se encarga de enviar las alertas de bloqueos a cada vendedor que las haya configurado en el sistema y que haya configurado las mismas con mas de cero días de anticipación
        /// </summary>
        public void EnviarAlertas(){
            IEnumerable<Usuario> usuarios = GestorUsuarios.Current.ListarUsuarios();
            List<Usuario> compradores = usuarios.Where(item => item.Permisos.Any(permiso => permiso.Nombre == "Comprador")).ToList();

            foreach(Usuario unComprador in compradores) {
                Alarma alarmaUsuario = ObtenerAlarmas(unComprador);
                List<ProductoMaterial> bloqueoPorStock = new List<ProductoMaterial>();
                if(alarmaUsuario.DiasAlarmaStock > 0 )
                    bloqueoPorStock = CalcularBloqueosPorFaltaDeStock(alarmaUsuario.DiasAlarmaStock);

                List<ProductoMaterial> bloqueoPorCompras = new List<ProductoMaterial>();
                if (alarmaUsuario.DiasAlarmaCompras > 0)
                    bloqueoPorCompras = CalcularBloqueosPorProblemasEnLasCompras(alarmaUsuario.DiasAlarmaCompras);

                if (bloqueoPorStock.Count > 0 || bloqueoPorCompras.Count > 0){
                    StringBuilder contenidoEmail = new StringBuilder();
                    contenidoEmail.Append($"Hola {unComprador.Nombre}:\n");
                    if (bloqueoPorStock.Count > 0) {
                        String[] nombres = bloqueoPorStock.Select(item => (string)item.Nombre).ToArray();
                        String materialesFaltantes = String.Join(",", nombres);
                        contenidoEmail.Append($"Hemos detectado que con el stock actual de {materialesFaltantes} en el plazo de {alarmaUsuario.DiasAlarmaStock} días no se podrá afrontar correctamente las tareas de fabricación. Por favor planifique las compras necesarias para evitar esta situación.\n");
                    }
                        
                    if (bloqueoPorCompras.Count > 0) {
                        String[] nombres = bloqueoPorCompras.Select(item => (string)item.Nombre).ToArray();
                        String materialesFaltantes = String.Join(",", nombres);
                        contenidoEmail.Append($"Hemos detectado que a pesar de las compras previstas la prevision de stock de {materialesFaltantes} en el plazo de {alarmaUsuario.DiasAlarmaCompras} días indica que no se podrá afrontar correctamente las tareas de fabricación. Por favor planifique las compras necesarias para evitar esta situación.\n");
                    }

                    contenidoEmail.Append($"Saludos, y que tenga buen día\nVelusel Fabrica");
                    GestorNotificaciones.Current.EnviarMail(unComprador.Email, "Posibles bloqueos de fabricacion", contenidoEmail.ToString());
                }
            }
        }
        
        /// <summary>
        /// Este método sirve para conocer el stock completo del almacén, no discrimina entre materiales o productos.
        /// </summary>
        /// <returns>Devuelve una lista de objetos ProductoMaterial</returns>
        public List<ProductoMaterial> ObtenerMaterialesActuales(){
            return unAlmacen.Stock;
        }

        /// <summary>
        /// Este método trae la configuración de alarmas de un usuario.
        /// </summary>
        /// <param name="unUsuario">Instancia del Usuario del cual se quiere consultar su configuración.</param>
        /// <returns>Devuelve un objeto Alarma</returns>
        public Alarma ObtenerAlarmas(Usuario unUsuario) {
            string[] criterios = { };
            string[] valores = { unUsuario.IdUsuario.ToString() };
            Alarma configAlarma = FabricaDAL.Current.ObtenerRepositorioDeAlarmas().BuscarUno(criterios, valores);

            if(configAlarma == null) {
                configAlarma = new Alarma();
                configAlarma.comprador = unUsuario;
                FabricaDAL.Current.ObtenerRepositorioDeAlarmas().Agregar(configAlarma);
            }

            return configAlarma;
        }
        
        /// <summary>
        /// Este metodo permite grabar la configuración de alarmas de un usuario.
        /// </summary>
        /// <param name="configAlarma">Recibe un objeto Alarma el cuál contiene toda la info necesaria</param>
        public void ConfigurarAlarmas(Alarma configAlarma) {
            if (configAlarma.DiasAlarmaCompras < configAlarma.DiasAlarmaStock)
                throw new Exception("La alarma por falta de compras no puede ser menor que la alarma por falta de stock");
            FabricaDAL.Current.ObtenerRepositorioDeAlarmas().Modificar(configAlarma);
        }

        #region Metodos para detectar bloqueos futuros en la producción
        private List<ProductoMaterial> CalcularBloqueosPorFaltaDeStock(int diasDeAnticipacion)
        {
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaAnalisis = CalcularFechaDescontandoFindes(fechaHoy, diasDeAnticipacion);
            IEnumerable<OrdenDeFabricacion> todasLasOF = BLL.GestorFabricacion.Current.ListarOrdenesDeFabricacion();
            IEnumerable<OrdenDeFabricacion> ofAgendadas = todasLasOF.Where(item => item.Estado == OrdenDeFabricacion.EnumEstadoOrdenFabricacion.AGENDADO);
            IEnumerable<OrdenDeFabricacion> ordenesDeFabricacion = ofAgendadas.Where(item => fechaHoy <= item.FechaPlanificada && item.FechaPlanificada < fechaAnalisis);

            List<ProductoMaterial> materialesEnStock = DiscriminarMateriales();
            List<ProductoMaterial> materialesNecesarios = CalcularMaterialesNecesarios(ordenesDeFabricacion);
            List<ProductoMaterial> materialesFaltantes = CalcularMaterialesFaltantes(materialesEnStock, materialesNecesarios);
            return materialesFaltantes;
        }

        private List<ProductoMaterial> CalcularBloqueosPorProblemasEnLasCompras(int diasDeAnticipacion)
        {
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaAnalisis = CalcularFechaDescontandoFindes(fechaHoy, diasDeAnticipacion);

            IEnumerable<OrdenDeFabricacion> todasLasOF = BLL.GestorFabricacion.Current.ListarOrdenesDeFabricacion();
            IEnumerable<OrdenDeFabricacion> ofAgendadas = todasLasOF.Where(item => item.Estado == OrdenDeFabricacion.EnumEstadoOrdenFabricacion.AGENDADO);
            IEnumerable<OrdenDeFabricacion> ordenesDeFabricacion = ofAgendadas.Where(item => fechaHoy <= item.FechaPlanificada && item.FechaPlanificada < fechaAnalisis);

            IEnumerable<OrdenDeCompra> todasLasOC = BLL.GestorCompras.Current.ConsultarOrdenesDeCompra();
            IEnumerable<OrdenDeCompra> ocAgendadas = todasLasOC.Where(item => fechaHoy <= item.FechaObjetivo && item.FechaObjetivo < fechaAnalisis);
            IEnumerable<OrdenDeCompra> ordenesDeCompra = ocAgendadas.Where(item => fechaHoy <= item.FechaEstimadaRecepcion && item.FechaEstimadaRecepcion < fechaAnalisis);

            List<ProductoMaterial> materialesEnStock = DiscriminarMateriales();
            List<ProductoMaterial> materialesNecesarios = CalcularMaterialesNecesarios(ordenesDeFabricacion);
            List<ProductoMaterial> materialesComprados = CalcularMaterialesComprados(ordenesDeCompra);
            List<ProductoMaterial> materialesEstimados = CalcularStockPrevisto(materialesEnStock, materialesComprados);
            List<ProductoMaterial> materialesFaltantes = CalcularMaterialesFaltantes(materialesEstimados, materialesNecesarios);
            return materialesFaltantes;
        }

        private DateTime CalcularFechaDescontandoFindes(DateTime unaFecha, int cantidadDeDias)
        {
            while (cantidadDeDias > 0)
            {
                unaFecha = unaFecha.AddDays(1);
                if (unaFecha.DayOfWeek != DayOfWeek.Saturday && unaFecha.DayOfWeek != DayOfWeek.Sunday)
                    cantidadDeDias--;
            }
            return unaFecha;
        }

        private List<ProductoMaterial> DiscriminarMateriales()
        {
            List<ProductoMaterial> stock = BLL.GestorStock.Current.ObtenerMaterialesActuales();
            return stock.Where(item => item is Material).ToList();        
        }

        private List<ProductoMaterial> CalcularMaterialesNecesarios(IEnumerable<OrdenDeFabricacion> fabricaciones)
        {
            List<ProductoMaterial> materialesNecesarios = new List<ProductoMaterial>();
            foreach (OrdenDeFabricacion unaOrdenDeFabricacion in fabricaciones)
            {
                foreach (ProductoMaterial unIngrediente in unaOrdenDeFabricacion.Objetivo.plantillaDeFabricacion.Ingredientes)
                {
                    ProductoMaterial tmp = unIngrediente.Copiar();
                    tmp.Cantidad = unIngrediente.Cantidad * unaOrdenDeFabricacion.Objetivo.Cantidad;
                    ProductoMaterial itemStock = materialesNecesarios.FirstOrDefault(item => item.Id == tmp.Id);
                    if (itemStock == null)
                    {
                        materialesNecesarios.Add(tmp);
                    }
                    else
                    {
                        itemStock.Cantidad = itemStock.Cantidad + tmp.Cantidad;
                    }
                }
            }
            return materialesNecesarios;
        }

        private List<ProductoMaterial> CalcularMaterialesFaltantes(List<ProductoMaterial> materialesEnStock, List<ProductoMaterial> materialesNecesarios)
        {
            List<ProductoMaterial> materialesFaltantes = new List<ProductoMaterial>();
            foreach (ProductoMaterial ingrediente in materialesNecesarios)
            {
                ProductoMaterial itemStock = materialesEnStock.FirstOrDefault(item => item.Id == ingrediente.Id);
                if (itemStock == null || itemStock.Cantidad < ingrediente.Cantidad)
                {
                    ProductoMaterial tmp = ingrediente.Copiar();
                    tmp.Cantidad = itemStock.Cantidad - ingrediente.Cantidad;
                    materialesFaltantes.Add(tmp);
                }
            }
            return materialesFaltantes;
        }

        private List<ProductoMaterial> CalcularMaterialesComprados(IEnumerable<OrdenDeCompra> compras)
        {
            List<ProductoMaterial> materialesComprados = new List<ProductoMaterial>();
            foreach (OrdenDeCompra unaOrdenDeCompra in compras)
            {
                ProductoMaterial tmp = unaOrdenDeCompra.Comprados.Copiar();
                ProductoMaterial itemComprado = materialesComprados.FirstOrDefault(item => item.Id == tmp.Id);
                if (itemComprado == null)
                {
                    materialesComprados.Add(tmp);
                }
                else
                {
                    itemComprado.Cantidad = itemComprado.Cantidad + tmp.Cantidad;
                }

            }
            return materialesComprados;
        }

        private List<ProductoMaterial> CalcularStockPrevisto(List<ProductoMaterial> materialesEnStock, List<ProductoMaterial> materialesComprados)
        {
            List<ProductoMaterial> stockPrevisto = new List<ProductoMaterial>();
            foreach (ProductoMaterial unMaterial in materialesEnStock)
            {
                ProductoMaterial tmp = unMaterial.Copiar();
                ProductoMaterial itemStock = stockPrevisto.FirstOrDefault(item => item.Id == tmp.Id);
                if (itemStock == null)
                {
                    stockPrevisto.Add(tmp);
                }
                else
                {
                    itemStock.Cantidad = itemStock.Cantidad + tmp.Cantidad;
                }
            }
            foreach (ProductoMaterial unMaterial in materialesComprados)
            {
                ProductoMaterial tmp = unMaterial.Copiar();
                ProductoMaterial itemStock = stockPrevisto.FirstOrDefault(item => item.Id == tmp.Id);
                if (itemStock == null)
                {
                    stockPrevisto.Add(tmp);
                }
                else
                {
                    itemStock.Cantidad = itemStock.Cantidad + tmp.Cantidad;
                }
            }
            return stockPrevisto;
        }
        #endregion
    }
}
