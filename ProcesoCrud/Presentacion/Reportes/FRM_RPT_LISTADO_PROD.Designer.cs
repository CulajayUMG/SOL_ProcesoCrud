namespace ProcesoCrud.Presentacion.Reportes
{
    partial class FRM_RPT_LISTADO_PROD
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dS_Reportes = new ProcesoCrud.Presentacion.Reportes.DS_Reportes();
            this.dSReportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSPLISTADOPRODBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_LISTADO_PRODTableAdapter = new ProcesoCrud.Presentacion.Reportes.DS_ReportesTableAdapters.USP_LISTADO_PRODTableAdapter();
            this.txt_01 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPLISTADOPRODBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.uSPLISTADOPRODBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProcesoCrud.Presentacion.Reportes.Rpt_Listado_Prod.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(902, 650);
            this.reportViewer1.TabIndex = 0;
            // 
            // dS_Reportes
            // 
            this.dS_Reportes.DataSetName = "DS_Reportes";
            this.dS_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dSReportesBindingSource
            // 
            this.dSReportesBindingSource.DataSource = this.dS_Reportes;
            this.dSReportesBindingSource.Position = 0;
            // 
            // uSPLISTADOPRODBindingSource
            // 
            this.uSPLISTADOPRODBindingSource.DataMember = "USP_LISTADO_PROD";
            this.uSPLISTADOPRODBindingSource.DataSource = this.dSReportesBindingSource;
            // 
            // uSP_LISTADO_PRODTableAdapter
            // 
            this.uSP_LISTADO_PRODTableAdapter.ClearBeforeFill = true;
            // 
            // txt_01
            // 
            this.txt_01.Location = new System.Drawing.Point(28, 46);
            this.txt_01.Name = "txt_01";
            this.txt_01.Size = new System.Drawing.Size(165, 22);
            this.txt_01.TabIndex = 1;
            this.txt_01.Visible = false;
            // 
            // FRM_RPT_LISTADO_PROD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 650);
            this.Controls.Add(this.txt_01);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FRM_RPT_LISTADO_PROD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_RPT_LISTADO_PROD";
            this.Load += new System.EventHandler(this.FRM_RPT_LISTADO_PROD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_Reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPLISTADOPRODBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPLISTADOPRODBindingSource;
        private System.Windows.Forms.BindingSource dSReportesBindingSource;
        private DS_Reportes dS_Reportes;
        private DS_ReportesTableAdapters.USP_LISTADO_PRODTableAdapter uSP_LISTADO_PRODTableAdapter;
        internal System.Windows.Forms.TextBox txt_01;
    }
}