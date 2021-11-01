using DAL.Implementaciones.SqlServer.Adapters;
using Dominio;
using Servicios.DAL.Contratos;
using Servicios.DAL.Herramientas;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DAL.Implementaciones.SqlServer
{
    class OrdenDeFabricacionRepositorio: IRepositorioGenerico<OrdenDeFabricacion>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[OrdenFabricacion] (Id, IdOrdenFabricacionPosterior, Estado, IdPedido, IdProducto, CantObjetivo, CantFabricados, CantAprobados, FechaPlanificada, FechaEjecucion) " +
                "VALUES (@Id, @IdOrdenFabricacionPosterior, @Estado, @IdPedido, @IdProducto, @CantObjetivo, @CantFabricados, @CantAprobados, @FechaPlanificada, @FechaEjecucion)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[OrdenFabricacion] SET IdOrdenFabricacionPosterior = @IdOrdenFabricacionPosterior, Estado = @Estado , IdPedido = @IdPedido , IdProducto = @IdProducto, CantObjetivo = @CantObjetivo, CantFabricados = @CantFabricados, CantAprobados = @CantAprobados, FechaPlanificada = @FechaPlanificada, FechaEjecucion = @FechaEjecucion WHERE Id = @Id";
        }
        private string SelectOneStatement
        {
            get => "SELECT Id, IdOrdenFabricacionPosterior, Estado, IdPedido, IdProducto, CantObjetivo, CantFabricados, CantAprobados, FechaPlanificada, FechaEjecucion FROM [dbo].[OrdenFabricacion] WHERE Id = @Id";
        }
        private string SelectAllStatement
        {
            get => "SELECT Id, IdOrdenFabricacionPosterior, Estado, IdPedido, IdProducto, CantObjetivo, CantFabricados, CantAprobados, FechaPlanificada, FechaEjecucion FROM [dbo].[OrdenFabricacion]";
        }
        #endregion

        private String connectionString;
        internal OrdenDeFabricacionRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(OrdenDeFabricacion unObjeto)
        {
            if (unObjeto.Id == Guid.Empty )
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@IdOrdenFabricacionPosterior", DBNull.Value),
                    new SqlParameter("@Estado", unObjeto.Estado.ToString()),
                    new SqlParameter("@IdPedido", unObjeto.pedido.Id),
                    new SqlParameter("@IdProducto", unObjeto.Objetivo.Id),
                    new SqlParameter("@CantObjetivo", unObjeto.Objetivo.Cantidad),
                    new SqlParameter("@CantFabricados", unObjeto.Fabricados.Cantidad),
                    new SqlParameter("@CantAprobados", unObjeto.Aprobados.Cantidad),
                    new SqlParameter("@FechaPlanificada", DBNull.Value),
                    new SqlParameter("@FechaEjecucion", DBNull.Value) };
                

                if (unObjeto.OrdenDeFabricacionPosterior!=null && unObjeto.OrdenDeFabricacionPosterior.Id != null)
                    sqlParams[1] = new SqlParameter("IdOrdenFabricacionPosterior", unObjeto.OrdenDeFabricacionPosterior.Id);
                if (unObjeto.FechaPlanificada != DateTime.MinValue)
                    sqlParams[8] = new SqlParameter("FechaPlanificada", unObjeto.FechaPlanificada);
                if (unObjeto.FechaEjecucion != DateTime.MinValue)
                    sqlParams[9] = new SqlParameter("FechaEjecucion", unObjeto.FechaEjecucion);

                sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, sqlParams);

            }
            catch (Exception ex) {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_OrdenFabricacion"))
                    throw new Exception("Ya existe otra orden de fabricación con ese mismo identificador");
                if (ex.Message.Contains("FK_OrdenFabricacion_OrdenFabricacion"))
                    throw new Exception("La orden de fabricación seleccionada no existe");
                if (ex.Message.Contains("FK_OrdenFabricacion_Pedido"))
                    throw new Exception("El pedido seleccionado no existe");
                if (ex.Message.Contains("FK_OrdenFabricacion_Producto"))
                    throw new Exception("El producto seleccionado no existe");
                throw new Exception("Hubo un problema al agregar un nuevo pedido");
            }
        }

        public void Borrar(OrdenDeFabricacion unObjeto)
        {
            throw new Exception("No está permitido borrar ordenes de fabricación");
        }

        public OrdenDeFabricacion BuscarUno(string[] criterios, string[] valores)
        {
            try {
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", valores.First()) };

                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text, sqlParams))
                {
                    if (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        OrdenDeFabricacion unaOrdenDeFabricacion = OrdenDeFabricacionAdapter.Current.Adapt(values);
                        return unaOrdenDeFabricacion;
                    }
                }
                return null;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar una orden de fabricación");
            }
        }

        public IEnumerable<OrdenDeFabricacion> Listar()
        {
            try {
                List<OrdenDeFabricacion> todasLasOrdenes = new List<OrdenDeFabricacion>();
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        OrdenDeFabricacion unaOrdenDeFabricacion = OrdenDeFabricacionAdapter.Current.Adapt(values);
                        todasLasOrdenes.Add(unaOrdenDeFabricacion);
                    }
                }
                return todasLasOrdenes;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar las ordenes de fabricación");
            }
        }

        public void Modificar(OrdenDeFabricacion unObjeto)
        {
            if (unObjeto.Id == Guid.Empty)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@IdOrdenFabricacionPosterior", DBNull.Value),
                    new SqlParameter("@Estado", unObjeto.Estado.ToString()),
                    new SqlParameter("@IdPedido", unObjeto.pedido.Id),
                    new SqlParameter("@IdProducto", unObjeto.Objetivo.Id),
                    new SqlParameter("@CantObjetivo", unObjeto.Objetivo.Cantidad),
                    new SqlParameter("@CantFabricados", unObjeto.Fabricados.Cantidad),
                    new SqlParameter("@CantAprobados", unObjeto.Aprobados.Cantidad),
                    new SqlParameter("@FechaPlanificada", DBNull.Value),
                    new SqlParameter("@FechaEjecucion", DBNull.Value) };


                if (unObjeto.OrdenDeFabricacionPosterior != null && unObjeto.OrdenDeFabricacionPosterior.Id != null)
                    sqlParams[1] = new SqlParameter("IdOrdenFabricacionPosterior", unObjeto.OrdenDeFabricacionPosterior.Id);
                if (unObjeto.FechaPlanificada != DateTime.MinValue)
                    sqlParams[8] = new SqlParameter("FechaPlanificada", unObjeto.FechaPlanificada);
                if (unObjeto.FechaEjecucion != DateTime.MinValue)
                    sqlParams[9] = new SqlParameter("FechaEjecucion", unObjeto.FechaEjecucion);
                
                sqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, sqlParams);                
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_Pedido"))
                    throw new Exception("Ya existe otro pedido con ese mismo identificador");
                if (ex.Message.Contains("FK_Pedido_Cliente"))
                    throw new Exception("El cliente seleccionado no existe");
                throw new Exception("Hubo un problema al modificar un pedido");
            }
        }
    }
}
