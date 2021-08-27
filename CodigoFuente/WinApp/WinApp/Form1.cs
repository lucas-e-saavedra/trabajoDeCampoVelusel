using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicios.Domain;
using Servicios.Extensions;
using Servicios.BLL;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            button1.Text = "Hola".Traducir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Evento unEvento = new Evento();
            unEvento.fechaYhora = DateTime.Now;
            unEvento.categoria = Evento.CategoriaEvento.DEPURACION;
            unEvento.mensaje = "Este es un mensaje de prueba";
            GestorHistorico.Current.RegistrarBitacora(unEvento);

            List<Evento> bitacora = GestorHistorico.Current.ListarBitacora();

            button1.Text = "Chau".Traducir();
        }
    }
}
