using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Extensions
{
    public static class ExtensionString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string Traducir(this string texto)
        {
            return GestorIdiomas.Current.Traducir(texto);
        }
    }
}
