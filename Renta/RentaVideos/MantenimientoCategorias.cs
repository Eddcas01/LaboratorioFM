using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaVideos
{
    public partial class MantenimientoCategorias : Form
    {
        string usuario = "";
        public MantenimientoCategorias(string user)
        {
            InitializeComponent();
            usuario = user;
            string[] alias = { "No_categoria","Nombre","Estado", };
            navegador1.asignarAlias(alias);
            navegador1.asignarSalida(this);
            Color Hotel = Color.FromArgb(253, 254, 254);
            navegador1.asignarColorFondo(Hotel);
            navegador1.asignarColorFuente(Color.Black);
            navegador1.asignarAyuda("1");
            navegador1.asignarTabla("categoria");
            navegador1.asignarNombreForm("");
        }

        private void Navegador1_Load(object sender, EventArgs e)
        {

            string aplicacionActiva = "1";
            navegador1.ObtenerIdUsuario(usuario);
            navegador1.botonesYPermisosInicial(usuario, aplicacionActiva);
            navegador1.ObtenerIdAplicacion(aplicacionActiva);
        }
    }
}
