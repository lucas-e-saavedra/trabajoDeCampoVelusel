using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using Servicios.Extensions;
using Servicios.UI;
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
    public partial class FormUsuarios : Form, IIdiomasObservador
    {
        Usuario usuarioseleccionado;
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            grillaUsuarios.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            grillaUsuarios.DataSource = GestorUsuarios.Current.ListarUsuarios();
        }

        private void FormUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM usuarios".Traducir();
            btnAgregar.Text = "Agregar".Traducir();
            btnBorrar.Text = "Borrar".Traducir();
            btnModificar.Text = "Modificar".Traducir();
            btnClave.Text = "Blanquear clave".Traducir();

            UsuarioLogin.HeaderText = "Usuario".Traducir();
            Nombre.HeaderText = "Nombre".Traducir();
            Email.HeaderText = "Email".Traducir();
            TipoDocumento.HeaderText = "Tipo Documento".Traducir();
            NroDocumento.HeaderText = "Documento".Traducir();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormUsuario form = new FormUsuario(new Usuario());
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                grillaUsuarios.DataSource = GestorUsuarios.Current.ListarUsuarios();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), "Borrar".Traducir(), MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    GestorUsuarios.Current.BorrarUsuario(usuarioseleccionado);
                    grillaUsuarios.DataSource = null;
                    grillaUsuarios.DataSource = GestorUsuarios.Current.ListarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnClave_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro?".Traducir(), "Blanquear clave".Traducir(), MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    GestorUsuarios.Current.BlanquearClave(usuarioseleccionado.IdUsuario);
                    MessageBox.Show("Se envió una nueva contraseña al mail del usuario".Traducir(), "Blanquear clave".Traducir());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.Traducir());
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            FormUsuario form = new FormUsuario(usuarioseleccionado);
            DialogResult resultado = form.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                grillaUsuarios.DataSource = GestorUsuarios.Current.ListarUsuarios();
            }
        }

        private void grillaUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaUsuarios.SelectedRows.Count > 0)
            {
                int index = grillaUsuarios.SelectedRows[0].Index;
                IEnumerable<Usuario> usuarios = (IEnumerable<Usuario>)grillaUsuarios.DataSource;
                usuarioseleccionado = usuarios.ElementAt(index);
            }
        }
    }
}
