using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain
{
    public class Evento
    {
        public enum CategoriaEvento { DEPURACION, INFORMATIVO, ADVERTENCIA, ERROR }

        public CategoriaEvento categoria { get; set; }

        public String mensaje { get; set; }

        public DateTime fechaYhora;
    }
}
