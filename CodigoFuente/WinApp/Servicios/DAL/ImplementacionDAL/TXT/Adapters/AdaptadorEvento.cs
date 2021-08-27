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
    class AdaptadorEvento
    {
        public static Evento desdeTexto(string textoEvento)
        {
            string textoFecha = textoEvento.Split('|').First();
            textoEvento = textoEvento.Split('|').Last();
            string textoCategoria = textoEvento.Split(':').First();
            string textoMensaje = textoEvento.Substring(textoCategoria.Length + 2);
            return new Evento()
            {
                fechaYhora = DateTime.ParseExact(textoFecha, "yyyy-MM-dd HH.mm.ss", CultureInfo.InvariantCulture),
                categoria = (CategoriaEvento)Enum.Parse(typeof(CategoriaEvento), textoCategoria),
                mensaje = textoMensaje
            };
        }

        public static string ConvertirATexto(Evento unObjeto)
        {
            //return $"{unObjeto.categoria.ToString()}: {unObjeto.mensaje}";
            //return $"{DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss") }|{ message }";
            return $"{unObjeto.fechaYhora.ToString("yyyy-MM-dd HH.mm.ss")}|{unObjeto.categoria}: {unObjeto.mensaje}";
        }

    }
}
