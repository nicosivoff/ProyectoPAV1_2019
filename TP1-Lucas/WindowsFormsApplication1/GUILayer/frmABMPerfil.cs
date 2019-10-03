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


namespace TrabajoPractico.GUILayer
{
    public partial class frmABMPerfil : Form
    {
        private FormMode formMode = FormMode.insert;
        DBHelper oBD = new DBHelper();
        private readonly PerfilService oPerfilService;
        private Perfil oPerfilSelected;
        public frmABMPerfil()
        {
            InitializeComponent();
            oPerfilService = new PerfilService();
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
                                Perfil oPerfil = new Perfil();
                                oPerfil.Nombre = txtNombrePerfil.Text;



                                if (oPerfilService.CrearPerfil(oPerfil))
                                {
                                    MessageBox.Show("Perfil insertado!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }



                            }
                        }
                        else
                            MessageBox.Show("Nombre de perfil encontrado!. Ingrese un nombre diferente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }

                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oPerfilSelected.Nombre = txtNombrePerfil.Text;

                            if (oPerfilService.ActualizarPerfil(oPerfilSelected))
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

                            if (oPerfilService.ModificarEstadoPerfil(oPerfilSelected))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmABMPerfil_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Perfil";
                        txtIdPerfil.Enabled = false;
                        txtNombrePerfil.Enabled = true;
                        break;
                    }

                case FormMode.update:
                    {
                        this.Text = "Actualizar Usuario";
                        // Recuperar usuario seleccionado en la grilla 
                        MostrarDatos();
                        txtIdPerfil.Enabled = false;
                        txtNombrePerfil.Enabled = true;
                        break;
                    }

                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Usuario";
                        txtIdPerfil.Enabled = false;
                        txtNombrePerfil.Enabled = false;
                        break;
                    }
            }
        }
        private void MostrarDatos()
        {
            if (oPerfilSelected != null)
            {
                txtIdPerfil.Text = oPerfilSelected.IdPerfil.ToString();
                txtNombrePerfil.Text = oPerfilSelected.Nombre.ToString();
            }
        }
        private bool ValidarCampos()
        {
            // campos obligatorios
            if (txtNombrePerfil.Text == string.Empty)
            {
                txtNombrePerfil.BackColor = Color.Red;
                txtNombrePerfil.Focus();
                return false;
            }
            else
                txtNombrePerfil.BackColor = Color.White;

            return true;
        }
        private bool ExistePerfil()
        {

            return oPerfilService.ObtenerPerfil(txtIdPerfil.Text);

        }
        public void SeleccionarPerfil(FormMode op, Perfil perfilSelected)
        {
            formMode = op;
            oPerfilSelected = perfilSelected;
        }
    }
}
