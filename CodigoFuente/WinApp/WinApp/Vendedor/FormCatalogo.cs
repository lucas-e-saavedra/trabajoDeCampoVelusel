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
            Bitmap Imagen { get; set; }

            public ProductoCatalogo(Producto unProducto) {
                this.Id = unProducto.Id;
                this.Nombre = unProducto.Nombre;
                this.Descripcion = unProducto.Descripcion;
                this.Foto = unProducto.Foto;

                if (Foto.Length > 0 && Foto.Contains("https://")) {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(this.Foto);
                    myRequest.Method = "GET";
                    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();

                    this.Imagen = bmp;
                } else { }
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
    }
}
