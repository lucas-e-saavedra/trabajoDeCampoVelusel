using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.SqlServer.Adapter;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servicios.DAL.ImplementacionDAL.SqlServer
{
    class FamiliaRepositorio: IRepositorioGenerico<Familia>
    {
        private String connectionString; 
        internal FamiliaRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(Familia unObjeto)
        {
            throw new NotImplementedException();
/*            String timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[] {
                        new SqlParameter("@TimeStamp", timeStamp),
                        new SqlParameter("@Severity", oneLog.severity.ToString()),
                        new SqlParameter("@Message", oneLog.message)});*/
        }

        public void Borrar(Familia unObjeto)
        {
            throw new NotImplementedException();
        }

        public Familia BuscarUno(string criterio, string valor)
        {
            Familia unaFamilia= null;
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            using (var dr = sqlHelper.ExecuteReader("Familia_Select", System.Data.CommandType.StoredProcedure,
                new SqlParameter[] { new SqlParameter("@IdFamilia", valor) }))
            {
                if (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);

                    unaFamilia = FamiliaAdapter.Current.Adapt(values);
                }
            }
            return unaFamilia;
        }

        public IEnumerable<Familia> Listar()
        {
            List<Familia> todasLasFamilias = new List<Familia>();
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            using (var dr = sqlHelper.ExecuteReader("Familia_SelectAll", System.Data.CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);

                    Familia unaFamilia = FamiliaAdapter.Current.Adapt(values);
                    todasLasFamilias.Add(unaFamilia);
                }
            }
            return todasLasFamilias;
        }

        public void Modificar(Familia unObjeto)
        {
            throw new NotImplementedException();
        }

    }

}
