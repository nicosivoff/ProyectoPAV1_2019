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
    public partial class frmPerfil: Form
    {
        private readonly PerfilService oPerfilService;
        DBHelper oBD = new DBHelper();

        public frmPerfil()
        {
            InitializeComponent();
            InitializeDataGridView();
            oPerfilService = new PerfilService();
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
                if (txtNombre.Text != string.Empty)
                {
                    condiciones += "AND nombre=" + "'" + txtNombre.Text + "'";
                }

                if (condiciones != "")
                    grdPerfiles.DataSource = oPerfilService.ObtenerConFiltros(condiciones);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                grdPerfiles.DataSource = oPerfilService.ObtenerTodos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMPerfil formulario = new frmABMPerfil();
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMPerfil formulario = new frmABMPerfil();
            var perfil = (Perfil)grdPerfiles.CurrentRow.DataBoundItem;
            formulario.SeleccionarPerfil(frmABMPerfil.FormMode.update, perfil);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMPerfil formulario = new frmABMPerfil();
            var perfil = (Perfil)grdPerfiles.CurrentRow.DataBoundItem;
            formulario.SeleccionarPerfil(frmABMPerfil.FormMode.delete, perfil);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                txtNombre.Enabled = false;

            }
            else
            {
                txtNombre.Enabled = true;
            }

        }

        private void frmPerfil_Load(object sender, EventArgs e)
        {
            grdPerfiles.DataSource = oPerfilService.ObtenerTodos();
            chkTodos.Checked = true;
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
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            grdPerfiles.ColumnCount = 2;
            grdPerfiles.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            grdPerfiles.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdPerfiles.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            grdPerfiles.Columns[0].Name = "Perfil";
            grdPerfiles.Columns[0].DataPropertyName = "idPerfil";
            // Definimos el ancho de la columna.

            grdPerfiles.Columns[1].Name = "Nombre";
            grdPerfiles.Columns[1].DataPropertyName = "nombre";

            // Cambia el tamaño de la altura de los encabezados de columna.
            grdPerfiles.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            grdPerfiles.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
