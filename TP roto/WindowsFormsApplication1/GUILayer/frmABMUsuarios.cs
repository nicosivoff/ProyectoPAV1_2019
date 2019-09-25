using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using TrabajoPractico.DataAccessLayer;

namespace TrabajoPractico
{
    public partial class frmABMUsuarios : Form
    {
        DBHelper oBD = new DBHelper();

        public frmABMUsuarios()
        {
            InitializeComponent();
        }


        private void frmABMUsuarios_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboPerfil, oBD.consultarTabla("Perfil"), "nombre", "idPerfil");
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }


    }
}
