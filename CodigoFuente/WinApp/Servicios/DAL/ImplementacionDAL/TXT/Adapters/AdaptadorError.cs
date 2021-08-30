using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Servicios.Domain.Evento;

namespace Servicios.DAL.ImplementacionDAL.TXT.Adapters
{
    class AdaptadorError
    {
        public static Error desdeTexto(string textoError)
        {
            string textoFecha = textoError.Split('|').First();
            textoError = textoError.Split('|').Last();
            string textoClase = textoError.Split(':').First();
            string textoDescripcion = textoError.Substring(textoClase.Length + 2);
            return new Error()
            {
                fechaYhora = DateTime.ParseExact(textoFecha, "yyyy-MM-dd HH.mm.ss", CultureInfo.InvariantCulture),
                clase = textoClase,
                descripcion = textoDescripcion
            };
        }

        public static string ConvertirATexto(Error unObjeto)
        {
            return $"{unObjeto.fechaYhora.ToString("yyyy-MM-dd HH.mm.ss")}|{unObjeto.clase}: {unObjeto.descripcion}";
        }

    }
}
