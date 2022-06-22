namespace AromasCollection
{
    partial class FrmProducto
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
            this.gbProductoInput = new System.Windows.Forms.GroupBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecioMayorista = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductoNombre = new System.Windows.Forms.TextBox();
            this.txtPrecioDetalle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgProducto = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnNuevoLote = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gbProductoInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // gbProductoInput
            // 
            this.gbProductoInput.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbProductoInput.Controls.Add(this.cmbCategoria);
            this.gbProductoInput.Controls.Add(this.label3);
            this.gbProductoInput.Controls.Add(this.txtPrecioMayorista);
            this.gbProductoInput.Controls.Add(this.txtDescripcion);
            this.gbProductoInput.Controls.Add(this.label2);
            this.gbProductoInput.Controls.Add(this.label6);
            this.gbProductoInput.Controls.Add(this.txtProductoNombre);
            this.gbProductoInput.Controls.Add(this.txtPrecioDetalle);
            this.gbProductoInput.Controls.Add(this.label5);
            this.gbProductoInput.Controls.Add(this.label1);
            this.gbProductoInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProductoInput.Location = new System.Drawing.Point(26, 12);
            this.gbProductoInput.Name = "gbProductoInput";
            this.gbProductoInput.Size = new System.Drawing.Size(277, 470);
            this.gbProductoInput.TabIndex = 0;
            this.gbProductoInput.TabStop = false;
            this.gbProductoInput.Text = "Aromas Collection";
            this.gbProductoInput.Enter += new System.EventHandler(this.gbProductoInput_Enter);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(10, 402);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(253, 28);
            this.cmbCategoria.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Categoria";
            // 
            // txtPrecioMayorista
            // 
            this.txtPrecioMayorista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioMayorista.Location = new System.Drawing.Point(10, 343);
            this.txtPrecioMayorista.Name = "txtPrecioMayorista";
            this.txtPrecioMayorista.Size = new System.Drawing.Size(253, 26);
            this.txtPrecioMayorista.TabIndex = 11;
            this.txtPrecioMayorista.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(10, 122);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(253, 118);
            this.txtDescripcion.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripcion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Precio de Mayorista";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtProductoNombre
            // 
            this.txtProductoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductoNombre.Location = new System.Drawing.Point(10, 61);
            this.txtProductoNombre.Name = "txtProductoNombre";
            this.txtProductoNombre.Size = new System.Drawing.Size(253, 26);
            this.txtProductoNombre.TabIndex = 1;
            // 
            // txtPrecioDetalle
            // 
            this.txtPrecioDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioDetalle.Location = new System.Drawing.Point(10, 277);
            this.txtPrecioDetalle.Name = "txtPrecioDetalle";
            this.txtPrecioDetalle.Size = new System.Drawing.Size(253, 26);
            this.txtPrecioDetalle.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Precio de Detalle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Producto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgProducto
            // 
            this.dgProducto.AllowUserToAddRows = false;
            this.dgProducto.AllowUserToDeleteRows = false;
            this.dgProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProducto.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducto.Location = new System.Drawing.Point(370, 12);
            this.dgProducto.MultiSelect = false;
            this.dgProducto.Name = "dgProducto";
            this.dgProducto.ReadOnly = true;
            this.dgProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProducto.Size = new System.Drawing.Size(706, 396);
            this.dgProducto.TabIndex = 1;
            this.dgProducto.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgProducto_CellMouseClick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(374, 424);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 25);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Location = new System.Drawing.Point(514, 423);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(119, 26);
            this.btnEditar.TabIndex = 17;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Location = new System.Drawing.Point(652, 424);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(119, 26);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnNuevoLote
            // 
            this.btnNuevoLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoLote.Location = new System.Drawing.Point(793, 423);
            this.btnNuevoLote.Name = "btnNuevoLote";
            this.btnNuevoLote.Size = new System.Drawing.Size(119, 26);
            this.btnNuevoLote.TabIndex = 19;
            this.btnNuevoLote.Text = "Nuevo Lote";
            this.btnNuevoLote.UseVisualStyleBackColor = true;
            this.btnNuevoLote.Click += new System.EventHandler(this.btnNuevoLote_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(931, 423);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 26);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(84)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1100, 612);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevoLote);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgProducto);
            this.Controls.Add(this.gbProductoInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProducto";
            this.Text = "FrmProducto";
            this.Load += new System.EventHandler(this.FrmProducto_Load);
            this.gbProductoInput.ResumeLayout(false);
            this.gbProductoInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProductoInput;
        private System.Windows.Forms.TextBox txtPrecioDetalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductoNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrecioMayorista;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnNuevoLote;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelar;
    }
}