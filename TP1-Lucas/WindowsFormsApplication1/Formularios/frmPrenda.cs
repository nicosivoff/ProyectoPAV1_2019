﻿using System;
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
    public partial class frmPrenda : Form
    {
        frmLogin fl = new frmLogin();
        Datos oBD = new Datos();
        Prenda prenda = new Prenda();
        bool nuevo = false;

        public frmPrenda()
        {
            InitializeComponent();
        }

        private void frmCargar_Load(object sender, EventArgs e)
        {
            fl.ShowDialog();
            llenarCombo(cboTipoPrenda, oBD.consultarTabla("TipoPrenda"), "descripcion","codTipoPrenda");
            this.grdPrenda.Rows.Clear();
            this.grdPrenda.DataSource = oBD.consultarTabla("Prenda");
            this.habilitar(false);
        }


        private void llenarCombo(ComboBox cbo, Object source, String display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.limpiar();
            this.habilitar(true);
            this.txtCodigo.Focus();
            this.nuevo = true;
            
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.habilitar(true);
            this.txtCodigo.Focus();
            this.nuevo = false;
        }
        private void habilitar(bool x)
        {
            txtCodigo.Enabled = x;
            txtTalle.Enabled = x;
            txtDescripcion.Enabled = x;
            txtPrecio.Enabled = x;
            txtCantidad.Enabled = x;
            cboTipoPrenda.Enabled = x;
            btnGrabar.Enabled = x;
            btnCancelar.Enabled = x;
            btnAgregar.Enabled = !x;
            btnEditar.Enabled = !x;
            btnBorrar.Enabled = !x;
      
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            prenda.Codigo = txtCodigo.Text;
            prenda.Tipo = Convert.ToInt32(cboTipoPrenda.SelectedValue);
            prenda.Talle = txtTalle.Text;
            prenda.Descripcion = txtDescripcion.Text;
            prenda.Precio = txtPrecio.Text;
            prenda.Cantidad = txtCantidad.Text;

            if (prenda.validarDatosPrenda())
            {
                if (this.nuevo)
                {
                    prenda.grabarPrenda();
                    MessageBox.Show("La prenda se grabo con exito!");
                }


                else
                {
                    prenda.actualizarPrenda();
                    MessageBox.Show("La prenda se actualizo con exito!");
                }

                this.grdPrenda.DataSource = oBD.consultarTabla("Prenda");
            }
            this.nuevo = false;
            this.habilitar(false);
        }

        private void limpiar()
        {
            txtCodigo.Clear();
            txtTalle.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            cboTipoPrenda.SelectedIndex = -1;
            txtCantidad.Clear();
        }


        
    }
}