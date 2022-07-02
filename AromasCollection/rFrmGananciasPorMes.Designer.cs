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
            this.ndAnio = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).BeginInit();
            this.SuspendLayout();
            // 
            // ndAnio
            // 
            this.ndAnio.Location = new System.Drawing.Point(227, 36);
            this.ndAnio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ndAnio.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.ndAnio.Name = "ndAnio";
            this.ndAnio.Size = new System.Drawing.Size(180, 26);
            this.ndAnio.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Año";
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(496, 27);
            this.btnCargar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(190, 40);
            this.btnCargar.TabIndex = 7;
            this.btnCargar.Text = "Cargar reporte";
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // rFrmGananciasPorMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ndAnio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCargar);
            this.Name = "rFrmGananciasPorMes";
            this.Text = "rFrmGananciasPorMes";
            ((System.ComponentModel.ISupportInitialize)(this.ndAnio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ndAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCargar;
    }
}