namespace TrabajoPractico.Reportes
{
    partial class frmReportePrenda
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.marcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrenda = new TrabajoPractico.dsPrenda();
            this.marcaTableAdapter = new TrabajoPractico.dsPrendaTableAdapters.MarcaTableAdapter();
            this.prendaTableAdapter = new TrabajoPractico.dsPrendaTableAdapters.PrendaTableAdapter();
            this.prendaMarcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prendaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.marcaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prendaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prendaMarcaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prendaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.prendaBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Reportes.ReportePrendas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(560, 410);
            this.reportViewer1.TabIndex = 0;
            // 
            // marcaBindingSource
            // 
            this.marcaBindingSource.DataMember = "Marca";
            this.marcaBindingSource.DataSource = this.dsPrendaBindingSource;
            // 
            // prendaBindingSource
            // 
            this.prendaBindingSource.DataMember = "Prenda";
            this.prendaBindingSource.DataSource = this.dsPrendaBindingSource;
            // 
            // dsPrendaBindingSource
            // 
            this.dsPrendaBindingSource.DataSource = this.dsPrenda;
            this.dsPrendaBindingSource.Position = 0;
            // 
            // dsPrenda
            // 
            this.dsPrenda.DataSetName = "dsPrenda";
            this.dsPrenda.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // marcaTableAdapter
            // 
            this.marcaTableAdapter.ClearBeforeFill = true;
            // 
            // prendaTableAdapter
            // 
            this.prendaTableAdapter.ClearBeforeFill = true;
            // 
            // prendaMarcaBindingSource
            // 
            this.prendaMarcaBindingSource.DataMember = "Prenda_Marca";
            this.prendaMarcaBindingSource.DataSource = this.prendaBindingSource;
            // 
            // prendaBindingSource1
            // 
            this.prendaBindingSource1.DataMember = "Prenda";
            this.prendaBindingSource1.DataSource = this.dsPrenda;
            // 
            // frmReportePrenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 410);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportePrenda";
            this.Text = "frmReportePrenda";
            this.Load += new System.EventHandler(this.frmReportePrenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.marcaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prendaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrendaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prendaMarcaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prendaBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dsPrendaBindingSource;
        private dsPrenda dsPrenda;
        private System.Windows.Forms.BindingSource marcaBindingSource;
        private dsPrendaTableAdapters.MarcaTableAdapter marcaTableAdapter;
        private System.Windows.Forms.BindingSource prendaBindingSource;
        private dsPrendaTableAdapters.PrendaTableAdapter prendaTableAdapter;
        private System.Windows.Forms.BindingSource prendaBindingSource1;
        private System.Windows.Forms.BindingSource prendaMarcaBindingSource;
    }
}