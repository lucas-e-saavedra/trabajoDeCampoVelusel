using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServicioDeAlertas
{
    public partial class EnviarAlertasPorMail : ServiceBase
    {
        public EnviarAlertasPorMail()
        {
            InitializeComponent();
            eventosDeSistema = new EventLog();
            if (!EventLog.SourceExists("Velusel_EnviarAlertas")) {
                EventLog.CreateEventSource("Velusel_EnviarAlertas", "Application");
            }
            eventosDeSistema.Source = "Velusel_EnviarAlertas";
            eventosDeSistema.Log = "Application";
        }

        protected override void OnStart(string[] args)
        {
            //TODO: link que compartió el profesor
            // https://proyectoa.com/crear-aplicacion-completa-de-servicio-windows-con-net-c-c-sharp/
            eventosDeSistema.WriteEntry("Iniciando verificacion de alertas");
            BLL.GestorStock.Current.EnviarAlertas();
            eventosDeSistema.WriteEntry("La tarea de verificar alertas ha terminado");
        }

        protected override void OnStop()
        {
        }
    }
}
