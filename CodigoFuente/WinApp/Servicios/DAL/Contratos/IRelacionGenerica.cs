using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.Contratos
{
    public interface IRelacionGenerica<T, U>
    {
        /// <summary>
        /// Agrego una relación de tipo 1 a *, T elemento origen, U es el destino
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        void Unir(T obj1, U obj2);

        /// <summary>
        /// Elimino una relación de tipo 1 a *, T elemento origen, U es el destino
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        void Desvincular(T obj1, U obj2);

        /// <summary>
        /// Elimino todas las relaciónes de tipo 1 a *, del elemento T
        /// </summary>
        /// <param name="obj1"></param>
        void DesvincularHijos(T obj1);

        /// <summary>
        /// Obtener elementos destino a partir de un elemento origen T
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<U> Obtener(T obj);

    }
}
