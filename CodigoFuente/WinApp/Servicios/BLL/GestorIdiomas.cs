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
    /// <summary>
    /// Este gestor se encarga del manejo del multi idioma
    /// </summary>
    public sealed class GestorIdiomas
    {
        #region Singleton
        private readonly static GestorIdiomas _instance = new GestorIdiomas();

        /// <summary>
        /// Acceso a la instancia del gestor
        /// </summary>
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

        /// <summary>
        /// Este método traduce un texto al idioma que el gestor tiene asignado, en caso de que dicho texto no tenga cargada ninguna traducción, lo agrega como una traducción vacía (para que luego se pueda recopilar facilmente todas las traducciones utilizadas que están pendientes de definir)
        /// </summary>
        /// <param name="texto">Recibe el texto a traducir</param>
        /// <returns>Devuelve el texto traducido al idioma correspondiente, o si no hay traducción devuelve el mismo texto que se recibió por parametro</returns>
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
        /// <summary>
        /// Este método permite que un formulario o un objeto visual pueda suscribirse a notificaciones sobre el idioma seleccionado
        /// </summary>
        /// <param name="unObservador">Recibe cualquier objeto que implemente la interfaz IIdiomasObservador</param>
        public void SuscribirObservador(IIdiomasObservador unObservador) {
            observadores.Add(unObservador);
        }

        /// <summary>
        /// Este método permite que un formulario o un objeto visual pueda desuscribirse a notificaciones sobre el idioma seleccionado
        /// </summary>
        /// <param name="unObservador">Recibe cualquier objeto que implemente la interfaz IIdiomasObservador</param>
        public void DesuscribirObservador(IIdiomasObservador unObservador) {
            observadores.Remove(unObservador);
        }

        /// <summary>
        /// Este método permite cambiar el idioma seleccionado y notifica a los observadores para que actualicen sus traducciones
        /// </summary>
        /// <param name="nuevoIdioma">Recibe el idioma seleccionado</param>
        public void SeleccionarIdioma(string nuevoIdioma) {
            idiomaSeleccionado = nuevoIdioma;
            NotificarObservadores();
        }
        private void NotificarObservadores() {
            observadores.ForEach(item => item.ActualizarTraducciones() );
        }
    }

    /// <summary>
    /// Todos los objetos que deseen mostrar traducciones y enterarse sobre cambios en el idioma deben implementar esta interfaz
    /// </summary>
    public interface IIdiomasObservador {
        /// <summary>
        /// Este método es el que se utiliza para notificar sobre el cambio de idioma.
        /// </summary>
        void ActualizarTraducciones();
    }
}
