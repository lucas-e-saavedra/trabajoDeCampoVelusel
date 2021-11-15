using System;
using System.Collections.Generic;
using System.IO;

namespace Servicios.DAL.Herramientas
{
    /// <summary>
    /// Esta clase se utiliza para interactuar con archivos planos
    /// </summary>
    public class FileHelper
    {
        private string filePath = String.Empty;

        /// <summary>
        /// Este es el constructor obligatorio que recibe por parámetro la ruta del archivo con el cual se va a interactuar
        /// </summary>
        /// <param name="onePath">String de la ruta del archivo</param>
        public FileHelper(String onePath)
        {
            filePath = onePath;
        }

        /// <summary>
        /// Este método sirve para agregar una nueva linea al final del archivo plano
        /// </summary>
        /// <param name="message">Texto de la linea que se va a agregar</param>
        public void Write(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }

        /// <summary>
        /// Este método sirve para leer el contenido de un archivo plano
        /// </summary>
        /// <returns>Devuelve una lista de textos uno por cada linea</returns>
        public List<string> Read()
        {
            List<String> lines = new List<string>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    lines.Add(streamReader.ReadLine());
                }
                streamReader.Close();
            }
            return lines;
        }

    }
}
