namespace TrabajoPractico.Reportes
{
    partial class frmReportePrendaMarca
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
            this.TipoPrenda = new TrabajoPractico.Reportes.TipoPrenda();
            this.PrendaMarcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PrendaMarcaTableAdapter = new TrabajoPractico.Reportes.TipoPrendaTableAdapters.PrendaMarcaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TipoPrenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrendaMarcaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.PrendaMarcaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Reportes.Reporte2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(637, 324);
            this.reportViewer1.TabIndex = 0;
            // 
            // TipoPrenda
            // 
            this.TipoPrenda.DataSetName = "TipoPrenda";
            this.TipoPrenda.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PrendaMarcaBindingSource
            // 
            this.PrendaMarcaBindingSource.DataMember = "PrendaMarca";
            this.PrendaMarcaBindingSource.DataSource = this.TipoPrenda;
            // 
            // PrendaMarcaTableAdapter
            // 
            this.PrendaMarcaTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportePrendaMarca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 324);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportePrendaMarca";
            this.Text = "frmReportePrendaMarca";
            this.Load += new System.EventHandler(this.frmReportePrendaMarca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TipoPrenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrendaMarcaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PrendaMarcaBindingSource;
        private TipoPrenda TipoPrenda;
        private TipoPrendaTableAdapters.PrendaMarcaTableAdapter PrendaMarcaTableAdapter;
    }
}