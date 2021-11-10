using Dominio.CompositeProducto;
using Servicios.BLL;
using Servicios.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp.Vendedor
{
    public partial class FormCatalogo : Form, IIdiomasObservador
    {
        public Producto productoSeleccionado;
        public FormCatalogo()
        {
            InitializeComponent();
        }

        private void FormCatalogo_Load(object sender, EventArgs e)
        {
            grillaProductos.AutoGenerateColumns = false;
            List<ProductoCatalogo> lista3 = BLL.GestorPedidos.Current.ConsultarCatalogo().ToList().ConvertAll(item => new ProductoCatalogo(item));
            grillaProductos.DataSource = lista3;
            GestorIdiomas.Current.SuscribirObservador(this);
            ActualizarTraducciones();
        }
        private void FormCatalogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }
        public void ActualizarTraducciones()
        {
            Text = "Catálogo".Traducir();
            btnSeleccionar.Text = "Seleccionar".Traducir();

            Nombre.HeaderText = "Nombre".Traducir();
            Descripción.HeaderText = "Descripción".Traducir();
            Imagen.HeaderText = "Imagen".Traducir();
        }
        class ProductoCatalogo : Producto {
            public Image bitmapImage { get; }
            public ProductoCatalogo(Producto unProducto) {
                this.Id = unProducto.Id;
                this.Nombre = unProducto.Nombre;
                this.Descripcion = unProducto.Descripcion;
                this.Foto = unProducto.Foto;

                if (unProducto.Foto.Length > 0 && unProducto.Foto.Contains("https://"))
                {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(unProducto.Foto);
                    myRequest.Method = "GET";
                    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    try {
                        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                        this.bitmapImage = bmp;
                    } catch (Exception ex) {
                        ex.RegistrarError();
                    } finally {
                        myResponse.Close();
                    }
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void grillaProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (grillaProductos.SelectedRows.Count > 0)
            {
                int index = grillaProductos.SelectedRows[0].Index;
                IEnumerable<ProductoCatalogo> productos = (IEnumerable<ProductoCatalogo>)grillaProductos.DataSource;
                productoSeleccionado = productos.ElementAt(index);
            }
        }

        private void grillaProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grillaProductos.Columns[e.ColumnIndex].Name == "Imagen")
            {
                IEnumerable<ProductoCatalogo> productos = (IEnumerable<ProductoCatalogo>)grillaProductos.DataSource;
                ProductoCatalogo unProducto = productos.ElementAt(e.RowIndex);

                grillaProductos.Rows[e.RowIndex].Height = 100;
                e.Value = (Image)unProducto.bitmapImage;
            }
        }
    }
}
