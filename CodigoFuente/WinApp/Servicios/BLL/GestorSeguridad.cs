using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.BLL
{
    public class GestorSeguridad
    {
        #region Singleton
        private readonly static GestorSeguridad _instance = new GestorSeguridad();

        public static GestorSeguridad Current
        {
            get
            {
                return _instance;
            }
        }

        private GestorSeguridad()
        { }
        #endregion

        public string Encriptar(string datoOriginal, string clave) {
            byte[] vectorInicializacion = new byte[16];
            byte[] array;

            try { 
                using (Aes algoritmo = Aes.Create())
                {
                    algoritmo.Key = Encoding.UTF8.GetBytes(clave);
                    algoritmo.IV = vectorInicializacion;

                    ICryptoTransform encriptador = algoritmo.CreateEncryptor(algoritmo.Key, algoritmo.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encriptador, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(datoOriginal);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }
                return Convert.ToBase64String(array);
            } catch(Exception ex) {
                ex.RegistrarError();
                throw new Exception("Falló el algoritmo de encriptación");
            }            
        }
        public string Desencriptar(string datoEncriptado, string clave) {
            //return datoEncriptado.Substring(1, datoEncriptado.Length - 2);
            byte[] vectorInicializacion = new byte[16];
            byte[] buffer = Convert.FromBase64String(datoEncriptado);

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(clave);
                    aes.IV = vectorInicializacion;
                    ICryptoTransform desencriptador = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, desencriptador, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                throw new Exception("Falló el algoritmo de encriptación");
            }
        }
        public string GenerarClaveAleatoria() {
            Random obj = new Random();
            string sCadena = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = sCadena.Length;
            char cletra;
            int nlongitud = 5;
            string sNuevacadena = string.Empty;

            for (int i = 0; i < nlongitud; i++)
            {
                cletra = sCadena[obj.Next(longitud)];
                sNuevacadena += cletra.ToString();
            }
            return sNuevacadena;
        }

        public bool ValidarIntegridad(object objetoAverificar, int datoVerificadorGuardado)
        {
            int datoVerificador = GenerarDatoVerificador(objetoAverificar);
            return datoVerificador == datoVerificadorGuardado;
        }

        public int GenerarDatoVerificador(object objetoAverificar) {
            Type tipo = objetoAverificar.GetType();
            System.Reflection.PropertyInfo[] properties = tipo.GetProperties();
            IEnumerable<System.Reflection.PropertyInfo> orderedProperties = properties.OrderBy(item => item.Name);
            StringBuilder stringObject = new StringBuilder();
            foreach (System.Reflection.PropertyInfo oneProperty in orderedProperties)
            {
                if (oneProperty.Name != "DatoVerificador")
                {
                    stringObject.Append($"{oneProperty.Name}({oneProperty.PropertyType})={oneProperty.GetValue(objetoAverificar)},");
                }
            }
            stringObject = stringObject.Remove(stringObject.Length - 1, 1);
            string objetoCompleto = stringObject.ToString();
            return objetoCompleto.GetHashCode();
        }
    }
}