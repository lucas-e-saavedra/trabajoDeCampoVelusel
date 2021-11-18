using DAL;
using Dominio;
using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    /// <summary>
    /// Este gestor se encarga de manejar la información de nuestros clientes
    /// </summary>
    public sealed class GestorClientes
    {
        private readonly static GestorClientes _instance = new GestorClientes();

        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
        public static GestorClientes Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorClientes()
        {
            //Implent here the initialization of your singleton
        }

        /// <summary>
        /// Este método se utiliza para consultar los clientes que tenemos en el sistema y que no han sido manipulados sus datos por fuera del sistema.
        /// </summary>
        /// <returns>Devuelve una colección de Clientes</returns>
        public IEnumerable<Cliente> ListarClientes() {
            IEnumerable<Cliente> clientesEncriptados = FabricaDAL.Current.ObtenerRepositorioDeClientes().Listar();
            List<Cliente> clientesValidados = new List<Cliente>();
            string llave = ConfigurationManager.AppSettings["claveCifrado"];
            foreach (Cliente unCliente in clientesEncriptados) {
                string emailDesencriptado = GestorSeguridad.Current.Desencriptar(unCliente.Email, llave);
                string documentoDesencriptado = GestorSeguridad.Current.Desencriptar(unCliente.NroDocumento, llave);
                string telefonoDesencriptado = GestorSeguridad.Current.Desencriptar(unCliente.Telefono, llave);
                unCliente.Email = emailDesencriptado;
                unCliente.NroDocumento = documentoDesencriptado;
                unCliente.Telefono = telefonoDesencriptado;

                if (GestorSeguridad.Current.ValidarIntegridad(unCliente, unCliente.DatoVerificador)) {
                    clientesValidados.Add(unCliente);
                }
            }
            return clientesValidados;
        }

        /// <summary>
        /// Este método agrega un nuevo cliente a y lo persiste en nuestra lista de clientes, ademas se asegura de grabar el dato verificador para que luego se pueda validar.
        /// </summary>
        /// <param name="unCliente">Instancia de Cliente que vamos a agregar</param>
        public void CrearCliente(Cliente unCliente)
        {
            unCliente.DatoVerificador = GestorSeguridad.Current.GenerarDatoVerificador(unCliente);
            
            string llave = ConfigurationManager.AppSettings["claveCifrado"];
            string emailEncriptado = GestorSeguridad.Current.Encriptar(unCliente.Email, llave);
            string documentoEncriptado = GestorSeguridad.Current.Encriptar(unCliente.NroDocumento, llave);
            string telefonoEncriptado = GestorSeguridad.Current.Encriptar(unCliente.Telefono, llave);
            unCliente.Email = emailEncriptado;
            unCliente.NroDocumento = documentoEncriptado;
            unCliente.Telefono = telefonoEncriptado;

            FabricaDAL.Current.ObtenerRepositorioDeClientes().Agregar(unCliente);
            Usuario usuario = GestorSesion.Current.usuarioActual;
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} agregó al cliente {unCliente.Nombre}({unCliente.Id})");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }

        /// <summary>
        /// Este método modifica un cliente existente a y lo persiste en nuestra lista de clientes, ademas vuelve a grabar un nuevo dato verificador para que luego se pueda validar.
        /// </summary>
        /// <param name="unCliente">Instancia del Cliente que vamos a modificar</param>
        public void ModificarCliente(Cliente unCliente)
        {
            unCliente.DatoVerificador = GestorSeguridad.Current.GenerarDatoVerificador(unCliente);

            string llave = ConfigurationManager.AppSettings["claveCifrado"];
            string emailEncriptado = GestorSeguridad.Current.Encriptar(unCliente.Email, llave);
            string documentoEncriptado = GestorSeguridad.Current.Encriptar(unCliente.NroDocumento, llave);
            string telefonoEncriptado = GestorSeguridad.Current.Encriptar(unCliente.Telefono, llave);
            unCliente.Email = emailEncriptado;
            unCliente.NroDocumento = documentoEncriptado;
            unCliente.Telefono = telefonoEncriptado;

            FabricaDAL.Current.ObtenerRepositorioDeClientes().Modificar(unCliente);
            Usuario usuario = GestorSesion.Current.usuarioActual;
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} modificó al cliente {unCliente.Nombre}({unCliente.Id})");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
    }

}
