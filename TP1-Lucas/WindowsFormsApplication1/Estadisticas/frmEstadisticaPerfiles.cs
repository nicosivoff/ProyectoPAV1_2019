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
    public partial class frmEstadisticaPerfiles : Form
    {
        public frmEstadisticaPerfiles()
        {
            InitializeComponent();
        }

        private void frmEstadisticaPerfiles_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPerfiles.Perfil' Puede moverla o quitarla según sea necesario.
            this.perfilTableAdapter.Fill(this.dsPerfiles.Perfil);

            this.reportViewer1.RefreshReport();
        }
    }
}
