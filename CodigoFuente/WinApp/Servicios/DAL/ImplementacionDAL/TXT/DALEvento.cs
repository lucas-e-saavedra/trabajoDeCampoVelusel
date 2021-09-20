using Servicios.DAL.Herramientas;
using Servicios.DAL.ImplementacionDAL.TXT.Adapters;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using Servicios.DAL.Contratos;
using Servicios.Extensions;

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
            try {
                FileHelper file = new FileHelper(rutaArchivo);
                file.Write(AdaptadorEvento.ConvertirATexto(unObjeto));
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al grabar la bitácora");
            }
        }

        public void Borrar(Evento unObjeto)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarUno(string[] criterios, string[] valores)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> Listar()
        {
            try {
                FileHelper fileHelper = new FileHelper(rutaArchivo);
                List<string> lineas = fileHelper.Read();

                Converter<string, Evento> conversor = new Converter<string, Evento>(AdaptadorEvento.desdeTexto);
                return lineas.ConvertAll<Evento>(conversor);
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al leer la bitácora");
            }
        }

        public void Modificar(Evento unObjeto)
        {
            throw new NotImplementedException();
        }

    }
}
