namespace TrabajoPractico.Estadisticas
{
    partial class frmEstadisticaVentaTotal
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
            this.VentaTransaccionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsEst = new TrabajoPractico.Estadisticas.DsEst();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.VentaTransaccionTableAdapter = new TrabajoPractico.Estadisticas.DsEstTableAdapters.VentaTransaccionTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VentaTransaccionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsEst)).BeginInit();
            this.SuspendLayout();
            // 
            // VentaTransaccionBindingSource
            // 
            this.VentaTransaccionBindingSource.DataMember = "VentaTransaccion";
            this.VentaTransaccionBindingSource.DataSource = this.DsEst;
            // 
            // DsEst
            // 
            this.DsEst.DataSetName = "DsEst";
            this.DsEst.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.VentaTransaccionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Estadisticas.EstadisticaVentaTotal.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(540, 356);
            this.reportViewer1.TabIndex = 0;
            // 
            // VentaTransaccionTableAdapter
            // 
            this.VentaTransaccionTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(546, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmEstadisticaVentaTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEstadisticaVentaTotal";
            this.Text = "frmEstadisticaVentaTipo";
            this.Load += new System.EventHandler(this.frmEstadisticaVentaTipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VentaTransaccionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsEst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VentaTransaccionBindingSource;
        private DsEst DsEst;
        private DsEstTableAdapters.VentaTransaccionTableAdapter VentaTransaccionTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}