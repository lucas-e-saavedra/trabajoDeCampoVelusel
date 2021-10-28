using DAL;
using Dominio;
using Dominio.CompositeProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public sealed class GestorStock
    {
        private readonly static GestorStock _instance = new GestorStock();
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

        public void ActualizarStock(ProductoMaterial diferencia) {
            ProductoMaterial unProductoMaterial = unAlmacen.Stock.First(item => item.Id == diferencia.Id);
            unProductoMaterial.Cantidad += diferencia.Cantidad;
            if(unProductoMaterial.Cantidad < 0){
                throw new Exception("No es posible tener stock negativo");
            }
            FabricaDAL.Current.ObtenerRepositorioDeAlmacenes().Modificar(unAlmacen);
        }
        public void ActualizarStockTiendOnline(){}
        public void EnviarAlertas(){ }
        public void EnviarMail(){ }
        public List<ProductoMaterial> ObtenerMaterialesActuales(){
            return unAlmacen.Stock;
        }
    }
}
