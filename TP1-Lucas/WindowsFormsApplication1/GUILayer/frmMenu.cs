using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.Estadisticas;
using TrabajoPractico.GUILayer;
using TrabajoPractico.Reportes;
namespace TrabajoPractico
{
    public partial class frmMenu : Form
    {
        frmConsulta consulta = new frmConsulta();
        frmUsuario usuario = new frmUsuario();
        frmPerfil perfil = new frmPerfil();
        frmMarca marca = new frmMarca();
        frmEmpleados empleado = new frmEmpleados();
        frmCliente cliente = new frmCliente();
        frmProveedor proveedor = new frmProveedor();
        frmTransaccion transaccion = new frmTransaccion();
        frmReportePrendaMarca reporteMarca = new frmReportePrendaMarca();
        frmReportePrendaTipo reporteTipo = new frmReportePrendaTipo();
        //frmEstadisticaVentaTotal estadisticaVenta = new frmEstadisticaVentaTotal();

        public frmMenu()
        {
            InitializeComponent();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta.ShowDialog();
        }

        

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perfil.ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marca.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empleado.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cliente.ShowDialog();
        }

        private void aBMToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            usuario.ShowDialog();
        
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proveedor.ShowDialog();
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transaccion.ShowDialog();
        }

        private void prendasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void marcaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            reporteMarca.ShowDialog();
        }

        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reporteTipo.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteClientes reporte = new frmReporteClientes();
            reporte.ShowDialog();
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReporteEmpleados reporte = new frmReporteEmpleados();
            reporte.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteProveedores reporte = new frmReporteProveedores();
            reporte.ShowDialog();
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportePerfiles reporte = new frmReportePerfiles();
            reporte.ShowDialog();
        }

        private void empleadosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmEstadisticaEmpleados formulario = new frmEstadisticaEmpleados();
            formulario.ShowDialog();
        }

        private void perfilesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEstadisticaPerfiles formulario = new frmEstadisticaPerfiles();
            formulario.ShowDialog();

        }

        private void prendaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReportePrenda formulario = new frmReportePrenda();
            formulario.ShowDialog();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaStock formulario = new frmEstadisticaStock();
            formulario.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEstadisticaClientes formulario = new frmEstadisticaClientes();
            formulario.ShowDialog();
        }

        private void ventasTotalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //estadisticaVenta.ShowDialog();
        }

        private void porMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaPrendaxMarca formulario = new frmEstadisticaPrendaxMarca();
            formulario.ShowDialog();
        }

        private void porTipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticaPrendaxTipo formulario = new frmEstadisticaPrendaxTipo();
            formulario.ShowDialog();
        }

        private void ventasConFiltrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstadisticasVenta formulario = new frmEstadisticasVenta();
            formulario.ShowDialog();
        }
    }
}
