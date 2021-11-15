using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain.CompositeSeguridad
{
    /// <summary>
    /// Esta clase se utiliza para representar a los usuarios que interactuan con el sistema.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador unico que distingue a este usuario
        /// </summary>
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Nombre de usuario que utiliza éste para ingresar al sistema
        /// </summary>
        public string UsuarioLogin { get; set; }

        /// <summary>
        /// Contraseña que utiliza el usuario para validar que efectivamente es él quien está interactuando con el sistema.
        /// </summary>
        public string Contrasenia { get; set; }

        /// <summary>
        /// Nombre y apellido del usuario
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Correo electrónico del usuario al cual se le enviará su contraseña cuando se blaquee y notificaciones de alertas.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Tipo de documento que utiliza el usuario para identificarse
        /// </summary>
        public EnumTipoDocumento TipoDocumento { get; set; }

        /// <summary>
        /// Número de documento que utiliza el usuario para identificarse
        /// </summary>
        public string NroDocumento { get; set; }

        /// <summary>
        /// Todos los permisos y familias de permisos que posee el usuario
        /// </summary>
        public List<PatenteFamilia> Permisos { get; set; } = new List<PatenteFamilia>();

        /// <summary>
        /// Esta enumeración sirve para parametrizar los tipos de documento
        /// </summary>
        public enum EnumTipoDocumento { 
            /// <summary>
            /// DNI argentino
            /// </summary>
            DNI, 
            /// <summary>
            /// CUIT o CUIL utilizado para AFIP
            /// </summary>
            CUIL, 
            /// <summary>
            /// Pasaporte emitido por cualquier país
            /// </summary>
            PASAPORTE}
    }
}
