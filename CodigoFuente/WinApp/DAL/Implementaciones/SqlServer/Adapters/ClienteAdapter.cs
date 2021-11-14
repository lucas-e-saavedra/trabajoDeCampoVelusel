using Dominio;
using Dominio.CompositeProducto;
using Servicios.Domain.CompositeSeguridad;
using System;

namespace DAL.Implementaciones.SqlServer.Adapters
{
    class ClienteAdapter
    {
        #region Singleton
        private readonly static ClienteAdapter _instance = new ClienteAdapter();

        public static ClienteAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private ClienteAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        public Cliente Adapt(object[] values)
        {
            Usuario.EnumTipoDocumento tipoDocumento = (Usuario.EnumTipoDocumento)Enum.Parse(typeof(Usuario.EnumTipoDocumento), values[2].ToString());
            int verificacion = 0;
            bool resultadoParse = int.TryParse(values[7].ToString(), out verificacion);
            return new Cliente()
            {
                Id = Guid.Parse(values[0].ToString()),
                Nombre = values[1].ToString(),
                TipoDocumento = tipoDocumento,
                NroDocumento = values[3].ToString(),
                Email = values[4].ToString(),
                Telefono = values[5].ToString(),
                Habilitado = Boolean.Parse(values[6].ToString()),
                DatoVerificador = verificacion
            };
        }

    }
}
