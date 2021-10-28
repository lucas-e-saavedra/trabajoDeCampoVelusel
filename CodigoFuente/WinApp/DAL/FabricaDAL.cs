using System.Configuration;
using Servicios.DAL.Contratos;
using Dominio.CompositeProducto;
using Dominio;

namespace DAL
{
    public class FabricaDAL
    {
        #region Singleton
        private readonly static FabricaDAL _instance = new FabricaDAL();

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

        public IRepositorioGenerico<Cliente> ObtenerRepositorioDeClientes()
        {
            return new Implementaciones.SqlServer.ClienteRepositorio(bbddVelusel);
        }
        public IRepositorioGenerico<Material> ObtenerRepositorioDeMateriales()
        {
            return new Implementaciones.SqlServer.MaterialRepositorio(bbddVelusel);
        }
        public IRepositorioGenerico<Producto> ObtenerRepositorioDeProductos()
        {
            return new Implementaciones.SqlServer.ProductoRepositorio(bbddVelusel);
        }
        public IRepositorioGenerico<PlantillaDeFabricacion> ObtenerRepositorioDePlantillasDeFabricacion()
        {
            return new Implementaciones.SqlServer.PlantillaDeFabricacionRepositorio(bbddVelusel);
        }
        public IRelacionGenerica<PlantillaDeFabricacion, Material> ObtenerProductoMaterialRelacion()
        {
            return new Implementaciones.SqlServer.PlantillaFabricacionMaterialRelacion(bbddVelusel);
        }
        public IRelacionGenerica<PlantillaDeFabricacion, Producto> ObtenerProductoProductoRelacion()
        {
            return new Implementaciones.SqlServer.PlantillaFabricacionSubproductoRelacion(bbddVelusel);
        }
        public IRepositorioGenerico<Pedido> ObtenerRepositorioDePedidos()
        {
            return new Implementaciones.SqlServer.PedidoRepositorio(bbddVelusel);
        }
        public IRelacionGenerica<Pedido, Producto> ObtenerPedidoProductoRelacion()
        {
            return new Implementaciones.SqlServer.PedidoProductoRelacion(bbddVelusel);
        }
        public IRepositorioGenerico<OrdenDeFabricacion> ObtenerRepositorioDeOrdenesDeFabricacion()
        {
            return new Implementaciones.SqlServer.OrdenDeFabricacionRepositorio(bbddVelusel);
        }
        public IRepositorioGenerico<OrdenDeCompra> ObtenerRepositorioDeOrdenesDeCompra()
        {
            return new Implementaciones.SqlServer.OrdenDeCompraRepositorio(bbddVelusel);
        }

        public IRepositorioGenerico<Almacen> ObtenerRepositorioDeAlmacenes()
        {
            return new Implementaciones.SqlServer.AlmacenRepositorio(bbddVelusel);
        }
        public IRelacionGenerica<Almacen, Producto> ObtenerAlmacenProductoRelacion()
        {
            return new Implementaciones.SqlServer.AlmacenProductoRelacion(bbddVelusel);
        }
        public IRelacionGenerica<Almacen, Material> ObtenerAlmacenMaterialRelacion()
        {
            return new Implementaciones.SqlServer.AlmacenMaterialRelacion(bbddVelusel);
        }

    }
}
