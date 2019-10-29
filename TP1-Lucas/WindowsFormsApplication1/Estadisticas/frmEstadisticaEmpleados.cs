using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TrabajoPractico.Estadisticas
{
    public partial class frmEstadisticaEmpleados : Form
    {
        public frmEstadisticaEmpleados()
        {
            InitializeComponent();
        }

        private void EstadisticaEmpleados_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
