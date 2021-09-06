using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.SqlServer.Adapter;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servicios.DAL.ImplementacionDAL.SqlServer
{
    class PatenteRepositorio: IRepositorioGenerico<Patente>
    {
        private String connectionString; 
        internal PatenteRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        /*
    [dbo].[Patente_Delete]
    [dbo].[Patente_Insert]
    [dbo].[Patente_Select]
    [dbo].[Patente_Update]
         */
        public void Agregar(Patente unObjeto)
        {
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            sqlHelper.ExecuteNonQuery("Patente_Insert", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdPatente", unObjeto.IdPatente.ToString()),
                        new SqlParameter("@Nombre", unObjeto.Nombre),
                        new SqlParameter("@Vista", unObjeto.Vista)});
        }

        public void Borrar(Patente unObjeto)
        {
            throw new NotImplementedException();
        }

        public Patente BuscarUno(string criterio, string valor)
        {
            Patente unaPatente = null;
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            using (var dr = sqlHelper.ExecuteReader("Patente_Select", System.Data.CommandType.StoredProcedure,
                new SqlParameter[] { new SqlParameter("@IdPatente", valor) }))
            {
                if (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    unaPatente = PatenteAdapter.Current.Adapt(values);
                }
            }
            return unaPatente;
        }

        public IEnumerable<Patente> Listar()
        {
            List<Patente> todasLasPatentes = new List<Patente>();
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            using (var dr = sqlHelper.ExecuteReader("Patente_SelectAll", System.Data.CommandType.StoredProcedure))
            {
                while (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    Patente unaPatente = PatenteAdapter.Current.Adapt(values);
                    todasLasPatentes.Add(unaPatente);
                }
            }
            return todasLasPatentes;
        }

        public void Modificar(Patente unObjeto)
        {
            throw new NotImplementedException();
        }

    }

}
