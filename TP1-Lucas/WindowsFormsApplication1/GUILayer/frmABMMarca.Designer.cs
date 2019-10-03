namespace TrabajoPractico.GUILayer
{
    partial class frmABMMarca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbMarca = new System.Windows.Forms.GroupBox();
            this.txtNombreMarca = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtIdMarca = new System.Windows.Forms.TextBox();
            this.lblIdMarca = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grbMarca.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbMarca
            // 
            this.grbMarca.Controls.Add(this.txtNombreMarca);
            this.grbMarca.Controls.Add(this.lblNombre);
            this.grbMarca.Controls.Add(this.txtIdMarca);
            this.grbMarca.Controls.Add(this.lblIdMarca);
            this.grbMarca.Location = new System.Drawing.Point(12, 12);
            this.grbMarca.Name = "grbMarca";
            this.grbMarca.Size = new System.Drawing.Size(276, 123);
            this.grbMarca.TabIndex = 0;
            this.grbMarca.TabStop = false;
            this.grbMarca.Text = "Marca";
            // 
            // txtNombreMarca
            // 
            this.txtNombreMarca.Location = new System.Drawing.Point(93, 69);
            this.txtNombreMarca.Name = "txtNombreMarca";
            this.txtNombreMarca.Size = new System.Drawing.Size(121, 20);
            this.txtNombreMarca.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(33, 69);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 13);
            this.lblNombre.TabIndex = 31;
            this.lblNombre.Text = "* Nombre:";
            // 
            // txtIdMarca
            // 
            this.txtIdMarca.Location = new System.Drawing.Point(93, 40);
            this.txtIdMarca.Name = "txtIdMarca";
            this.txtIdMarca.Size = new System.Drawing.Size(121, 20);
            this.txtIdMarca.TabIndex = 0;
            // 
            // lblIdMarca
            // 
            this.lblIdMarca.AutoSize = true;
            this.lblIdMarca.Location = new System.Drawing.Point(33, 43);
            this.lblIdMarca.Name = "lblIdMarca";
            this.lblIdMarca.Size = new System.Drawing.Size(58, 13);
            this.lblIdMarca.TabIndex = 29;
            this.lblIdMarca.Text = "* Id marca:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(12, 141);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(213, 141);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmABMMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(300, 176);
            this.Controls.Add(this.grbMarca);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(316, 214);
            this.MinimumSize = new System.Drawing.Size(316, 214);
            this.Name = "frmABMMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmABMMarca";
            this.Load += new System.EventHandler(this.frmABMMarca_Load);
            this.grbMarca.ResumeLayout(false);
            this.grbMarca.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMarca;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtIdMarca;
        private System.Windows.Forms.Label lblIdMarca;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombreMarca;
    }
}