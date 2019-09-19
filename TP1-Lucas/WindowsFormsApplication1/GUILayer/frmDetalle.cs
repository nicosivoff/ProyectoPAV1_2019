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
    public partial class frmDetalle : Form
    {
        private PrendaService prendaService;
        public frmDetalle()
        {
            InitializeComponent();
            prendaService = new PrendaService();
        }

        public void inicializarDetalle(string iD)
        {
            var resultado = prendaService.ConsultarPrendaPorId(iD);
            if (resultado != null)
            {
                txtCodigo.Text = resultado.CodPrenda.ToString();
                txtTipo.Text = resultado.TipoPrenda.ToString();
                txtTalle.Text = resultado.Talle.ToString();
                txtDescripcion.Text = resultado.Descripcion.ToString();
                txtPrecio.Text = resultado.Precio.ToString();
                txtCantidad.Text = resultado.Cantidad.ToString();
                txtMarca.Text = resultado.Marca.ToString();
            }
        }

       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTalle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
/*namespace TrabajoPractico
{
    public partial class frmDetalle : Form
    {
        DBHelper oBD = new DBHelper();
        Prenda pr = new Prenda();
        public frmDetalle()
        {
            InitializeComponent();
        }

        public void inicializarDetalle(string iD)
        {
            string strSql = "SELECT p.codPrenda, t.descripcion, p.talle, p.descripcion, p.precio, p.cantidad, m.nombre"
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
            txtCodigo.Text = resultado["codPrenda"].ToString();
            txtTipo.Text = resultado["descripcion"].ToString();
            txtTalle.Text = resultado["talle"].ToString();
            txtDescripcion.Text = resultado["descripcion1"].ToString();
            txtPrecio.Text = resultado["precio"].ToString();
            txtCantidad.Text = resultado["cantidad"].ToString();
            txtMarca.Text = resultado["nombre"].ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            txtTipo.Text = pr.TipoPrenda.ToString();
            txtCodigo.Text = pr.CodPrenda.ToString();
            txtDescripcion.Text = pr.Descripcion.ToString();
            txtMarca.Text = pr.Marca.ToString();
            txtPrecio.Text = pr.Precio.ToString();
            txtTalle.Text = pr.Talle.ToString();
            txtCantidad.Text = pr.Cantidad.ToString();
        }
    }
}
*/
