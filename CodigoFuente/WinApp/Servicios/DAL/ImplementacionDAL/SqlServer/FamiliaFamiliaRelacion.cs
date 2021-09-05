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
    class FamiliaFamiliaRelacion : IRelacionGenerica<Familia, Familia>
    {
        private string conexion;
        internal FamiliaFamiliaRelacion(String oneConnectionString)
        {
            conexion = oneConnectionString;
        }
        public List<Familia> Obtener(Familia obj)
        {
            //Familia_Patente_Select
            //GUID EN EL CASO DE QUE UTILICEN uniqueidentifier
            string IdFamilia = obj.IdFamilia.ToString();
            List<Familia> familias = new List<Familia>();

            try
            {
                using (var dr = new SqlHelper(conexion).ExecuteReader("Familia_Familia_Select2", System.Data.CommandType.StoredProcedure,
                                                       new SqlParameter[] { new SqlParameter("@IdFamilia", IdFamilia) }))
                {
                    //Cada read equivale a leer una relación de mi familia con una patente...
                    while (dr.Read())
                    {
                        //Tengo una nueva patente relacionada...
                        Familia unaFamilia = new FamiliaRepositorio(conexion).BuscarUno("guid", dr.GetString(1));
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


        public void Unir(Familia obj1, Familia obj2)
        {
            throw new NotImplementedException();
        }

    }
}
