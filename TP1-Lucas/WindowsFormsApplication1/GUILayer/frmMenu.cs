using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.GUILayer;

namespace TrabajoPractico
{
    public partial class frmMenu : Form
    {
        frmConsulta consulta = new frmConsulta();
        frmUsuario usuario = new frmUsuario();
        frmPerfil perfil = new frmPerfil();
        frmMarca marca = new frmMarca();
        public frmMenu()
        {
            InitializeComponent();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta.ShowDialog();
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuario.ShowDialog();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perfil.ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marca.ShowDialog();
        }
    }
}
