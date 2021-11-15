using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.Contratos
{
    /// <summary>
    /// Esta interfaz sirve para definir los métodos a traves de los cuales se va a persistir la información de los objetos que pertenecen a la clase que implementa esta interfaz
    /// </summary>
    /// <typeparam name="T">Tipo de objeto a persistir</typeparam>
    public interface IRepositorioGenerico<T>
    {
        /// <summary>
        /// Este método sirve para buscar entre los objetos persistidos uno que coincida con los parametros especificados
        /// </summary>
        /// <param name="criterios">Lista de criterios de búsqueda</param>
        /// <param name="valores">Lista de valores para los criterios de busqueda</param>
        /// <returns>Devuelve el primer objeto que cumple con los requisitos o null si ninguno cumple</returns>
        T BuscarUno(string[] criterios, string[] valores);
        
        /// <summary>
        /// Este método sirve para eliminar un objeto de entre los objetos persistidos
        /// </summary>
        /// <param name="unObjeto">Objeto a eliminar</param>
        void Borrar(T unObjeto);

        /// <summary>
        /// Este método sirve para insertar un objeto a los objetos persistidos
        /// </summary>
        /// <param name="unObjeto">Objeto a insertar</param>
        void Agregar(T unObjeto);

        /// <summary>
        /// Este metodo sirve para obtener una colección de todos los objetos de este tipo que están persistidos
        /// </summary>
        /// <returns>Devuelve una lista de objetos del tipo T</returns>
        IEnumerable<T> Listar();

        /// <summary>
        /// Este método sirve para modificar uno objeto de los objetos persistidos
        /// </summary>
        /// <param name="unObjeto">Objeto a modificar</param>
        void Modificar(T unObjeto);
    }
}
