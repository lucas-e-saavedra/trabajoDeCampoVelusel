
using Servicios.Domain.CompositeSeguridad;

namespace Dominio
{
    public class Alarma
    {
        public Usuario comprador { get; set; }
        public int DiasAlarmaStock { get; set; }
        public int DiasAlarmaCompras { get; set; }
    }
}
