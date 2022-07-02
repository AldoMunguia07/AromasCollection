namespace AromasCollection
{
    partial class rFrmGananciasPorMes
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
            this.sp_GananciasXMesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AromasDBDataSet = new AromasCollection.AromasDBDataSet();
            this.ndAnio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_GananciasXMesTableAdapter = new AromasCollection.AromasDBDataSetTableAdapters.sp_GananciasXMesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_GananciasXMesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AromasDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_GananciasXMesBindingSource
            // 
            this.sp_GananciasXMesBindingSource.DataMember = "sp_GananciasXMes";
            this.sp_GananciasXMesBindingSource.DataSource = this.AromasDBDataSet;
            // 
            // AromasDBDataSet
            // 
            this.AromasDBDataSet.DataSetName = "AromasDBDataSet";
            this.AromasDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ndAnio
            // 
            this.ndAnio.Location = new System.Drawing.Point(335, 17);
            this.ndAnio.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndAnio.Name = "ndAnio";
            this.ndAnio.Size = new System.Drawing.Size(120, 20);
            this.ndAnio.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(295, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Año";
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(515, 12);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(127, 26);
            this.btnCargar.TabIndex = 7;
            this.btnCargar.Text = "Cargar reporte";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "GananciasPorMes";
            reportDataSource1.Value = this.sp_GananciasXMesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AromasCollection.Reportes.rptGananciasPorMes.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1045, 510);
            this.reportViewer1.TabIndex = 10;
            // 
            // sp_GananciasXMesTableAdapter
            // 
            this.sp_GananciasXMesTableAdapter.ClearBeforeFill = true;
            // 
            // rFrmGananciasPorMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1048, 561);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.ndAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCargar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "rFrmGananciasPorMes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "rFrmGananciasPorMes";
            this.Load += new System.EventHandler(this.rFrmGananciasPorMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_GananciasXMesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AromasDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ndAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCargar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_GananciasXMesBindingSource;
        private AromasDBDataSet AromasDBDataSet;
        private AromasDBDataSetTableAdapters.sp_GananciasXMesTableAdapter sp_GananciasXMesTableAdapter;
    }
}