using System;
using System.Windows.Forms;
using Servicios.BLL;
using Servicios.Domain.CompositeSeguridad;
using System.Linq;
using System.Configuration;
using System.Threading;
using Servicios.UI;
using System.Reflection;
using Servicios.Extensions;

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
            IniciarSesion();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            ConstruirMenu();
        }

        #region Gestion del Menu y sus items
        private ToolStripMenuItem crearItemMenu(Patente unaPatente)
        {
            ToolStripMenuItem itemMenu = new ToolStripMenuItem(unaPatente.Nombre.Traducir(), null, this.ItemMenu_click);
            itemMenu.Tag = unaPatente.Vista;
            return itemMenu;
        }
        private ToolStripMenuItem crearItemMenu(Familia unaFamilia)
        {
            ToolStripMenuItem itemMenu = new ToolStripMenuItem(unaFamilia.Nombre.Traducir());
            unaFamilia.ListadoHijos.ForEach(
                hijo => itemMenu.DropDownItems.Add(crearItemMenu(hijo))
                );
            return itemMenu;
        }
        private ToolStripMenuItem crearItemMenu(PatenteFamilia unaPatenteFamilia)
        {
            if (unaPatenteFamilia is Familia)
                return crearItemMenu((Familia)unaPatenteFamilia);
            else
                return crearItemMenu((Patente)unaPatenteFamilia);
        }

        private void ItemMenu_click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem itemSeleccionado = (ToolStripMenuItem)sender;
                string textoAccion = (string)itemSeleccionado.Tag;
                if (textoAccion.StartsWith("Accion_"))
                {
                    string nombreMetodo = textoAccion.Substring("Accion_".Length);
                    this.GetType().GetMethod(nombreMetodo).Invoke(this, null);
                }
                else
                {
                    Assembly ensamblado = textoAccion.Contains('/')
                    ? Assembly.Load(textoAccion.Split('/').First())
                    : this.GetType().Assembly;
                    string nombreTipo = textoAccion.Contains('/') ? textoAccion.Split('/').Last() : textoAccion;

                    foreach (Form item in this.MdiChildren)
                    {
                        item.Close();
                    }
                    Type tipo = ensamblado.GetType(nombreTipo);
                    Form unFormulario = (Form)Activator.CreateInstance(tipo);
                    unFormulario.MdiParent = this;
                    unFormulario.WindowState = FormWindowState.Maximized;
                    unFormulario.Show();
                }
            }
            catch (Exception ex)
            {
                ex.RegistrarError();
                MessageBox.Show("La acción seleccionada no está configurada adecuadamente.".Traducir(), "Contacte al administrador".Traducir());
            }
        }
        #endregion

        #region Metodos públicos disponibles para usar desde el menú
        public void CerrarSesion()
        {
            this.MdiChildren.ToList().ForEach(item=> item.Close());
            GestorSesion.Current.CerrarSesion();
            ConstruirMenu();
        }

        public void CambiarIdiomaES()
        {
            GestorIdiomas.Current.SeleccionarIdioma("ES");
        }
        public void CambiarIdiomaEN()
        {
            GestorIdiomas.Current.SeleccionarIdioma("EN");
        }

        public void IniciarSesion()
        {
            FormIngresar formIngresar = new FormIngresar();
            formIngresar.ShowDialog();
            ConstruirMenu();
        }

        private void ConstruirMenu()
        {
            menuNavegacion.Items.Clear();
            Usuario unUsuario = GestorSesion.Current.usuarioActual;
            if (unUsuario == null) {
                ToolStripMenuItem itemMenu = new ToolStripMenuItem("Iniciar sesión".Traducir(), null, this.ItemMenu_click);
                itemMenu.Tag = "Accion_IniciarSesion";
                menuNavegacion.Items.Add(itemMenu);
            } else {
                unUsuario.Permisos.ForEach(permiso => menuNavegacion.Items.Add(crearItemMenu(permiso)));

                ToolStripMenuItem familiaDefault = new ToolStripMenuItem("Mi cuenta".Traducir());

                ToolStripMenuItem misDatos = new ToolStripMenuItem("Mis datos".Traducir(), null, this.ItemMenu_click);
                misDatos.Tag = "Servicios/Servicios.UI.FormMiCuenta";
                familiaDefault.DropDownItems.Add(misDatos);

                ToolStripMenuItem familiaIdiomas = new ToolStripMenuItem("Seleccionar idioma".Traducir());
                ToolStripMenuItem idiomaEs = new ToolStripMenuItem("Español".Traducir(), null, this.ItemMenu_click);
                idiomaEs.Tag = "Accion_CambiarIdiomaES";
                familiaIdiomas.DropDownItems.Add(idiomaEs);
                ToolStripMenuItem idiomaEn = new ToolStripMenuItem("Ingles".Traducir(), null, this.ItemMenu_click);
                idiomaEn.Tag = "Accion_CambiarIdiomaEN";
                familiaIdiomas.DropDownItems.Add(idiomaEn);
                familiaDefault.DropDownItems.Add(familiaIdiomas);

                ToolStripMenuItem cerrarSesion = new ToolStripMenuItem("Cerrar sesión".Traducir(), null, this.ItemMenu_click);
                cerrarSesion.Tag = "Accion_CerrarSesion";
                familiaDefault.DropDownItems.Add(cerrarSesion);

                menuNavegacion.Items.Add(familiaDefault);

            }
        }
        #endregion
    }
}
