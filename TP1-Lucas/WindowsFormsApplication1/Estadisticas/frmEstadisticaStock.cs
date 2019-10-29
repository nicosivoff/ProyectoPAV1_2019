using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico.Estadisticas
{
    public partial class frmEstadisticaStock : Form
    {
        public frmEstadisticaStock()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrenda.Prenda' Puede moverla o quitarla según sea necesario.
            this.prendaTableAdapter.Fill(this.dsPrenda.Prenda);

            this.reportViewer1.RefreshReport();
        }
    }
}
