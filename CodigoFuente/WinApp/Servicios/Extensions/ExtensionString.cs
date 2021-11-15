using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servicios.BLL;

namespace Servicios.Extensions
{
    /// <summary>
    /// Esta clase la utilizamos para agregar comportamiento a la clase String para realizar mas fácil y con menos lineas las acciones relacionadas con el multi-idioma
    /// </summary>
    public static class ExtensionString
    {
        /// <summary>
        /// Esta función de extensión permite invocar al gestor de idiomas para traducir este string
        /// </summary>
        /// <param name="texto">Este es el texto que se va a traducir</param>
        /// <returns>Devuelve el texto ya traducido</returns>
        public static string Traducir(this string texto)
        {
            return GestorIdiomas.Current.Traducir(texto);
        }
    }
}
