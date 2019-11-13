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
    public partial class frmEstadisticaPrendaxTipo : Form
    {
        public frmEstadisticaPrendaxTipo()
        {
            InitializeComponent();
        }
        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = source;
            cbo.SelectedIndex = -1;
        }

        private void frmEstadisticaPrendaxTipo_Load(object sender, EventArgs e)
        {
            
            // TODO: esta línea de código carga datos en la tabla 'DsPrendaxTipo.DsPrendaxTipo' Puede moverla o quitarla según sea necesario.
            LlenarCombo(cboTipoPrenda, DBHelper.GetDBHelper().consultar("SELECT * FROM TipoPrenda"), "descrip", "codTipoPrenda");
            //this.reportViewer1.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cboTipoPrenda.SelectedIndex > -1 && !string.IsNullOrEmpty(txtPrecioDesde.Text) && !string.IsNullOrEmpty(txtPrecioHasta.Text))
            {
                this.DsPrendaxTipoTableAdapter.ConsultarPorTipoPrecio(this.DsPrendaxTipo._DsPrendaxTipo, Convert.ToInt32(cboTipoPrenda.SelectedValue),
                    Convert.ToInt32(txtPrecioDesde.Text), Convert.ToInt32(txtPrecioHasta.Text));
            }
            else 
            {
                if (cboTipoPrenda.SelectedIndex > -1 && (string.IsNullOrEmpty(txtPrecioDesde.Text) || (string.IsNullOrEmpty(txtPrecioHasta.Text))))
                {
                    this.DsPrendaxTipoTableAdapter.ConsultarPorTipo(this.DsPrendaxTipo._DsPrendaxTipo, Convert.ToInt32(cboTipoPrenda.SelectedValue));
                }
                else 
                {
                    if (cboTipoPrenda.SelectedIndex == -1 && !string.IsNullOrEmpty(txtPrecioDesde.Text) && !string.IsNullOrEmpty(txtPrecioHasta.Text))
                    {
                        txtPrecioDesde.Text = "";
                        txtPrecioHasta.Text = "";
                        this.DsPrendaxTipoTableAdapter.ConsultarPorPrecio(this.DsPrendaxTipo._DsPrendaxTipo, Convert.ToInt32(txtPrecioDesde.Text), Convert.ToInt32(txtPrecioHasta.Text));
                    }
                    else
                    {
                        this.DsPrendaxTipoTableAdapter.ConsultarSinParametro(this.DsPrendaxTipo._DsPrendaxTipo);
                    }
                }
            }
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
