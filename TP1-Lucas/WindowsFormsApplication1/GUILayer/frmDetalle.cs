﻿using System;
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


namespace TrabajoPractico
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

        private void frmDetalle_Load(object sender, EventArgs e)
        {
            txtTipo.Text = pr.tipoPrenda.ToString();
            txtCodigo.Text = pr.codPrenda.ToString();
            txtDescripcion.Text = pr.descripcion.ToString();
            txtMarca.Text = pr.marca.ToString();
            txtPrecio.Text = pr.precio.ToString();
            txtTalle.Text = pr.talle.ToString();
            txtCantidad.Text = pr.cantidad.ToString();
        }
    }
}
