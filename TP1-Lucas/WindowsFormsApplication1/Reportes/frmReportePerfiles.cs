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
    public partial class frmReportePerfiles : Form
    {
        public frmReportePerfiles()
        {
            InitializeComponent();
        }

        private void frmReportePerfiles_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPerfiles.Perfil' Puede moverla o quitarla según sea necesario.
            this.perfilTableAdapter.Fill(this.dsPerfiles.Perfil);

            this.reportViewer1.RefreshReport();
        }
    }
}
