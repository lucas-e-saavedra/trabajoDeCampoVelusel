using Dominio;
using Dominio.CompositeProducto;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Linq;
using static Dominio.OrdenDeCompra;
using static Dominio.OrdenDeFabricacion;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class OrdenDeCompraAdapter
    {
        #region Singleton
        private readonly static OrdenDeCompraAdapter _instance = new OrdenDeCompraAdapter();

        public static OrdenDeCompraAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private OrdenDeCompraAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public OrdenDeCompra Adapt(object[] values)
        {
            Guid idOrdenFabricacion = Guid.Parse(values[0].ToString());
            Usuario unUsuario = null;
            if (values[1] != DBNull.Value)
            {
                Guid guidSolicitante = Guid.Parse(values[1].ToString());
                unUsuario = Servicios.BLL.GestorUsuarios.Current.ListarUsuarios().ToList().FirstOrDefault(item => item.IdUsuario == guidSolicitante);
            }
            Material unMaterial = null;
            if (values[2] != DBNull.Value)
            {
                string[] criterios = { };
                string[] valores = { values[2].ToString() };
                unMaterial = FabricaDAL.Current.ObtenerRepositorioDeMateriales().BuscarUno(criterios, valores);
            }
            EnumEstadoOrdenCompra estado = (EnumEstadoOrdenCompra)Enum.Parse(typeof(EnumEstadoOrdenCompra), values[3].ToString());
            
            Material objetivo = unMaterial.Copiar();
            objetivo.Cantidad = float.Parse(values[4].ToString());
            DateTime fechaObjetivo = DateTime.Parse(values[5].ToString());

            Material comprados = unMaterial.Copiar();
            comprados.Cantidad = float.Parse(values[6].ToString());
            DateTime fechaestimadarecepcion = DateTime.MinValue;
            if (values[7] != DBNull.Value) {
                fechaestimadarecepcion = DateTime.Parse(values[7].ToString());
            }

            Material recibidos = unMaterial.Copiar();
            recibidos.Cantidad = float.Parse(values[8].ToString());
            DateTime fecharealrecepcion = DateTime.MinValue;
            if (values[9] != DBNull.Value)
            {
                fecharealrecepcion = DateTime.Parse(values[9].ToString());
            }


            OrdenDeCompra unaOrdenDeFabricacion = new OrdenDeCompra()
            {
                Id = idOrdenFabricacion,
                solicitante = unUsuario,
                Estado = estado,
                Objetivo = objetivo,
                FechaObjetivo = fechaObjetivo,
                Comprados = comprados,
                FechaEstimadaRecepcion = fechaestimadarecepcion,
                Recibidos = recibidos,
                FechaRealRecepcion = fecharealrecepcion
            };

            return unaOrdenDeFabricacion;
        }

    }
}
