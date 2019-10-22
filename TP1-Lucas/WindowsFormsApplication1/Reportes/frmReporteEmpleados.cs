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
    public partial class frmReporteEmpleados : Form
    {
        public frmReporteEmpleados()
        {
            InitializeComponent();
        }

        private void frmReporteEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsEmpleados.Empleado' table. You can move, or remove it, as needed.
            this.empleadoTableAdapter.Fill(this.dsEmpleados.Empleado);

            this.reportViewer1.RefreshReport();
        }
    }
}
