using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDiseno;
using CapaDatos;

namespace RentaVideos
{
    public partial class MDIFilmagic : Form
    {
        private int childFormNumber = 0;
        sentencia sn = new sentencia();
        string usuarioact;

        public MDIFilmagic()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MantenimientoDeBonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
          MantenimientoBono frm = new MantenimientoBono(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDeCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantenimientoCategorias frm = new MantenimientoCategorias(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManteniminetoCliente frm = new ManteniminetoCliente(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MantenimientoEmpleados frm = new MantenimientoEmpleados(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MantenimientoDeMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
         MantenimientoMaterial frm = new MantenimientoMaterial(lblUsuario.Text);
            frm.MdiParent = this;
            frm.Show();
        }

        private void MDIFilmagic_Load(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.ShowDialog();

            lblUsuario.Text = login.obtenerNombreUsuario();
            usuarioact = lblUsuario.Text;
        }

        private void SeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDI_Seguridad seguridad = new MDI_Seguridad(lblUsuario.Text);
            seguridad.lbl_nombreUsuario.Text = lblUsuario.Text;
            seguridad.ShowDialog();
            sn.insertarBitacora(lblUsuario.Text, "Probo la bitacora", "Usuarios");
        }

        private void RentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
