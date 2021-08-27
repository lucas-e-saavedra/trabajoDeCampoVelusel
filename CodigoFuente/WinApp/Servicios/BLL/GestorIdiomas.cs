using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            filePath = @"I18n\idioma.";
        }
        #endregion

        private string filePath = String.Empty;

        public string Traducir(string texto)
        {
            string textoTraducido = texto;

            string culturaCodigo = Thread.CurrentThread.CurrentUICulture.Name.Split('-').First();

            using (StreamReader streamReader = new StreamReader(filePath + culturaCodigo))
            {
                while (!streamReader.EndOfStream)
                {
                    string linea = streamReader.ReadLine();
                    string[] claveValor = linea.Split('|');

                    if (claveValor[0].ToLower() == texto.ToLower())
                    {
                        textoTraducido = claveValor[1];
                        break;
                    }
                }
            }

            return textoTraducido;
        }

    }
}
