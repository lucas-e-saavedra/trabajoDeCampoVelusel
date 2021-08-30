using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Servicios.DAL;

namespace Servicios.BLL
{
    internal sealed class GestorIdiomas
    {
        #region Singleton
        private readonly static GestorIdiomas _instance = new GestorIdiomas();

        public static GestorIdiomas Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorIdiomas()
        {
        }
        #endregion

        public string Traducir(string texto)
        {
            string culturaCodigo = Thread.CurrentThread.CurrentUICulture.Name.Split('-').First();

            string textoTraducido = FabricaDAL.Current.ObtenerRepositorioDeTraducciones(culturaCodigo).BuscarUno("key", texto);

            if (textoTraducido != null) {
                if (textoTraducido.Trim().Length > 0)
                    return textoTraducido;
                else
                    return texto;
            } else {
                FabricaDAL.Current.ObtenerRepositorioDeTraducciones(culturaCodigo).Agregar(texto);
                return texto;
            }
        }

    }
}
