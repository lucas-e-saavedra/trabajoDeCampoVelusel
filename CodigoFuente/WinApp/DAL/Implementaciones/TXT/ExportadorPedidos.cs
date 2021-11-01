using Dominio;
using Servicios.DAL.Contratos;
using Servicios.DAL.Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementaciones.TXT
{
    class ExportadorPedidos : IRepositorioGenerico<Pedido>
    {
        public void Agregar(Pedido unObjeto)
        {
            string rutaArchivo = $"ExportarATienda/Pedido-{unObjeto.Id}.txt";
            FileHelper file = new FileHelper(rutaArchivo);
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(unObjeto.Detalle);
            //throw new Exception($"El pedido no se pudo exportar:\n{output}");
            file.Write(output);
        }

        public void Borrar(Pedido unObjeto)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarUno(string[] criterios, string[] valores)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> Listar()
        {
            throw new NotImplementedException();
        }

        public void Modificar(Pedido unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
