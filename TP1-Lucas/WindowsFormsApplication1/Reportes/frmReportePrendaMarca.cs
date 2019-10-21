using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico.Reportes
{
    public partial class frmReportePrendaMarca : Form
    {
        public frmReportePrendaMarca()
        {
            InitializeComponent();
        }

        private void frmReportePrendaMarca_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'TipoPrenda.PrendaMarca' table. You can move, or remove it, as needed.
            this.PrendaMarcaTableAdapter.Fill(this.TipoPrenda.PrendaMarca);

            this.reportViewer1.RefreshReport();
        }
    }
}
