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
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico
{
    public partial class frmUsuario : Form
    {
        private readonly UsuarioService oUsuarioService;
        DBHelper oBD = new DBHelper();

        public frmUsuario()
        {
            InitializeComponent();
            InitializeDataGridView();
            oUsuarioService = new UsuarioService();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboPerfil, oBD.consultarTabla("Perfil"), "nombre", "idPerfil");
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
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            grdUsuarios.ColumnCount = 3;
            grdUsuarios.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            grdUsuarios.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdUsuarios.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            grdUsuarios.Columns[0].Name = "Usuario";
            grdUsuarios.Columns[0].DataPropertyName = "idUsuario";
            // Definimos el ancho de la columna.

            grdUsuarios.Columns[1].Name = "Email";
            grdUsuarios.Columns[1].DataPropertyName = "email";

            grdUsuarios.Columns[2].Name = "Perfil";
            grdUsuarios.Columns[2].DataPropertyName = "perfil";

            // Cambia el tamaño de la altura de los encabezados de columna.
            grdUsuarios.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            grdUsuarios.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmABMUsuarios formulario = new frmABMUsuarios();
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            String condiciones = "";

            if (!chkTodos.Checked)
            {
                // Validar si el combo 'Perfiles' esta seleccionado.
                if (cboPerfil.Text != string.Empty)
                {
                    condiciones += " AND u.perfil=" + cboPerfil.SelectedValue.ToString();

                }

                // Validar si el textBox 'Nombre' esta vacio.
                if (txtNombre.Text != string.Empty)
                {
                    condiciones += "AND u.idUsuario=" + "'" + txtNombre.Text + "'";
                }

                if (condiciones != "")
                        grdUsuarios.DataSource = oUsuarioService.ObtenerConFiltros(condiciones);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                grdUsuarios.DataSource = oUsuarioService.ObtenerTodos();
        }

        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmABMUsuarios formulario = new frmABMUsuarios();
            var usuario = (Usuario)grdUsuarios.CurrentRow.DataBoundItem;
            formulario.SeleccionarUsuario(frmABMUsuarios.FormMode.update, usuario);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmABMUsuarios formulario = new frmABMUsuarios();
            var usuario = (Usuario)grdUsuarios.CurrentRow.DataBoundItem;
            formulario.SeleccionarUsuario(frmABMUsuarios.FormMode.delete, usuario);
            formulario.ShowDialog();
            btnConsultar_Click(sender, e);
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                txtNombre.Enabled = false;
                cboPerfil.Enabled = false;
            }
            else
            {
                txtNombre.Enabled = true;
                cboPerfil.Enabled = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
