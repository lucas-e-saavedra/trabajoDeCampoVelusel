using DAL;
using Dominio;
using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Domain;
using Servicios.Domain.CompositeSeguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public sealed class GestorClientes
    {
        private readonly static GestorClientes _instance = new GestorClientes();

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

        public IEnumerable<Cliente> ListarClientes() {
            return FabricaDAL.Current.ObtenerRepositorioDeClientes().Listar();
        }

        public void CrearCliente(Cliente unCliente)
        {
            FabricaDAL.Current.ObtenerRepositorioDeClientes().Agregar(unCliente);
            Usuario usuario = GestorSesion.Current.usuarioActual;
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} agregó al cliente {unCliente.Nombre}({unCliente.Id})");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
        public void ModificarCliente(Cliente unCliente)
        {
            FabricaDAL.Current.ObtenerRepositorioDeClientes().Modificar(unCliente);
            Usuario usuario = GestorSesion.Current.usuarioActual;
            Evento unEvento = new Evento(Evento.CategoriaEvento.INFORMATIVO, $"El usuario {usuario.UsuarioLogin} modificó al cliente {unCliente.Nombre}({unCliente.Id})");
            GestorHistorico.Current.RegistrarBitacora(unEvento);
        }
    }

}
