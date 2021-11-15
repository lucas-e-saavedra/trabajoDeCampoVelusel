using System.Configuration;
using Servicios.DAL.Contratos;
using Dominio.CompositeProducto;
using Dominio;

namespace DAL
{
    /// <summary>
    /// Esta clase se encarga de crear los objetos que gestionan la persistencia de los objetos de la capa de Dominio.
    /// </summary>
    public class FabricaDAL
    {
        #region Singleton
        private readonly static FabricaDAL _instance = new FabricaDAL();

        /// <summary>
        /// Acceso a la instancia del creador de DALs
        /// </summary>
        public static FabricaDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private FabricaDAL()
        {
            bbddVelusel = ConfigurationManager.ConnectionStrings["VeluselConString"].ConnectionString;
        }
        #endregion
        private string bbddVelusel;

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia de los clientes del sistema
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<Cliente> ObtenerRepositorioDeClientes()
        {
            return new Implementaciones.SqlServer.ClienteRepositorio(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia de los materiales que se utilizan para fabricar los productos del sistema
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<Material> ObtenerRepositorioDeMateriales()
        {
            return new Implementaciones.SqlServer.MaterialRepositorio(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia de los productos que se fabrican 
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<Producto> ObtenerRepositorioDeProductos()
        {
            return new Implementaciones.SqlServer.ProductoRepositorio(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia de las plantillas de fabricación de especifican las reglas de como debe ser fabricado cada producto.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<PlantillaDeFabricacion> ObtenerRepositorioDePlantillasDeFabricacion()
        {
            return new Implementaciones.SqlServer.PlantillaDeFabricacionRepositorio(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la vinculación entre la plantilla de fabricación y los materiales necesarios.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRelacionGenerica</returns>
        public IRelacionGenerica<PlantillaDeFabricacion, Material> ObtenerProductoMaterialRelacion()
        {
            return new Implementaciones.SqlServer.PlantillaFabricacionMaterialRelacion(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la vinculación entre la plantilla de fabricación y los subproductos necesarios.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRelacionGenerica</returns>
        public IRelacionGenerica<PlantillaDeFabricacion, Producto> ObtenerProductoProductoRelacion()
        {
            return new Implementaciones.SqlServer.PlantillaFabricacionSubproductoRelacion(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia de los pedidos que manejan los vendedores en el sistema.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<Pedido> ObtenerRepositorioDePedidos()
        {
            return new Implementaciones.SqlServer.PedidoRepositorio(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que permite exportar la informacion del pedido a la tienda online por ahora esto es solo un mock.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<Pedido> ObtenerExpotadorDePedidos()
        {
            return new Implementaciones.TXT.ExportadorPedidos();
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la vinculación entre un pedido y los productos que incluye cada pedido.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRelacionGenerica</returns>
        public IRelacionGenerica<Pedido, Producto> ObtenerPedidoProductoRelacion()
        {
            return new Implementaciones.SqlServer.PedidoProductoRelacion(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia de las ordenes de fabricación que ordenan la producción.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<OrdenDeFabricacion> ObtenerRepositorioDeOrdenesDeFabricacion()
        {
            return new Implementaciones.SqlServer.OrdenDeFabricacionRepositorio(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia de las ordenes de compra que permiten el aprovisionamiento de materiales para la producción.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<OrdenDeCompra> ObtenerRepositorioDeOrdenesDeCompra()
        {
            return new Implementaciones.SqlServer.OrdenDeCompraRepositorio(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia del deposito donde se almacena el inventario.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<Almacen> ObtenerRepositorioDeAlmacenes()
        {
            return new Implementaciones.SqlServer.AlmacenRepositorio(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la vinculación entre el almacen y los productos que hay en el inventario.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRelacionGenerica</returns>
        public IRelacionGenerica<Almacen, Producto> ObtenerAlmacenProductoRelacion()
        {
            return new Implementaciones.SqlServer.AlmacenProductoRelacion(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la vinculación entre el almacen y los materiales que hay en el inventario.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRelacionGenerica</returns>
        public IRelacionGenerica<Almacen, Material> ObtenerAlmacenMaterialRelacion()
        {
            return new Implementaciones.SqlServer.AlmacenMaterialRelacion(bbddVelusel);
        }

        /// <summary>
        /// Este método provee el objeto que gestiona la persistencia de las alarmas que configuran los vendedores para evitar bloqueos en la producción.
        /// </summary>
        /// <returns>Devuelve un objeto que implemente la interfaz IRepositorioGenerico</returns>
        public IRepositorioGenerico<Alarma> ObtenerRepositorioDeAlarmas()
        {
            return new Implementaciones.SqlServer.AlarmaRepositorio(bbddVelusel);
        }
    }
}
