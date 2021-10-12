using Dominio.CompositeProducto;
using Servicios.DAL.Contratos;
using Servicios.DAL.Herramientas;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Implementaciones.SqlServer
{
    class PlantillaFabricacionSubproductoRelacion : IRelacionGenerica<PlantillaDeFabricacion, Producto>
    {
        #region Statements
        private string ObtenerHijosStatement
        {
            get => "SELECT IdPlantilla, IdSubProducto, Cantidad FROM [dbo].[PlantillaF_Subproducto] WHERE IdPlantilla= @IdPlantilla";
        }
        private string InsertarHijoStatement
        {
            get => "INSERT INTO [dbo].[PlantillaF_Subproducto] (IdPlantilla, IdSubProducto, Cantidad) VALUES (@IdPlantilla, @IdSubProducto, @Cantidad)";
        }
        private string BorrarUnHijoStatement
        {
            get => "DELETE FROM [dbo].[PlantillaF_Subproducto] WHERE IdPlantilla = @IdPlantilla AND IdSubProducto = @IdSubProducto";
        }
        private string BorrarTodosLosHijosStatement
        {
            get => "DELETE FROM [dbo].[PlantillaF_Subproducto] WHERE IdPlantilla = @IdPlantilla";
        }
        #endregion
        private string conexion;
        internal PlantillaFabricacionSubproductoRelacion(String oneConnectionString)
        {
            conexion = oneConnectionString;
        }

        public List<Producto> Obtener(PlantillaDeFabricacion obj)
        {
            string IdPlantilla = obj.IdPlantilla.ToString();
            List<Producto> subproductos = new List<Producto>();

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
                        Producto unProducto = FabricaDAL.Current.ObtenerRepositorioDeProductos().BuscarUno(criterios, valores);
                        unProducto.Cantidad = float.Parse(values[2].ToString());
                        subproductos.Add(unProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }

            return subproductos;
        }
        public void Unir(PlantillaDeFabricacion obj1, Producto obj2)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdPlantilla", obj1.IdPlantilla),
                    new SqlParameter("@IdSubProducto", obj2.Id),
                    new SqlParameter("@Cantidad", obj2.Cantidad) };

                sqlHelper.ExecuteNonQuery(InsertarHijoStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void Desvincular(PlantillaDeFabricacion obj1, Producto obj2){
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdPlantilla", obj1.IdPlantilla),
                    new SqlParameter("@IdSubProducto", obj2.Id) };

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
