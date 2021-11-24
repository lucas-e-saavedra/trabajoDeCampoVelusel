using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
namespace WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();


            /*OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup File |*.bak";
            openFileDialog.Multiselect = false;

            //RunScript();
            //string pathDDBBSecurity = "BBDD\\SecurityDB-INICIAL.bak";
            //RestoreDatabaseBAK("SecurityDB", pathDDBBSecurity);
            string pathDDBBVelusel = "BBDD\\Velusel-INICIAL.bak";
            RestoreDatabaseBAK("Velusel", pathDDBBVelusel);*/
        }

        public void RestoreDatabaseBAK(string nombreBBDD, string rutaArchivoBAK) {
            string connString = "Data Source=LAPTOP-ETGG4K9E\\SQLEXPRESS; Initial Catalog=master;User ID=sa;password=.";
            string sql = "RESTORE DATABASE ["+ nombreBBDD + "] FROM DISK = '"+ rutaArchivoBAK + "' WITH REPLACE;";

            SqlConnection con = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(sql, con);

            con.Open();
            command.ExecuteNonQuery();

            //MessageBox.Show("Database Recovered Successfully!");
            con.Close();
            con.Dispose();
        }

        public void RunScript() {
            var fileContent = File.ReadAllText("SecurityDB-script.sql");
            var sqlqueries = fileContent.Split(new[] { " GO " }, StringSplitOptions.RemoveEmptyEntries);

            string connString = "Data Source=LAPTOP-ETGG4K9E\\SQLEXPRESS; Initial Catalog=master;User ID=sa;password=.";
            var con = new SqlConnection(connString);
            var cmd = new SqlCommand("query", con);
            con.Open();
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
