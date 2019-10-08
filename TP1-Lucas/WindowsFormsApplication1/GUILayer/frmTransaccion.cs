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
using TrabajoPractico.BusinessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.GUILayer
{
    public partial class frmTransaccion : Form
    {
        FacturaService facturaService = new FacturaService();
        private readonly BindingList<DetalleFactura> listaDetalle;
        DBHelper oBD = new DBHelper();
        PrendaService oPrenda = new PrendaService();
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
            LlenarCombo(cboPrenda, oBD.consultarTabla("Prenda"), "codPrenda", "codPrenda");
            LlenarCombo(cboTipoFactura, oBD.consultarTabla("TipoFactura"), "codTipoFactura", "codTipoFactura");
            txtTipoPrenda.Enabled = false;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            listaDetalle.Add(new DetalleFactura()
            {
                codPrenda = (int)cboPrenda.SelectedValue,
                cantidad = txtCantidad.Text,
            });

            //cargar grillaaa
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var factura = new Factura
            {   
                idUsuario = cboVendedor.SelectedValue.ToString(),
                tipoFactura = (TipoFactura)cboTipoFactura.SelectedItem,
                FacturaDetalle = listaDetalle,
                tipoPago = (TipoPago)cboFormaPago.SelectedItem,
                fecha = dtpFecha.Value,
            };

            if (facturaService.ValidarDatos(factura))
            {
                facturaService.Crear(factura);

                MessageBox.Show(string.Concat("La factura nro: ", factura.codFactura, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

       

       

        /*private void cboPrenda_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (cboPrenda.SelectedValue != null)
            {
                string id = cboPrenda.SelectedValue.ToString();
                var prenda = oPrenda.ConsultarPrendaPorId(id);
                txtTipoPrenda.Text = prenda.TipoPrenda.Nombre;
            }


        }*/
    }
}

