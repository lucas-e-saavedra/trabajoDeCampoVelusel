using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios.BLL;
using Servicios.Domain;

namespace Servicios.Extensions
{
    /// <summary>
    /// Esta clase la utilizamos para agregar comportamiento a la clase Exception para realizar mas fácil y con menos lineas las acciones relacionadas con el manejo de errores
    /// </summary>
    public static class ExtensionException
    {
        /// <summary>
        /// Este metodo agrega la capacidad de registrar en el historico de errores cuando ocurre un error
        /// </summary>
        /// <param name="unaExcepcion">Este es el objeto Exception que se va a registrar</param>
        public static void RegistrarError(this Exception unaExcepcion)
        {
            //unaExcepcion.InnerException
            Error unError = new Error();
            unError.clase = unaExcepcion.GetType().Name;
            unError.descripcion = unaExcepcion.Message;
            unError.detalle = unaExcepcion.StackTrace;
            GestorHistorico.Current.RegistrarErrores(unError);
        }

        /// <summary>
        /// Este metodo agrega la capacidad de que se muestre facilmente por pantalla el mensaje de error que detalla el problema que sucedió
        /// </summary>
        /// <param name="unaExcepcion">Este es el objeto Exception que se va a mostrar</param>
        public static void MostrarEnAlert(this Exception unaExcepcion)
        {
            MessageBox.Show(unaExcepcion.Message.Traducir());
        }
    }
}
