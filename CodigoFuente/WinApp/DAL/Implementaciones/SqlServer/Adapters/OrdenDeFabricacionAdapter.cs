using Dominio;
using Dominio.CompositeProducto;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Linq;
using static Dominio.OrdenDeFabricacion;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class OrdenDeFabricacionAdapter
    {
        #region Singleton
        private readonly static OrdenDeFabricacionAdapter _instance = new OrdenDeFabricacionAdapter();

        public static OrdenDeFabricacionAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private OrdenDeFabricacionAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public OrdenDeFabricacion Adapt(object[] values)
        {
            Guid idOrdenFabricacion = Guid.Parse(values[0].ToString());
            //TODO: queda por ver que hacer con esto Guid idOFPosterior = Guid.Parse(values[1].ToString());
            EnumEstadoOrdenFabricacion estado = (EnumEstadoOrdenFabricacion)Enum.Parse(typeof(EnumEstadoOrdenFabricacion), values[2].ToString());
            Pedido unPedido = null;
            if (values[3] != DBNull.Value) { 
                string[] criterios = { };
                string[] valores = { values[3].ToString() };
                unPedido = FabricaDAL.Current.ObtenerRepositorioDePedidos().BuscarUno(criterios, valores);
            }
            Producto unProducto = null;
            if (values[4] != DBNull.Value)
            {
                string[] criterios = { };
                string[] valores = { values[4].ToString() };
                unProducto = FabricaDAL.Current.ObtenerRepositorioDeProductos().BuscarUno(criterios, valores);
            }
            Producto objetivo = unProducto.Copiar();
            objetivo.Cantidad = float.Parse(values[5].ToString());
            Producto fabricados = unProducto.Copiar();
            fabricados.Cantidad = float.Parse(values[6].ToString());
            Producto aprobados = unProducto.Copiar();
            aprobados.Cantidad = float.Parse(values[7].ToString());

            DateTime unaFecha = DateTime.Parse(values[8].ToString());


            OrdenDeFabricacion unaOrdenDeFabricacion = new OrdenDeFabricacion()
            {
                Id = idOrdenFabricacion,
                OrdenDeFabricacionPosterior = null, // falta agregar esto todavia me resta definir si va hacia adelanteo hacia atras
                Estado = estado,
                pedido = unPedido,
                Objetivo = objetivo,
                Fabricados = fabricados,
                Aprobados = aprobados,
                fecha = unaFecha
            };

            return unaOrdenDeFabricacion;
        }

    }
}
