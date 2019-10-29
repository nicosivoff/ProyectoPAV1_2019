namespace TrabajoPractico.Estadisticas
{
    partial class frmEstadisticaEmpleados
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
            this.dsEmpleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsEmpleados = new TrabajoPractico.dsEmpleados();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsClientes = new TrabajoPractico.dsClientes();
            this.dsClientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dsEmpleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsEmpleadosBindingSource
            // 
            this.dsEmpleadosBindingSource.DataSource = this.dsEmpleados;
            this.dsEmpleadosBindingSource.Position = 0;
            // 
            // dsEmpleados
            // 
            this.dsEmpleados.DataSetName = "dsEmpleados";
            this.dsEmpleados.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsEmpleados";
            reportDataSource1.Value = this.dsEmpleadosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Estadisticas.EstadisticaEmpleados.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(569, 504);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsClientes
            // 
            this.dsClientes.DataSetName = "dsClientes";
            this.dsClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsClientesBindingSource
            // 
            this.dsClientesBindingSource.DataSource = this.dsClientes;
            this.dsClientesBindingSource.Position = 0;
            // 
            // frmEstadisticaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 504);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEstadisticaEmpleados";
            this.Text = "EstadisticaEmpleados";
            this.Load += new System.EventHandler(this.EstadisticaEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsEmpleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsClientesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dsEmpleadosBindingSource;
        private dsEmpleados dsEmpleados;
        private dsClientes dsClientes;
        private System.Windows.Forms.BindingSource dsClientesBindingSource;

    }
}