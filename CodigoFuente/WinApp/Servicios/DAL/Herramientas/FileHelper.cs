using System;
using System.Collections.Generic;
using System.IO;

namespace Servicios.DAL.Herramientas
{
    class FileHelper
    {
        private string filePath = String.Empty;
        internal FileHelper(String onePath)
        {
            filePath = onePath;
        }

        public void Write(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath, true))
            {
                streamWriter.WriteLine(message);
            }
        }

        public List<string> Read()
        {
            List<String> lines = new List<string>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                while (!streamReader.EndOfStream)
                {
                    lines.Add(streamReader.ReadLine());
                }
            }
            return lines;
        }

    }
}
