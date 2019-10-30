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
    public partial class frmEstadisticaVentaTotal : Form
    {
        public frmEstadisticaVentaTotal()
        {
            InitializeComponent();
        }

        private void frmEstadisticaVentaTipo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DsEst.VentaTransaccion' table. You can move, or remove it, as needed.
            this.VentaTransaccionTableAdapter.Fill(this.DsEst.VentaTransaccion);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
           
        }
    }
}
