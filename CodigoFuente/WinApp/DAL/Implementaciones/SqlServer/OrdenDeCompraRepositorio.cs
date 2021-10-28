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
    class OrdenDeCompraRepositorio: IRepositorioGenerico<OrdenDeCompra>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[OrdenCompra] (Id, IdSolicitante, IdMaterial, Estado, CantObjetivo, FechaObjetivo, CantComprada, FechaEstimadaRecepcion, CantRecibida, FechaRealRecepcion) " +
                "VALUES (@Id, @IdSolicitante, @IdMaterial, @Estado, @CantObjetivo, @FechaObjetivo, @CantComprada, @FechaEstimadaRecepcion, @CantRecibida, @FechaRealRecepcion)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[OrdenCompra] SET IdSolicitante = @IdSolicitante, IdMaterial = @IdMaterial, Estado = @Estado, CantObjetivo = @CantObjetivo, FechaObjetivo = @FechaObjetivo, CantComprada = @CantComprada, FechaEstimadaRecepcion = @FechaEstimadaRecepcion, CantRecibida = @CantRecibida, FechaRealRecepcion = @FechaRealRecepcion WHERE Id = @Id";
        }
        private string SelectOneStatement
        {
            get => "SELECT Id, IdSolicitante, IdMaterial, Estado, CantObjetivo, FechaObjetivo, CantComprada, FechaEstimadaRecepcion, CantRecibida, FechaRealRecepcion FROM [dbo].[OrdenCompra] WHERE Id = @Id";
        }
        private string SelectAllStatement
        {
            get => "SELECT Id, IdSolicitante, IdMaterial, Estado, CantObjetivo, FechaObjetivo, CantComprada, FechaEstimadaRecepcion, CantRecibida, FechaRealRecepcion FROM [dbo].[OrdenCompra]";
        }
        #endregion

        private String connectionString;
        internal OrdenDeCompraRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(OrdenDeCompra unObjeto)
        {
            if (unObjeto.Id == Guid.Empty )
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);

                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@IdSolicitante", DBNull.Value),
                    new SqlParameter("@IdMaterial", unObjeto.Objetivo.Id),
                    new SqlParameter("@Estado", unObjeto.Estado.ToString()),
                    new SqlParameter("@CantObjetivo", unObjeto.Objetivo.Cantidad),
                    new SqlParameter("@FechaObjetivo", unObjeto.FechaObjetivo),
                    new SqlParameter("@CantComprada", unObjeto.Comprados.Cantidad),
                    new SqlParameter("@FechaEstimadaRecepcion", DBNull.Value),
                    new SqlParameter("@CantRecibida", unObjeto.Recibidos.Cantidad),
                    new SqlParameter("@FechaRealRecepcion", DBNull.Value)};

                if(unObjeto.solicitante!=null)
                    sqlParams[1] = new SqlParameter("@IdSolicitante", unObjeto.solicitante.IdUsuario);
                if (unObjeto.FechaEstimadaRecepcion > DateTime.MinValue)
                    sqlParams[7] = new SqlParameter("@FechaEstimadaRecepcion", unObjeto.FechaEstimadaRecepcion);
                if (unObjeto.FechaRealRecepcion > DateTime.MinValue)
                    sqlParams[9] = new SqlParameter("@FechaRealRecepcion", unObjeto.FechaRealRecepcion);
                
                sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, sqlParams);

            }
            catch (Exception ex) {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_OrdenCompra"))
                    throw new Exception("Ya existe otra orden de compra con ese mismo identificador");
                if (ex.Message.Contains("FK_OrdenCompra_Material"))
                    throw new Exception("El material seleccionado no existe");
                throw new Exception("Hubo un problema al agregar una nueva orden de compra");
            }
        }

        public void Borrar(OrdenDeCompra unObjeto)
        {
            throw new Exception("No está permitido borrar ordenes de compra");
        }

        public OrdenDeCompra BuscarUno(string[] criterios, string[] valores)
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
                        OrdenDeCompra unaOrdenDeFabricacion = OrdenDeCompraAdapter.Current.Adapt(values);
                        return unaOrdenDeFabricacion;
                    }
                }
                return null;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar una orden de fabricación");
            }
        }

        public IEnumerable<OrdenDeCompra> Listar()
        {
            try {
                List<OrdenDeCompra> todasLasOrdenes = new List<OrdenDeCompra>();
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        OrdenDeCompra unaOrdenDeFabricacion = OrdenDeCompraAdapter.Current.Adapt(values);
                        todasLasOrdenes.Add(unaOrdenDeFabricacion);
                    }
                }
                return todasLasOrdenes;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar las ordenes de fabricación");
            }
        }

        public void Modificar(OrdenDeCompra unObjeto)
        {
            if (unObjeto.Id == Guid.Empty)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@IdSolicitante", DBNull.Value),
                    new SqlParameter("@IdMaterial", unObjeto.Objetivo.Id),
                    new SqlParameter("@Estado", unObjeto.Estado.ToString()),
                    new SqlParameter("@CantObjetivo", unObjeto.Objetivo.Cantidad),
                    new SqlParameter("@FechaObjetivo", unObjeto.FechaObjetivo),
                    new SqlParameter("@CantComprada", unObjeto.Comprados.Cantidad),
                    new SqlParameter("@FechaEstimadaRecepcion", DBNull.Value),
                    new SqlParameter("@CantRecibida", unObjeto.Recibidos.Cantidad),
                    new SqlParameter("@FechaRealRecepcion", DBNull.Value)};

                if (unObjeto.solicitante != null)
                    sqlParams[1] = new SqlParameter("@IdSolicitante", unObjeto.solicitante.IdUsuario);
                if (unObjeto.FechaEstimadaRecepcion > DateTime.MinValue)
                    sqlParams[7] = new SqlParameter("@FechaEstimadaRecepcion", unObjeto.FechaEstimadaRecepcion);
                if (unObjeto.FechaRealRecepcion > DateTime.MinValue)
                    sqlParams[9] = new SqlParameter("@FechaRealRecepcion", unObjeto.FechaRealRecepcion);

                sqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, sqlParams);                
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_OrdenCompra"))
                    throw new Exception("Ya existe otra orden de compra con ese mismo identificador");
                if (ex.Message.Contains("FK_OrdenCompra_Material"))
                    throw new Exception("El material seleccionado no existe");
                throw new Exception("Hubo un problema al modificar una nueva orden de compra");
            }
        }
    }
}
