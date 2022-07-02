
namespace AromasCollection
{
    partial class rFrmVentasPorMes
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
            this.sp_VentasXMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AromasDBDataSet = new AromasCollection.AromasDBDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbMeses = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.sp_VentasXMesTableAdapter = new AromasCollection.AromasDBDataSetTableAdapters.sp_VentasXMesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ndAnio = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sp_VentasXMesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AromasDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_VentasXMesBindingSource
            // 
            this.sp_VentasXMesBindingSource.DataMember = "sp_VentasXMes";
            this.sp_VentasXMesBindingSource.DataSource = this.AromasDBDataSet;
            // 
            // AromasDBDataSet
            // 
            this.AromasDBDataSet.DataSetName = "AromasDBDataSet";
            this.AromasDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "VentasPorMes";
            reportDataSource1.Value = this.sp_VentasXMesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AromasCollection.Reportes.rptVentasPorMes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(4, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1045, 521);
            this.reportViewer1.TabIndex = 0;
            // 
            // cmbMeses
            // 
            this.cmbMeses.FormattingEnabled = true;
            this.cmbMeses.Location = new System.Drawing.Point(198, 10);
            this.cmbMeses.Name = "cmbMeses";
            this.cmbMeses.Size = new System.Drawing.Size(121, 21);
            this.cmbMeses.TabIndex = 2;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(671, 7);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(127, 26);
            this.btnCargar.TabIndex = 3;
            this.btnCargar.Text = "Cargar reporte";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // sp_VentasXMesTableAdapter
            // 
            this.sp_VentasXMesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Año";
            // 
            // ndAnio
            // 
            this.ndAnio.Location = new System.Drawing.Point(450, 10);
            this.ndAnio.Maximum = new decimal(new int[] {
            276447232,
            23283,
            0,
            0});
            this.ndAnio.Name = "ndAnio";
            this.ndAnio.Size = new System.Drawing.Size(120, 20);
            this.ndAnio.TabIndex = 6;
            // 
            // rFrmVentasPorMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1048, 561);
            this.Controls.Add(this.ndAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.cmbMeses);
            this.Controls.Add(this.reportViewer1);
            this.Name = "rFrmVentasPorMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rFrmVentasPorMes";
            this.Load += new System.EventHandler(this.rFrmVentasPorMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_VentasXMesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AromasDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_VentasXMesBindingSource;
        private AromasCollection.AromasDBDataSet AromasDBDataSet;
        private AromasCollection.AromasDBDataSetTableAdapters.sp_VentasXMesTableAdapter sp_VentasXMesTableAdapter;
        private System.Windows.Forms.ComboBox cmbMeses;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ndAnio;
    }
}