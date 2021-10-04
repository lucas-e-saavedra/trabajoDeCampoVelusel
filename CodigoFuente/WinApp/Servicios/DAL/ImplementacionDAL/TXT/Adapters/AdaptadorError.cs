using Servicios.Domain;
using System;
using System.Globalization;
using System.Linq;

namespace Servicios.DAL.ImplementacionDAL.TXT.Adapters
{
    class AdaptadorError
    {
        //falta modificar esto para poder grabar el stack trace tambien
        public static Error desdeTexto(string textoError)
        {
            string[] elementos = textoError.Split('|');
            textoError = elementos[1];
            string textoClase = textoError.Split(':').First();
            string textoDescripcion = textoError.Substring(textoClase.Length + 2);
            return new Error()
            {
                fechaYhora = DateTime.ParseExact(elementos.First(), "yyyy-MM-dd HH.mm.ss", CultureInfo.InvariantCulture),
                clase = textoClase,
                descripcion = textoDescripcion,
                detalle = elementos.Last()
            };
        }

        public static string ConvertirATexto(Error unObjeto)
        {
            string descripcion = unObjeto.descripcion.Replace("\r\n", "\t");
            string detalle = unObjeto.detalle.Replace("\r\n", "\t");
            return $"{unObjeto.fechaYhora.ToString("yyyy-MM-dd HH.mm.ss")}|{unObjeto.clase}: {descripcion}|{detalle}";
        }

    }
}
