
namespace AromasCollection
{
    partial class FrmColaborador
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbProductoInput = new System.Windows.Forms.GroupBox();
            this.txtColaboradorContrasena = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColaboradorApellido = new System.Windows.Forms.TextBox();
            this.cmbColaboradorPuesto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColaboradorCorreo = new System.Windows.Forms.TextBox();
            this.txtColaboradorUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtColaboradorNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvColaborador = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lbBuscar = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbVerEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.gbProductoInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaborador)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(629, 515);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(119, 26);
            this.btnLimpiar.TabIndex = 23;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(491, 514);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(119, 26);
            this.btnEditar.TabIndex = 22;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(351, 515);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(119, 25);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbProductoInput
            // 
            this.gbProductoInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(84)))), ((int)(((byte)(135)))));
            this.gbProductoInput.Controls.Add(this.label8);
            this.gbProductoInput.Controls.Add(this.cmbEstado);
            this.gbProductoInput.Controls.Add(this.txtColaboradorContrasena);
            this.gbProductoInput.Controls.Add(this.label4);
            this.gbProductoInput.Controls.Add(this.txtColaboradorApellido);
            this.gbProductoInput.Controls.Add(this.cmbColaboradorPuesto);
            this.gbProductoInput.Controls.Add(this.label3);
            this.gbProductoInput.Controls.Add(this.txtColaboradorCorreo);
            this.gbProductoInput.Controls.Add(this.txtColaboradorUsuario);
            this.gbProductoInput.Controls.Add(this.label2);
            this.gbProductoInput.Controls.Add(this.label6);
            this.gbProductoInput.Controls.Add(this.txtColaboradorNombre);
            this.gbProductoInput.Controls.Add(this.label5);
            this.gbProductoInput.Controls.Add(this.label1);
            this.gbProductoInput.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProductoInput.ForeColor = System.Drawing.Color.White;
            this.gbProductoInput.Location = new System.Drawing.Point(40, 71);
            this.gbProductoInput.Name = "gbProductoInput";
            this.gbProductoInput.Size = new System.Drawing.Size(277, 470);
            this.gbProductoInput.TabIndex = 19;
            this.gbProductoInput.TabStop = false;
            this.gbProductoInput.Text = "Aromas Collection";
            // 
            // txtColaboradorContrasena
            // 
            this.txtColaboradorContrasena.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColaboradorContrasena.Location = new System.Drawing.Point(10, 305);
            this.txtColaboradorContrasena.Name = "txtColaboradorContrasena";
            this.txtColaboradorContrasena.Size = new System.Drawing.Size(253, 27);
            this.txtColaboradorContrasena.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Contraseña";
            // 
            // txtColaboradorApellido
            // 
            this.txtColaboradorApellido.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColaboradorApellido.Location = new System.Drawing.Point(10, 111);
            this.txtColaboradorApellido.Name = "txtColaboradorApellido";
            this.txtColaboradorApellido.Size = new System.Drawing.Size(253, 27);
            this.txtColaboradorApellido.TabIndex = 14;
            this.txtColaboradorApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColaboradorApellido_KeyPress);
            // 
            // cmbColaboradorPuesto
            // 
            this.cmbColaboradorPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColaboradorPuesto.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbColaboradorPuesto.FormattingEnabled = true;
            this.cmbColaboradorPuesto.Location = new System.Drawing.Point(10, 370);
            this.cmbColaboradorPuesto.Name = "cmbColaboradorPuesto";
            this.cmbColaboradorPuesto.Size = new System.Drawing.Size(253, 29);
            this.cmbColaboradorPuesto.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 344);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Puesto";
            // 
            // txtColaboradorCorreo
            // 
            this.txtColaboradorCorreo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColaboradorCorreo.Location = new System.Drawing.Point(10, 177);
            this.txtColaboradorCorreo.Name = "txtColaboradorCorreo";
            this.txtColaboradorCorreo.Size = new System.Drawing.Size(253, 27);
            this.txtColaboradorCorreo.TabIndex = 9;
            // 
            // txtColaboradorUsuario
            // 
            this.txtColaboradorUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColaboradorUsuario.Location = new System.Drawing.Point(10, 243);
            this.txtColaboradorUsuario.Name = "txtColaboradorUsuario";
            this.txtColaboradorUsuario.Size = new System.Drawing.Size(253, 27);
            this.txtColaboradorUsuario.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Usuario";
            // 
            // txtColaboradorNombre
            // 
            this.txtColaboradorNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColaboradorNombre.Location = new System.Drawing.Point(10, 50);
            this.txtColaboradorNombre.Name = "txtColaboradorNombre";
            this.txtColaboradorNombre.Size = new System.Drawing.Size(253, 27);
            this.txtColaboradorNombre.TabIndex = 1;
            this.txtColaboradorNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColaboradorNombre_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Correo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre ";
            // 
            // dgvColaborador
            // 
            this.dgvColaborador.AllowUserToAddRows = false;
            this.dgvColaborador.AllowUserToDeleteRows = false;
            this.dgvColaborador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColaborador.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvColaborador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColaborador.Location = new System.Drawing.Point(332, 109);
            this.dgvColaborador.MultiSelect = false;
            this.dgvColaborador.Name = "dgvColaborador";
            this.dgvColaborador.ReadOnly = true;
            this.dgvColaborador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColaborador.Size = new System.Drawing.Size(706, 396);
            this.dgvColaborador.TabIndex = 24;
            this.dgvColaborador.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvColaborador_CellMouseClick);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(896, 516);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 25);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(401, 78);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(458, 26);
            this.txtBuscar.TabIndex = 29;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lbBuscar
            // 
            this.lbBuscar.AutoSize = true;
            this.lbBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBuscar.ForeColor = System.Drawing.Color.White;
            this.lbBuscar.Location = new System.Drawing.Point(332, 80);
            this.lbBuscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBuscar.Name = "lbBuscar";
            this.lbBuscar.Size = new System.Drawing.Size(70, 20);
            this.lbBuscar.TabIndex = 28;
            this.lbBuscar.Text = "Buscar:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(861, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 31;
            this.label7.Text = "Estado";
            // 
            // cmbVerEstado
            // 
            this.cmbVerEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVerEstado.FormattingEnabled = true;
            this.cmbVerEstado.Location = new System.Drawing.Point(926, 80);
            this.cmbVerEstado.Name = "cmbVerEstado";
            this.cmbVerEstado.Size = new System.Drawing.Size(112, 21);
            this.cmbVerEstado.TabIndex = 30;
            this.cmbVerEstado.SelectedIndexChanged += new System.EventHandler(this.cmbVerEstado_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(10, 424);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(253, 29);
            this.cmbEstado.TabIndex = 17;
            this.cmbEstado.SelectedIndexChanged += new System.EventHandler(this.cmbEstado_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(22)))), ((int)(((byte)(46)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(761, 515);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(119, 26);
            this.btnEliminar.TabIndex = 32;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FrmColaborador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(84)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(1100, 662);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbVerEstado);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lbBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvColaborador);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gbProductoInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmColaborador";
            this.Text = "FrmColaborador";
            this.Load += new System.EventHandler(this.FrmColaborador_Load);
            this.gbProductoInput.ResumeLayout(false);
            this.gbProductoInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColaborador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.GroupBox gbProductoInput;
        private System.Windows.Forms.ComboBox cmbColaboradorPuesto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColaboradorUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtColaboradorNombre;
        private System.Windows.Forms.TextBox txtColaboradorCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtColaboradorContrasena;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtColaboradorApellido;
        private System.Windows.Forms.DataGridView dgvColaborador;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lbBuscar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbVerEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnEliminar;
    }
}