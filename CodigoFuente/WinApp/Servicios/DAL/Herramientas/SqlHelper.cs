using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Servicios.DAL.Herramientas
{
    /// <summary>
    /// Esta clase se utiliza para interactuar con una base de datos de MS Sql Server
    /// </summary>
    public class SqlHelper
    {
        private string connectionString;

        /// <summary>
        /// Este es el constructor obligatorio que recibe un connectionString con los datos de la base de datos con la cual se va a comunicar
        /// </summary>
        /// <param name="oneConnectionstring">ConnectionString con los parametros de conexión</param>
        public SqlHelper(String oneConnectionstring)
        {
            connectionString = oneConnectionstring;
        }

        /// <summary>
        /// Este método se utiliza para ejecutar un script en la base de datos en el cual no es importante obtener un detalle de la respuesta
        /// </summary>
        /// <param name="commandText">Texto del script</param>
        /// <param name="commandType">Tipo de script puede ser texto o un stored procedure</param>
        /// <param name="parameters">Lista de parametros para el script</param>
        /// <returns>Devuelve la cantidad de filas afectadas por el script</returns>
        public Int32 ExecuteNonQuery(String commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    // There're three command types: StoredProcedure, Text, TableDirect. The TableDirect 
                    // type is only for OLE DB.  
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para ejecutar un script en la base de datos en el cual el valor resultante es una sola celda
        /// </summary>
        /// <param name="commandText">Texto del script</param>
        /// <param name="commandType">Tipo de script puede ser texto o un stored procedure</param>
        /// <param name="parameters">Lista de parametros para el script</param>
        /// <returns>Devuelve el contenido de esa celda de respuesta</returns>
        public Object ExecuteScalar(String commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Este método se utiliza para ejecutar un script en la base de datos que forma una consulta cuyo valor resultante es un conjunto de filas de registros
        /// </summary>
        /// <param name="commandText">Texto del script</param>
        /// <param name="commandType">Tipo de script puede ser texto o un stored procedure</param>
        /// <param name="parameters">Lista de parametros para el script</param>
        /// <returns>Devuelve un objeto SqlDataReader con el contenido de la consulta</returns>
        public SqlDataReader ExecuteReader(String commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the 
                // IDataReader is closed.
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

    }
}
