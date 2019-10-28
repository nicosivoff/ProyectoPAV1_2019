namespace TrabajoPractico.Reportes
{
    partial class frmReporteProveedores
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
            this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProveedores = new TrabajoPractico.DsProveedores();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.proveedorTableAdapter = new TrabajoPractico.DsProveedoresTableAdapters.ProveedorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProveedoresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // proveedorBindingSource
            // 
            this.proveedorBindingSource.DataMember = "Proveedor";
            this.proveedorBindingSource.DataSource = this.dsProveedoresBindingSource;
            // 
            // dsProveedoresBindingSource
            // 
            this.dsProveedoresBindingSource.DataSource = this.dsProveedores;
            this.dsProveedoresBindingSource.Position = 0;
            // 
            // dsProveedores
            // 
            this.dsProveedores.DataSetName = "DsProveedores";
            this.dsProveedores.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.proveedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Reportes.ReporteProveedores.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(783, 579);
            this.reportViewer1.TabIndex = 0;
            // 
            // proveedorTableAdapter
            // 
            this.proveedorTableAdapter.ClearBeforeFill = true;
            // 
            // frmReporteProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 579);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteProveedores";
            this.Load += new System.EventHandler(this.frmReporteProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProveedoresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProveedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dsProveedoresBindingSource;
        private DsProveedores dsProveedores;
        private System.Windows.Forms.BindingSource proveedorBindingSource;
        private DsProveedoresTableAdapters.ProveedorTableAdapter proveedorTableAdapter;
    }
}