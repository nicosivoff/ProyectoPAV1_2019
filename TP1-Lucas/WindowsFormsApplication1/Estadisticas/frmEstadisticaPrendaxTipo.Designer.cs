namespace TrabajoPractico.Estadisticas
{
    partial class frmEstadisticaPrendaxTipo
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
            this.dsPrendaxTipoBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrendaxTipoBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cboTipoPrenda = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtPrecioDesde = new System.Windows.Forms.TextBox();
            this.txtPrecioHasta = new System.Windows.Forms.TextBox();
            this.lblTipoPrenda = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DsPrendaxTipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsPrendaxTipo = new TrabajoPractico.Estadisticas.DsPrendaxTipo();
            this.dsPrendaxTipo1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrendaxTipo1 = new TrabajoPractico.Estadisticas.DsPrendaxTipo();
            this.dsPrendaxTipoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DsPrendaxTipoTableAdapter = new TrabajoPractico.Estadisticas.DsPrendaxTipoTableAdapters.DsPrendaxTipoTableAdapter();
            this.dsPrendaxTipoBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipoBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipoBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPrendaxTipoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPrendaxTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipo1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipoBindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // dsPrendaxTipoBindingSource3
            // 
            this.dsPrendaxTipoBindingSource3.DataMember = "DsPrendaxTipo";
            this.dsPrendaxTipoBindingSource3.DataSource = this.dsPrendaxTipo1BindingSource;
            // 
            // dsPrendaxTipoBindingSource2
            // 
            this.dsPrendaxTipoBindingSource2.DataMember = "DsPrendaxTipo";
            this.dsPrendaxTipoBindingSource2.DataSource = this.dsPrendaxTipoBindingSource1;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DsPrendaxTipoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Estadisticas.rptEstadisticasVentaxTipo.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 66);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(770, 384);
            this.reportViewer1.TabIndex = 0;
            // 
            // cboTipoPrenda
            // 
            this.cboTipoPrenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPrenda.FormattingEnabled = true;
            this.cboTipoPrenda.Location = new System.Drawing.Point(93, 21);
            this.cboTipoPrenda.Name = "cboTipoPrenda";
            this.cboTipoPrenda.Size = new System.Drawing.Size(100, 21);
            this.cboTipoPrenda.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(626, 18);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(708, 18);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // txtPrecioDesde
            // 
            this.txtPrecioDesde.Location = new System.Drawing.Point(292, 21);
            this.txtPrecioDesde.Name = "txtPrecioDesde";
            this.txtPrecioDesde.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioDesde.TabIndex = 4;
            // 
            // txtPrecioHasta
            // 
            this.txtPrecioHasta.Location = new System.Drawing.Point(497, 21);
            this.txtPrecioHasta.Name = "txtPrecioHasta";
            this.txtPrecioHasta.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioHasta.TabIndex = 5;
            // 
            // lblTipoPrenda
            // 
            this.lblTipoPrenda.AutoSize = true;
            this.lblTipoPrenda.Location = new System.Drawing.Point(17, 24);
            this.lblTipoPrenda.Name = "lblTipoPrenda";
            this.lblTipoPrenda.Size = new System.Drawing.Size(65, 13);
            this.lblTipoPrenda.TabIndex = 6;
            this.lblTipoPrenda.Text = "Tipo Prenda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Precio Minimo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Precio Maximo";
            // 
            // DsPrendaxTipoBindingSource
            // 
            this.DsPrendaxTipoBindingSource.DataMember = "DsPrendaxTipo";
            this.DsPrendaxTipoBindingSource.DataSource = this.DsPrendaxTipo;
            // 
            // DsPrendaxTipo
            // 
            this.DsPrendaxTipo.DataSetName = "DsPrendaxTipo";
            this.DsPrendaxTipo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPrendaxTipo1BindingSource
            // 
            this.dsPrendaxTipo1BindingSource.DataSource = this.dsPrendaxTipo1;
            this.dsPrendaxTipo1BindingSource.Position = 0;
            // 
            // dsPrendaxTipo1
            // 
            this.dsPrendaxTipo1.DataSetName = "DsPrendaxTipo";
            this.dsPrendaxTipo1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsPrendaxTipoBindingSource1
            // 
            this.dsPrendaxTipoBindingSource1.DataSource = this.DsPrendaxTipo;
            this.dsPrendaxTipoBindingSource1.Position = 0;
            // 
            // DsPrendaxTipoTableAdapter
            // 
            this.DsPrendaxTipoTableAdapter.ClearBeforeFill = true;
            // 
            // dsPrendaxTipoBindingSource4
            // 
            this.dsPrendaxTipoBindingSource4.DataMember = "DsPrendaxTipo";
            this.dsPrendaxTipoBindingSource4.DataSource = this.dsPrendaxTipo1;
            // 
            // frmEstadisticaPrendaxTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 462);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTipoPrenda);
            this.Controls.Add(this.txtPrecioHasta);
            this.Controls.Add(this.txtPrecioDesde);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cboTipoPrenda);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEstadisticaPrendaxTipo";
            this.Text = "frmEstadisticaPrendaxTipo";
            this.Load += new System.EventHandler(this.frmEstadisticaPrendaxTipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipoBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipoBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPrendaxTipoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPrendaxTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipo1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaxTipoBindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox cboTipoPrenda;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtPrecioDesde;
        private System.Windows.Forms.TextBox txtPrecioHasta;
        private System.Windows.Forms.Label lblTipoPrenda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource DsPrendaxTipoBindingSource;
        private DsPrendaxTipo DsPrendaxTipo;
        private DsPrendaxTipoTableAdapters.DsPrendaxTipoTableAdapter DsPrendaxTipoTableAdapter;
        private System.Windows.Forms.BindingSource dsPrendaxTipoBindingSource2;
        private System.Windows.Forms.BindingSource dsPrendaxTipoBindingSource1;
        private System.Windows.Forms.BindingSource dsPrendaxTipoBindingSource3;
        private System.Windows.Forms.BindingSource dsPrendaxTipo1BindingSource;
        private DsPrendaxTipo dsPrendaxTipo1;
        private System.Windows.Forms.BindingSource dsPrendaxTipoBindingSource4;
    }
}