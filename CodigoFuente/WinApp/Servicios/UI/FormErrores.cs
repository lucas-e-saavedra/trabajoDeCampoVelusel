using Servicios.BLL;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Servicios.UI
{
    public partial class FormErrores : Form
    {
        public FormErrores()
        {
            InitializeComponent();
        }

        private void FormErrores_Load(object sender, EventArgs e)
        {
            IEnumerable<Error> errores = GestorHistorico.Current.ListarErrores();
            grillaErrores.DataSource = errores.Reverse().ToList();
        }
    }
}
