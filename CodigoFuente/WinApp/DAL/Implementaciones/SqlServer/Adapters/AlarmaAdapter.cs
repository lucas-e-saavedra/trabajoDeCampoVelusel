using Dominio;
using Dominio.CompositeProducto;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class AlarmaAdapter
    {
        #region Singleton
        private readonly static AlarmaAdapter _instance = new AlarmaAdapter();

        public static AlarmaAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private AlarmaAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public Alarma Adapt(object[] values)
        {
            Guid idUsuario = Guid.Parse(values[0].ToString());
            Usuario unUsuario = new Usuario();
            unUsuario.IdUsuario = idUsuario;

            int alarmaStock = 0;
            if (values[1] != DBNull.Value) {
                alarmaStock = Int16.Parse(values[1].ToString());
            }
            int alarmaCompras = 0; 
            if (values[2] != DBNull.Value) {
                alarmaCompras = Int16.Parse(values[2].ToString());
            }

            return new Alarma() {
                comprador = unUsuario,
                DiasAlarmaStock = alarmaStock,
                DiasAlarmaCompras = alarmaCompras
            };
        }

    }
}
