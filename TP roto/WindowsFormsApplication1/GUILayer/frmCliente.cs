using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.BusinessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.GUILayer
{
    public partial class frmCliente : Form
    {
        private readonly ClienteService oClienteService;

        public frmCliente()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
        }
        


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCliente.Checked)
            {
                txtDoc.Enabled = false;
                txtApellido.Enabled = false;

            }
            else
            {
                txtDoc.Enabled = true;
                txtApellido.Enabled = true;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";

            if (!chkCliente.Checked)
            {
                if (txtDoc.Text != string.Empty)
                {
                    condiciones += "AND nroDoc=" + "'" + (txtDoc.Text).ToString() + "'";
                }

                if (txtApellido.Text != string.Empty)
                {
                    condiciones += "AND apellido=" + "'" + txtApellido.Text + "'";
                }

                if (condiciones != "")
                    grdClientes.DataSource = oClienteService.ConsultarClientes(condiciones);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                grdClientes.DataSource = oClienteService.ConsultarClientes(condiciones);
        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            grdClientes.ColumnCount = 2;
            grdClientes.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            grdClientes.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdClientes.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            grdClientes.Columns[0].Name = "Nro de Doc";
            grdClientes.Columns[0].DataPropertyName = "nroDoc";
            // Definimos el ancho de la columna.

            grdClientes.Columns[1].Name = "Nombre";
            grdClientes.Columns[1].DataPropertyName = "nombre";

            grdClientes.Columns[2].Name = "Apellido";
            grdClientes.Columns[2].DataPropertyName = "apellido";

            grdClientes.Columns[3].Name = "Telefono";
            grdClientes.Columns[3].DataPropertyName = "telefono";

            grdClientes.Columns[4].Name = "Email";
            grdClientes.Columns[4].DataPropertyName = "email";

            // Cambia el tamaño de la altura de los encabezados de columna.
            grdClientes.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            grdClientes.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMCliente frmcliente = new frmABMCliente();
            frmcliente.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMCliente formulario = new frmABMCliente();
            var cliente = (Cliente)grdClientes.CurrentRow.DataBoundItem;
            formulario.SeleccionarCliente(frmABMCliente.FormMode.update, cliente);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMCliente formulario = new frmABMCliente();
            var cliente = (Cliente)grdClientes.CurrentRow.DataBoundItem;
            formulario.SeleccionarCliente(frmABMCliente.FormMode.delete, cliente);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            grdClientes.DataSource = oClienteService.GetClientes();
            chkCliente.Checked = true;
        }


    }
}
