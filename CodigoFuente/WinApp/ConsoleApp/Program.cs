using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando verificacion de alertas");
            BLL.GestorStock.Current.EnviarAlertas();
            Console.WriteLine("La tarea de verificar alertas ha terminado");

            Console.WriteLine("Iniciando backup de la base de datos SecurityDB");
            Servicios.BLL.GestorHistorico.Current.GenerarBackupBaseDeDatos("SecurityDB");
            Console.WriteLine("Ha terminado el backup de la base de datos SecurityDB");

            Console.WriteLine("Iniciando backup de la base de datos Velusel");
            Servicios.BLL.GestorHistorico.Current.GenerarBackupBaseDeDatos("Velusel");
            Console.WriteLine("Ha terminado el backup de la base de datos Velusel");

        }
    }
}
