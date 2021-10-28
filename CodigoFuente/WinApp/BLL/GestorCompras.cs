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
    public sealed class GestorCompras
    {
        private readonly static GestorCompras _instance = new GestorCompras();

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
        public List<Material> CalcularMaterialesComprados(DateTime desde, DateTime hasta) {
            //TODO: el estado todavía no lo puedo filtrar por ahora puse las no canceladas
            List<OrdenDeCompra> todas = FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeCompra().Listar().ToList();
            List<OrdenDeCompra> compradas = todas.Where(item => item.Estado != OrdenDeCompra.EnumEstadoOrdenCompra.CANCELADO).ToList();
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
        public List<Material> CalcularMaterialesNecesarios(DateTime desde, DateTime hasta) {
            List<OrdenDeFabricacion> todas = GestorFabricacion.Current.ListarOrdenesDeFabricacion().ToList();
            List<OrdenDeFabricacion> agendadas = todas.Where(item => item.Estado == OrdenDeFabricacion.EnumEstadoOrdenFabricacion.AGENDADO).ToList();
            List<OrdenDeFabricacion> enFecha = todas.Where(item => item.fecha >= DateTime.Today && item.fecha < hasta).ToList();
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
        public void ComprarOrdenDeComprar(OrdenDeCompra unaOrdenDeCompra) { }
        public IEnumerable<OrdenDeCompra> ConsultarOrdenesDeCompra() { return null; }
        public void CrearOrdenDeCompra(OrdenDeCompra unaOrdenDeCompra) {
            if (unaOrdenDeCompra.Objetivo == null || unaOrdenDeCompra.Objetivo.Id == Guid.Empty)
                throw new Exception("No está permitido crear una orden de compra sin un material");
            if (unaOrdenDeCompra.Objetivo.Cantidad == 0)
                throw new Exception("No está permitido crear una orden de compra de cantidad cero");

            Usuario usuario = GestorSesion.Current.usuarioActual;
            unaOrdenDeCompra.Estado = OrdenDeCompra.EnumEstadoOrdenCompra.FORMULADO;
            unaOrdenDeCompra.solicitante = usuario;

            FabricaDAL.Current.ObtenerRepositorioDeOrdenesDeCompra().Agregar(unaOrdenDeCompra);
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} agregó la orden de compra {unaOrdenDeCompra.Id}");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        public OrdenDeCompra CrearOrdenDeCompra(DateTime fechaObjetivo, Material materialSolicitado) {
            OrdenDeCompra unaOrdenDeCompra = new OrdenDeCompra(materialSolicitado);
            unaOrdenDeCompra.Id = Guid.NewGuid();
            unaOrdenDeCompra.FechaObjetivo = fechaObjetivo;

            return unaOrdenDeCompra;
        }
        public void GrabarOrdenesDeCompraSugeridas(IEnumerable<OrdenDeCompra> ordenesDeCompra) {
            if (ordenesDeCompra.Any(item => item.FechaObjetivo < DateTime.Today))
                throw new Exception("No está permitido crear ordenes de compra con fecha anterior a hoy");
            foreach (OrdenDeCompra unaOrdenDeCompra in ordenesDeCompra){
                BLL.GestorCompras.Current.CrearOrdenDeCompra(unaOrdenDeCompra);
            }
        }
        public void RecibirOrdenDeCompra(OrdenDeCompra unaOrdenDeCompra) { }
        public void RevertirOrdenDeCompra(OrdenDeCompra unaOrdenDeCompra) { }
    }
}
