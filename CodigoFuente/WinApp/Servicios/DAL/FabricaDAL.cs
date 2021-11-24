using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System.Configuration;
using Servicios.DAL.Contratos;
using Servicios.DAL.Herramientas;
using System;
using Servicios.Extensions;
using System.IO;

namespace Servicios.DAL
{
    class FabricaDAL
    {
        #region Singleton
        private readonly static FabricaDAL _instance = new FabricaDAL();

        public static FabricaDAL Current
        {
            get
            {
                return _instance;
            }
        }

        private FabricaDAL()
        {
            bbddSeguridad = ConfigurationManager.ConnectionStrings["SLConString"].ConnectionString;
            archivoBitacora = ConfigurationManager.AppSettings["rutaArchivoBitacora"];
            if (!archivoBitacora.Contains("\\")) {
                archivoBitacora = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), archivoBitacora);
            }
            archivoErrores = ConfigurationManager.AppSettings["rutaArchivoErrores"];
            if (!archivoErrores.Contains("\\")) {
                archivoErrores = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), archivoErrores);
            }
            carpetaTraducciones = "I18n\\idioma.";
            if (true) { //usar true cuando se buildea para armar el instalable, y false cuando se va a ejecutar desde visual studio
                carpetaTraducciones = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), carpetaTraducciones);
            }
        }
        #endregion
        private string bbddSeguridad;
        private string archivoBitacora;
        private string archivoErrores;
        private string carpetaTraducciones;

        public IRepositorioGenerico<Evento> ObtenerRepositorioDeEventos()
        {
            return new ImplementacionDAL.TXT.DALEvento(archivoBitacora);
        }

        public IRepositorioGenerico<Error> ObtenerRepositorioDeErrores()
        {
            return new ImplementacionDAL.TXT.DALError(archivoErrores);
        }

        public IRepositorioGenerico<string> ObtenerRepositorioDeTraducciones(string codigoIdioma)
        {
            return new ImplementacionDAL.TXT.DALTraductor(carpetaTraducciones+codigoIdioma);
        }

        public IRepositorioGenerico<Usuario> ObtenerRepositorioDeUsuarios()
        {
            return new ImplementacionDAL.SqlServer.UsuarioRepositorio(bbddSeguridad);
        }
        public IRepositorioGenerico<Patente> ObtenerRepositorioDePatentes()
        {
            return new ImplementacionDAL.SqlServer.PatenteRepositorio(bbddSeguridad);
        }
        public IRepositorioGenerico<Familia> ObtenerRepositorioDeFamilias()
        {
            return new ImplementacionDAL.SqlServer.FamiliaRepositorio(bbddSeguridad);
        }

        public IRelacionGenerica<Usuario, Patente> ObtenerUsuarioPatenteRelacion()
        {
            return new ImplementacionDAL.SqlServer.UsuarioPatenteRelacion(bbddSeguridad);
        }
        public IRelacionGenerica<Usuario, Familia> ObtenerUsuarioFamiliaRelacion() {
            return new ImplementacionDAL.SqlServer.UsuarioFamiliaRelacion(bbddSeguridad);
        }
        public IRelacionGenerica<Familia, Patente> ObtenerFamiliaPatenteRelacion()
        {
            return new ImplementacionDAL.SqlServer.FamiliaPatenteRelacion(bbddSeguridad);
        }
        public IRelacionGenerica<Familia, Familia> ObtenerFamiliaFamiliaRelacion()
        {
            return new ImplementacionDAL.SqlServer.FamiliaFamiliaRelacion(bbddSeguridad);
        }

        /// <summary>
        /// Este método sirve para generar un backup (.bak) de la base de datos especificada en la ruta mencionada
        /// </summary>
        /// <param name="nombreBBDD">Nombre de la base de datos a resguardar</param>
        /// <param name="rutaArchivo">Ruta del archivo donde se guardará el backup</param>
        /// <returns>Devuelve True si pudo ejecutar el backup, y devuelve False si no pudo ejecutarlo</returns>
        public bool GenerarBackUp(string nombreBBDD, string rutaArchivo)
        {
            try
            {
                string query = $"Backup database {nombreBBDD} to disk='{rutaArchivo}'";
                SqlHelper sqlHelper = new SqlHelper(bbddSeguridad);
                sqlHelper.ExecuteNonQuery(query, System.Data.CommandType.Text);
                return true;
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                return false;
            }
        }
    }
}
