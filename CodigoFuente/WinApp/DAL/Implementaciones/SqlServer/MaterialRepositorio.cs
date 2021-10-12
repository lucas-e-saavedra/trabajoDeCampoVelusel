using DAL.Implementaciones.SqlServer.Adapters;
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
    class MaterialRepositorio: IRepositorioGenerico<Material>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Material] (Id, Nombre, Unidad) VALUES (@Id, @Nombre, @Unidad)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Material] SET Nombre = @Nombre, Unidad = @Unidad WHERE Id = @Id";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Material] WHERE Id = @Id";
        }

        private string SelectOneStatement
        {
            get => "SELECT Id, Nombre, Unidad FROM [dbo].[Material] WHERE Id = @Id";
        }

        private string SelectAllStatement
        {
            get => "SELECT Id, Nombre, Unidad FROM [dbo].[Material]";
        }
        #endregion

        private String connectionString;
        internal MaterialRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(Material unObjeto)
        {
            if (unObjeto.Id == Guid.Empty || unObjeto.Nombre.Length == 0 )
                throw new Exception("Faltan completar datos");

            try {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] { 
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@Nombre", unObjeto.Nombre),
                    new SqlParameter("@Unidad", unObjeto.Unidad.ToString()) };

                sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_Material"))
                    throw new Exception("Ya existe otro material con ese mismo identificador");
                throw new Exception("Hubo un problema al agregar un nuevo material");
            }
        }

        public void Borrar(Material unObjeto)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id) };

                sqlHelper.ExecuteNonQuery(DeleteStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al eliminar un material");
            }
        }

        public Material BuscarUno(string[] criterios, string[] valores)
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
                        Material unMaterial = MaterialAdapter.Current.Adapt(values);
                        return unMaterial;
                    }
                }
                return null;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar un material");
            }
        }

        public IEnumerable<Material> Listar()
        {
            try {
                List<Material> todosLosMateriales = new List<Material>();
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        Material unMaterial = MaterialAdapter.Current.Adapt(values);
                        todosLosMateriales.Add(unMaterial);
                    }
                }
                return todosLosMateriales;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar los materiales");
            }
        }

        public void Modificar(Material unObjeto)
        {
            if (unObjeto.Id == Guid.Empty || unObjeto.Nombre.Length == 0)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@Nombre", unObjeto.Nombre),
                    new SqlParameter("@Unidad", unObjeto.Unidad.ToString()) };

                sqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_Material"))
                    throw new Exception("Ya existe otro material con ese mismo identificador");
                throw new Exception("Hubo un problema al modificar un material");
            }
        }
    }
}
