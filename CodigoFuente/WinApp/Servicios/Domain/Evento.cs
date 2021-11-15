using System;

namespace Servicios.Domain
{
    /// <summary>
    /// Esta clase se utiliza para representar los eventos que se almacenan en la bitácora que se producen durante la ejecución del sistema
    /// </summary>
    public class Evento
    {
        /// <summary>
        /// Esta enumeración sirve para parametrizar las categorias de evento
        /// </summary>
        public enum CategoriaEvento { 
            /// <summary>
            /// Eventos utiles para obtener información sin tener que detenerse a depurar el sistema
            /// </summary>
            DEPURACION, 
            /// <summary>
            /// Eventos importantes que se piden en los casos de uso que se registren
            /// </summary>
            INFORMATIVO, 
            /// <summary>
            /// Advertencias de posibles inconvenientes
            /// </summary>
            ADVERTENCIA, 
            /// <summary>
            /// Errores surgidos por no respetar reglas de negocio
            /// </summary>
            ERROR }

        /// <summary>
        /// La categoría indica el tipo de evento que se registró
        /// </summary>
        public CategoriaEvento categoria { get; set; }

        /// <summary>
        /// El mensaje contiene una descripción del evento registrado
        /// </summary>
        public String mensaje { get; set; }

        /// <summary>
        /// Fecha y hora en que sucedió el evento
        /// </summary>
        public DateTime fechaYhora;

        /// <summary>
        /// Representación en forma de texto de la fecha y hora en que sucedió el evento
        /// </summary>
        public String timestamp { get { return fechaYhora.ToString(); } }

        /// <summary>
        /// El contructor por defecto no asigna ningún valor por defecto a las propiedades del objeto
        /// </summary>
        public Evento() { }
        
        /// <summary>
        /// El contructor recibe la categoria y mensaje. Además utiliza la fecha y hora actual
        /// </summary>
        public Evento(CategoriaEvento unaCategoria, String unMensaje){
            fechaYhora = DateTime.Now;
            categoria = unaCategoria;
            mensaje = unMensaje;
        }
    }
}
