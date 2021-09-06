using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.SqlServer.Adapter;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
                        new SqlParameter("@Nombre", unObjeto.Nombre)});
            
            unObjeto.Permisos.ForEach(unHijo => {
                if (unHijo is Patente)
                {
                    new UsuarioPatenteRelacion(connectionString).Unir(unObjeto, (Patente)unHijo);
                }
                if (unHijo is Familia)
                {
                    new UsuarioFamiliaRelacion(connectionString).Unir(unObjeto, (Familia)unHijo);
                }
            });
        }

        public void Borrar(Usuario unObjeto)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarUno(string criterio, string valor)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }

}
