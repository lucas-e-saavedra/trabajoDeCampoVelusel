using Servicios.BLL;
using Servicios.Domain;
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
    public partial class FormErrores : Form, IIdiomasObservador
    {
        Error errorSeleccionado = null;
        IEnumerable<Error> errores;
        public FormErrores()
        {
            InitializeComponent();
        }

        private void FormErrores_Load(object sender, EventArgs e)
        {
            grillaErrores.AutoGenerateColumns = false;
            GestorIdiomas.Current.SuscribirObservador(this);
            errores = GestorHistorico.Current.ListarErrores();
            ActualizarTraducciones();
            ActualizarGrilla();
        }
        private void FormErrores_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "Ver errores".Traducir();
            btnDetalle.Enabled = errorSeleccionado != null;
            btnDetalle.Text = "Ver detalle".Traducir();

            fechaYhora.HeaderText = "Fecha y hora".Traducir();
            clase.HeaderText = "Categoría".Traducir();
            descripcion.HeaderText = "Mensaje".Traducir();
            lblFiltroClase.Text = "Filtrar por clase".Traducir();
            lblFiltroDescripcion.Text = "Filtrar por descripción".Traducir();

        }
        private void ActualizarGrilla()
        {
            List<Error> erroresFiltrados = errores.ToList();
            if (inputFiltroClase.Text.Length > 0)
                erroresFiltrados = erroresFiltrados.Where(item => item.clase.ToString().ToLower().Contains(inputFiltroClase.Text.ToLower())).ToList();
            if (inputFiltroDescripcion.Text.Length > 0)
                erroresFiltrados = erroresFiltrados.Where(item => item.descripcion.ToLower().Contains(inputFiltroDescripcion.Text.ToLower())).ToList();

            erroresFiltrados.Reverse();
            grillaErrores.DataSource = erroresFiltrados;
        }
        private void grillaErrores_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaErrores.SelectedRows.Count > 0)
            {
                int index = grillaErrores.SelectedRows[0].Index;
                IEnumerable<Error> errores = (IEnumerable<Error>)grillaErrores.DataSource;
                errorSeleccionado = errores.ElementAt(index);
                btnDetalle.Enabled = errorSeleccionado != null;
            }
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            FormError form = new FormError(errorSeleccionado);
            form.ShowDialog();
        }

        private void inputFiltroClase_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void inputFiltroDescripcion_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
