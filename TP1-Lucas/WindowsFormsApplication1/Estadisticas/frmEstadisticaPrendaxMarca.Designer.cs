namespace TrabajoPractico.Estadisticas
{
    partial class frmEstadisticaPrendaxMarca
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dsPrendaxMarcaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrendaxMarcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrendaxMarca = new TrabajoPractico.Estadisticas.DsPrendaxMarca();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtPrecioHasta = new System.Windows.Forms.TextBox();
            this.txtPrecioDesde = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.dsPrendaxMarca1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsPrendaxMarcaTableAdapter = new TrabajoPractico.Estadisticas.DsPrendaxMarcaTableAdapters.DsPrendaxMarcaTableAdapter();
            this.dsPrendaxMarca2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarcaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarcaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarca1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarca2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsPrendaxMarcaBindingSource1
            // 
            this.dsPrendaxMarcaBindingSource1.DataMember = "DsPrendaxMarca";
            this.dsPrendaxMarcaBindingSource1.DataSource = this.dsPrendaxMarcaBindingSource;
            // 
            // dsPrendaxMarcaBindingSource
            // 
            this.dsPrendaxMarcaBindingSource.DataSource = this.dsPrendaxMarca;
            this.dsPrendaxMarcaBindingSource.Position = 0;
            // 
            // dsPrendaxMarca
            // 
            this.dsPrendaxMarca.DataSetName = "DsPrendaxMarca";
            this.dsPrendaxMarca.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DsPrendaxMarca";
            reportDataSource1.Value = this.dsPrendaxMarcaBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Estadisticas.rptEstadisticasPrendaxMarca.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 70);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(751, 413);
            this.reportViewer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(395, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Precio Maximo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Precio Minimo:";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(9, 17);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 14;
            this.lblMarca.Text = "Marca:";
            // 
            // txtPrecioHasta
            // 
            this.txtPrecioHasta.Location = new System.Drawing.Point(477, 14);
            this.txtPrecioHasta.Name = "txtPrecioHasta";
            this.txtPrecioHasta.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioHasta.TabIndex = 13;
            // 
            // txtPrecioDesde
            // 
            this.txtPrecioDesde.Location = new System.Drawing.Point(261, 14);
            this.txtPrecioDesde.Name = "txtPrecioDesde";
            this.txtPrecioDesde.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioDesde.TabIndex = 12;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(688, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(598, 12);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cboMarca
            // 
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(55, 14);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(100, 21);
            this.cboMarca.TabIndex = 9;
            // 
            // DsPrendaxMarcaTableAdapter
            // 
            this.DsPrendaxMarcaTableAdapter.ClearBeforeFill = true;
            // 
            // frmEstadisticaPrendaxMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 530);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtPrecioHasta);
            this.Controls.Add(this.txtPrecioDesde);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEstadisticaPrendaxMarca";
            this.Text = "frmEstadisticaPrendaxMarca";
            this.Load += new System.EventHandler(this.frmEstadisticaPrendaxMarca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarcaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarcaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarca1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxMarca2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dsPrendaxMarcaBindingSource;
        private DsPrendaxMarca dsPrendaxMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtPrecioHasta;
        private System.Windows.Forms.TextBox txtPrecioDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.BindingSource dsPrendaxMarca1BindingSource;
        private DsPrendaxMarcaTableAdapters.DsPrendaxMarcaTableAdapter DsPrendaxMarcaTableAdapter;
        private System.Windows.Forms.BindingSource dsPrendaxMarca2BindingSource;
        private System.Windows.Forms.BindingSource dsPrendaxMarcaBindingSource1;
    }
}