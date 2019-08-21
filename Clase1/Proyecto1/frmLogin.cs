using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class frmLogin : Form
    {
        string usu = "admin";
        string clv = "1234";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUsuario.Text))
            {   MessageBox.Show("Debe ingresar un usuario");
                txtUsuario.Focus();
                return;
            }

            if (this.txtClave.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar una clave");
                txtClave.Focus();
                return;
            }

            if (this.txtUsuario.Text == this.usu && this.txtClave.Text == this.clv)
                MessageBox.Show("Usuario valido");
            else
                MessageBox.Show("Usuario Invalido");

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
