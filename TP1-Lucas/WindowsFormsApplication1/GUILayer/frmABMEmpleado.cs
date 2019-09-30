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
using TrabajoPractico.GUILayer;

namespace TrabajoPractico
{
    public partial class frmABMEmpleado : Form
    {
        private FormMode formMode = FormMode.insert;
        DBHelper oBD = new DBHelper();
        private readonly EmpleadoService oEmpleadoService;
        private Empleado oEmpleadoSelected;
        frmEmpleados frmEmpleado = new frmEmpleados();

        public frmABMEmpleado()
        {
            InitializeComponent();
            oEmpleadoService = new EmpleadoService();
        }
        public enum FormMode
        {
            insert,
            update,
            delete
        }


        private void frmABMEmpleado_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Empleado";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Empleado";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtLegajoEmpleado.Enabled = false;
                        txtNombreEmpleado.Enabled = true;
                        txtApellidoEmpleado.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Empleado";
                        txtLegajoEmpleado.Enabled = false;
                        txtNombreEmpleado.Enabled = false;
                        txtApellidoEmpleado.Enabled = false;
                        break;
                    }
            }
        }



        private void MostrarDatos()
        {
            if (oEmpleadoSelected != null)
            {
                txtLegajoEmpleado.Text = oEmpleadoSelected.Legajo.ToString();
                txtNombreEmpleado.Text = oEmpleadoSelected.Nombre;
                txtApellidoEmpleado.Text = oEmpleadoSelected.Apellido;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtLegajoEmpleado.Text == string.Empty)
            {
                txtLegajoEmpleado.BackColor = Color.Red;
                txtLegajoEmpleado.Focus();
                return false;
            }
            else
                txtLegajoEmpleado.BackColor = Color.White;
            if (txtNombreEmpleado.Text == string.Empty)
            {
                txtNombreEmpleado.BackColor = Color.Red;
                txtNombreEmpleado.Focus();
                return false;
            }
            else
                txtNombreEmpleado.BackColor = Color.White;
            if (txtApellidoEmpleado.Text == string.Empty)
            {
                txtApellidoEmpleado.BackColor = Color.Red;
                txtApellidoEmpleado.Focus();
                return false;
            }
            else
                txtApellidoEmpleado.BackColor = Color.White;

            return true;
        }
        private bool ExisteEmpleado()
        {

            return oEmpleadoService.ObtenerEmpleado(Convert.ToInt32(txtLegajoEmpleado.Text));

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
        public void SeleccionarEmpleado(FormMode op, Empleado empleadoSelected)
        {
            formMode = op;
            oEmpleadoSelected = empleadoSelected;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (!ExisteEmpleado())
                        {
                            if (ValidarCampos())
                            {
                                Empleado oEmpleado = new Empleado();
                                oEmpleado.Legajo = Convert.ToInt32(txtLegajoEmpleado.Text);
                                oEmpleado.Nombre = txtNombreEmpleado.Text;
                                oEmpleado.Apellido = txtApellidoEmpleado.Text;

                                if (oEmpleadoService.CrearEmpleado(oEmpleado))
                                {
                                    MessageBox.Show("Empleado insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                    
                                }
                            }
                        }
                        else
                            MessageBox.Show("Legajo de empleado encontrado!. Ingrese un legajo diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        break;
                    }

                case FormMode.update:
                    {
                        if (ExisteEmpleado())
                        {
                            if (ValidarCampos())
                            {
                                oEmpleadoSelected.Legajo = Convert.ToInt32(txtLegajoEmpleado.Text);
                                oEmpleadoSelected.Nombre = txtNombreEmpleado.Text;
                                oEmpleadoSelected.Apellido = txtApellidoEmpleado.Text;

                                if (oEmpleadoService.ActualizarEmpleado(oEmpleadoSelected))
                                {
                                    MessageBox.Show("Empleado actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Dispose();
                                }
                                else
                                    MessageBox.Show("Error al actualizar el empleado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el empleado seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oEmpleadoService.ModificarEstadoEmpleado(oEmpleadoSelected))
                            {
                                MessageBox.Show("Empleado Habilitado/Deshabilitado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al deshabilitar el empleado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {

        }
    }
}