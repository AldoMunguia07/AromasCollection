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
            this.ndAnio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            this.cmbMeses = new System.Windows.Forms.ComboBox();
           
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // ndAnio
            // 
            this.ndAnio.Location = new System.Drawing.Point(458, 57);
            this.ndAnio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ndAnio.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.ndAnio.Name = "ndAnio";
            this.ndAnio.Size = new System.Drawing.Size(180, 26);
            this.ndAnio.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mes";
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(719, 48);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(190, 40);
            this.btnCargar.TabIndex = 8;
            this.btnCargar.Text = "Cargar reporte";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // cmbMeses
            // 
            this.cmbMeses.FormattingEnabled = true;
            this.cmbMeses.Location = new System.Drawing.Point(127, 55);
            this.cmbMeses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMeses.Name = "cmbMeses";
            this.cmbMeses.Size = new System.Drawing.Size(180, 28);
            this.cmbMeses.TabIndex = 7;
            // 
            // sp_TotVentasYUnidadesTableAdapter1
            // 
         
            // 
            // rFrmTotalVentasYUnidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 577);
            this.Controls.Add(this.ndAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.cmbMeses);
            this.Name = "rFrmTotalVentasYUnidades";
            this.Text = "Total de Ventas y Unidades";
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
      
    }
}