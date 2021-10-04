using DAL;
using Dominio.CompositeProducto;
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

namespace DAL.Implementaciones.SqlServer
{
    class PlantillaFabricacionMaterialRelacion : IRelacionGenerica<PlantillaDeFabricacion, Material>
    {
        #region Statements

        private string ObtenerHijosStatement
        {
            get => "SELECT IdPlantilla, IdMaterial, Cantidad FROM [dbo].[PlantillaF_Material] WHERE IdPlantilla= @IdPlantilla";
        }
        private string InsertarHijoStatement
        {
            get => "INSERT INTO [dbo].[PlantillaF_Material] (IdPlantilla, IdMaterial, Cantidad) VALUES (@IdPlantilla, @IdMaterial, @Cantidad)";
        }
        private string BorrarUnHijoStatement
        {
            get => "DELETE FROM [dbo].[PlantillaF_Material] WHERE IdPlantilla = @IdPlantilla AND IdMaterial = @IdMaterial";
        }
        private string BorrarTodosLosHijosStatement
        {
            get => "DELETE FROM [dbo].[PlantillaF_Material] WHERE IdPlantilla = @IdPlantilla";
        }
        #endregion
        private string conexion;
        internal PlantillaFabricacionMaterialRelacion(String oneConnectionString)
        {
            conexion = oneConnectionString;
        }

        public List<Material> Obtener(PlantillaDeFabricacion obj)
        {
            string IdPlantilla = obj.IdPlantilla.ToString();
            List<Material> materiales = new List<Material>();

            try
            {
                using (var dr = new SqlHelper(conexion).ExecuteReader(ObtenerHijosStatement, System.Data.CommandType.Text,
                                                       new SqlParameter[] { new SqlParameter("@IdPlantilla", IdPlantilla) }))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        string[] criterios = { "guid" };
                        string[] valores = { values[1].ToString() };
                        Material unMaterial = FabricaDAL.Current.ObtenerRepositorioDeMateriales().BuscarUno(criterios, valores);

                        materiales.Add(unMaterial);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }

            return materiales;
        }
        public void Unir(PlantillaDeFabricacion obj1, Material obj2)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdPlantilla", obj1.IdPlantilla),
                    new SqlParameter("@IdMaterial", obj2.Id),
                    new SqlParameter("@Cantidad", "0") };

                sqlHelper.ExecuteNonQuery(InsertarHijoStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void Desvincular(PlantillaDeFabricacion obj1, Material obj2){
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdPlantilla", obj1.IdPlantilla),
                    new SqlParameter("@IdMaterial", obj2.Id) };

                sqlHelper.ExecuteNonQuery(BorrarUnHijoStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void DesvincularHijos(PlantillaDeFabricacion obj1) {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdPlantilla", obj1.IdPlantilla) };

                sqlHelper.ExecuteNonQuery(BorrarTodosLosHijosStatement, System.Data.CommandType.Text, sqlParams);

            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }
        
    }
}
