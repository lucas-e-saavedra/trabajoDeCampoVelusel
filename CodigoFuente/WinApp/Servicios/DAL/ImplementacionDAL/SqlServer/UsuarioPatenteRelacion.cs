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
    class UsuarioPatenteRelacion : IRelacionGenerica<Usuario, Patente>
    {
        private string conexion;
        internal UsuarioPatenteRelacion(String oneConnectionString)
        {
            conexion = oneConnectionString;
        }
        public List<Patente> Obtener(Usuario obj)
        {
            //GUID EN EL CASO DE QUE UTILICEN uniqueidentifier
            string IdUsuario = obj.IdUsuario.ToString();
            List<Patente> patentes = new List<Patente>();

            try
            {
                using (var dr = new SqlHelper(conexion).ExecuteReader("Usuario_Patente_SelectParticular", System.Data.CommandType.StoredProcedure,
                                                       new SqlParameter[] { new SqlParameter("@IdUsuario", IdUsuario) }))
                {
                    //Cada read equivale a leer una relación de mi familia con una patente...
                    while (dr.Read())
                    {
                        //Tengo una nueva patente relacionada...
                        Patente unaPatente = new PatenteRepositorio(conexion).BuscarUno("guid", dr.GetString(1));
                        patentes.Add(unaPatente);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }

            return patentes;
        }


        public void Unir(Usuario obj1, Patente obj2)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                sqlHelper.ExecuteNonQuery("Usuario_Patente_Insert", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", obj1.IdUsuario.ToString()),
                        new SqlParameter("@IdPatente", obj2.IdPatente.ToString())});
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

    }
}
