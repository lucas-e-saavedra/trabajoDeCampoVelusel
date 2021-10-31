﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Domain
{
    public class Error
    {
        public String clase { get; set; }
        public String descripcion { get; set; }
        public String detalle { get; set; }

        public DateTime fechaYhora;
        public String timestamp { get { return fechaYhora.ToString(); } }
        public Error(){
            fechaYhora = DateTime.Now;
        }
    }
}
