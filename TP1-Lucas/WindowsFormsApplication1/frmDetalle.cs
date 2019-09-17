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
using System.Data;

namespace TrabajoPractico
{
    public partial class frmDetalle : Form
    {
        Datos oBD = new Datos();
        public frmDetalle()
        {
            InitializeComponent();
        }

        public void inicializarDetalle(string iD)
        {
            string strSql = @"SELECT p.codPrenda, t.descripcion, p.talle, p.descripcion, p.precio, p.cantidad, m.nombre"
                            + " FROM Prenda p, TipoPrenda t, Marca m"
                            + " WHERE p.tipoPrenda=t.codTipoPrenda"
                            + " AND p.marca=m.idMarca"
                            + " AND p.codPrenda="+iD.ToString();
            DataTable tabla = oBD.consultar(strSql);
            cargarTxt(tabla);
        }

        private void cargarTxt(DataTable tabla)
        {
            var resultado = tabla.Rows[0];
            txtCodigo.Text = resultado["codTipoPrenda"].ToString();
            txtTipo.Text = resultado["descripcion"].ToString();
            txtTalle.Text = resultado["talle"].ToString();
            txtDescripcion.Text = resultado["descripcion"].ToString();
            txtPrecio.Text = resultado["precio"].ToString();
            txtCantidad.Text = resultado["cantidad"].ToString();
            txtMarca.Text = resultado["nombre"].ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
