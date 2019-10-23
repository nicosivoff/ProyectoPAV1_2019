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
        DBHelper oBD = new DBHelper();
        private readonly BindingList<VentaDetalle> listaFacturaDetalle;
        private readonly TransaccionService transaccionService;
        private readonly ClienteService clienteService;
        private readonly PrendaService prendaService;
        private readonly EmpleadoService empleadoService;

        public frmTransaccion()
        {
            InitializeComponent();
            grdDetalle.AutoGenerateColumns = false;

            transaccionService = new TransaccionService();
            clienteService = new ClienteService();
            prendaService = new PrendaService();
            empleadoService = new EmpleadoService();


            listaFacturaDetalle = new BindingList<VentaDetalle>();
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
            LlenarCombo(cboCliente, clienteService.ObtenerTodos(), "apellido", "nroDoc");
            LlenarCombo(cboVendedor, empleadoService.ObtenerTodos(), "apellido", "legajo");
            LlenarCombo(cboFormaPago, oBD.consultarTabla("TipoPago"), "nombre", "codTipoPago");
            LlenarCombo(cboPrenda, prendaService.ObtenerTodos(), "descripcion", "codPrenda");
            LlenarCombo(cboTipoFac, oBD.consultarTabla("TipoFactura"), "codTipoFac", "codTipoFac");

            grdDetalle.DataSource = listaFacturaDetalle;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            this.cboPrenda.SelectedIndexChanged += new System.EventHandler(this.cboPrenda_SelectedIndexChanged);


        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            frmABMCliente frmCliente = new frmABMCliente();
            frmCliente.ShowDialog();
            LlenarCombo(cboCliente, oBD.consultarTabla("Cliente"), "apellido", "nroDoc");
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPrenda.SelectedItem != null)
            {
                var cliente = (Cliente)cboCliente.SelectedItem;
              
            }
            if (cboCliente.SelectedIndex == -1) 
            {
                cboPrenda.Enabled = false;
            }
            else
            {
                cboPrenda.Enabled = true;
            }
        }

        private void cboPrenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPrenda.SelectedItem != null)
            {
                var prenda = (Prenda) cboPrenda.SelectedItem;
                txtPrecio.Text = prenda.Precio.ToString("C");
                txtCantidad.Enabled = true;
                int cantidad = 0;
                int.TryParse(txtCantidad.Text, out cantidad);
                btnAgregar.Enabled = true;

            }
            else
            {
                btnAgregar.Enabled = false;
                txtCantidad.Enabled = false;
                txtCantidad.Text = "";
                txtPrecio.Text = "";
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (cboPrenda.SelectedItem != null)
            {
                int cantidad = 0;
                int.TryParse(txtCantidad.Text, out cantidad);
                var prenda = (Prenda)cboPrenda.SelectedItem;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                int cantidad = 0;
                int.TryParse(txtCantidad.Text, out cantidad);

                var prenda = (Prenda)cboPrenda.SelectedItem;

                listaFacturaDetalle.Add(new VentaDetalle()
                {
                    NroItem = listaFacturaDetalle.Count + 1,
                    Prenda = prenda,
                    Cantidad = cantidad,
                    PrecioUnitario = prenda.Precio
                });
                CalcularTotales();
                InicializarDetalle();
            }
            else
            {
                MessageBox.Show("Debe ingresar la cantidad", "Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void CalcularTotales()
        {
            var subtotal = listaFacturaDetalle.Sum(p => p.Importe);
            txtTotal.Text = subtotal.ToString();
        }

        private void InicializarFormulario()
        {
            btnAgregar.Enabled = false;
            cboCliente.SelectedIndex = -1;
            txtTotal.Clear();
            InicializarDetalle();

            grdDetalle.DataSource = null;
            
            
        }

        private void InicializarDetalle()
        {
            cboPrenda.SelectedItem = -1;
            txtCantidad.Text = "";
            txtPrecio.Text = 0.ToString("N2");

        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (grdDetalle.CurrentRow != null)
            {
                var detalleSeleccionado = (VentaDetalle)grdDetalle.CurrentRow.DataBoundItem;
                listaFacturaDetalle.Remove(detalleSeleccionado);
                CalcularTotales();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            InicializarDetalle();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                var venta = new Venta
                {
                    Fecha = dtpFecha.Value,
                    Cliente = (Cliente)cboCliente.SelectedItem,
                    TipoFactura = cboTipoFac.SelectedValue.ToString(),
                    VentaDetalle = listaFacturaDetalle,
                    SubTotal = double.Parse(txtTotal.Text),
                };

                if (transaccionService.ValidarDatos(venta))
                {
                    transaccionService.Crear(venta);

                    MessageBox.Show(string.Concat("La factura nro: ", venta.IdVenta, " se generó correctamente."), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    InicializarFormulario();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la factura! " + ex.Message + ex.StackTrace, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImporte_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

