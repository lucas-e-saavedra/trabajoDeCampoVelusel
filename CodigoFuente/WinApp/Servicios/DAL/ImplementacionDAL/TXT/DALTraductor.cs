using Servicios.DAL.Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using Servicios.DAL.Contratos;
using Servicios.Extensions;

namespace Servicios.DAL.ImplementacionDAL.TXT
{
    class DALTraductor : IRepositorioGenerico<string>
    {
        private string rutaArchivo;
        internal DALTraductor(string ruta)
        {
            rutaArchivo = ruta;
        }
        public void Agregar(string unObjeto)
        {
            try {
                FileHelper file = new FileHelper(rutaArchivo);
                file.Write(unObjeto + '|');
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al agregar una traduccion");
            }
        }

        public void Borrar(string unObjeto)
        {
            throw new NotImplementedException();
        }

        public string BuscarUno(string[] criterios, string[] valores)
        {
            try { 
                FileHelper fileHelper = new FileHelper(rutaArchivo);
                List<string> lineas = fileHelper.Read();

                string lineaBuscada = lineas.FirstOrDefault(item =>{
                    return item.Split('|').First().ToLower() == valores.First().ToLower();                
                });
                return lineaBuscada?.Split('|')?.ElementAt(1);
            } catch (Exception ex) {
                ex.RegistrarError();
                throw new Exception("Hubo un problema al buscar una traduccion");
            }
        }

        public IEnumerable<string> Listar()
        {
            throw new NotImplementedException();
        }

        public void Modificar(string unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
