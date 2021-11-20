using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class ServicioDiarioVelusel : ServiceBase
    {
        public ServicioDiarioVelusel()
        {
            InitializeComponent();
            eventosSistema = new EventLog();
            if (!EventLog.SourceExists("ServicioDiarioVelusel")) {
                EventLog.CreateEventSource("ServicioDiarioVelusel", "Application");
            }
            eventosSistema.Source = "ServicioDiarioVelusel";
            eventosSistema.Log = "Application";
        }

        protected override void OnStart(string[] args)
        {
            eventosSistema.WriteEntry("Iniciando ServicioDiarioVelusel");

            eventosSistema.WriteEntry("Iniciando verificacion de alertas");
            BLL.GestorStock.Current.EnviarAlertas();
            eventosSistema.WriteEntry("La tarea de verificar alertas ha terminado");

            eventosSistema.WriteEntry("Iniciando backup de la base de datos SecurityDB");
            Servicios.BLL.GestorHistorico.Current.GenerarBackupBaseDeDatos("SecurityDB");
            eventosSistema.WriteEntry("Ha terminado el backup de la base de datos SecurityDB");

            eventosSistema.WriteEntry("Iniciando backup de la base de datos Velusel");
            Servicios.BLL.GestorHistorico.Current.GenerarBackupBaseDeDatos("Velusel");
            eventosSistema.WriteEntry("Ha terminado el backup de la base de datos Velusel");

        }

        protected override void OnStop()
        {
            eventosSistema.WriteEntry("Se ha detenido ServicioDiarioVelusel");
        }
    }
}
