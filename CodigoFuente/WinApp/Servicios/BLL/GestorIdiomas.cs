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
    public sealed class GestorIdiomas
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
            idiomaSeleccionado = Thread.CurrentThread.CurrentUICulture.Name.Split('-').First();
            observadores = new List<IIdiomasObservador>();
        }
        #endregion


        public string Traducir(string texto)
        {
            string[] criterios = {"key"};
            string[] valores = {texto};
            string textoTraducido = FabricaDAL.Current.ObtenerRepositorioDeTraducciones(idiomaSeleccionado).BuscarUno(criterios, valores);

            if (textoTraducido != null) {
                if (textoTraducido.Trim().Length > 0)
                    return textoTraducido;
                else
                    return texto;
            } else {
                FabricaDAL.Current.ObtenerRepositorioDeTraducciones(idiomaSeleccionado).Agregar(texto);
                return texto;
            }
        }

        private string idiomaSeleccionado;
        private List<IIdiomasObservador> observadores;
        public void SuscribirObservador(IIdiomasObservador unObservador) {
            observadores.Add(unObservador);
        }
        public void DesuscribirObservador(IIdiomasObservador unObservador) {
            observadores.Remove(unObservador);
        }

        public void SeleccionarIdioma(string nuevoIdioma) {
            idiomaSeleccionado = nuevoIdioma;
            NotificarObservadores();
        }
        private void NotificarObservadores() {
            observadores.ForEach(item => item.ActualizarTraducciones() );
        }
    }

    public interface IIdiomasObservador {
        void ActualizarTraducciones();
    }
}
