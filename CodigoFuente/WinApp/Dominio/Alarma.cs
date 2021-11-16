
using Servicios.Domain.CompositeSeguridad;

namespace Dominio
{
    /// <summary>
    /// Esta entidad contiene la representación de las distintas alarmas que puede configurar el usuario vendedor
    /// </summary>
    public class Alarma
    {
        /// <summary>
        /// Aqui está representado quien es el destinatario de las notificaciones
        /// </summary>
        public Usuario comprador { get; set; }

        /// <summary>
        /// Cantidad de días hábiles de anticipación que verifica el sistema por bloqueos en la falta de materiales en el inventario
        /// </summary>
        public int DiasAlarmaStock { get; set; }

        /// <summary>
        /// Cantidad de días hábiles de anticipación que verifica el sistema por bloqueos en el inventario y en las compras previstas
        /// </summary>
        public int DiasAlarmaCompras { get; set; }
    }
}
