using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.Clases;

namespace TrabajoPractico
{
    public partial class frmConsulta : Form
    {
        Datos oBD = new Datos();
        Prenda pr = new Prenda();

        public frmConsulta()
        {
            InitializeComponent();

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
            cargarGrilla(grdPrenda,pr.recuperarPrenda());
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
            string strSql = "SELECT p.codPrenda, t.descripcion, p.talle, p.descripcion, p.precio, p.cantidad, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca";


            if (cboTipoPrenda.SelectedIndex != -1)
            {
                strSql += " AND p.tipoPrenda=" + cboTipoPrenda.SelectedValue;
            }
            if (cboMarca.SelectedIndex != -1)
            {
                strSql += " AND p.marca=" + cboMarca.SelectedValue;
            }

            cargarGrilla(grdPrenda, oBD.consultar(strSql));
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (grdPrenda.CurrentRow != null)
            {
                frmDetalle detalle = new frmDetalle();
                var seleccionado = (DataRowView)grdPrenda.CurrentRow.DataBoundItem;
                detalle.inicializarDetalle(seleccionado["codPrenda"].ToString());
                detalle.ShowDialog();
            }
        }

        private void grdPrenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDetalle.Enabled = true;
        }

        public DataGridViewRow x { get; set; }
    }
}
