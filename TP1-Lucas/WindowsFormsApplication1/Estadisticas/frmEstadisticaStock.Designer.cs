﻿namespace TrabajoPractico.Estadisticas
{
    partial class frmEstadisticaStock
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
            this.prendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrenda = new TrabajoPractico.dsPrenda();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.prendaTableAdapter = new TrabajoPractico.dsPrendaTableAdapters.PrendaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.prendaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrenda)).BeginInit();
            this.SuspendLayout();
            // 
            // prendaBindingSource
            // 
            this.prendaBindingSource.DataMember = "Prenda";
            this.prendaBindingSource.DataSource = this.dsPrenda;
            // 
            // dsPrenda
            // 
            this.dsPrenda.DataSetName = "dsPrenda";
            this.dsPrenda.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.prendaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPractico.Estadisticas.EstadisticaPrendaStock.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(394, 314);
            this.reportViewer1.TabIndex = 0;
            // 
            // prendaTableAdapter
            // 
            this.prendaTableAdapter.ClearBeforeFill = true;
            // 
            // frmEstadisticaStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 314);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmEstadisticaStock";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prendaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsPrenda dsPrenda;
        private System.Windows.Forms.BindingSource prendaBindingSource;
        private dsPrendaTableAdapters.PrendaTableAdapter prendaTableAdapter;
    }
}