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

namespace TrabajoPractico.GUILayer
{
    public partial class frmABMMarca : Form
    {
        private FormMode formMode = FormMode.insert;
        DBHelper oBD = new DBHelper();
        private readonly MarcaService oMarcaService;
        private Marca oMarcaSelected;
        
        public enum FormMode
        {
            insert,
            update,
            delete
        }

        public frmABMMarca()
        {
            InitializeComponent();
            oMarcaService = new MarcaService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ValidarCampos())
                        {
                            if (existeMarca() == false)
                            {
                                var oMarca = new Marca();
                                oMarca.IdMarca = Convert.ToInt32(txtIdMarca.Text);
                                oMarca.Nombre = txtNombreMarca.Text;

                                if (oMarcaService.crearMarca(oMarca))
                                {
                                    MessageBox.Show("Marca Insertada!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else
                                MessageBox.Show("Marca encontrada!.Debe ingresar una marca no registrada", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        break;
                    }
                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oMarcaSelected.Nombre = txtNombreMarca.Text;
                            if (oMarcaService.actualizarMarca(oMarcaSelected))
                            {
                                MessageBox.Show("Marca actualizada!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar la marca!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        break;
                    }
                case FormMode.delete:
                    {
                        if(MessageBox.Show("Seguro que desea deshabilitar la marca seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            if (oMarcaService.modificarEstadoMarca(oMarcaSelected))
                            {
                                MessageBox.Show("Marca Deshabilitada!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar la marca", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                  
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmABMMarca_Load(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nueva Marca";
                        break;
                    }
                case FormMode.update:
                    {
                        this.Text = "Actualizar Marca";
                        MostrarDatos();
                        txtIdMarca.Enabled = false;
                        txtNombreMarca.Enabled = true;

                        break;
                    }
                case FormMode.delete:
                    {
                        MostrarDatos();
                        this.Text = "Habilitar/Deshabilitar Marca";
                        txtIdMarca.Enabled = false;
                        txtNombreMarca.Enabled = false;
                        break;

                    }
            }
        }
        public void MostrarDatos()
        {
            if (oMarcaSelected != null)
            {
                txtIdMarca.Text = oMarcaSelected.IdMarca.ToString();
                txtNombreMarca.Text = oMarcaSelected.Nombre.ToString();
            }
        }
        private bool ValidarCampos()
        {
            if (txtIdMarca.Text == string.Empty)
            {
                txtIdMarca.BackColor = Color.Red;
                txtIdMarca.Focus();
                return false;
            }
            else
                txtIdMarca.BackColor = Color.White;

            if (txtNombreMarca.Text == string.Empty)
            {
                txtNombreMarca.BackColor = Color.Red;
                txtNombreMarca.Focus();
                return false;
            }
            else
                txtNombreMarca.BackColor = Color.White;
            
            return true;

        }
        private bool existeMarca()
        {
            return oMarcaService.obtenerMarca(txtIdMarca.Text) != null;
        }
        public void seleccionarMarca(FormMode op, Marca marca)
        {
            formMode = op;
            oMarcaSelected = marca;
        }

    }
}
