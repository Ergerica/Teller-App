namespace Teller
{
    partial class ReporteTransaccionesForm
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
            this.TellerLocalDataSet = new Teller.TellerLocalDataSet();
            this.tblTransaccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblTransaccionesTableAdapter = new Teller.TellerLocalDataSetTableAdapters.tblTransaccionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TellerLocalDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTransaccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetFinal";
            reportDataSource1.Value = this.tblTransaccionesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Teller.ReportTransacciones.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(807, 466);
            this.reportViewer1.TabIndex = 0;
            // 
            // TellerLocalDataSet
            // 
            this.TellerLocalDataSet.DataSetName = "TellerLocalDataSet";
            this.TellerLocalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblTransaccionesBindingSource
            // 
            this.tblTransaccionesBindingSource.DataMember = "tblTransacciones";
            this.tblTransaccionesBindingSource.DataSource = this.TellerLocalDataSet;
            // 
            // tblTransaccionesTableAdapter
            // 
            this.tblTransaccionesTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteTransaccionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 466);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteTransaccionesForm";
            this.Text = "ReporteTransaccionesForm";
            this.Load += new System.EventHandler(this.ReporteTransaccionesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TellerLocalDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblTransaccionesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblTransaccionesBindingSource;
        private TellerLocalDataSet TellerLocalDataSet;
        private TellerLocalDataSetTableAdapters.tblTransaccionesTableAdapter tblTransaccionesTableAdapter;
    }
}