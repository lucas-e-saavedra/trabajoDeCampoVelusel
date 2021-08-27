using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.TXT.Adapters;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.ImplementacionDAL.TXT
{
    class DALEvento: IRepositorioGenerico<Evento>
    {
        private string rutaArchivo;
        internal DALEvento(string ruta)
        {
            rutaArchivo = ruta;
        }

        public void Agregar(Evento unObjeto)
        {
            FileHelper file = new FileHelper(rutaArchivo);
            file.Write(AdaptadorEvento.ConvertirATexto(unObjeto));
        }

        public void Borrar(Evento unObjeto)
        {
            throw new NotImplementedException();
        }

        public List<Evento> Buscar(string criterio, string valor)
        {
            throw new NotImplementedException();
        }

        public List<Evento> Listar()
        {
            FileHelper fileHelper = new FileHelper(rutaArchivo);
            List<string> lineas = fileHelper.Read();

            Converter<string, Evento> conversor = new Converter<string, Evento>(AdaptadorEvento.desdeTexto);
            return lineas.ConvertAll<Evento>(conversor);
        }

        public void Modificar(Evento unObjeto)
        {
            throw new NotImplementedException();
        }

    }
}
