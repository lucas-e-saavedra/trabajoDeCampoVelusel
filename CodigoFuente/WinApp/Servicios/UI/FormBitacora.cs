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
    public partial class FormBitacora : Form
    {
        public FormBitacora()
        {
            InitializeComponent();
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            IEnumerable<Evento> bitacora = GestorHistorico.Current.ListarBitacora();
            grillaBitacora.DataSource = bitacora.Reverse().ToList();
        }
    }
}
