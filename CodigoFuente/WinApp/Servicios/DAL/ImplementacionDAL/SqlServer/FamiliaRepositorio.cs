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
    class FamiliaRepositorio: IRepositorioGenerico<Familia>
    {
        private String connectionString; 
        internal FamiliaRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(Familia unObjeto)
        {
            try { 
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Familia_Insert", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdFamilia", unObjeto.IdFamilia.ToString()),
                        new SqlParameter("@Nombre", unObjeto.Nombre)});

                unObjeto.ListadoHijos.ForEach(unHijo => {
                    if (unHijo is Patente) {
                        FabricaDAL.Current.ObtenerFamiliaPatenteRelacion().Unir(unObjeto, (Patente)unHijo);
                    }
                    if (unHijo is Familia)
                    {
                        FabricaDAL.Current.ObtenerFamiliaFamiliaRelacion().Unir(unObjeto, (Familia)unHijo);
                    }
                });
            } catch (Exception ex) {
                    ex.RegistrarError();
                    throw new Exception("Hubo un problema al agregar una familia");
            }
        }

        public void Borrar(Familia unObjeto)
        {
            try {
                unObjeto.ListadoHijos.ForEach(unHijo => {
                    if (unHijo is Patente)
                    {
                        FabricaDAL.Current.ObtenerFamiliaPatenteRelacion().Desvincular(unObjeto, (Patente)unHijo);
                    }
                    if (unHijo is Familia)
                    {
                        FabricaDAL.Current.ObtenerFamiliaFamiliaRelacion().Desvincular(unObjeto, (Familia)unHijo);
                    }
                });
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Familia_Delete", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdFamilia", unObjeto.IdFamilia.ToString())});
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al borrar una familia");
            }
        }

        public Familia BuscarUno(string[] criterios, string[] valores)
        {
            try {
                Familia unaFamilia= null;
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader("Familia_Select", System.Data.CommandType.StoredProcedure,
                    new SqlParameter[] { new SqlParameter("@IdFamilia", valores.First()) }))
                {
                    if (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        unaFamilia = FamiliaAdapter.Current.Adapt(values);
                    }
                }
                return unaFamilia;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar una familia");
            }
        }

        public IEnumerable<Familia> Listar()
        {
            try {
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
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar las familias");
            }
        }

        public void Modificar(Familia unObjeto)
        {
            try { 
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Familia_Update", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdFamilia", unObjeto.IdFamilia.ToString()),
                        new SqlParameter("@Nombre", unObjeto.Nombre)});

                FabricaDAL.Current.ObtenerFamiliaPatenteRelacion().DesvincularHijos(unObjeto);
                FabricaDAL.Current.ObtenerFamiliaFamiliaRelacion().DesvincularHijos(unObjeto);
                unObjeto.ListadoHijos.ForEach(unHijo => {
                    if (unHijo is Patente)
                    {
                        FabricaDAL.Current.ObtenerFamiliaPatenteRelacion().Unir(unObjeto, (Patente)unHijo);
                    }
                    if (unHijo is Familia)
                    {
                        FabricaDAL.Current.ObtenerFamiliaFamiliaRelacion().Unir(unObjeto, (Familia)unHijo);
                    }
                });
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al modificar una familia");
            }
        }
    }

}
