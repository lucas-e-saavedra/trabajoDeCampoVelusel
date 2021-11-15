using Servicios.DAL;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.BLL
{
    /// <summary>
    /// Este gestor se encarga de registrar el historial de eventos y excepciones
    /// </summary>
    public class GestorHistorico
    {
        #region Singleton
        private readonly static GestorHistorico _instance = new GestorHistorico();
        
        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
        public static GestorHistorico Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorHistorico()
        {}
        #endregion

        /// <summary>
        /// Este método se utiliza para consultar el listado completo de eventos registrados en la bitácora
        /// </summary>
        /// <returns>Devuelve una lista de Eventos</returns>
        public IEnumerable<Evento> ListarBitacora() {
            return FabricaDAL.Current.ObtenerRepositorioDeEventos().Listar();
        }

        /// <summary>
        /// Este método se utiliza para consultar el listado completo de excepciones registradas en el historial de errores
        /// </summary>
        /// <returns>Devuelve una lista de Errores</returns>
        public IEnumerable<Error> ListarErrores() { 
            return FabricaDAL.Current.ObtenerRepositorioDeErrores().Listar();
        }

        /// <summary>
        /// Este método se utiliza para insertar un evento en la bitácora
        /// </summary>
        /// <param name="unEvento">Instancia del evento a agregar</param>
        public void RegistrarBitacora(Evento unEvento) {
            FabricaDAL.Current.ObtenerRepositorioDeEventos().Agregar(unEvento);
        }

        /// <summary>
        /// Este método se utiliza para insertar un registro en el historial de errores
        /// </summary>
        /// <param name="unError">Instancia del error a agregar</param>
        public void RegistrarErrores(Error unError) {
            FabricaDAL.Current.ObtenerRepositorioDeErrores().Agregar(unError);
        }
    }
}
