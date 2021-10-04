using DAL;
using Dominio.CompositeProducto;
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

        public void RegistrarMaterial(Material unMaterial)
        {
            FabricaDAL.Current.ObtenerRepositorioDeMateriales().Agregar(unMaterial);
        }
        public void RegistrarProducto(Producto unProducto)
        {
            FabricaDAL.Current.ObtenerRepositorioDeProductos().Agregar(unProducto);
        }
        public void BorrarMaterial(Material unMaterial)
        {
            FabricaDAL.Current.ObtenerRepositorioDeMateriales().Borrar(unMaterial);
        }
        public void BorrarProducto(Producto unProducto)
        {
            FabricaDAL.Current.ObtenerRepositorioDeProductos().Borrar(unProducto);
        }
        public void ModificarMaterial(Material unMaterial)
        {
            FabricaDAL.Current.ObtenerRepositorioDeMateriales().Modificar(unMaterial);
        }
        public void ModificarProducto(Producto unProducto)
        {
            FabricaDAL.Current.ObtenerRepositorioDeProductos().Modificar(unProducto);
        }
        public IEnumerable<Material> ListarMateriales() {
            return FabricaDAL.Current.ObtenerRepositorioDeMateriales().Listar();
        }
        public IEnumerable<Producto> ListarProductos() {
            return FabricaDAL.Current.ObtenerRepositorioDeProductos().Listar();
        }

    }

}
