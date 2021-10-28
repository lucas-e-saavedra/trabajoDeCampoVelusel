using Dominio;
using Dominio.CompositeProducto;
using Servicios.DAL.Contratos;
using Servicios.DAL.Herramientas;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Implementaciones.SqlServer
{
    class AlmacenMaterialRelacion : IRelacionGenerica<Almacen, Material>
    {
        #region Statements
        private string ObtenerHijosStatement
        {
            get => "SELECT IdAlmacen, IdMaterial, Cantidad FROM [dbo].[Almacen_Material] WHERE IdAlmacen= @IdAlmacen";
        }
        private string InsertarHijoStatement
        {
            get => "INSERT INTO [dbo].[Almacen_Material] (IdAlmacen, IdMaterial, Cantidad) VALUES (@IdAlmacen, @IdMaterial, @Cantidad)";
        }
        private string BorrarUnHijoStatement
        {
            get => "DELETE FROM [dbo].[Almacen_Material] WHERE IdAlmacen = @IdAlmacen AND IdMaterial = @IdMaterial";
        }
        private string BorrarTodosLosHijosStatement
        {
            get => "DELETE FROM [dbo].[Almacen_Material] WHERE IdAlmacen = @IdAlmacen";
        }
        #endregion
        private string conexion;
        internal AlmacenMaterialRelacion(String oneConnectionString)
        {
            conexion = oneConnectionString;
        }

        public List<Material> Obtener(Almacen obj)
        {
            string IdAlmacen = obj.Id.ToString();
            List<Material> materiales = new List<Material>();

            try
            {
                using (var dr = new SqlHelper(conexion).ExecuteReader(ObtenerHijosStatement, System.Data.CommandType.Text,
                                                       new SqlParameter[] { new SqlParameter("@IdAlmacen", IdAlmacen) }))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        string[] criterios = { "guid" };
                        string[] valores = { values[1].ToString() };
                        Material unMaterial = FabricaDAL.Current.ObtenerRepositorioDeMateriales().BuscarUno(criterios, valores);
                        unMaterial.Cantidad = float.Parse(values[2].ToString());
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
        public void Unir(Almacen obj1, Material obj2)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdAlmacen", obj1.Id),
                    new SqlParameter("@IdMaterial", obj2.Id),
                    new SqlParameter("@Cantidad", obj2.Cantidad) };

                sqlHelper.ExecuteNonQuery(InsertarHijoStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void Desvincular(Almacen obj1, Material obj2){
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdAlmacen", obj1.Id),
                    new SqlParameter("@IdMaterial", obj2.Id) };

                sqlHelper.ExecuteNonQuery(BorrarUnHijoStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void DesvincularHijos(Almacen obj1) {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdAlmacen", obj1.Id) };

                sqlHelper.ExecuteNonQuery(BorrarTodosLosHijosStatement, System.Data.CommandType.Text, sqlParams);

            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }
        
    }
}
