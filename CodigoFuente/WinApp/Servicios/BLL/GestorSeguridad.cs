using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.BLL
{
    class GestorSeguridad
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

        public string Encriptar(string datoOriginal) {
            return "(" + datoOriginal + ")";
        }
        public string Desencriptar(string datoEncriptado) {
            return datoEncriptado.Substring(1, datoEncriptado.Length - 2);
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
    }
}
