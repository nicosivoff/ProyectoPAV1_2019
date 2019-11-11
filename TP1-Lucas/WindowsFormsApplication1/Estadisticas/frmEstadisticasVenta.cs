using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using TrabajoPractico.BusinessLayer;
using TrabajoPractico.DataAccessLayer;
namespace TrabajoPractico.Estadisticas
{
    public partial class frmEstadisticasVenta : Form
    {
        ClienteService oClienteService;
        public frmEstadisticasVenta()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
        }

        private void frmEstadisticasVenta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsVentaEstadisticas.DsVenta' Puede moverla o quitarla según sea necesario.
            //this.DsVentaTableAdapter.Fill(this.DsVentaEstadisticas.DsVenta);
            // TODO: esta línea de código carga datos en la tabla 'DsVentaEstadisticas.DsVenta' Puede moverla o quitarla según sea necesario.
            //this.DsVentaTableAdapter.Fill(this.DsVentaEstadisticas.DsVenta);
            dtpFechaDesde.Value = DateTime.Parse("01/01/2019 00:00:00");
            dtpFechaHasta.Value = DateTime.Now;
            LlenarCombo(cboCliente,oClienteService.ObtenerTodos() , "apellido", "nroDoc");
            LlenarCombo(cboTipo, DBHelper.GetDBHelper().consultar("SELECT * FROM TipoFactura"), "codTipoFac", "codTipoFac");
            //this.reportViewer1.RefreshReport();
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
            ReportParameter[] parametros = new ReportParameter[6];
            //Establecemos el valor de los parámetros
            parametros[0] = new ReportParameter("fechadesde", dtpFechaDesde.Value.ToShortDateString());
            parametros[1] = new ReportParameter("fechahasta", dtpFechaHasta.Value.ToShortDateString());
            parametros[2] = new ReportParameter("IdCliente", cboCliente.SelectedIndex == -1 ? "0" : cboCliente.SelectedValue.ToString());
            parametros[3] = new ReportParameter("tipoF", cboTipo.SelectedIndex == -1 ? "0" : cboTipo.SelectedValue.ToString());
            parametros[4] = new ReportParameter("min", txtMinimo.Text);
            parametros[5] = new ReportParameter("max", txtMaximo.Text);

            
            if (cboCliente.SelectedIndex > -1 && cboTipo.SelectedIndex > -1 && !string.IsNullOrEmpty(txtMinimo.Text) && !string.IsNullOrEmpty(txtMaximo.Text))
            {
                /*this.DsVentaTableAdapter.ConsultaFechaClienteFacturaSubtotal(
                    this.DsVentaEstadisticas.DsVenta, "01-01-2017", "01-01-2020"
                    , cboCliente.SelectedValue.ToString(),Convert.ToInt32(txtMaximo.Text),Convert.ToInt32(txtMinimo.Text),cboTipo.SelectedValue.ToString());*/
                this.DsVentaTableAdapter.ConsultaFechaClienteFacturaSubtotal(
                    this.DsVentaEstadisticas.DsVenta, "01-01-2017", "01-01-2020"
                    , cboCliente.SelectedValue.ToString(), Convert.ToInt32(txtMinimo.Text), Convert.ToInt32(txtMaximo.Text), cboTipo.SelectedValue.ToString());
            }

            //reportViewer1.LocalReport.SetParameters(parametros);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
