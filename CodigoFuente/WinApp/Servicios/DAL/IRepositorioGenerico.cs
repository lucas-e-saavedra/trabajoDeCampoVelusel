using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL
{
    internal interface IRepositorioGenerico<T>
    {
        List<T> Buscar(string criterio, string valor);
        void Borrar(T unObjeto);

        void Agregar(T unObjeto);

        List<T> Listar();

        void Modificar(T unObjeto);
    }
}
