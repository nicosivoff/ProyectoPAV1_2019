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

namespace TrabajoPractico.GUILayer
{
    public partial class frmMarca : Form
    {
        DBHelper oBD = new DBHelper();
        MarcaService oMarcaService = new MarcaService();
        public frmMarca()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboNombre, oBD.consultarTabla("Marca"), "nombre", "nombre");
            chkTodos.Checked = true;
            btnConsultar_Click(sender, e);
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }
        private void InitializeDataGridView()
        {
            grdMarcas.ColumnCount = 2;
            grdMarcas.ColumnHeadersVisible = true;

            grdMarcas.AutoGenerateColumns = false;

            DataGridViewCellStyle style = new DataGridViewCellStyle();

            style.BackColor = Color.Beige;
            style.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdMarcas.ColumnHeadersDefaultCellStyle = style;

            grdMarcas.Columns[0].Name = "Id";
            grdMarcas.Columns[0].DataPropertyName = "idMarca";

            grdMarcas.Columns[1].Name = "Marca";
            grdMarcas.Columns[1].DataPropertyName = "nombre";

            grdMarcas.AutoResizeColumnHeadersHeight();

            grdMarcas.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if(chkTodos.Checked)
            {
                txtId.Enabled = false;
                cboNombre.Enabled = false;
            }
            else
            {
                txtId.Enabled = true;
                cboNombre.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";
            if (!chkTodos.Checked)
            {
                if (cboNombre.Text != string.Empty)
                {
                    condiciones += " AND nombre= '" + cboNombre.SelectedValue.ToString() + "'";
                }

                if (txtId.Text != string.Empty)
                {
                    condiciones += " AND idMarca=" + txtId.Text;
                }
                if (condiciones != "")
                    grdMarcas.DataSource = oMarcaService.obtenerConFiltros(condiciones);
                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                grdMarcas.DataSource = oMarcaService.obtenerTodos();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMMarca formulario = new frmABMMarca();
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMMarca formulario = new frmABMMarca();
            var marca = (Marca)grdMarcas.CurrentRow.DataBoundItem;
            formulario.seleccionarMarca(frmABMMarca.FormMode.update, marca);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMMarca formulario = new frmABMMarca();
            var marca = (Marca)grdMarcas.CurrentRow.DataBoundItem;
            formulario.seleccionarMarca(frmABMMarca.FormMode.delete, marca);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }



    }
}
