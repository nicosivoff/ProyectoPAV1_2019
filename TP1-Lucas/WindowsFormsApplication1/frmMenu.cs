using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico
{
    public partial class frmMenu : Form
    {
        frmConsulta consulta = new frmConsulta();
        frmPrenda prenda = new frmPrenda();
        public frmMenu()
        {
            InitializeComponent();
        }

        private void aBMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prenda.ShowDialog();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta.ShowDialog();
        }
    }
}
