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
    public partial class frmABMPrenda : Form
    {
        private DBHelper oBD = new DBHelper();
        private FormMode formMode = FormMode.insert;
        private Prenda oPrendaSelected = new Prenda();
        private PrendaService oPrendaService = new PrendaService();
        public frmABMPrenda()
        {
            InitializeComponent();
            PrendaService oPrendaService = new PrendaService();
        }
        public enum FormMode
        {
            insert,
            update,
            delete
        }
        private void LlenarCombo(ComboBox cbo, Object source, string display, String value)
        {
            cbo.DataSource = source;
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.SelectedIndex = -1;
        }
        public bool ValidarCampos()
        {
            if (txtCodPrenda.Text == string.Empty)
            {
                txtCodPrenda.BackColor = Color.Red;
                txtCodPrenda.Focus();
                return false;
            }
            else
                txtCodPrenda.BackColor = Color.White;
            /*if (Convert.ToInt32(cboTipoPrenda.SelectedValue) == -1)
            {
                cboTipoPrenda.BackColor = Color.Red;
                cboTipoPrenda.Focus();
                return false;
            }
            else
                cboTipoPrenda.BackColor = Color.Red;*/
            if (txtTalle.Text == string.Empty)
            {
                txtTalle.BackColor = Color.Red;
                txtTalle.Focus();
                return false;
            }
            else
                txtTalle.BackColor = Color.White;
            if (txtPrecio.Text == string.Empty)
            {
                txtPrecio.BackColor = Color.Red;
                txtPrecio.Focus();
                return false;
            }
            else
                txtPrecio.BackColor = Color.White;
            if (txtCantidad.Text == string.Empty)
            {
                txtCantidad.BackColor = Color.Red;
                txtCantidad.Focus();
                return false;
            }
            else
                txtCantidad.BackColor = Color.White;
            /*if (((int)cboMarca.SelectedValue) == -1)
            {
                cboMarca.BackColor = Color.Red;
                cboMarca.Focus();
                return false;
            }
            else
                cboMarca.BackColor = Color.White;*/
            if (txtDescripcion.Text == string.Empty)
                txtDescripcion.Text = " ";
            return true;
        }
        public bool ExistePrenda()
        {
            return oPrendaService.ObtenerPrenda(txtCodPrenda.Text) != null;
        }
        public void seleccionarPrenda(FormMode op, Prenda prenda)
        {
            formMode = op;
            oPrendaSelected = prenda;
        }

        private void frmAMBPrenda_Load(object sender, EventArgs e)
        {
            LlenarCombo(cboMarca, oBD.consultarTabla("Marca"), "nombre", "idMarca");
            LlenarCombo(cboTipoPrenda, oBD.consultarTabla("TipoPrenda"), "descrip", "codTipoPrenda");
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        this.Text = "Nuevo Prenda";
                        break;
                    }
                case FormMode.update:
                    {
                        this.Text = "Actualizar Prenda";
                        MostrarDatos();
                        txtCodPrenda.Enabled = false;
                        cboTipoPrenda.Enabled = true;
                        txtTalle.Enabled = true;
                        txtPrecio.Enabled = true;
                        txtCantidad.Enabled = true;
                        cboMarca.Enabled = true;
                        txtDescripcion.Enabled = true;
                        break;
                    }
                case FormMode.delete:
                    {
                        this.Text = "Habilitar/Deshabilitar Prenda";
                        MostrarDatos();
                        txtCodPrenda.Enabled = false;
                        cboTipoPrenda.Enabled = false;
                        txtTalle.Enabled = false;
                        txtPrecio.Enabled = false;
                        txtCantidad.Enabled = false;
                        cboMarca.Enabled = false;
                        txtDescripcion.Enabled = false;
                        break;
                    }
            }
        }
        public void MostrarDatos()
        {
            if (oPrendaSelected != null)
            {

                txtCodPrenda.Text = oPrendaSelected.CodPrenda.ToString();
                cboTipoPrenda.Text = oPrendaSelected.TipoPrenda.Nombre;
                txtTalle.Text = oPrendaSelected.Talle;
                txtPrecio.Text = oPrendaSelected.Precio.ToString();
                txtCantidad.Text = oPrendaSelected.Cantidad.ToString();
                cboMarca.Text = oPrendaSelected.Marca.Nombre;
                txtDescripcion.Text = oPrendaSelected.Descripcion;

            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ValidarCampos())
                        {
                            if (ExistePrenda() == false)
                            {
                                var oPrenda = new Prenda();
                                oPrenda.CodPrenda = Convert.ToInt32(txtCodPrenda.Text);
                                oPrenda.TipoPrenda = new TipoPrenda();
                                oPrenda.TipoPrenda.Codigo = (int)cboTipoPrenda.SelectedValue;
                                oPrenda.Talle = txtTalle.Text;
                                oPrenda.Precio = Convert.ToInt32(txtPrecio.Text);
                                oPrenda.Cantidad = Convert.ToInt32(txtCantidad.Text);
                                oPrenda.Marca = new Marca();
                                oPrenda.Marca.IdMarca = (int)cboMarca.SelectedValue;
                                oPrenda.Descripcion = txtDescripcion.Text;

                                if (oPrendaService.crearPrenda(oPrenda))
                                {
                                    MessageBox.Show("Prenda Insertada!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else
                                MessageBox.Show("Prenda encontrada!. Ingrese una **** ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        
                        break;
                    }
                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oPrendaSelected.TipoPrenda = new TipoPrenda();
                            oPrendaSelected.TipoPrenda.Codigo = (int)cboTipoPrenda.SelectedValue;
                            oPrendaSelected.Talle = txtTalle.Text;
                            oPrendaSelected.Precio = Convert.ToInt32(txtPrecio.Text);
                            oPrendaSelected.Cantidad = Convert.ToInt32(txtCantidad.Text);
                            oPrendaSelected.Marca = new Marca();
                            oPrendaSelected.Marca.IdMarca = (int)cboMarca.SelectedValue;
                            oPrendaSelected.Descripcion = txtDescripcion.Text;

                            if (oPrendaService.actualizarPrenda(oPrendaSelected))
                            {
                                MessageBox.Show("Prenda actualizada!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar la prenda!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar la prenda seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            if (oPrendaService.modificarEstadoPrenda(oPrendaSelected))
                            {
                                MessageBox.Show("Prenda habilitado/deshabilitado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar la prenda", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            switch (formMode)
            {
                case FormMode.insert:
                    {
                        if (ValidarCampos())
                        {
                            if (ExistePrenda() == false)
                            {
                                var oPrenda = new Prenda();
                                oPrenda.CodPrenda = Convert.ToInt32(txtCodPrenda.Text);
                                oPrenda.TipoPrenda = new TipoPrenda();
                                oPrenda.TipoPrenda.Codigo = (int)cboTipoPrenda.SelectedValue;
                                oPrenda.Talle = txtTalle.Text;
                                oPrenda.Precio = Convert.ToInt32(txtPrecio.Text);
                                oPrenda.Cantidad = Convert.ToInt32(txtCantidad.Text);
                                oPrenda.Marca = new Marca();
                                oPrenda.Marca.IdMarca = (int)cboMarca.SelectedValue;
                                oPrenda.Descripcion = txtDescripcion.Text;

                                if (oPrendaService.crearPrenda(oPrenda))
                                {
                                    MessageBox.Show("Prenda Insertada!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            else
                                MessageBox.Show("Prenda encontrada!. Ingrese un id diferente ", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        break;
                    }
                case FormMode.update:
                    {
                        if (ValidarCampos())
                        {
                            oPrendaSelected.TipoPrenda = new TipoPrenda();
                            oPrendaSelected.TipoPrenda.Codigo = (int)cboTipoPrenda.SelectedValue;
                            oPrendaSelected.Talle = txtTalle.Text;
                            oPrendaSelected.Precio = Convert.ToInt32(txtPrecio.Text);
                            oPrendaSelected.Cantidad = Convert.ToInt32(txtCantidad.Text);
                            oPrendaSelected.Marca = new Marca();
                            oPrendaSelected.Marca.IdMarca = (int)cboMarca.SelectedValue;
                            oPrendaSelected.Descripcion = txtDescripcion.Text;

                            if (oPrendaService.actualizarPrenda(oPrendaSelected))
                            {
                                MessageBox.Show("Prenda actualizada!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                            }
                            else
                                MessageBox.Show("Error al actualizar la prenda!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
                case FormMode.delete:
                    {
                        if (MessageBox.Show("Seguro que desea habilitar/deshabilitar la prenda seleccionada?", "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            if (oPrendaService.modificarEstadoPrenda(oPrendaSelected))
                            {
                                MessageBox.Show("Prenda habilitado/deshabilitado!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                                MessageBox.Show("Error al actualizar la prenda", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                    }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

