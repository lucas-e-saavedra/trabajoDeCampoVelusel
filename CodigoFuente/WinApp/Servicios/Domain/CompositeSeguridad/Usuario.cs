using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain.CompositeSeguridad
{
    public class Usuario
    {
        public Guid guid { get; set; }
        public string Nombre { get; set; }

        public string Contraseña { get; set; }

        public List<PatenteFamilia> Permisos { get; set; } = new List<PatenteFamilia>();

    }
}
