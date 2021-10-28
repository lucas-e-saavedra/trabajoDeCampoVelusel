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

namespace DAL.Implementaciones.SqlServer
{
    class AlmacenRepositorio: IRepositorioGenerico<Almacen>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Almacen] (Id, Nombre) VALUES (@Id, @Nombre)";
        }
        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Almacen] SET Nombre = @Nombre WHERE Id = @Id";
        }
        private string SelectOneStatement
        {
            get => "SELECT Id, Nombre FROM [dbo].[Almacen] WHERE Id = @Id";
        }
        private string SelectAllStatement
        {
            get => "SELECT Id, Nombre FROM [dbo].[Almacen]";
        }
        #endregion

        private String connectionString;
        internal AlmacenRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(Almacen unObjeto)
        {
            if (unObjeto.Id == Guid.Empty )
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@Nombre", unObjeto.Nombre) };
                sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, sqlParams);
                
                unObjeto.Stock.ForEach(unHijo => {
                    if(unHijo is Producto)
                        FabricaDAL.Current.ObtenerAlmacenProductoRelacion().Unir(unObjeto, (Producto)unHijo);
                    if (unHijo is Material)
                        FabricaDAL.Current.ObtenerAlmacenMaterialRelacion().Unir(unObjeto, (Material)unHijo);
                });
            }
            catch (Exception ex) {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_Almacen"))
                    throw new Exception("Ya existe otro almacén con ese mismo identificador");
                throw new Exception("Hubo un problema al agregar un nuevo almacén");
            }
        }

        public void Borrar(Almacen unObjeto)
        {
            throw new Exception("No está permitido borrar un almacen");
        }

        public Almacen BuscarUno(string[] criterios, string[] valores)
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
                        Almacen unAlmacen = AlmacenAdapter.Current.Adapt(values);
                        return unAlmacen;
                    }
                }
                return null;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar un almacén");
            }
        }

        public IEnumerable<Almacen> Listar()
        {
            try {
                List<Almacen> todosLosAlmacenes = new List<Almacen>();
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        Almacen unAlmacen = AlmacenAdapter.Current.Adapt(values);
                        todosLosAlmacenes.Add(unAlmacen);
                    }
                }
                return todosLosAlmacenes;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar los almacenes");
            }
        }

        public void Modificar(Almacen unObjeto)
        {
            if (unObjeto.Id == Guid.Empty)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@Id", unObjeto.Id),
                    new SqlParameter("@Nombre", unObjeto.Nombre) };
                sqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, sqlParams);

                FabricaDAL.Current.ObtenerAlmacenProductoRelacion().DesvincularHijos(unObjeto);
                unObjeto.Stock.ForEach(unHijo => {
                    if (unHijo is Producto)
                        FabricaDAL.Current.ObtenerAlmacenProductoRelacion().Unir(unObjeto, (Producto)unHijo);
                    if (unHijo is Material)
                        FabricaDAL.Current.ObtenerAlmacenMaterialRelacion().Unir(unObjeto, (Material)unHijo);
                });
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_Almacen"))
                    throw new Exception("Ya existe otro almacén con ese mismo identificador");
                throw new Exception("Hubo un problema al modificar un almacén");
            }
        }
    }
}
