using DAL.Implementaciones.SqlServer.Adapters;
using Dominio;
using Dominio.CompositeProducto;
using Servicios.DAL.Contratos;
using Servicios.DAL.Herramientas;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementaciones.SqlServer
{
    class PedidoRepositorio: IRepositorioGenerico<Pedido>
    {

        #region Statements
        private string InsertWithClientStatement
        {
            get => "INSERT INTO [dbo].[Pedido] (Id, Estado, IdSolicitante, IdVendedor) VALUES (@Id, @Estado, @IdSolicitante, @IdVendedor)";
        }
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Pedido] (Id, Estado, IdVendedor) VALUES (@Id, @Estado, @IdVendedor)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Pedido] SET Estado = @Estado, IdSolicitante = @IdSolicitante, IdVendedor= @IdVendedor WHERE Id = @Id";

        }
        private string SelectOneStatement
        {
            get => "SELECT Id, Estado, IdSolicitante, IdVendedor FROM [dbo].[Pedido] WHERE Id = @Id";
        }
        private string SelectAllStatement
        {
            get => "SELECT Id, Estado, IdSolicitante, IdVendedor FROM [dbo].[Pedido]";
        }
        #endregion

        private String connectionString;
        internal PedidoRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(Pedido unObjeto)
        {
            if (unObjeto.Id == Guid.Empty )
                throw new Exception("Faltan completar datos");

            try
            {
                Guid idSolicitante = Guid.Empty;
                if(unObjeto.Solicitante?.Id != null)
                    idSolicitante = unObjeto.Solicitante.Id;
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@Estado", unObjeto.Estado.ToString()),
                    new SqlParameter("@IdSolicitante", idSolicitante),
                    new SqlParameter("@IdVendedor", unObjeto.Vendedor.IdUsuario) };

                if (idSolicitante == Guid.Empty)
                    sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, sqlParams);
                else
                    sqlHelper.ExecuteNonQuery(InsertWithClientStatement, System.Data.CommandType.Text, sqlParams);

                unObjeto.Detalle.ForEach(unHijo => {
                    FabricaDAL.Current.ObtenerPedidoProductoRelacion().Unir(unObjeto, unHijo);
                });
            }
            catch (Exception ex) {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_Pedido"))
                    throw new Exception("Ya existe otro pedido con ese mismo identificador");
                if (ex.Message.Contains("FK_Pedido_Cliente"))
                    throw new Exception("El cliente seleccionado no existe");
                throw new Exception("Hubo un problema al agregar un nuevo pedido");
            }
        }

        public void Borrar(Pedido unObjeto)
        {
            throw new Exception("No está permitido borrar pedidos");
        }

        public Pedido BuscarUno(string[] criterios, string[] valores)
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
                        Pedido unPedido = PedidoAdapter.Current.Adapt(values);
                        return unPedido;
                    }
                }
                return null;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar un producto");
            }
        }

        public IEnumerable<Pedido> Listar()
        {
            try {
                List<Pedido> todosLosPedidos= new List<Pedido>();
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        Pedido unPedido = PedidoAdapter.Current.Adapt(values);
                        todosLosPedidos.Add(unPedido);
                    }
                }
                return todosLosPedidos;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar los pedidos");
            }
        }

        public void Modificar(Pedido unObjeto)
        {
            if (unObjeto.Id == Guid.Empty)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@Estado", unObjeto.Estado.ToString()),
                    new SqlParameter("@IdSolicitante", unObjeto.Solicitante.Id),
                    new SqlParameter("@IdVendedor", unObjeto.Vendedor.IdUsuario) };
                sqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, sqlParams);

                FabricaDAL.Current.ObtenerPedidoProductoRelacion().DesvincularHijos(unObjeto);
                unObjeto.Detalle.ForEach(unHijo => {
                    FabricaDAL.Current.ObtenerPedidoProductoRelacion().Unir(unObjeto, unHijo);
                });
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
