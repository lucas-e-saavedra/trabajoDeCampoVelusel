using Servicios.DAL.Contratos;
using Servicios.DAL.Herramientas;
using Servicios.Domain.CompositeSeguridad;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Servicios.DAL.ImplementacionDAL.SqlServer
{
    class FamiliaPatenteRelacion : IRelacionGenerica<Familia, Patente>
    {
        private string conexion;
        internal FamiliaPatenteRelacion(String oneConnectionString)
        {
            conexion = oneConnectionString;
        }
        public List<Patente> Obtener(Familia obj)
        {
            //Familia_Patente_Select
            //GUID EN EL CASO DE QUE UTILICEN uniqueidentifier
            string IdFamilia = obj.IdFamilia.ToString();
            List<Patente> patentes = new List<Patente>();

            try
            {
                using (var dr = new SqlHelper(conexion).ExecuteReader("Familia_Patente_Select", System.Data.CommandType.StoredProcedure,
                                                       new SqlParameter[] { new SqlParameter("@IdFamilia", IdFamilia) }))
                {
                    //Cada read equivale a leer una relación de mi familia con una patente...
                    while (dr.Read())
                    {
                        //Tengo una nueva patente relacionada...
                        Patente patente = new PatenteRepositorio(conexion).BuscarUno("guid", dr.GetString(1));

                        patentes.Add(patente);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }

            return patentes;
        }


        public void Unir(Familia obj1, Patente obj2)
        {
            try { 
                SqlHelper sqlHelper = new SqlHelper(conexion);
                sqlHelper.ExecuteNonQuery("Familia_Patente_Insert", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdFamilia", obj1.IdFamilia.ToString()),
                        new SqlParameter("@IdPatente", obj2.IdPatente.ToString())});
            } catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void Desvincular(Familia obj1, Patente obj2)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                sqlHelper.ExecuteNonQuery("Familia_Patente_Delete", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdFamilia", obj1.IdFamilia.ToString()),
                        new SqlParameter("@IdPatente", obj2.IdPatente.ToString())});
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void DesvincularHijos(Familia obj1)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                sqlHelper.ExecuteNonQuery("Familia_Patente_DeleteParticular", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdFamilia", obj1.IdFamilia.ToString())});
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }
    }
}
