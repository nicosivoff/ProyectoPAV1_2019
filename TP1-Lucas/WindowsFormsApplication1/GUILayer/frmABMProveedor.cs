using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPractico.DataAccessLayer;
using TrabajoPractico.BusinessLayer;
using TrabajoPractico.Entities;

namespace TrabajoPractico.GUILayer
{
    public partial class frmABMProveedor : Form
    {
        private FormMode formMode = FormMode.insert;
        DBHelper oBD = new DBHelper();
        private readonly ProveedorService oProveedorService;
        private Proveedor oProveedorSelected;

        public frmABMProveedor()
        {
            InitializeComponent();
            oProveedorService = new ProveedorService();
        }

        public enum FormMode
        {
            insert,
            update,
            delete
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
            case FormMode.insert:
                    {
                        if (!ExisteProveedor())
                        {
                            if (ValidarCampos())
                            {
                                Proveedor oProveedor = new Proveedor();
                                oProveedor.CUIL = Convert.ToInt32(txtCUIL.Text);
                                oProveedor.RazonSocial = txtRazonSocial.Text;
                                oProveedor.Direccion = txtDireccion.Text;
                                oProveedor.Telefono = Convert.ToInt32(txtTelefono.Text);

                                if (oProveedorService.crearProveedor(oProveedor))
                                {
                                    MessageBox.Show("Proveedor insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            oProveedorSelected.CUIL = Convert.ToInt32(txtCUIL.Text);
                            oProveedorSelected.RazonSocial = txtRazonSocial.Text;
                            oProveedorSelected.Direccion = txtDireccion.Text;
                            oProveedorSelected.Telefono = Convert.ToInt32(txtTelefono.Text);

                            if (oProveedorService.actualizarProveedor(oProveedorSelected))
                            {
                                MessageBox.Show("Proveedor actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el proveedor!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el perfil seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oProveedorService.ModificarEstadoPerfil(oProveedorSelected))
                            {
                                MessageBox.Show("Proveedor Habilitado/Deshabilitado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el proveedor!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }

        }

        private void frmABMProveedor_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Perfil";
                        txtCUIL.Enabled = true;
                        txtRazonSocial.Enabled = true;
                        txtDireccion.Enabled = true;
                        txtTelefono.Enabled = true;
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Usuario";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtCUIL.Enabled = false;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Usuario";
                        txtCUIL.Enabled = false;
                        txtDireccion.Enabled = false;
                        txtRazonSocial.Enabled = false;
                        txtTelefono.Enabled = false;
                        break;
                    }
            }
        }

        private void MostrarDatos()
        {
            if (oProveedorSelected != null)
            {
                txtCUIL.Text = oProveedorSelected.CUIL.ToString();
                txtRazonSocial.Text = oProveedorSelected.RazonSocial.ToString();
                txtDireccion.Text = oProveedorSelected.Direccion.ToString();
                txtTelefono.Text = oProveedorSelected.Telefono.ToString();
            }
        }
        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtCUIL.Text == string.Empty)
            {
                txtCUIL.BackColor = Color.Red;
                txtCUIL.Focus();
                return false;
            }
            else
                txtCUIL.BackColor = Color.White;

            return true;
        }
        private bool ExisteProveedor()
        {
            return oProveedorService.ObtenerProveedor(Convert.ToInt32(txtCUIL.Text));

        }

        public void SeleccionarProveedor(FormMode op, Proveedor proveedorSelected)
        {
            formMode = op;
            oProveedorSelected = proveedorSelected;
        }
    }
}
