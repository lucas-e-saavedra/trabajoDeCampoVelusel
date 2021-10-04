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
    class PlantillaDeFabricacionRepositorio : IRepositorioGenerico<PlantillaDeFabricacion>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[PlantillaFabricacion] (IdProducto, ReposoMinRequeridoHs) VALUES (@IdProducto, @ReposoMinRequeridoHs)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[PlantillaFabricacion] SET ReposoMinRequeridoHs = @ReposoMinRequeridoHs WHERE IdProducto = @IdProducto";

        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[PlantillaFabricacion] WHERE IdProducto = @IdProducto";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdProducto, ReposoMinRequeridoHs FROM [dbo].[PlantillaFabricacion] WHERE IdProducto = @IdProducto";
        }

        private string SelectAllStatement
        {
            get => "SELECT IdProducto, ReposoMinRequeridoHs FROM [dbo].[PlantillaFabricacion]";
        }
        #endregion

        private String connectionString;
        internal PlantillaDeFabricacionRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(PlantillaDeFabricacion unObjeto)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdProducto", unObjeto.IdPlantilla),
                    new SqlParameter("@ReposoMinRequeridoHs", unObjeto.ReposoNecesario) };

                sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, sqlParams);
                unObjeto.Ingredientes.Keys.ToList().ForEach(unHijo => {
                    if (unHijo is Material)
                    {
                        FabricaDAL.Current.ObtenerProductoMaterialRelacion().Unir(unObjeto, (Material)unHijo);
                    }
                    if (unHijo is Producto)
                    {
                        //TODO:FabricaDAL.Current.ObtenerProductoProductoRelacion().Unir(unObjeto, (Producto)unHijo);
                    }
                });
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_PlantillaFabricacion"))
                    throw new Exception("Ya existe otra plantilla de fabricación con ese mismo identificador");
                throw new Exception("Hubo un problema al agregar una plantilla de fabricación");
            }
        }

        public void Borrar(PlantillaDeFabricacion unObjeto)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdProducto", unObjeto.IdPlantilla) };

                sqlHelper.ExecuteNonQuery(DeleteStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al eliminar una plantilla de fabricación");
            }
        }

        public PlantillaDeFabricacion BuscarUno(string[] criterios, string[] valores)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@IdProducto", valores.First()) };
                using (var dr = sqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text, sqlParams))
                {
                    if (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        PlantillaDeFabricacion unProducto = PlantillaDeFabricacionAdapter.Current.Adapt(values);
                        return unProducto;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al obtener la plantilla de fabricación");
            }
        }

        public IEnumerable<PlantillaDeFabricacion> Listar()
        {
            throw new NotImplementedException();
        }

        public void Modificar(PlantillaDeFabricacion unObjeto)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdProducto", unObjeto.IdPlantilla),
                    new SqlParameter("@ReposoMinRequeridoHs", unObjeto.ReposoNecesario) };

                sqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, sqlParams);

                FabricaDAL.Current.ObtenerProductoMaterialRelacion().DesvincularHijos(unObjeto);
                //TODO:FabricaDAL.Current.ObtenerProductoProductoRelacion().DesvincularHijos(unObjeto);
                unObjeto.Ingredientes.Keys.ToList().ForEach(unHijo => {
                    if (unHijo is Material)
                    {
                        FabricaDAL.Current.ObtenerProductoMaterialRelacion().Unir(unObjeto, (Material)unHijo);
                    }
                    if (unHijo is Producto)
                    {
                        //TODO:FabricaDAL.Current.ObtenerProductoProductoRelacion().Unir(unObjeto, (Producto)unHijo);
                    }
                });
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_PlantillaFabricacion"))
                    throw new Exception("Ya existe otra plantilla de fabricación con ese mismo identificador");
                throw new Exception("Hubo un problema al modificar una plantilla de fabricación");
            }
        }
    }
}
