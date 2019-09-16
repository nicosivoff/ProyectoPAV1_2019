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
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.BusinessLayer;

namespace TrabajoPractico
{
    public partial class frmConsulta : Form
    {
        DBHelper oBD = new DBHelper();
        Prenda pr = new Prenda();
        private readonly PrendaService prendaService;

        public frmConsulta()
        {
            InitializeComponent();
            InitializeDataGridView();
            prendaService = new PrendaService();

        }

        private void llenarCombo(ComboBox cbo, Object source, String display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void frmConsulta_Load(object sender, EventArgs e)
        {
            btnDetalle.Enabled = false;
            llenarCombo(cboTipoPrenda, oBD.consultarTabla("TipoPrenda"), "descripcion", "codTipoPrenda");
            llenarCombo(cboMarca, oBD.consultarTabla("Marca"), "Nombre", "idMarca");
            this.grdPrenda.Rows.Clear();
        }


        private void cargarGrilla(DataGridView grilla, DataTable tabla)
        {
            grilla.Rows.Clear();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                grilla.Rows.Add(tabla.Rows[i]["codPrenda"],
                                tabla.Rows[i]["descripcion"],
                                tabla.Rows[i]["talle"],
                                tabla.Rows[i]["descripcion"],
                                tabla.Rows[i]["precio"],
                                tabla.Rows[i]["cantidad"],
                                tabla.Rows[i]["nombre"]);
            }
        }

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            String strSql = "";

            if (cboTipoPrenda.SelectedIndex != -1)
            {
                strSql += " AND p.tipoPrenda=" + cboTipoPrenda.SelectedValue.ToString();
            }
            if (cboMarca.SelectedIndex != -1)
            {
                strSql += " AND p.marca=" + cboMarca.SelectedValue.ToString();
            }

            IList<Prenda> listadoPrendas = prendaService.ConsultarPrendasConFiltros(strSql);
            grdPrenda.DataSource = listadoPrendas;
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (grdPrenda.CurrentRow != null)
            {
    
            }
        }

        private void grdPrenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            btnDetalle.Enabled = true;
        }

        private void grdPrenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InitializeDataGridView()
        {
            // Cree un DataGridView no vinculado declarando un recuento de columnas.
            grdPrenda.ColumnCount = 10;
            grdPrenda.ColumnHeadersVisible = true;

            // Configuramos la AutoGenerateColumns en false para que no se autogeneren las columnas
            grdPrenda.AutoGenerateColumns = false;

            // Cambia el estilo de la cabecera de la grilla.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            grdPrenda.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            // Definimos el nombre de la columnas y el DataPropertyName que se asocia a DataSource
            grdPrenda.Columns[0].Name = "ID";
            grdPrenda.Columns[0].DataPropertyName = "codPrenda";
            // Definimos el ancho de la columna.
            grdPrenda.Columns[0].Width = 50;

            grdPrenda.Columns[1].Name = "Tipo";
            grdPrenda.Columns[1].DataPropertyName = "tipoPrenda";

            grdPrenda.Columns[2].Name = "Talle";
            grdPrenda.Columns[2].DataPropertyName = "talle";

            grdPrenda.Columns[3].Name = "Descripcion";
            grdPrenda.Columns[3].DataPropertyName = "descripcion";

            grdPrenda.Columns[4].Name = "Precio";
            grdPrenda.Columns[4].DataPropertyName = "precio";

            grdPrenda.Columns[5].Name = "Cantidad";
            grdPrenda.Columns[5].DataPropertyName = "cantidad";

            grdPrenda.Columns[6].Name = "Marca";
            grdPrenda.Columns[6].DataPropertyName = "marca";


            // Cambia el tamaño de la altura de los encabezados de columna.
            grdPrenda.AutoResizeColumnHeadersHeight();

            // Cambia el tamaño de todas las alturas de fila para ajustar el contenido de todas las celdas que no sean de encabezado.
            grdPrenda.AutoResizeRows(
                DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }
    }
}
