﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.BLL;
using Servicios.Domain;

namespace Servicios.Extensions
{
    public static class ExtensionException
    {
        /// <summary>
        /// Este metodo agrega la capacidad de registrar en el historico de errores cuando ocurre un error
        /// </summary>
        /// <param name="unaExcepcion"></param>
        /// <returns></returns>
        public static void RegistrarError(this Exception unaExcepcion)
        {
            //unaExcepcion.InnerException
            Error unError = new Error();
            unError.fechaYhora = DateTime.Now;
            unError.clase = unaExcepcion.GetType().Name;
            unError.descripcion = unaExcepcion.Message;
            unError.detalle = unaExcepcion.StackTrace;
            GestorHistorico.Current.RegistrarErrores(unError);
        }
    }
}
