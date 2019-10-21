namespace TrabajoPractico.Reportes
{
    partial class frmReportePrendaTipo
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
            this.prendaTipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prendaTipoTableAdapter = new TrabajoPractico.Reportes.TipoPrendaTableAdapters.PrendaTipoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TipoPrenda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prendaTipoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Prenda";
            reportDataSource1.Value = this.prendaTipoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Reportes.Reporte1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(541, 446);
            this.reportViewer1.TabIndex = 0;
            // 
            // TipoPrenda
            // 
            this.TipoPrenda.DataSetName = "TipoPrenda";
            this.TipoPrenda.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // prendaTipoBindingSource
            // 
            this.prendaTipoBindingSource.DataMember = "PrendaTipo";
            this.prendaTipoBindingSource.DataSource = this.TipoPrenda;
            // 
            // prendaTipoTableAdapter
            // 
            this.prendaTipoTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportePrendaTipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 446);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReportePrendaTipo";
            this.Text = "frmReportePrendaTipo";
            this.Load += new System.EventHandler(this.frmReportePrendaTipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TipoPrenda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prendaTipoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private TipoPrenda TipoPrenda;
        private System.Windows.Forms.BindingSource prendaTipoBindingSource;
        private TipoPrendaTableAdapters.PrendaTipoTableAdapter prendaTipoTableAdapter;
    }
}