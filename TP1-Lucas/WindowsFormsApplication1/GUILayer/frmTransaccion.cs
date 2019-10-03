using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.GUILayer;
using TrabajoPractico.DataAccessLayer;

namespace TrabajoPractico.GUILayer
{
    public partial class frmTransaccion : Form
    {
        DBHelper oBD = new DBHelper();
        public frmTransaccion()
        {
            InitializeComponent();
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void frmTransaccion_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboCliente, oBD.consultarTabla("Cliente"), "apellido", "nroDoc");
            LlenarCombo(cboVendedor, oBD.consultarTabla("Empleado"), "apellido", "legajo");
            LlenarCombo(cboFormaPago, oBD.consultarTabla("TipoPago"), "nombre", "codTipoPago");

        }
    }
}

