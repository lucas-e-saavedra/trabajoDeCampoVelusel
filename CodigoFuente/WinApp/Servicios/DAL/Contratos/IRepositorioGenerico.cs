using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.Contratos
{
    public interface IRepositorioGenerico<T>
    {
        T BuscarUno(string[] criterios, string[] valores);
        void Borrar(T unObjeto);

        void Agregar(T unObjeto);

        IEnumerable<T> Listar();

        void Modificar(T unObjeto);
    }
}
