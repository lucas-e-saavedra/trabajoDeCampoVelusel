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
    class PedidoProductoRelacion : IRelacionGenerica<Pedido, Producto>
    {
        #region Statements
        private string ObtenerHijosStatement
        {
            get => "SELECT IdPedido, IdProducto, Cantidad FROM [dbo].[Pedido_Detalle] WHERE IdPedido= @IdPedido";
        }
        private string InsertarHijoStatement
        {
            get => "INSERT INTO [dbo].[Pedido_Detalle] (IdPedido, IdProducto, Cantidad) VALUES (@IdPedido, @IdProducto, @Cantidad)";
        }
        private string BorrarUnHijoStatement
        {
            get => "DELETE FROM [dbo].[Pedido_Detalle] WHERE IdPedido = @IdPedido AND IdProducto = @IdProducto";
        }
        private string BorrarTodosLosHijosStatement
        {
            get => "DELETE FROM [dbo].[Pedido_Detalle] WHERE IdPedido = @IdPedido";
        }
        #endregion
        private string conexion;
        internal PedidoProductoRelacion(String oneConnectionString)
        {
            conexion = oneConnectionString;
        }

        public List<Producto> Obtener(Pedido obj)
        {
            string IdPedido = obj.Id.ToString();
            List<Producto> productos = new List<Producto>();
            try
            {
                using (var dr = new SqlHelper(conexion).ExecuteReader(ObtenerHijosStatement, System.Data.CommandType.Text,
                                                       new SqlParameter[] { new SqlParameter("@IdPedido", IdPedido) }))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);

                        string[] criterios = { "guid" };
                        string[] valores = { values[1].ToString() };
                        Producto unProducto = FabricaDAL.Current.ObtenerRepositorioDeProductos().BuscarUno(criterios, valores);
                        unProducto.Cantidad = float.Parse(values[2].ToString());
                        productos.Add(unProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }

            return productos;
        }
        public void Unir(Pedido obj1, Producto obj2)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdPedido", obj1.Id),
                    new SqlParameter("@IdProducto", obj2.Id),
                    new SqlParameter("@Cantidad", obj2.Cantidad) };

                sqlHelper.ExecuteNonQuery(InsertarHijoStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void Desvincular(Pedido obj1, Producto obj2){
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdPedido", obj1.Id),
                    new SqlParameter("@IdProducto", obj2.Id) };

                sqlHelper.ExecuteNonQuery(BorrarUnHijoStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }

        public void DesvincularHijos(Pedido obj1) {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(conexion);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdPedido", obj1.Id) };

                sqlHelper.ExecuteNonQuery(BorrarTodosLosHijosStatement, System.Data.CommandType.Text, sqlParams);

            }
            catch (Exception ex)
            {
                ex.RegistrarError();
            }
        }
        
    }
}
