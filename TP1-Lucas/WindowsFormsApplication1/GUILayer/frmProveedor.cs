using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.Entities;
using TrabajoPractico.BusinessLayer;

namespace TrabajoPractico.GUILayer
{
    public partial class frmProveedor : Form
    {   
        private readonly ProveedorService oProveedorService;
        public frmProveedor()
        {
            InitializeComponent();
            oProveedorService = new ProveedorService();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";

                if (txtCUIL.Text != string.Empty)
                {
                    condiciones += "AND CUIL=" + txtCUIL.Text;
                }

                grdProveedor.DataSource = oProveedorService.ConsultarProveedores(condiciones);
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            grdProveedor.ColumnCount = 2;
            grdProveedor.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            grdProveedor.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdProveedor.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            grdProveedor.Columns[0].Name = "CUIL";
            grdProveedor.Columns[0].DataPropertyName = "CUIL";
            // Definimos el ancho de la columna.

            grdProveedor.Columns[1].Name = "Razon Social";
            grdProveedor.Columns[1].DataPropertyName = "razonSocial";

            grdProveedor.Columns[2].Name = "Telefono";
            grdProveedor.Columns[2].DataPropertyName = "telefono";

            grdProveedor.Columns[3].Name = "Direccion";
            grdProveedor.Columns[3].DataPropertyName = "direccion";

            // Cambia el tamaño de la altura de los encabezados de columna.
            grdProveedor.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            grdProveedor.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMProveedor formulario = new frmABMProveedor();
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMProveedor formulario = new frmABMProveedor();
            var proveedor = (Proveedor)grdProveedor.CurrentRow.DataBoundItem;
            formulario.SeleccionarProveedor(frmABMProveedor.FormMode.update, proveedor);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMProveedor formulario = new frmABMProveedor();
            var proveedor = (Proveedor)grdProveedor.CurrentRow.DataBoundItem;
            formulario.SeleccionarProveedor(frmABMProveedor.FormMode.delete, proveedor);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            grdProveedor.DataSource = oProveedorService.GetProveedores();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }




    }
