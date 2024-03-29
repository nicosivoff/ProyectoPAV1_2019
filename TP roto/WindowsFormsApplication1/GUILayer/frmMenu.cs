﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.GUILayer;

namespace TrabajoPractico
{
    public partial class frmMenu : Form
    {
        frmConsulta consulta = new frmConsulta();
        frmUsuario usuario = new frmUsuario();
        frmPerfil perfil = new frmPerfil();
        frmMarca marca = new frmMarca();
        frmEmpleados empleado = new frmEmpleados();
        frmCliente cliente = new frmCliente();
        frmProveedor proveedor = new frmProveedor();

        public frmMenu()
        {
            InitializeComponent();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consulta.ShowDialog();
        }

        

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            perfil.ShowDialog();
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marca.ShowDialog();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            empleado.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cliente.ShowDialog();
        }

        private void aBMToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            usuario.ShowDialog();
        
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proveedor.ShowDialog();
        }
    }
}
