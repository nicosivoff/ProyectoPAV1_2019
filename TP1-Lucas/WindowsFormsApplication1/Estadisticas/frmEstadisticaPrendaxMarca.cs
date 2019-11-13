using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.DataAccessLayer;

namespace TrabajoPractico.Estadisticas
{
    public partial class frmEstadisticaPrendaxMarca : Form
    {
        public frmEstadisticaPrendaxMarca()
        {
            InitializeComponent();
        }

        private void frmEstadisticaPrendaxMarca_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'dsPrendaxMarca.DsPrendaxMarca' table. You can move, or remove it, as needed.
            LlenarCombo(cboMarca, DBHelper.GetDBHelper().consultar("SELECT * FROM Marca"), "nombre", "idMarca");

            //this.reportViewer1.RefreshReport();
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = source;
            cbo.SelectedIndex = -1;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cboMarca.SelectedIndex > -1 && !string.IsNullOrEmpty(txtPrecioDesde.Text) && !string.IsNullOrEmpty(txtPrecioHasta.Text))
            {
                this.DsPrendaxMarcaTableAdapter.ConsultaMarcaPrecios(this.dsPrendaxMarca._DsPrendaxMarca, Convert.ToInt32(cboMarca.SelectedValue),
                    Convert.ToInt32(txtPrecioDesde.Text), Convert.ToInt32(txtPrecioHasta.Text));
            }
            else 
            {
                if (cboMarca.SelectedIndex > -1 && (string.IsNullOrEmpty(txtPrecioDesde.Text) || (string.IsNullOrEmpty(txtPrecioHasta.Text))))
                {
                    this.DsPrendaxMarcaTableAdapter.ConsultaPorMarca(this.dsPrendaxMarca._DsPrendaxMarca, Convert.ToInt32(cboMarca.SelectedValue));
                }
                else 
                {
                    if (cboMarca.SelectedIndex == -1 && !string.IsNullOrEmpty(txtPrecioDesde.Text) && !string.IsNullOrEmpty(txtPrecioHasta.Text))
                    {
                        txtPrecioDesde.Text = "";
                        txtPrecioHasta.Text = "";
                        this.DsPrendaxMarcaTableAdapter.ConsultaPorPrecio(this.dsPrendaxMarca._DsPrendaxMarca, Convert.ToInt32(txtPrecioDesde.Text), Convert.ToInt32(txtPrecioHasta.Text));
                    }
                    else
                    {
                        this.DsPrendaxMarcaTableAdapter.ConsultaSinParametros(this.dsPrendaxMarca._DsPrendaxMarca);
                    }
                }
            }

            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cboMarca.SelectedIndex = -1;
            txtPrecioDesde.Text = "";
            txtPrecioHasta.Text = "";
        }

        
    }
}
