﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TrabajoPractico
{
    public partial class frmLogin : Form
    {
        Datos oBD = new Datos();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar Usuario...","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtUsuario.Focus();
                return;
            }
            if (this.txtClave.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar Clave...","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                txtClave.Focus();
                return;
            }

            if (ValidarUsuario(txtUsuario.Text, txtClave.Text))
            {
                MessageBox.Show("Usuario valido", "Validacion...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                txtClave.Text = "";
                txtUsuario.Focus();
                MessageBox.Show("Usuario invalido", "Validacion...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarUsuario(string Usuario, string Password)
        {

            bool usuarioValido = false;

            String consultaSql = string.Concat(" SELECT * ",
                                                   "   FROM Usuario ",
                                                   "  WHERE idUsuario =  '", Usuario, "'");

            DataTable tabla = oBD.consultar(consultaSql);

            if (tabla.Rows.Count >= 1)
            {
                if (tabla.Rows[0]["contraseña"].ToString() == Password)
                {
                    usuarioValido = true;
                }


            }

            return usuarioValido;
        }




    }
}
