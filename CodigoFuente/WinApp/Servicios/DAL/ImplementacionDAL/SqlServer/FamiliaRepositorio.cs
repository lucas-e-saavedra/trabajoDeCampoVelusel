using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.SqlServer.Adapter;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Servicios.DAL.Contratos;

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
        }

        public void Borrar(Familia unObjeto)
        {
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
        }

    }

}
