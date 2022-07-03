namespace AromasCollection
{
    partial class FrmDetalleVenta
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
            this.label6 = new System.Windows.Forms.Label();
            this.dgDetalleFactura = new System.Windows.Forms.DataGridView();
            this.lblCodigoFactura = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTSub = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(30, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(594, 58);
            this.label6.TabIndex = 13;
            this.label6.Text = "Detalle de la Factura: N°\r\n";
            // 
            // dgDetalleFactura
            // 
            this.dgDetalleFactura.AllowUserToAddRows = false;
            this.dgDetalleFactura.AllowUserToDeleteRows = false;
            this.dgDetalleFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDetalleFactura.BackgroundColor = System.Drawing.Color.White;
            this.dgDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalleFactura.Location = new System.Drawing.Point(40, 116);
            this.dgDetalleFactura.Name = "dgDetalleFactura";
            this.dgDetalleFactura.ReadOnly = true;
            this.dgDetalleFactura.RowHeadersWidth = 62;
            this.dgDetalleFactura.Size = new System.Drawing.Size(923, 259);
            this.dgDetalleFactura.TabIndex = 14;
            // 
            // lblCodigoFactura
            // 
            this.lblCodigoFactura.AutoSize = true;
            this.lblCodigoFactura.Font = new System.Drawing.Font("Century Gothic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoFactura.ForeColor = System.Drawing.Color.White;
            this.lblCodigoFactura.Location = new System.Drawing.Point(615, 39);
            this.lblCodigoFactura.Name = "lblCodigoFactura";
            this.lblCodigoFactura.Size = new System.Drawing.Size(25, 58);
            this.lblCodigoFactura.TabIndex = 15;
            this.lblCodigoFactura.Text = "\r\n";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Century Gothic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.White;
            this.lblSubtotal.Location = new System.Drawing.Point(287, 400);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(25, 58);
            this.lblSubtotal.TabIndex = 17;
            this.lblSubtotal.Text = "\r\n";
            // 
            // lblTSub
            // 
            this.lblTSub.AutoSize = true;
            this.lblTSub.Font = new System.Drawing.Font("Century Gothic", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTSub.ForeColor = System.Drawing.Color.White;
            this.lblTSub.Location = new System.Drawing.Point(30, 400);
            this.lblTSub.Name = "lblTSub";
            this.lblTSub.Size = new System.Drawing.Size(267, 58);
            this.lblTSub.TabIndex = 16;
            this.lblTSub.Text = "SubTotal L.";
            // 
            // FrmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(84)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1000, 487);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblTSub);
            this.Controls.Add(this.lblCodigoFactura);
            this.Controls.Add(this.dgDetalleFactura);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmDetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetalleVenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalleFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgDetalleFactura;
        private System.Windows.Forms.Label lblCodigoFactura;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTSub;
    }
}