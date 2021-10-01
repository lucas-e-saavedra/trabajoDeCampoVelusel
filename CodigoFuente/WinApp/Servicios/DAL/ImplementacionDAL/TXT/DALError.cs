using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.TXT.Adapters;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using Servicios.DAL.Contratos;

namespace Servicios.DAL.ImplementacionDAL.TXT
{
    class DALError: IRepositorioGenerico<Error>
    {
        private string rutaArchivo;
        internal DALError(string ruta)
        {
            rutaArchivo = ruta;
        }

        public void Agregar(Error unObjeto)
        {
            FileHelper file = new FileHelper(rutaArchivo);
            file.Write(AdaptadorError.ConvertirATexto(unObjeto));
        }

        public void Borrar(Error unObjeto)
        {
            throw new NotImplementedException();
        }

        public Error BuscarUno(string[] criterios, string[] valores)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Error> Listar()
        {
            FileHelper fileHelper = new FileHelper(rutaArchivo);
            List<string> lineas = fileHelper.Read();

            Converter<string, Error> conversor = new Converter<string, Error>(AdaptadorError.desdeTexto);
            return lineas.ConvertAll<Error>(conversor);
        }

        public void Modificar(Error unObjeto)
        {
            throw new NotImplementedException();
        }

    }
}
