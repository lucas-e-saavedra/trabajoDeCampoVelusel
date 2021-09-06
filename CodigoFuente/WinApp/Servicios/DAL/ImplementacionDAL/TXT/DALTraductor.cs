using Servicios.DAL.Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using Servicios.DAL.Contratos;

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
            FileHelper file = new FileHelper(rutaArchivo);
            file.Write(unObjeto + '|');
        }

        public void Borrar(string unObjeto)
        {
            throw new NotImplementedException();
        }

        public string BuscarUno(string criterio, string valor)
        {
            FileHelper fileHelper = new FileHelper(rutaArchivo);
            List<string> lineas = fileHelper.Read();

            string lineaBuscada = lineas.FirstOrDefault(item =>{
                return item.Split('|').First().ToLower() == valor.ToLower();                
            });
            return lineaBuscada?.Split('|')?.ElementAt(1);
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
