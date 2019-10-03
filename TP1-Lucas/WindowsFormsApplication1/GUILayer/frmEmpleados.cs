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
using TrabajoPractico.BusinessLayer;
using TrabajoPractico.GUILayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.GUILayer
{
    public partial class frmEmpleados : Form
    {
        private readonly EmpleadoService oEmpleadoService;
        DBHelper oBD = new DBHelper();


        public frmEmpleados()
        {
            InitializeComponent();
            chkTodos.Checked = true;
            InitializeDataGridView();
            oEmpleadoService = new EmpleadoService();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";

            if (!chkTodos.Checked)
            {
                // Validar si el combo 'Perfiles' esta seleccionado.
                /*if (cboPerfil.Text != string.Empty)
                {
                    condiciones += " AND u.perfil=" + cboPerfil.SelectedValue.ToString();

                }**/

                // Validar si el textBox 'Nombre' esta vacio.
                if (txtLegajoEmpleado.Text != string.Empty)
                {
                    condiciones += "AND legajo=" + "'" + txtLegajoEmpleado.Text + "'";
                }
                if (txtNombreEmpleado.Text != string.Empty)
                {
                    condiciones += "AND nombre=" + "'" + txtNombreEmpleado.Text + "'";
                }
                if (txtApellidoEmpleado.Text != string.Empty)
                {
                    condiciones += "AND apellido=" + "'" + txtApellidoEmpleado.Text + "'";
                }

                if (condiciones != "")
                    grdEmpleados.DataSource = oEmpleadoService.ObtenerConFiltros(condiciones);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                grdEmpleados.DataSource = oEmpleadoService.ObtenerTodos();
        }


        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            grdEmpleados.DataSource = oEmpleadoService.ObtenerTodos();
            
        }
        

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            grdEmpleados.ColumnCount = 3;
            grdEmpleados.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            grdEmpleados.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdEmpleados.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            grdEmpleados.Columns[0].Name = "Legajo";
            grdEmpleados.Columns[0].DataPropertyName = "legajo";
            // Definimos el ancho de la columna.

            grdEmpleados.Columns[1].Name = "Nombre";
            grdEmpleados.Columns[1].DataPropertyName = "nombre";

            grdEmpleados.Columns[2].Name = "Apellido";
            grdEmpleados.Columns[2].DataPropertyName = "apellido";

            // Cambia el tamaño de la altura de los encabezados de columna.
            grdEmpleados.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            grdEmpleados.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void chkTodos_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                txtLegajoEmpleado.Enabled = false;
                txtNombreEmpleado.Enabled = false;
                txtApellidoEmpleado.Enabled = false;

            }
            else
            {
                txtLegajoEmpleado.Enabled = true;
                txtNombreEmpleado.Enabled = true;
                txtApellidoEmpleado.Enabled = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMEmpleado formulario = new frmABMEmpleado();
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMEmpleado formulario = new frmABMEmpleado();
            var perfil = (Empleado)grdEmpleados.CurrentRow.DataBoundItem;
            formulario.SeleccionarEmpleado(frmABMEmpleado.FormMode.delete, perfil);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMEmpleado formulario = new frmABMEmpleado();
            var empleado = (Empleado)grdEmpleados.CurrentRow.DataBoundItem;
            formulario.SeleccionarEmpleado(frmABMEmpleado.FormMode.update, empleado);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

