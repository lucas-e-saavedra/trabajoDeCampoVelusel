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
    /// <summary>
    /// Este gestor se encarga de realizar acciones relacionadas con la seguridad del sistema y sus datos
    /// </summary>
    public class GestorSeguridad
    {
        #region Singleton
        private readonly static GestorSeguridad _instance = new GestorSeguridad();

        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
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

        /// <summary>
        /// Este metodo se utiliza transformar un dato sensible para poder grabarlo o transmitirlo en forma segura.
        /// </summary>
        /// <param name="datoOriginal">Aqui se recibe el dato original que se va a encriptar debe ser un string</param>
        /// <param name="clave">Aqui se recibe cual es la clave que se utilizará en el algoritmo de encriptación</param>
        /// <returns>Devuelve el texto encriptado segun el dato original y la clave utilizada</returns>
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

        /// <summary>
        /// Este metodo se utiliza volver a obtener un dato sensible que se ha grabado o transmitido en forma segura.
        /// </summary>
        /// <param name="datoEncriptado">Aqui se recibe el dato encriptado que se va a descifrar, debe ser un string</param>
        /// <param name="clave">Aqui se recibe cual es la clave que se utilizará en el algoritmo de desencriptación</param>
        /// <returns>Devuelve el dato original recreado segun el dato encriptado y la clave utilizada</returns>
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
        
        /// <summary>
        /// Este metodo genera una clave aleatoria de 5 caractéres utilizando letras de la A a la Z (incluyendo mayúsculas y minusculas) y los números del 0 al 9
        /// </summary>
        /// <returns>Devuelve un string con la clave generada</returns>
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

        /// <summary>
        /// Este método se utiliza para verificar si el objeto que se recibió concuerda con el dato verificador guardado
        /// </summary>
        /// <param name="objetoAverificar">Recibe un objeto cualquiera</param>
        /// <param name="datoVerificadorGuardado">Recibe el dato verificador almacenado</param>
        /// <returns>Devuelve True si ambos datos verificadores coinciden y devuelve False si no coinciden</returns>
        public bool ValidarIntegridad(object objetoAverificar, int datoVerificadorGuardado)
        {
            int datoVerificador = GenerarDatoVerificador(objetoAverificar);
            return datoVerificador == datoVerificadorGuardado;
        }

        /// <summary>
        /// Este método genera un numero entero que se utiliza como dato verificador de un objeto de cualquier tipo (utiliza Reflection)
        /// </summary>
        /// <param name="objetoAverificar">Recibe un objeto cualquiera para calcular el dato verificador</param>
        /// <returns>Devuelve el numero de hash basandose en las propiedades del objeto</returns>
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