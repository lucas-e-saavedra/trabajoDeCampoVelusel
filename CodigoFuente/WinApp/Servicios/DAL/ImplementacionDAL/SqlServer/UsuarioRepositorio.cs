using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.SqlServer.Adapter;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Servicios.DAL.Contratos;
using System.Linq;
using Servicios.Extensions;

namespace Servicios.DAL.ImplementacionDAL.SqlServer
{
    class UsuarioRepositorio: IRepositorioGenerico<Usuario>
    {
        private String connectionString; 
        internal UsuarioRepositorio(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }


        public void Agregar(Usuario unObjeto)
        {
            if (unObjeto.UsuarioLogin.Length == 0 ||
                unObjeto.Nombre.Length == 0 ||
                unObjeto.Email.Length == 0 ||
                unObjeto.NroDocumento.Length == 0)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Usuario_Insert", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", unObjeto.IdUsuario.ToString()),
                        new SqlParameter("@Usuario", unObjeto.UsuarioLogin),
                        new SqlParameter("@Contrasenia", unObjeto.Contrasenia),
                        new SqlParameter("@Nombre", unObjeto.Nombre),
                        new SqlParameter("@Email", unObjeto.Email),
                        new SqlParameter("@TipoDocumento", unObjeto.TipoDocumento.ToString()),
                        new SqlParameter("@NroDocumento", unObjeto.NroDocumento)});

                unObjeto.Permisos.ForEach(unHijo => {
                    if (unHijo is Patente)
                    {
                        FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().Unir(unObjeto, (Patente)unHijo);
                    }
                    if (unHijo is Familia)
                    {
                        FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().Unir(unObjeto, (Familia)unHijo);
                    }
                });
            } catch (Exception ex)  {
                ex.RegistrarError();
                if (ex.Message.Contains("UQ_UsuarioApodo"))
                    throw new Exception("Ya existe otro usuario con ese mismo inicio de sesión");
                if (ex.Message.Contains("UQ_UsuarioDocumento"))
                    throw new Exception("Ya existe otro usuario con ese mismo tipo y número de documento");
                throw new Exception("Hubo un problema al agregar un usuario");
            }
        }

        public void Borrar(Usuario unObjeto)
        {
            try{
                unObjeto.Permisos.ForEach(unHijo => {
                    if (unHijo is Patente)
                    {
                        FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().Desvincular(unObjeto, (Patente)unHijo);
                    }
                    if (unHijo is Familia)
                    {
                        FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().Desvincular(unObjeto, (Familia)unHijo);
                    }
                });
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Usuario_Delete", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                        new SqlParameter("@IdUsuario", unObjeto.IdUsuario.ToString())});
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al borrar un usuario");
            }
        }

        public Usuario BuscarUno(string[] criterios, string[] valores)
        {
            try {
                string where = "";
                for (int c=0; c<criterios.Length; c++) {
                    where = where + (c==0 ?"":" AND ") + criterios[c] + "= '" + valores[c] +"'";
                }
                string query = "SELECT [IdUsuario], [Usuario], [Contrasenia], [Nombre], [Email], [TipoDocumento], [NroDocumento] FROM Usuario WHERE " + where;
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader(query, System.Data.CommandType.Text))
                {
                    if (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        return UsuarioAdapter.Current.Adapt(values);
                    }
                }
                return null;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar un usuario");
            }
        }

        public IEnumerable<Usuario> Listar()
        {
            try {
                List<Usuario> todosLosUsuarios = new List<Usuario>();
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                using (var dr = sqlHelper.ExecuteReader("Usuario_SelectAll", System.Data.CommandType.StoredProcedure))
                {
                    while (dr.Read())
                    {
                        object[] values = new object[dr.FieldCount];
                        dr.GetValues(values);
                        Usuario unUsuario = UsuarioAdapter.Current.Adapt(values);
                        todosLosUsuarios.Add(unUsuario);
                    }
                }
                return todosLosUsuarios;
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al listar los usuarios");
            }
        }

        public void Modificar(Usuario unObjeto)
        {
            if (unObjeto.UsuarioLogin.Length == 0 ||
                unObjeto.Nombre.Length == 0 ||
                unObjeto.Email.Length == 0 ||
                unObjeto.NroDocumento.Length == 0)
                throw new Exception("Faltan completar datos");

            try
            {
                SqlHelper sqlHelper = new SqlHelper(connectionString);
                sqlHelper.ExecuteNonQuery("Usuario_Update", System.Data.CommandType.StoredProcedure, new SqlParameter[] {
                            new SqlParameter("@IdUsuario", unObjeto.IdUsuario.ToString()),
                            new SqlParameter("@Usuario", unObjeto.UsuarioLogin),
                            new SqlParameter("@Contrasenia", unObjeto.Contrasenia),                                
                            new SqlParameter("@Nombre", unObjeto.Nombre),
                            new SqlParameter("@Email", unObjeto.Email),
                            new SqlParameter("@TipoDocumento", unObjeto.TipoDocumento.ToString()),
                            new SqlParameter("@NroDocumento", unObjeto.NroDocumento)});

                FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().DesvincularHijos(unObjeto);
                FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().DesvincularHijos(unObjeto);
                unObjeto.Permisos.ForEach(unHijo => {
                    if (unHijo is Patente)
                    {
                        FabricaDAL.Current.ObtenerUsuarioPatenteRelacion().Unir(unObjeto, (Patente)unHijo);
                    }
                    if (unHijo is Familia)
                    {
                        FabricaDAL.Current.ObtenerUsuarioFamiliaRelacion().Unir(unObjeto, (Familia)unHijo);
                    }
                });
            } catch (Exception ex) {
                ex.RegistrarError();
                if (ex.Message.Contains("UQ_UsuarioApodo"))
                    throw new Exception("Ya existe otro usuario con ese mismo inicio de sesión");
                if (ex.Message.Contains("UQ_UsuarioDocumento"))
                    throw new Exception("Ya existe otro usuario con ese mismo tipo y número de documento");
                throw new Exception("Hubo un problema al modificar un usuario");
            }
        }

    }

}
