
namespace AromasCollection
{
    partial class FrmReportes
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
            this.btnVentasPorMes = new System.Windows.Forms.Button();
            this.btnGananciasPorMes = new System.Windows.Forms.Button();
            this.btnTotalUnidadesVendidas = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVentasPorMes
            // 
            this.btnVentasPorMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnVentasPorMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVentasPorMes.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasPorMes.ForeColor = System.Drawing.Color.White;
            this.btnVentasPorMes.Location = new System.Drawing.Point(197, 131);
            this.btnVentasPorMes.Name = "btnVentasPorMes";
            this.btnVentasPorMes.Size = new System.Drawing.Size(277, 215);
            this.btnVentasPorMes.TabIndex = 0;
            this.btnVentasPorMes.Text = "Ventas por mes";
            this.btnVentasPorMes.UseVisualStyleBackColor = false;
            this.btnVentasPorMes.Click += new System.EventHandler(this.btnVentasPorMes_Click);
            // 
            // btnGananciasPorMes
            // 
            this.btnGananciasPorMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnGananciasPorMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGananciasPorMes.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGananciasPorMes.ForeColor = System.Drawing.Color.White;
            this.btnGananciasPorMes.Location = new System.Drawing.Point(553, 131);
            this.btnGananciasPorMes.Name = "btnGananciasPorMes";
            this.btnGananciasPorMes.Size = new System.Drawing.Size(277, 215);
            this.btnGananciasPorMes.TabIndex = 1;
            this.btnGananciasPorMes.Text = "Ganancias por mes";
            this.btnGananciasPorMes.UseVisualStyleBackColor = false;
            this.btnGananciasPorMes.Click += new System.EventHandler(this.btnGananciasPorMes_Click);
            // 
            // btnTotalUnidadesVendidas
            // 
            this.btnTotalUnidadesVendidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnTotalUnidadesVendidas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTotalUnidadesVendidas.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalUnidadesVendidas.ForeColor = System.Drawing.Color.White;
            this.btnTotalUnidadesVendidas.Location = new System.Drawing.Point(197, 391);
            this.btnTotalUnidadesVendidas.Name = "btnTotalUnidadesVendidas";
            this.btnTotalUnidadesVendidas.Size = new System.Drawing.Size(277, 215);
            this.btnTotalUnidadesVendidas.TabIndex = 2;
            this.btnTotalUnidadesVendidas.Text = "Total unidades vendidas";
            this.btnTotalUnidadesVendidas.UseVisualStyleBackColor = false;
            this.btnTotalUnidadesVendidas.Click += new System.EventHandler(this.btnTotalUnidadesVendidas_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStock.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.Location = new System.Drawing.Point(553, 391);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(277, 215);
            this.btnStock.TabIndex = 3;
            this.btnStock.Text = "Total existencia de productos";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(395, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 58);
            this.label6.TabIndex = 13;
            this.label6.Text = "Reportes";
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(84)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1093, 662);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnTotalUnidadesVendidas);
            this.Controls.Add(this.btnGananciasPorMes);
            this.Controls.Add(this.btnVentasPorMes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVentasPorMes;
        private System.Windows.Forms.Button btnGananciasPorMes;
        private System.Windows.Forms.Button btnTotalUnidadesVendidas;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Label label6;
    }
}