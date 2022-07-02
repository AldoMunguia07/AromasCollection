namespace AromasCollection
{
    partial class rFrmTotalVentasYUnidades
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
            this.sp_TotVentasYUnidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AromasDBDataSet = new AromasCollection.AromasDBDataSet();
            this.ndAnio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.cmbMeses = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.sp_TotVentasYUnidadesTableAdapter = new AromasCollection.AromasDBDataSetTableAdapters.sp_TotVentasYUnidadesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sp_TotVentasYUnidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AromasDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_TotVentasYUnidadesBindingSource
            // 
            this.sp_TotVentasYUnidadesBindingSource.DataMember = "sp_TotVentasYUnidades";
            this.sp_TotVentasYUnidadesBindingSource.DataSource = this.AromasDBDataSet;
            // 
            // AromasDBDataSet
            // 
            this.AromasDBDataSet.DataSetName = "AromasDBDataSet";
            this.AromasDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ndAnio
            // 
            this.ndAnio.Location = new System.Drawing.Point(371, 18);
            this.ndAnio.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ndAnio.Name = "ndAnio";
            this.ndAnio.Size = new System.Drawing.Size(120, 20);
            this.ndAnio.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(335, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mes";
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(545, 12);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(127, 26);
            this.btnCargar.TabIndex = 8;
            this.btnCargar.Text = "Cargar reporte";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // cmbMeses
            // 
            this.cmbMeses.FormattingEnabled = true;
            this.cmbMeses.Location = new System.Drawing.Point(151, 17);
            this.cmbMeses.Name = "cmbMeses";
            this.cmbMeses.Size = new System.Drawing.Size(121, 21);
            this.cmbMeses.TabIndex = 7;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "TotalUnidadesVendidas";
            reportDataSource1.Value = this.sp_TotVentasYUnidadesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AromasCollection.Reportes.rptTotalUnidadesVendidas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 55);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1047, 505);
            this.reportViewer1.TabIndex = 12;
            // 
            // sp_TotVentasYUnidadesTableAdapter
            // 
            this.sp_TotVentasYUnidadesTableAdapter.ClearBeforeFill = true;
            // 
            // rFrmTotalVentasYUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1048, 561);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.ndAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.cmbMeses);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "rFrmTotalVentasYUnidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Total de Ventas y Unidades";
            this.Load += new System.EventHandler(this.rFrmTotalVentasYUnidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_TotVentasYUnidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AromasDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    

        private System.Windows.Forms.NumericUpDown ndAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ComboBox cmbMeses;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_TotVentasYUnidadesBindingSource;
        private AromasDBDataSet AromasDBDataSet;
        private AromasDBDataSetTableAdapters.sp_TotVentasYUnidadesTableAdapter sp_TotVentasYUnidadesTableAdapter;
    }
}