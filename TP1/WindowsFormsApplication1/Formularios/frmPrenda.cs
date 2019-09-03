using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPractico
{
    public partial class frmPrenda : Form
    {
        frmLogin fl = new frmLogin();
        Datos oBD = new Datos();
        public frmPrenda()
        {
            InitializeComponent();
        }

        private void frmCargar_Load(object sender, EventArgs e)
        {
            fl.ShowDialog();
            llenarCombo(cboTipoPrenda, oBD.consultarTabla("TipoPrenda"), "descripcion","codTipoPrenda");
            this.grdPrenda.Rows.Clear();
            this.grdPrenda.DataSource = oBD.consultarTabla("Prenda");
        }


        private void llenarCombo(ComboBox cbo, Object source, String display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string sqlInsert = "";

            sqlInsert = @"INSERT INTO Prenda (codPrenda,tipoPrenda,talle,descripcion,precio,cantidad) VALUES ('" +
                         txtCodigo.Text + "', '" +
                         Convert.ToInt32(cboTipoPrenda.SelectedValue) + "', '" +
                         txtDescripcion.Text + "', '" +
                         txtTalle.Text + "', '" +
                         txtPrecio.Text + "', '" +
                         txtCantidad.Text + "')";

            oBD.actualizar(sqlInsert);
            this.grdPrenda.DataSource = oBD.consultarTabla("Prenda");
        }

        
    }
}
