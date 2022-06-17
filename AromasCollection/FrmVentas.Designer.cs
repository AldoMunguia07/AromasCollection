
namespace AromasCollection
{
    partial class FrmVentas
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
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.dgFacturas = new System.Windows.Forms.DataGridView();
            this.btnDetalleVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.Location = new System.Drawing.Point(25, 55);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(142, 28);
            this.btnNuevaVenta.TabIndex = 0;
            this.btnNuevaVenta.Text = "Nueva venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            this.btnNuevaVenta.Click += new System.EventHandler(this.btnNuevaVenta_Click);
            // 
            // dgFacturas
            // 
            this.dgFacturas.AllowUserToAddRows = false;
            this.dgFacturas.AllowUserToDeleteRows = false;
            this.dgFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFacturas.BackgroundColor = System.Drawing.Color.White;
            this.dgFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFacturas.Location = new System.Drawing.Point(12, 180);
            this.dgFacturas.Name = "dgFacturas";
            this.dgFacturas.ReadOnly = true;
            this.dgFacturas.Size = new System.Drawing.Size(1059, 233);
            this.dgFacturas.TabIndex = 1;
            // 
            // btnDetalleVenta
            // 
            this.btnDetalleVenta.Location = new System.Drawing.Point(206, 55);
            this.btnDetalleVenta.Name = "btnDetalleVenta";
            this.btnDetalleVenta.Size = new System.Drawing.Size(142, 28);
            this.btnDetalleVenta.TabIndex = 2;
            this.btnDetalleVenta.Text = "Ver detalle de la venta";
            this.btnDetalleVenta.UseVisualStyleBackColor = true;
            this.btnDetalleVenta.Click += new System.EventHandler(this.btnDetalleVenta_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(32, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(93, 133);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(353, 20);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(84)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1100, 612);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDetalleVenta);
            this.Controls.Add(this.dgFacturas);
            this.Controls.Add(this.btnNuevaVenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmVentas";
            this.Text = "FrmVentas";
            ((System.ComponentModel.ISupportInitialize)(this.dgFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaVenta;
        private System.Windows.Forms.DataGridView dgFacturas;
        private System.Windows.Forms.Button btnDetalleVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}