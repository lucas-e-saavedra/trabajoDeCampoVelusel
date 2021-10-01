using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Servicios.Domain.CompositeSeguridad.Usuario;

namespace Servicios.DAL.ImplementacionDAL.SqlServer.Adapter
{
    class UsuarioAdapter
    {
        #region Singleton
        private readonly static UsuarioAdapter _instance = new UsuarioAdapter();

        public static UsuarioAdapter Current
        {
            get
            {
                return _instance;
            }
        }

        private UsuarioAdapter()
        {
            //Implement here the initialization code
        }
        #endregion

        //public Familia Adapt(object[] values, int level)
        public Usuario Adapt(object[] values)
        {
            //Adapter primitivos -> Hidratación -> Niveles
            //Nivel 0
            Usuario usuario = new Usuario();
            usuario.IdUsuario = Guid.Parse(values[0].ToString());
            usuario.UsuarioLogin = values[1].ToString();
            usuario.Contrasenia = values[2].ToString();
            usuario.Nombre = values[3].ToString();
            usuario.Email = values[4].ToString();
            EnumTipoDocumento unTipoDocumento = (EnumTipoDocumento)Enum.Parse(typeof(EnumTipoDocumento), values[5].ToString());
            usuario.TipoDocumento = unTipoDocumento;
            usuario.NroDocumento = values[6].ToString();

            //Vemos si hay patentes para mi usuario?
            List<Patente> patentesRelacionadas = FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().Obtener(usuario);

            foreach (var item in patentesRelacionadas)
            {
                usuario.Permisos.Add(item);
            }

            //Vemos si hay familias para mi usuario?asdf
            List<Familia> familiasRelacionadas = FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().Obtener(usuario);

            foreach (var item in familiasRelacionadas)
            {
                usuario.Permisos.Add(item);
            }

            return usuario;
        }

    }
}
