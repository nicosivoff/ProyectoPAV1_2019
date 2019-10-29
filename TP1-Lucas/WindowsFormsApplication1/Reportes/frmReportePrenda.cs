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
    public partial class frmReportePrenda : Form
    {
        public frmReportePrenda()
        {
            InitializeComponent();
        }

        private void frmReportePrenda_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrenda.Prenda' Puede moverla o quitarla según sea necesario.
            this.prendaTableAdapter.Fill(this.dsPrenda.Prenda);
            // TODO: esta línea de código carga datos en la tabla 'dsPrenda.Marca' Puede moverla o quitarla según sea necesario.
            this.marcaTableAdapter.Fill(this.dsPrenda.Marca);

            this.reportViewer1.RefreshReport();
        }
    }
}
