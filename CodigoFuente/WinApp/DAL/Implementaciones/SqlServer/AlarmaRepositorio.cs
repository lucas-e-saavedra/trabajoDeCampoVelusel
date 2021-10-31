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
    class AlarmaRepositorio : IRepositorioGenerico<Alarma>
    {

        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Usuario_Alerta] (IdUsuario, DiasAlertaStock, DiasAlertaCompras) VALUES (@IdUsuario, @DiasAlertaStock, @DiasAlertaCompras)";
        }

        private string UpdateStatement
        {
            get => "UPDATE [dbo].[Usuario_Alerta] SET DiasAlertaStock = @DiasAlertaStock, DiasAlertaCompras = @DiasAlertaCompras WHERE IdUsuario = @IdUsuario";
        }

        private string DeleteStatement
        {
            get => "DELETE FROM [dbo].[Usuario_Alerta] WHERE IdUsuario = @IdUsuario";
        }

        private string SelectOneStatement
        {
            get => "SELECT IdUsuario, DiasAlertaStock, DiasAlertaCompras FROM [dbo].[Usuario_Alerta] WHERE IdUsuario = @IdUsuario";
        }
        #endregion

        private String connectionString;
        internal AlarmaRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public void Agregar(Alarma unObjeto)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdUsuario", unObjeto.comprador.IdUsuario),
                    new SqlParameter("@DiasAlertaStock", unObjeto.DiasAlarmaStock),
                    new SqlParameter("@DiasAlertaCompras", unObjeto.DiasAlarmaCompras) };

                sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_Usuario_Alerta"))
                    throw new Exception("Ya existe otra configuración de alarmas con ese mismo identificador");
                throw new Exception("Hubo un problema al agregar una configuración de alarmas");
            }
        }

        public void Borrar(Alarma unObjeto)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdUsuario", unObjeto.comprador.IdUsuario) };

                sqlHelper.ExecuteNonQuery(DeleteStatement, System.Data.CommandType.Text, sqlParams);
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al eliminar una configuración de alarmas");
            }
        }

        public Alarma BuscarUno(string[] criterios, string[] valores)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] { new SqlParameter("@IdUsuario", valores.First()) };
                using (var dr = sqlHelper.ExecuteReader(SelectOneStatement, System.Data.CommandType.Text, sqlParams))
                {
                    if (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        Alarma alarma = AlarmaAdapter.Current.Adapt(values);
                        return alarma;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al obtener la configuración de alarmas");
            }
        }

        public IEnumerable<Alarma> Listar()
        {
            throw new NotImplementedException();
        }

        public void Modificar(Alarma unObjeto)
        {
            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdUsuario", unObjeto.comprador.IdUsuario),
                    new SqlParameter("@DiasAlertaStock", unObjeto.DiasAlarmaStock),
                    new SqlParameter("@DiasAlertaCompras", unObjeto.DiasAlarmaCompras) };

                sqlHelper.ExecuteNonQuery(UpdateStatement, System.Data.CommandType.Text, sqlParams);
            } catch (Exception ex) {
                ex.RegistrarError();
                if (ex.Message.Contains("PK_Usuario_Alerta"))
                    throw new Exception("Ya existe otra configuración de alarmas con ese mismo identificador");
                throw new Exception("Hubo un problema al modificar una configuración de alarmas");
            }
        }
    }
}
