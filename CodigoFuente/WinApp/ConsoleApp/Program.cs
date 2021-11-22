using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Restaurando la base de datos SecurityDB");
            string pathDDBBSecurity = Directory.GetCurrentDirectory() + "\\SecurityDB-INICIAL.bak";
            RestoreDatabaseBAK("SecurityDB", pathDDBBSecurity);
            Console.WriteLine("Se ha restaurado la base de datos SecurityDB correctamente");
            
            Console.WriteLine("Restaurando la base de datos Velusel");
            string pathDDBBVelusel  = Directory.GetCurrentDirectory() + "\\Velusel-INICIAL.bak";
            RestoreDatabaseBAK("Velusel", pathDDBBVelusel);
            Console.WriteLine("Se ha restaurado la base de datos Velusel correctamente");
            Console.Read();
        }

        public static void RestoreDatabaseBAK(string nombreBBDD, string rutaArchivoBAK)
        {
            string connString = "Data Source=LAPTOP-ETGG4K9E\\SQLEXPRESS; Initial Catalog=master;User ID=sa;password=.";
            string sql = "RESTORE DATABASE [" + nombreBBDD + "] FROM DISK = '" + rutaArchivoBAK + "' WITH REPLACE;";

            SqlConnection con = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(sql, con);

            con.Open();
            command.ExecuteNonQuery();

            //MessageBox.Show("Database Recovered Successfully!");
            con.Close();
            con.Dispose();
        }
    }
}
