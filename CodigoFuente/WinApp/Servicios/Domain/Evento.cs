using System;

namespace Servicios.Domain
{
    public class Evento
    {
        public enum CategoriaEvento { DEPURACION, INFORMATIVO, ADVERTENCIA, ERROR }

        public CategoriaEvento categoria { get; set; }

        public String mensaje { get; set; }

        public DateTime fechaYhora;

        public Evento() { }
        public Evento(CategoriaEvento unaCategoria, String unMensaje){
            fechaYhora = DateTime.Now;
            categoria = unaCategoria;
            mensaje = unMensaje;
        }
    }
}
