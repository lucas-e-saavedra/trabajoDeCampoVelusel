using System;
using System.Windows.Forms;
using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using System.Linq;
using System.Configuration;
using System.Threading;
using Servicios.UI;

namespace WinApp
{
    public partial class FormPrincipal : Form, IIdiomasObservador
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);

            FormIngresar formIngresar = new FormIngresar();
            formIngresar.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form item in this.MdiChildren) {
                item.Close();
            }
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.MdiParent = this;
            formUsuarios.WindowState = FormWindowState.Maximized;
            formUsuarios.Show();
        }

        private void familiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                item.Close();
            }
            FormFamilias formFamilias = new FormFamilias();
            formFamilias.MdiParent = this;
            formFamilias.WindowState = FormWindowState.Maximized;
            formFamilias.Show();
        }

        private void patentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                item.Close();
            }
            FormPatentes formPatentes = new FormPatentes();
            formPatentes.MdiParent = this;
            formPatentes.WindowState = FormWindowState.Maximized;
            formPatentes.Show();
        }
    }
}
