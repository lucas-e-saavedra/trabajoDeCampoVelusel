using Servicios.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp.Fabricante
{
    public partial class FormProductos : Form, IIdiomasObservador
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            ActualizarTraducciones();
            GestorIdiomas.Current.SuscribirObservador(this);
            grillaProductos.DataSource = BLL.GestorFabricacion.Current.ListarProductos();
            /*Producto unProducto = new Producto();
            unProducto.Id = Guid.NewGuid();
            unProducto.Nombre = "Vela Londres";
            unProducto.Unidad = Unidades.Un;
            unProducto.Descripcion = "Vela Londres, es una vela muy simple";
            unProducto.Foto = "https://www.vapati.com.ar/wp-content/uploads/2020/09/Velas-aromaticas-con-palabra-01.jpg";
            BLL.GestorFabricacion.Current.RegistrarProducto(unProducto);*/
        }

        private void FormProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            GestorIdiomas.Current.DesuscribirObservador(this);
        }

        public void ActualizarTraducciones()
        {

        }
    }
}
