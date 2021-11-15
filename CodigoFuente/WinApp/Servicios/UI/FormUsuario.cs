using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using Servicios.Extensions;
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
#pragma warning disable 1591
    public partial class FormUsuario : Form, IIdiomasObservador
    {
        Usuario usuarioActual;
        PatenteFamilia permisoAagregar;
        PatenteFamilia permisoAquitar;
        public FormUsuario(Usuario unUsuario)
        {
            InitializeComponent();
            usuarioActual = unUsuario;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            grillaPermisos.AutoGenerateColumns = false;
            grillaDisponibles.AutoGenerateColumns = false;
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);

            List<KeyValuePair<string, string>> lstTiposDocumento = new List<KeyValuePair<string, string>>();
            Array tipos = Enum.GetValues(typeof(Usuario.EnumTipoDocumento));
            foreach (Usuario.EnumTipoDocumento tipo in tipos)
            {
                lstTiposDocumento.Add(new KeyValuePair<string, string>(tipo.ToString(), ((int)tipo).ToString()));
            }
            comboDocumento.DataSource = lstTiposDocumento;
            comboDocumento.DisplayMember = "Key";
            comboDocumento.ValueMember = "Value";

            inputUsuario.Text = usuarioActual.UsuarioLogin;
            inputNombre.Text = usuarioActual.Nombre;
            inputEmail.Text = usuarioActual.Email;
            comboDocumento.SelectedValue = ((int)usuarioActual.TipoDocumento).ToString();
            inputDocumento.Text = usuarioActual.NroDocumento;


            grillaPermisos.DataSource = usuarioActual.Permisos;
            List<PatenteFamilia> disponibles = new List<PatenteFamilia>();
            disponibles.AddRange(GestorUsuarios.Current.ListarFamilias());
            disponibles.AddRange(GestorUsuarios.Current.ListarPatentes());
            usuarioActual.Permisos.ForEach(item => disponibles.Remove(item));
            grillaDisponibles.DataSource = disponibles;
        }

        private void FormUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM usuarios".Traducir();
            lblUsuario.Text = "Usuario".Traducir();
            lblNombre.Text = "Nombre".Traducir();
            lblEmail.Text = "Email".Traducir();
            lblDocumento.Text = "Documento".Traducir();
            lblPermisos.Text = "Permisos".Traducir();
            lblDisponibles.Text = "Disponibles".Traducir();
            btnGrabar.Text = usuarioActual.IdUsuario == Guid.Empty ? "Agregar".Traducir() : "Modificar".Traducir();
            btnCancelar.Text = "Cancelar".Traducir();


            Nombre_P.HeaderText = "Nombre".Traducir();
            Nombre_D.HeaderText = "Nombre".Traducir();
            CantidadHijos_P.HeaderText = "(Sub)Permisos".Traducir();
            CantidadHijos_P.HeaderText = "(Sub)Permisos".Traducir();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try { 
                usuarioActual.UsuarioLogin = inputUsuario.Text;
                usuarioActual.Nombre = inputNombre.Text;
                usuarioActual.Email = inputEmail.Text;
                usuarioActual.NroDocumento = inputDocumento.Text;
                KeyValuePair<string, string> tipoDocumentoSeleccionado = (KeyValuePair<string, string>) comboDocumento.SelectedItem;
                Usuario.EnumTipoDocumento unTipoDocumento = (Usuario.EnumTipoDocumento)Enum.Parse(typeof(Usuario.EnumTipoDocumento), tipoDocumentoSeleccionado.Value);
                usuarioActual.TipoDocumento = unTipoDocumento;
                if (usuarioActual.IdUsuario == Guid.Empty)
                {
                    GestorUsuarios.Current.CrearUsuario(usuarioActual);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    GestorUsuarios.Current.ModificarUsuario(usuarioActual);
                    this.DialogResult = DialogResult.OK;
                }
            } catch (Exception ex){
                ex.MostrarEnAlert();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

        private void grillaPermisos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaPermisos.SelectedRows.Count > 0)
            {
                int index = grillaPermisos.SelectedRows[0].Index;
                IEnumerable<PatenteFamilia> items = (IEnumerable<PatenteFamilia>)grillaPermisos.DataSource;
                permisoAquitar = items.ElementAt(index);
            }
        }

        private void grillaDisponibles_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaDisponibles.SelectedRows.Count > 0)
            {
                int index = grillaDisponibles.SelectedRows[0].Index;
                IEnumerable<PatenteFamilia> items = (IEnumerable<PatenteFamilia>)grillaDisponibles.DataSource;
                permisoAagregar = items.ElementAt(index);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            usuarioActual.Permisos.Add(permisoAagregar);
            grillaPermisos.DataSource = null;
            grillaPermisos.DataSource = usuarioActual.Permisos;

            List<PatenteFamilia> items = (List<PatenteFamilia>)grillaDisponibles.DataSource;
            items.Remove(permisoAagregar);
            grillaDisponibles.DataSource = null;
            grillaDisponibles.DataSource = items;
            permisoAagregar = null;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            usuarioActual.Permisos.Remove(permisoAquitar);
            grillaPermisos.DataSource = null;
            grillaPermisos.DataSource = usuarioActual.Permisos;

            List<PatenteFamilia> items = (List<PatenteFamilia>)grillaDisponibles.DataSource;
            items.Add(permisoAquitar);
            grillaDisponibles.DataSource = null;
            grillaDisponibles.DataSource = items;
            permisoAquitar = null;
        }
    }
}
