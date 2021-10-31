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
        }
    }
}
