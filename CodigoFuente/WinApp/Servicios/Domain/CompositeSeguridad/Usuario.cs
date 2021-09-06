using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain.CompositeSeguridad
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string UsuarioLogin { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public EnumTipoDocumento TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public List<PatenteFamilia> Permisos { get; set; } = new List<PatenteFamilia>();

        public enum EnumTipoDocumento { DNI, CUIL, PASAPORTE}
    }
}
