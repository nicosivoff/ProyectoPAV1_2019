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
    public partial class frmReporteProveedores : Form
    {
        public frmReporteProveedores()
        {
            InitializeComponent();
        }

        private void frmReporteProveedores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsProveedores.Proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.dsProveedores.Proveedor);
            
            this.reportViewer1.RefreshReport();
        }
    }
}
