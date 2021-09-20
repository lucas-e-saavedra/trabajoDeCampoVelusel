using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.SqlServer.Adapter;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Servicios.DAL.Contratos;
using Servicios.Extensions;
using System.Linq;

namespace Servicios.DAL.ImplementacionDAL.SqlServer
{
    class PatenteRepositorio: IRepositorioGenerico<Patente>
    {
        private String connectionString; 
        internal PatenteRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(Patente unObjeto)
        {
            try {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Patente_Insert", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdPatente", unObjeto.IdPatente.ToString()),
                        new SqlParameter("@Nombre", unObjeto.Nombre),
                        new SqlParameter("@Vista", unObjeto.Vista)});
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al agregar una patente");
            }
        }

        public void Borrar(Patente unObjeto)
        {
            try {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Patente_Delete", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdPatente", unObjeto.IdPatente.ToString())});
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al borrar una patente");
            }
        }

        public Patente BuscarUno(string[] criterios, string[] valores)
        {
            try {
                Patente unaPatente = null;
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader("Patente_Select", System.Data.CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@IdPatente", valores.First()) }))
                {
                    if (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        unaPatente = PatenteAdapter.Current.Adapt(values);
                    }
                }
                return unaPatente;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar una patente");
            }
        }

        public IEnumerable<Patente> Listar()
        {
            try {
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
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar las patentes");
            }
        }

        public void Modificar(Patente unObjeto)
        {
            try {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Patente_Update", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdPatente", unObjeto.IdPatente.ToString()),
                        new SqlParameter("@Nombre", unObjeto.Nombre),
                        new SqlParameter("@Vista", unObjeto.Vista)});
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al modificar una patente");
            }
        }

    }

}
