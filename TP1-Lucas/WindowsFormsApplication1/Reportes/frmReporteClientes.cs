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
    public partial class frmReporteClientes : Form
    {
        public frmReporteClientes()
        {
            InitializeComponent();
        }

        private void frmReporteClientes_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsClientes.Cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.Fill(this.dsClientes.Cliente);

            this.reportViewer1.RefreshReport();
        }
    }
}
