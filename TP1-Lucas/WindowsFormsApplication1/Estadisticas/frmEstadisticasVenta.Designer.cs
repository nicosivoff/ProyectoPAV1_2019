namespace TrabajoPractico.Estadisticas
{
    partial class frmEstadisticasVenta
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DsVentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsVentaEstadisticas = new TrabajoPractico.Estadisticas.DsVentaEstadisticas();
            this.dsVentaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.txtMinimo = new System.Windows.Forms.TextBox();
            this.txtMaximo = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.DsVentaTableAdapter = new TrabajoPractico.Estadisticas.DsVentaEstadisticasTableAdapters.DsVentaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DsVentaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsVentaEstadisticas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVentaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // DsVentaBindingSource
            // 
            this.DsVentaBindingSource.DataMember = "DsVenta";
            this.DsVentaBindingSource.DataSource = this.DsVentaEstadisticas;
            // 
            // DsVentaEstadisticas
            // 
            this.DsVentaEstadisticas.DataSetName = "DsVentaEstadisticas";
            this.DsVentaEstadisticas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsVentaBindingSource1
            // 
            this.dsVentaBindingSource1.DataMember = "DsVenta";
            this.dsVentaBindingSource1.DataSource = this.DsVentaEstadisticas;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha desde:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo de factura:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cliente:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Subtotal minimo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Subtotal maximo:";
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesde.Location = new System.Drawing.Point(100, 13);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(99, 20);
            this.dtpFechaDesde.TabIndex = 7;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHasta.Location = new System.Drawing.Point(314, 12);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(111, 20);
            this.dtpFechaHasta.TabIndex = 8;
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(100, 44);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(99, 21);
            this.cboTipo.TabIndex = 9;
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(314, 44);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(111, 21);
            this.cboCliente.TabIndex = 10;
            // 
            // txtMinimo
            // 
            this.txtMinimo.Location = new System.Drawing.Point(99, 84);
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.Size = new System.Drawing.Size(100, 20);
            this.txtMinimo.TabIndex = 11;
            // 
            // txtMaximo
            // 
            this.txtMaximo.Location = new System.Drawing.Point(314, 84);
            this.txtMaximo.Name = "txtMaximo";
            this.txtMaximo.Size = new System.Drawing.Size(111, 20);
            this.txtMaximo.TabIndex = 12;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(476, 10);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 13;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(476, 84);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // DsVentaTableAdapter
            // 
            this.DsVentaTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DsVentaBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.dsVentaBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Estadisticas.rptEstadisticasVenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(15, 134);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(628, 368);
            this.reportViewer1.TabIndex = 15;
            // 
            // frmEstadisticasVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 523);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtMaximo);
            this.Controls.Add(this.txtMinimo);
            this.Controls.Add(this.cboCliente);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEstadisticasVenta";
            this.Text = "frmEstadisticasVenta";
            this.Load += new System.EventHandler(this.frmEstadisticasVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsVentaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsVentaEstadisticas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVentaBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.TextBox txtMinimo;
        private System.Windows.Forms.TextBox txtMaximo;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.BindingSource DsVentaBindingSource;
        private DsVentaEstadisticas DsVentaEstadisticas;
        private DsVentaEstadisticasTableAdapters.DsVentaTableAdapter DsVentaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dsVentaBindingSource1;
    }
}