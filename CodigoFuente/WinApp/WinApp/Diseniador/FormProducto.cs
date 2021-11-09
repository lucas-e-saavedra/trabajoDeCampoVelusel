using BLL;
using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinApp.Diseniador
{
    public partial class FormProducto : Form, IIdiomasObservador
    {
        Producto productoActual;
        ProductoMaterial ingredienteAagregar;
        ProductoMaterial ingredienteAquitar;
        public FormProducto(Producto unProducto)
        {
            InitializeComponent();
            productoActual = unProducto;
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            grillaIngredientes.AutoGenerateColumns = false;
            grillaDisponibles.AutoGenerateColumns = false;
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

            if (productoActual != null)
            {
                inputNombre.Text = productoActual.Nombre;
                comboUnidad.SelectedValue = (productoActual.Unidad).ToString();
                checkCatalogo.Checked = productoActual.DisponibleEnCatalogo;
                inputReposo.Text = productoActual.plantillaDeFabricacion.ReposoNecesario.ToString();
                inputDescripcion.Text = productoActual.Descripcion;
                inputFotoUrl.Text = productoActual.Foto;
            }

            List<ProductoMaterial> ingrs = productoActual.plantillaDeFabricacion.Ingredientes.ToList();
            grillaIngredientes.DataSource = ingrs;            
            foreach (DataGridViewRow row in grillaIngredientes.Rows)
            {
                object a1 = row.Cells[1].EditType;
                object a2 = row.Cells[1].FormattedValueType;
                object a3 = row.Cells[1].ValueType;
                row.Cells[1].ReadOnly = false;
            }

            List<ProductoMaterial> disponibles = new List<ProductoMaterial>();
            disponibles.AddRange(GestorFabricacion.Current.ListarProductos());
            disponibles.AddRange(GestorFabricacion.Current.ListarMateriales());
            disponibles.Remove(productoActual);
            ingrs.ForEach(item => disponibles.Remove(item));
            grillaDisponibles.DataSource = disponibles;

        }

        private void FormProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {
            Text = "ABM Productos".Traducir();
            lblNombre.Text = "Nombre".Traducir();
            lblUnidad.Text = "Unidad de medida".Traducir();
            btnGrabar.Text = productoActual.Id == Guid.Empty ? "Agregar".Traducir() : "Modificar".Traducir();
            btnCancelar.Text = "Cancelar".Traducir();
            checkCatalogo.Text = "Mostrar en el catálogo".Traducir();
            lblIngredientes.Text = "Ingredientes".Traducir();
            lblDisponibles.Text = "Disponibles".Traducir();
            lblReposo.Text = "Reposo necesario".Traducir();
            lblDescripcion.Text = "Descripción".Traducir();
            lblFotoUrl.Text = "Url de la foto".Traducir();

            Cantidad.HeaderText = "Cantidad".Traducir();
            Unidad.HeaderText = "Unidad de medida".Traducir();
            Nombre.HeaderText = "Nombre".Traducir();
            Unidad_D.HeaderText = "Unidad de medida".Traducir();
            Nombre_D.HeaderText = "Nombre".Traducir();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                productoActual.Nombre = inputNombre.Text;
                KeyValuePair<string, string> unidadSeleccionada = (KeyValuePair<string, string>)comboUnidad.SelectedItem;
                Unidades unaUnidad = (Unidades)Enum.Parse(typeof(Unidades), unidadSeleccionada.Value);
                productoActual.Unidad = unaUnidad;
                productoActual.DisponibleEnCatalogo = checkCatalogo.Checked;
                productoActual.plantillaDeFabricacion.ReposoNecesario = Int16.Parse(inputReposo.Text);
                productoActual.Descripcion = inputDescripcion.Text;
                productoActual.Foto = inputFotoUrl.Text;


                List<ProductoMaterial> ingrsA = productoActual.plantillaDeFabricacion.Ingredientes.ToList();
                IEnumerable<ProductoMaterial> itemsB = (IEnumerable<ProductoMaterial>)grillaIngredientes.DataSource;


                if (productoActual.Id == Guid.Empty)
                {
                    productoActual.Id = Guid.NewGuid();
                    BLL.GestorFabricacion.Current.RegistrarProducto(productoActual);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    BLL.GestorFabricacion.Current.ModificarProducto(productoActual);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                ex.MostrarEnAlert();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void grillaIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaIngredientes.SelectedRows.Count > 0)
            {
                int index = grillaIngredientes.SelectedRows[0].Index;
                IEnumerable<ProductoMaterial> items = (IEnumerable<ProductoMaterial>)grillaIngredientes.DataSource;
                ingredienteAquitar = items.ElementAt(index);
            }
        }
        private void grillaDisponibles_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaDisponibles.SelectedRows.Count > 0)
            {
                int index = grillaDisponibles.SelectedRows[0].Index;
                IEnumerable<ProductoMaterial> items = (IEnumerable<ProductoMaterial>)grillaDisponibles.DataSource;
                ingredienteAagregar = items.ElementAt(index);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            productoActual.Agregar(ingredienteAagregar);
            grillaIngredientes.DataSource = null;
            List<ProductoMaterial> ingrs = productoActual.plantillaDeFabricacion.Ingredientes;
            grillaIngredientes.DataSource = ingrs;

            List<ProductoMaterial> items = (List<ProductoMaterial>)grillaDisponibles.DataSource;
            items.Remove(ingredienteAagregar);
            grillaDisponibles.DataSource = null;
            grillaDisponibles.DataSource = items;
            ingredienteAagregar = null;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            productoActual.plantillaDeFabricacion.Ingredientes.Remove(ingredienteAquitar);
            grillaIngredientes.DataSource = null;
            List<ProductoMaterial> ingrs = productoActual.plantillaDeFabricacion.Ingredientes;
            grillaIngredientes.DataSource = ingrs;

            List<ProductoMaterial> items = (List<ProductoMaterial>)grillaDisponibles.DataSource;
            items.Add(ingredienteAquitar);
            grillaDisponibles.DataSource = null;
            grillaDisponibles.DataSource = items;
            ingredienteAquitar = null;
        }
    }
}
