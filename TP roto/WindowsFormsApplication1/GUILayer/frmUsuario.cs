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
            grdUsuarios.Columns[2].DataPropertyName = "nombre";

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
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            /*String strSql = "";

            if (txtNombre.Text == "")
            {
                strSql += " AND u.idUsuario = " + txtNombre.Text;
            }
            if (cboPerfil.SelectedIndex != -1)
            {
                strSql += " AND u.perfil = " + cboPerfil.SelectedValue.ToString();
            }
            
            IList<Usuario> listadoUsuarios = oUsuarioService.ConsultarUsuarios(strSql);
            grdUsuarios.DataSource = listadoUsuarios;*/
            String condiciones="";
            var filters = new Dictionary<string, object>();

            if (!chkTodos.Checked)
            {
                // Validar si el combo 'Perfiles' esta seleccionado.
                if (cboPerfil.Text != string.Empty)
                {
                    // Si el cbo tiene un texto no vacìo entonces recuperamos el valor de la propiedad ValueMember
                    filters.Add("idPerfil", cboPerfil.SelectedValue);
                    condiciones += " AND u.idperfil=" + cboPerfil.SelectedValue.ToString();
                    
                }

                // Validar si el textBox 'Nombre' esta vacio.
                if (txtNombre.Text != string.Empty)
                {
                    // Si el textBox tiene un texto no vacìo entonces recuperamos el valor del texto
                    filters.Add("usuario", txtNombre.Text);
                    condiciones += "AND u.usuario=" + "'" + txtNombre.Text+"'";
                }

                if (filters.Count > 0)
                    //SIN PARAMETROS
                    grdUsuarios.DataSource = oUsuarioService.ConsultarConFiltrosSinParametros(condiciones);

                    //CON PARAMETROS
                    //dgvUsers.DataSource = oUsuarioService.ConsultarConFiltrosConParametros(filters);

                else
                    MessageBox.Show("Debe ingresar al menos un criterio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                grdUsuarios.DataSource = oUsuarioService.ObtenerTodos();
        }

        private void grdUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }
        }
    }
}
