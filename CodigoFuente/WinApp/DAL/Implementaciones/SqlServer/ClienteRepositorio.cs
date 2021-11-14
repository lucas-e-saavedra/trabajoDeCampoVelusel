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
    class ClienteRepositorio: IRepositorioGenerico<Cliente>
    {
        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Cliente] ([Id], [Nombre], [TipoDocumento], [NroDocumento], [Email], [Telefono], [Habilitado], [Verificacion]) VALUES (@Id, @Nombre, @TipoDocumento, @NroDocumento, @Email, @Telefono, @Habilitado, @Verificacion)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Cliente] SET Nombre = @Nombre, TipoDocumento = @TipoDocumento, NroDocumento = @NroDocumento, Email = @Email, Telefono = @Telefono, Habilitado = @Habilitado, Verificacion = @Verificacion WHERE Id = @Id";
        }
        private string SelectOneStatement
        {
            get => "SELECT [Id], [Nombre], [TipoDocumento], [NroDocumento], [Email], [Telefono], [Habilitado], [Verificacion] FROM [dbo].[Cliente] WHERE Id = @Id";
        }
        private string SelectAllStatement
        {
            get => "SELECT [Id], [Nombre], [TipoDocumento], [NroDocumento], [Email], [Telefono], [Habilitado], [Verificacion] FROM [dbo].[Cliente]";
        }
        #endregion

        private String connectionString;
        internal ClienteRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(Cliente unObjeto)
        {
            if (unObjeto.Id == Guid.Empty || unObjeto.Nombre.Length == 0 || unObjeto.NroDocumento.Length == 0)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@Nombre", unObjeto.Nombre),
                    new SqlParameter("@TipoDocumento", unObjeto.TipoDocumento.ToString()),
                    new SqlParameter("@NroDocumento", unObjeto.NroDocumento),
                    new SqlParameter("@Email", unObjeto.Email),
                    new SqlParameter("@Telefono", unObjeto.Telefono),
                    new SqlParameter("@Habilitado", unObjeto.Habilitado),
                    new SqlParameter("@Verificacion", unObjeto.DatoVerificador) };

                sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("UQ_Cliente"))
                    throw new Exception("Ya existe otro cliente con ese mismo documento");
                throw new Exception("Hubo un problema al agregar un nuevo cliente");
            }
        }

        public void Borrar(Cliente unObjeto)
        {
            throw new Exception("No está permitido borrar clientes");
        }

        public Cliente BuscarUno(string[] criterios, string[] valores)
        {
            try
            {
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", valores.First()) };

                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text, sqlParams))
                {
                    if (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        Cliente unCliente = ClienteAdapter.Current.Adapt(values);
                        return unCliente;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar un cliente");
            }
        }

        public IEnumerable<Cliente> Listar()
        {
            try
            {
                List<Cliente> todosLosClientes = new List<Cliente>();
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        Cliente unCliente = ClienteAdapter.Current.Adapt(values);
                        todosLosClientes.Add(unCliente);
                    }
                }
                return todosLosClientes;
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar los clientes");
            }
        }
        public void Modificar(Cliente unObjeto)
        {
            if (unObjeto.Id == Guid.Empty || unObjeto.Nombre.Length == 0 || unObjeto.NroDocumento.Length == 0)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@Nombre", unObjeto.Nombre),
                    new SqlParameter("@TipoDocumento", unObjeto.TipoDocumento.ToString()),
                    new SqlParameter("@NroDocumento", unObjeto.NroDocumento),
                    new SqlParameter("@Email", unObjeto.Email),
                    new SqlParameter("@Telefono", unObjeto.Telefono),
                    new SqlParameter("@Habilitado", unObjeto.Habilitado),
                    new SqlParameter("@Verificacion", unObjeto.DatoVerificador) };

                sqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("UQ_Cliente"))
                    throw new Exception("Ya existe otro cliente con ese mismo documento");
                throw new Exception("Hubo un problema al modificar un cliente");
            }
        }
    }
}
