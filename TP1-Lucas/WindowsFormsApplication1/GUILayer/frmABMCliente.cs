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

namespace TrabajoPractico.GUILayer
{
    public partial class frmABMCliente : Form
    {
        private FormMode formMode = FormMode.insert;
        DBHelper oBD = new DBHelper();
        private readonly ClienteService oClienteService;
        private Cliente oClienteSelected;

        public frmABMCliente()
        {
            InitializeComponent();
            oClienteService = new ClienteService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (!ExistePerfil())
                        {
                            if (ValidarCampos())
                            {
                                Cliente oCliente = new Cliente();
                                oCliente.NroDoc = Convert.ToInt32(txtDoc.Text);
                                oCliente.Nombre = txtNombre.Text;
                                oCliente.Apellido = txtApellido.Text;
                                oCliente.Domicilio = txtDomicilio.Text;
                                oCliente.Telefono = Convert.ToInt32(txtTelefono.Text);
                                oCliente.Mail = txtEmail.Text;

                                if (oClienteService.crearCliente(oCliente))
                                {
                                    MessageBox.Show("Usuario insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }

                            }
                        }
                        else
                            MessageBox.Show("Nombre de usuario encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                    case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oClienteSelected.NroDoc = Convert.ToInt32(txtDoc.Text);
                            oClienteSelected.Nombre = txtNombre.Text;
                            oClienteSelected.Apellido = txtApellido.Text;
                            oClienteSelected.Domicilio = txtDomicilio.Text;
                            oClienteSelected.Telefono = Convert.ToInt32(txtTelefono.Text);
                            oClienteSelected.Mail = txtEmail.Text;


                            if (oClienteService.actualizarCliente(oClienteSelected))
                            {
                                MessageBox.Show("Perfil actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el perfil!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el perfil seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oClienteService.ModificarEstadoPerfil(oClienteSelected))
                            {
                                MessageBox.Show("Perfil Habilitado/Deshabilitado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el Perfil!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }

        }

        private void frmAMBCliente_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Perfil";
                        txtDoc.Enabled = true;
                        txtNombre.Enabled = true;
                        txtApellido.Enabled = true;
                        txtDomicilio.Enabled = true;
                        txtEmail.Enabled = true;
                        txtTelefono.Enabled = true;
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Usuario";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtDoc.Enabled = false;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Usuario";
                        txtDoc.Enabled = false;
                        txtNombre.Enabled = false;
                        txtApellido.Enabled = false;
                        txtDomicilio.Enabled = false;
                        txtEmail.Enabled = false;
                        txtTelefono.Enabled = false;
                        break;
                    }
            }
        }

         private void MostrarDatos()
        {
            if (oClienteSelected != null)
            {
                txtDoc.Text = oClienteSelected.NroDoc.ToString();
                txtNombre.Text = oClienteSelected.Nombre.ToString();
                txtApellido.Text = oClienteSelected.Apellido.ToString();
                txtTelefono.Text = oClienteSelected.Telefono.ToString();
                txtDomicilio.Text = oClienteSelected.Domicilio.ToString();
                txtEmail.Text = oClienteSelected.Mail.ToString();
            }
        }
        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtDoc.Text == string.Empty)
            {
                txtDoc.BackColor = Color.Red;
                txtDoc.Focus();
                return false;
            }
            else
                txtDoc.BackColor = Color.White;

            return true;
        }
        private bool ExistePerfil()
        {
            return oClienteService.ObtenerCliente(Convert.ToInt32(txtDoc.Text));

        }

        public void SeleccionarCliente(FormMode op, Cliente clienteSelected)
        {
            formMode = op;
            oClienteSelected = clienteSelected;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

