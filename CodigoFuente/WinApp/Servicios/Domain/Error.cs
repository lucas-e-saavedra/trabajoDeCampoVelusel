using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain
{
    /// <summary>
    /// Esta clase se utiliza para representar los errores y excepciones que se producen durante la ejecución del sistema
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Nombre de la clase del tipo de excepción que se produjo
        /// </summary>
        public String clase { get; set; }

        /// <summary>
        /// Mensaje de la excepción
        /// </summary>
        public String descripcion { get; set; }
        
        /// <summary>
        /// El detalle del error contiene el stacktrace con las lineas de código que produjeron el error
        /// </summary>
        public String detalle { get; set; }

        /// <summary>
        /// Fecha y hora en que sucedió el error
        /// </summary>
        public DateTime fechaYhora;
        
        /// <summary>
        /// Representación en forma de texto de la fecha y hora en que sucedió el error
        /// </summary>
        public String timestamp { get { return fechaYhora.ToString(); } }
        
        /// <summary>
        /// El contructor por defecto utiliza la fecha y hora actual
        /// </summary>
        public Error(){
            fechaYhora = DateTime.Now;
        }
    }
}
