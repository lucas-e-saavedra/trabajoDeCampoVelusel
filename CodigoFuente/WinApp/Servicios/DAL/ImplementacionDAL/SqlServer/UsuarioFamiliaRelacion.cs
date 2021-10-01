using Servicios.DAL.Contratos;
using Servicios.DAL.Herramientas;
using Servicios.Domain.CompositeSeguridad;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.ImplementacionDAL.SqlServer
{
    class UsuarioFamiliaRelacion : IRelacionGenerica<Usuario, Familia>
    {
        private string conexion;
        internal UsuarioFamiliaRelacion(String oneConnectionString)
        {
            conexion = oneConnectionString;
        }
        public List<Familia> Obtener(Usuario obj)
        {
            //GUID EN EL CASO DE QUE UTILICEN uniqueidentifier
            string IdUsuario = obj.IdUsuario.ToString();
            List<Familia> familias = new List<Familia>();

            try
            {
                using (var dr = new SqlHelper(conexion).ExecuteReader("Usuario_Familia_Select", System.Data.CommandType.StoredProcedure,
                                                       new SqlParameter[] { new SqlParameter("@IdUsuario", IdUsuario) }))
                {
                    //Cada read equivale a leer una relación de mi familia con una patente...
                    while (dr.Read())
                    {
                        //Tengo una nueva patente relacionada...
                        string[] criterios = { "guid" };
                        string[] valores = { dr.GetString(1) };
                        Familia unaFamilia = new FamiliaRepositorio(conexion).BuscarUno(criterios, valores);
                        familias.Add(unaFamilia);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }

            return familias;
        }


        public void Unir(Usuario obj1, Familia obj2)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                sqlHelper.ExecuteNonQuery("Usuario_Familia_Insert", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", obj1.IdUsuario.ToString()),
                        new SqlParameter("@IdFamilia", obj2.IdFamilia.ToString())});
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void Desvincular(Usuario obj1, Familia obj2)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                sqlHelper.ExecuteNonQuery("Usuario_Familia_Delete", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", obj1.IdUsuario.ToString()),
                        new SqlParameter("@IdFamilia", obj2.IdFamilia.ToString())});
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void DesvincularHijos(Usuario obj1)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                sqlHelper.ExecuteNonQuery("Usuario_Familia_DeleteParticular", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", obj1.IdUsuario.ToString())});
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }
    }
}
