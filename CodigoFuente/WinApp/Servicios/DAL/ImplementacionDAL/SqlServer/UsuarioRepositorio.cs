using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.SqlServer.Adapter;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Servicios.DAL.Contratos;
using System.Linq;

namespace Servicios.DAL.ImplementacionDAL.SqlServer
{
    class UsuarioRepositorio: IRepositorioGenerico<Usuario>
    {
        private String connectionString; 
        internal UsuarioRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }


        public void Agregar(Usuario unObjeto)
        {
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            sqlHelper.ExecuteNonQuery("Usuario_Insert", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", unObjeto.IdUsuario.ToString()),
                        new SqlParameter("@Usuario", unObjeto.UsuarioLogin),
                        new SqlParameter("@Contrasenia", unObjeto.Contrasenia),
                        new SqlParameter("@Nombre", unObjeto.Nombre),
                        new SqlParameter("@Email", unObjeto.Email),
                        new SqlParameter("@TipoDocumento", unObjeto.TipoDocumento.ToString()),
                        new SqlParameter("@NroDocumento", unObjeto.NroDocumento)});
            
            unObjeto.Permisos.ForEach(unHijo => {
                if (unHijo is Patente)
                {
                    FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().Unir(unObjeto, (Patente)unHijo);
                }
                if (unHijo is Familia)
                {
                    FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().Unir(unObjeto, (Familia)unHijo);
                }
            });
        }

        public void Borrar(Usuario unObjeto)
        {
            unObjeto.Permisos.ForEach(unHijo => {
                if (unHijo is Patente)
                {
                    FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().Desvincular(unObjeto, (Patente)unHijo);
                }
                if (unHijo is Familia)
                {
                    FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().Desvincular(unObjeto, (Familia)unHijo);
                }
            });
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            sqlHelper.ExecuteNonQuery("Usuario_Delete", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", unObjeto.IdUsuario.ToString())});
        }

        public Usuario BuscarUno(string criterio, string valor)
        {
            string[] criterios = criterio.Split('¿');
            string[] valores = valor.Split('¿');
            string where = "";
            for (int c=0; c<criterios.Length; c++) {
                where = where + (c==0 ?"":" AND ") + criterios[c] + "= '" + valores[c] +"'";
            }
            string query = "SELECT [IdUsuario], [Usuario], [Contrasenia], [Nombre], [Email], [TipoDocumento], [NroDocumento] FROM Usuario WHERE " + where;
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            using (var dr = sqlHelper.ExecuteReader(query, System.Data.CommandType.Text))
            {
                if (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    return UsuarioAdapter.Current.Adapt(values);
                }
            }
            return null;
        }

        public IEnumerable<Usuario> Listar()
        {
            List<Usuario> todosLosUsuarios = new List<Usuario>();
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            using (var dr = sqlHelper.ExecuteReader("Usuario_SelectAll", System.Data.CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    Usuario unUsuario = UsuarioAdapter.Current.Adapt(values);
                    todosLosUsuarios.Add(unUsuario);
                }
            }
            return todosLosUsuarios;
        }

        public void Modificar(Usuario unObjeto)
        {
            //TODO: faltan modificar los demas datos del usuario
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            sqlHelper.ExecuteNonQuery("Usuario_Update", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", unObjeto.IdUsuario.ToString()),
                        new SqlParameter("@Nombre", unObjeto.Nombre)});

            FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().DesvincularHijos(unObjeto);
            FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().DesvincularHijos(unObjeto);
            unObjeto.Permisos.ForEach(unHijo => {
                if (unHijo is Patente)
                {
                    FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().Unir(unObjeto, (Patente)unHijo);
                }
                if (unHijo is Familia)
                {
                    FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().Unir(unObjeto, (Familia)unHijo);
                }
            });
        }

    }

}
