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

namespace TrabajoPractico
{
    public partial class frmABMUsuarios : Form
    {
        private FormMode formMode = FormMode.insert;
        DBHelper oBD = new DBHelper();
        private readonly UsuarioService oUsuarioService;
        private Usuario oUsuarioSelected;
        public frmABMUsuarios()
        {
            InitializeComponent();
            oUsuarioService = new UsuarioService();
        }
        public enum FormMode
        {
            insert,
            update,
            delete
        }


        private void frmABMUsuarios_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboPerfil, oBD.consultarTabla("Perfil"), "nombre", "idPerfil");
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Usuario";
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Usuario";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtIdUsuario.Enabled = false;
                        txtEmail.Enabled = true;
                        txtContraseña.Enabled = true;
                        txtRepContra.Enabled = true;
                        cboPerfil.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Usuario";
                        txtIdUsuario.Enabled = false;
                        txtEmail.Enabled = false;
                        txtContraseña.Enabled = false;
                        txtRepContra.Enabled = false;
                        cboPerfil.Enabled = false;
                        break;
                    }
            }
        }

        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (!ExisteUsuario())
                        {
                            if (ValidarCampos())
                            {
                                Usuario oUsuario = new Usuario();
                                oUsuario.IdUsuario = txtIdUsuario.Text;
                                oUsuario.Contraseña = txtContraseña.Text;
                                oUsuario.Email = txtEmail.Text;
                                oUsuario.Perfil = new Perfil();
                                oUsuario.Perfil.IdPerfil = (int)cboPerfil.SelectedValue;

                                
                                
                                if (oUsuarioService.CrearUsuario(oUsuario))
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
                            oUsuarioSelected.IdUsuario = txtIdUsuario.Text;
                            oUsuarioSelected.Contraseña = txtContraseña.Text;
                            oUsuarioSelected.Email = txtEmail.Text;
                            oUsuarioSelected.Perfil = new Perfil();
                            oUsuarioSelected.Perfil.IdPerfil = (int)cboPerfil.SelectedValue;

                            if (oUsuarioService.ActualizarUsuario(oUsuarioSelected))
                            {
                                MessageBox.Show("Usuario actualizado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar el usuario!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }

                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar el usuario seleccionado?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (oUsuarioService.ModificarEstadoUsuario(oUsuarioSelected))
                            {
                                MessageBox.Show("Usuario Habilitado/Deshabilitado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar el usuario!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        break;
                    }
            }
        }
        private void MostrarDatos()
        {
            if (oUsuarioSelected != null)
            {
                txtIdUsuario.Text = oUsuarioSelected.IdUsuario;
                txtEmail.Text = oUsuarioSelected.Email;
                txtContraseña.Text = oUsuarioSelected.Contraseña;
                txtRepContra.Text = txtContraseña.Text;
                cboPerfil.Text = oUsuarioSelected.Perfil.Nombre;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtIdUsuario.Text == string.Empty)
            {
                txtIdUsuario.BackColor = Color.Red;
                txtIdUsuario.Focus();
                return false;
            }
            else
                txtIdUsuario.BackColor = Color.White;
            if (txtContraseña.Text != txtRepContra.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                txtContraseña.BackColor = Color.Red;
                txtRepContra.BackColor = Color.Red;
                txtContraseña.Focus();
                return false;
            }
            else
                txtIdUsuario.BackColor = Color.White;
            return true;
        }
        private bool ExisteUsuario()
        {

            return oUsuarioService.ObtenerUsuario(txtIdUsuario.Text);
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalir_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
        public void SeleccionarUsuario(FormMode op, Usuario usuarioSelected)
        {
            formMode = op;
            oUsuarioSelected = usuarioSelected;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
