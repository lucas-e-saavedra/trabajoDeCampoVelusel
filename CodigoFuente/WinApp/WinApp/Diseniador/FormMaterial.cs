using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinApp.Diseniador
{
    public partial class FormMaterial : Form, IIdiomasObservador
    {
        Material materialActual;

        public FormMaterial(Material unMaterial)
        {
            InitializeComponent();
            materialActual = unMaterial;
        }

        private void FormMaterial_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            List<KeyValuePair<string, string>> lstUnidades = new List<KeyValuePair<string, string>>();
            Array unidades = Enum.GetValues(typeof(Unidades));
            foreach (Unidades unidad in unidades)
            {
                lstUnidades.Add(new KeyValuePair<string, string>(unidad.ToString(), unidad.ToString()));
            }
            comboUnidad.DataSource = lstUnidades;
            comboUnidad.DisplayMember = "Key";
            comboUnidad.ValueMember = "Value";

            if (materialActual != null) {
                inputNombre.Text = materialActual.Nombre;
                comboUnidad.SelectedValue = (materialActual.Unidad).ToString();
            }
        }

        private void FormMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM Materiales".Traducir();
            lblNombre.Text = "Nombre".Traducir();
            lblUnidad.Text = "Unidad de medida".Traducir();
            btnGrabar.Text = materialActual.Id == Guid.Empty ? "Agregar".Traducir() : "Modificar".Traducir();
            btnCancelar.Text = "Cancelar".Traducir();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {
                materialActual.Nombre = inputNombre.Text;
                KeyValuePair<string, string> unidadSeleccionada = (KeyValuePair<string, string>)comboUnidad.SelectedItem;
                Unidades unaUnidad = (Unidades)Enum.Parse(typeof(Unidades), unidadSeleccionada.Value);
                materialActual.Unidad = unaUnidad;
                if (materialActual.Id == Guid.Empty) {
                    materialActual.Id = Guid.NewGuid();
                    BLL.GestorFabricacion.Current.RegistrarMaterial(materialActual);
                    this.DialogResult = DialogResult.OK;
                } else {
                    BLL.GestorFabricacion.Current.ModificarMaterial(materialActual);
                    this.DialogResult = DialogResult.OK;
                }
            } catch (Exception ex) {
                ex.MostrarEnAlert();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
