using Servicios.DAL.Herramientas;
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
            throw new NotImplementedException();
/*            String timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[] {
                        new SqlParameter("@TimeStamp", timeStamp),
                        new SqlParameter("@Severity", oneLog.severity.ToString()),
                        new SqlParameter("@Message", oneLog.message)});*/
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
                    Usuario unUsuario = new Usuario() {
                        guid = Guid.Parse(dr.GetString(0)),
                        Nombre = dr.GetString(1)
                    };
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
