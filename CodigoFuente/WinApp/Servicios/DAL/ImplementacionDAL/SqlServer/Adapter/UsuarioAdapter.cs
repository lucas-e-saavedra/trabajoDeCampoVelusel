using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            usuario.Nombre = values[1].ToString();

            //Vemos si hay patentes para mi usuario?
            string conString = ConfigurationManager.ConnectionStrings["SLConString"].ConnectionString;
            List<Patente> patentesRelacionadas = new UsuarioPatenteRelacion(conString).Obtener(usuario);

            foreach (var item in patentesRelacionadas)
            {
                usuario.Permisos.Add(item);
            }

            //Vemos si hay familias para mi usuario?asdf
            List<Familia> familiasRelacionadas = new UsuarioFamiliaRelacion(conString).Obtener(usuario);

            foreach (var item in familiasRelacionadas)
            {
                usuario.Permisos.Add(item);
            }

            return usuario;
        }

    }
}
