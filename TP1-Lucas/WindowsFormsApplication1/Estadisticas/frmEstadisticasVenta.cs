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
            
            if (cboCliente.SelectedIndex > -1 && cboTipo.SelectedIndex > -1 && !string.IsNullOrEmpty(txtMinimo.Text) && !string.IsNullOrEmpty(txtMaximo.Text))
            {
                this.DsVentaTableAdapter.ConsultaFechaClienteSubtotalFactura(
                    this.DsVentaEstadisticas.DsVenta, dtpFechaDesde.Value.ToShortDateString(), dtpFechaHasta.Value.ToShortDateString()
                    , Convert.ToInt32(cboCliente.SelectedValue), Convert.ToInt32(txtMinimo.Text), Convert.ToInt32(txtMaximo.Text), cboTipo.SelectedValue.ToString());
            }
            else
            {
                if (cboCliente.SelectedIndex > -1 && !string.IsNullOrEmpty(txtMinimo.Text) && !string.IsNullOrEmpty(txtMaximo.Text) && cboTipo.SelectedIndex == -1)
                {
                    this.DsVentaTableAdapter.ConsultaFechaClienteSubtotal(
                    this.DsVentaEstadisticas.DsVenta, dtpFechaDesde.Value.ToShortDateString(), dtpFechaHasta.Value.ToShortDateString()
                    , Convert.ToInt32(cboCliente.SelectedValue), Convert.ToInt32(txtMinimo.Text), Convert.ToInt32(txtMaximo.Text));
                }
                else
                {
                     if (cboCliente.SelectedIndex > -1 && cboTipo.SelectedIndex > -1 && string.IsNullOrEmpty(txtMinimo.Text) && string.IsNullOrEmpty(txtMaximo.Text))
                     {
                         this.DsVentaTableAdapter.ConsultaFechaClienteFactura(
                         this.DsVentaEstadisticas.DsVenta, dtpFechaDesde.Value.ToShortDateString(), dtpFechaHasta.Value.ToShortDateString()
                         , Convert.ToInt32(cboCliente.SelectedValue), cboTipo.SelectedValue.ToString());
                     }
                     else
                     {
                         if (cboTipo.SelectedIndex > -1 && !string.IsNullOrEmpty(txtMinimo.Text) && !string.IsNullOrEmpty(txtMaximo.Text) && cboCliente.SelectedIndex == -1)
                         {
                             this.DsVentaTableAdapter.ConsultaFechaSubtotalFactura(
                             this.DsVentaEstadisticas.DsVenta, dtpFechaDesde.Value.ToShortDateString(), dtpFechaHasta.Value.ToShortDateString()
                             , Convert.ToInt32(txtMinimo.Text), Convert.ToInt32(txtMaximo.Text), cboTipo.SelectedValue.ToString());
                         }
                         else
                         {
                             if (cboCliente.SelectedIndex > -1)
                             {
                                 this.DsVentaTableAdapter.ConsultaFechaCliente(
                                 this.DsVentaEstadisticas.DsVenta, dtpFechaDesde.Value.ToShortDateString(), dtpFechaHasta.Value.ToShortDateString()
                                 , Convert.ToInt32(cboCliente.SelectedValue));
                             }
                             else
                             {
                                 if (!string.IsNullOrEmpty(txtMinimo.Text) && !string.IsNullOrEmpty(txtMaximo.Text))
                                 {
                                     this.DsVentaTableAdapter.ConsultaFechaSubtotal(
                                     this.DsVentaEstadisticas.DsVenta, dtpFechaDesde.Value.ToShortDateString(), dtpFechaHasta.Value.ToShortDateString()
                                     , Convert.ToInt32(txtMinimo.Text), Convert.ToInt32(txtMaximo.Text));
                                 }
                                 else
                                 {
                                     if (cboTipo.SelectedIndex > -1)
                                     {
                                         this.DsVentaTableAdapter.ConsultaFechaFactura(
                                         this.DsVentaEstadisticas.DsVenta, dtpFechaDesde.Value.ToShortDateString(), dtpFechaHasta.Value.ToShortDateString()
                                         , cboTipo.SelectedValue.ToString());
                                     }
                                     else
                                     {
                                         this.DsVentaTableAdapter.ConsultaFecha(
                                         this.DsVentaEstadisticas.DsVenta, dtpFechaDesde.Value.ToShortDateString(), dtpFechaHasta.Value.ToShortDateString());
                                     }
                                 }
                             }
                         }
                     }
                }
            }


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
