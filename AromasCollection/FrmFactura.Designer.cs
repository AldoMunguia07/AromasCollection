
namespace AromasCollection
{
    partial class FrmFactura
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMayorista = new System.Windows.Forms.RadioButton();
            this.rbDetalle = new System.Windows.Forms.RadioButton();
            this.btnProducto = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.numCantidad = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCliente = new System.Windows.Forms.Button();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtNumFactura = new System.Windows.Forms.TextBox();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgCarrito = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtISV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numDescuento = new System.Windows.Forms.NumericUpDown();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbEnviosMall = new System.Windows.Forms.RadioButton();
            this.rbOtros = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCantidadNumerosDisponibles = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMayorista);
            this.groupBox1.Controls.Add(this.rbDetalle);
            this.groupBox1.Controls.Add(this.btnProducto);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.txtProducto);
            this.groupBox1.Controls.Add(this.numCantidad);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(784, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(744, 311);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar al carrito";
            // 
            // rbMayorista
            // 
            this.rbMayorista.AutoSize = true;
            this.rbMayorista.Location = new System.Drawing.Point(574, 112);
            this.rbMayorista.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMayorista.Name = "rbMayorista";
            this.rbMayorista.Size = new System.Drawing.Size(150, 24);
            this.rbMayorista.TabIndex = 17;
            this.rbMayorista.TabStop = true;
            this.rbMayorista.Text = "Precio mayorista";
            this.rbMayorista.UseVisualStyleBackColor = true;
            // 
            // rbDetalle
            // 
            this.rbDetalle.AutoSize = true;
            this.rbDetalle.Location = new System.Drawing.Point(412, 112);
            this.rbDetalle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbDetalle.Name = "rbDetalle";
            this.rbDetalle.Size = new System.Drawing.Size(129, 24);
            this.rbDetalle.TabIndex = 16;
            this.rbDetalle.TabStop = true;
            this.rbDetalle.Text = "Precio detalle";
            this.rbDetalle.UseVisualStyleBackColor = true;
            // 
            // btnProducto
            // 
            this.btnProducto.Location = new System.Drawing.Point(495, 38);
            this.btnProducto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(112, 35);
            this.btnProducto.TabIndex = 10;
            this.btnProducto.Text = "Producto";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(244, 194);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(159, 51);
            this.btnQuitar.TabIndex = 15;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Producto";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(34, 194);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(164, 51);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(170, 42);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(314, 26);
            this.txtProducto.TabIndex = 4;
            // 
            // numCantidad
            // 
            this.numCantidad.Location = new System.Drawing.Point(170, 108);
            this.numCantidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numCantidad.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCantidad.Name = "numCantidad";
            this.numCantidad.Size = new System.Drawing.Size(180, 26);
            this.numCantidad.TabIndex = 5;
            this.numCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cantidad";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCliente);
            this.groupBox2.Controls.Add(this.txtObservaciones);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtCliente);
            this.groupBox2.Controls.Add(this.txtNumFactura);
            this.groupBox2.Controls.Add(this.txtCodigoCliente);
            this.groupBox2.Location = new System.Drawing.Point(20, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(711, 311);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Factura";
            // 
            // btnCliente
            // 
            this.btnCliente.Location = new System.Drawing.Point(522, 94);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(112, 35);
            this.btnCliente.TabIndex = 9;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(196, 180);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(314, 62);
            this.txtObservaciones.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Número de factura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Observaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(255, 98);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(256, 26);
            this.txtCliente.TabIndex = 2;
            // 
            // txtNumFactura
            // 
            this.txtNumFactura.Location = new System.Drawing.Point(196, 28);
            this.txtNumFactura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumFactura.Name = "txtNumFactura";
            this.txtNumFactura.ReadOnly = true;
            this.txtNumFactura.Size = new System.Drawing.Size(314, 26);
            this.txtNumFactura.TabIndex = 1;
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(196, 98);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.ReadOnly = true;
            this.txtCodigoCliente.Size = new System.Drawing.Size(48, 26);
            this.txtCodigoCliente.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.lblCantidadNumerosDisponibles);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1551, 380);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(0, 377);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1678, 517);
            this.panel2.TabIndex = 1;
            // 
            // dgCarrito
            // 
            this.dgCarrito.AllowUserToAddRows = false;
            this.dgCarrito.AllowUserToDeleteRows = false;
            this.dgCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Product,
            this.Precio,
            this.Cantidad,
            this.Total});
            this.dgCarrito.Location = new System.Drawing.Point(18, 382);
            this.dgCarrito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgCarrito.Name = "dgCarrito";
            this.dgCarrito.ReadOnly = true;
            this.dgCarrito.RowHeadersWidth = 62;
            this.dgCarrito.Size = new System.Drawing.Size(1509, 343);
            this.dgCarrito.TabIndex = 1;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 8;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.HeaderText = "Producto";
            this.Product.MinimumWidth = 8;
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 8;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 8;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 8;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(44, 777);
            this.btnFacturar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(232, 60);
            this.btnFacturar.TabIndex = 16;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(819, 768);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Descuento";
            // 
            // txtISV
            // 
            this.txtISV.Location = new System.Drawing.Point(986, 792);
            this.txtISV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtISV.Name = "txtISV";
            this.txtISV.ReadOnly = true;
            this.txtISV.Size = new System.Drawing.Size(110, 26);
            this.txtISV.TabIndex = 7;
            this.txtISV.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1023, 768);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "ISV";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(1170, 792);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(110, 26);
            this.txtSubtotal.TabIndex = 8;
            this.txtSubtotal.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1191, 768);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Subtotal";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(1358, 792);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(110, 26);
            this.txtTotal.TabIndex = 9;
            this.txtTotal.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1390, 768);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Total";
            // 
            // numDescuento
            // 
            this.numDescuento.Location = new System.Drawing.Point(806, 792);
            this.numDescuento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numDescuento.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numDescuento.Name = "numDescuento";
            this.numDescuento.Size = new System.Drawing.Size(112, 26);
            this.numDescuento.TabIndex = 23;
            this.numDescuento.ValueChanged += new System.EventHandler(this.numDescuento_ValueChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(308, 797);
            this.rbNormal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(129, 24);
            this.rbNormal.TabIndex = 24;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Venta normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbEnviosMall
            // 
            this.rbEnviosMall.AutoSize = true;
            this.rbEnviosMall.Location = new System.Drawing.Point(447, 797);
            this.rbEnviosMall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbEnviosMall.Name = "rbEnviosMall";
            this.rbEnviosMall.Size = new System.Drawing.Size(113, 24);
            this.rbEnviosMall.TabIndex = 25;
            this.rbEnviosMall.TabStop = true;
            this.rbEnviosMall.Text = "Envios mall";
            this.rbEnviosMall.UseVisualStyleBackColor = true;
            this.rbEnviosMall.CheckedChanged += new System.EventHandler(this.rbEnviosMall_CheckedChanged);
            // 
            // rbOtros
            // 
            this.rbOtros.AutoSize = true;
            this.rbOtros.Location = new System.Drawing.Point(578, 797);
            this.rbOtros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbOtros.Name = "rbOtros";
            this.rbOtros.Size = new System.Drawing.Size(73, 24);
            this.rbOtros.TabIndex = 26;
            this.rbOtros.TabStop = true;
            this.rbOtros.Text = "Otros";
            this.rbOtros.UseVisualStyleBackColor = true;
            this.rbOtros.CheckedChanged += new System.EventHandler(this.rbOtros_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(540, 352);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(259, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Números disponibles para facturar: ";
            // 
            // lblCantidadNumerosDisponibles
            // 
            this.lblCantidadNumerosDisponibles.AutoSize = true;
            this.lblCantidadNumerosDisponibles.Location = new System.Drawing.Point(802, 351);
            this.lblCantidadNumerosDisponibles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadNumerosDisponibles.Name = "lblCantidadNumerosDisponibles";
            this.lblCantidadNumerosDisponibles.Size = new System.Drawing.Size(0, 20);
            this.lblCantidadNumerosDisponibles.TabIndex = 11;
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1546, 900);
            this.Controls.Add(this.rbOtros);
            this.Controls.Add(this.rbEnviosMall);
            this.Controls.Add(this.rbNormal);
            this.Controls.Add(this.numDescuento);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtISV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.dgCarrito);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidad)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.NumericUpDown numCantidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtNumFactura;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgCarrito;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtISV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.NumericUpDown numDescuento;
        private System.Windows.Forms.RadioButton rbMayorista;
        private System.Windows.Forms.RadioButton rbDetalle;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbEnviosMall;
        private System.Windows.Forms.RadioButton rbOtros;
        private System.Windows.Forms.Label lblCantidadNumerosDisponibles;
        private System.Windows.Forms.Label label10;
    }
}