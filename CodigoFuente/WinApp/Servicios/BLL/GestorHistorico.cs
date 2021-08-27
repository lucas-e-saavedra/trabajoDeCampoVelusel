using Servicios.DAL;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.BLL
{
    public class GestorHistorico
    {
        #region Singleton
        private readonly static GestorHistorico _instance = new GestorHistorico();

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

        public List<Evento> ListarBitacora() {
            return FabricaDAL.Current.ObtenerRepositorioDeEventos().Listar();
        }

        public List<Error> ListarErrores() { 
            return FabricaDAL.Current.ObtenerRepositorioDeErrores().Listar();
        }

        public void RegistrarBitacora(Evento unEvento) {
            FabricaDAL.Current.ObtenerRepositorioDeEventos().Agregar(unEvento);
        }
        public void RegistrarErrores(Error unError) {
            FabricaDAL.Current.ObtenerRepositorioDeErrores().Agregar(unError);
        }
    }
}
