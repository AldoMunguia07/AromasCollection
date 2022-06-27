﻿using System;
using AromasCollection.Clases;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AromasCollection
{
    public partial class FrmColaborador : Form
    {
        Colaborador colaborador = new Colaborador();
        Validacion Validacion = new Validacion();
        bool selecionActiva = false;
        public FrmColaborador(Colaborador uncolaborador)
        {
            InitializeComponent();
            InicializarDatagrid();
            colaborador.IdColaboradorSAR = uncolaborador.IdColaborador;
            colaborador.CargarComboBoxEstado(cmbColaboradorPuesto);

        }
        private void InicializarDatagrid()
        {
            colaborador.Mostrar(dgvColaborador);
            dgvColaborador.Columns["ID"].Visible = false;
        }
        private void ObtenerParametros()
        {
            colaborador.NombreColaborador = txtColaboradorNombre.Text;
            colaborador.ApellidoColaborador = txtColaboradorApellido.Text;
            colaborador.Correo = txtColaboradorCorreo.Text;
            colaborador.Usuario = txtColaboradorUsuario.Text;
            colaborador.Contrasenia = txtColaboradorContrasena.Text;
            colaborador.IdPuesto = int.Parse(cmbColaboradorPuesto.SelectedValue.ToString());
        }

        private void MasterCleaner()
        {
            Cleaner();
            selecionActiva = false;
            btnAgregar.Enabled = true;
        }
        private void Cleaner()
        {
            foreach (Control ctr in gbProductoInput.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
            }
            btnAgregar.Enabled = true;
            InicializarDatagrid();
        }
        private void FrmColaborador_Load(object sender, EventArgs e)
        {

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Cleaner();
        }
        private bool VerificarParametros()
        {
            if (!Validacion.verificarTextoLargo(txtColaboradorNombre.Text, 30))
            {
                MessageBox.Show("Por favor, ingrese el nombre de maximo 30 caracteres para el colaborador.");
                return false;
            }

            if (!Validacion.verificarTextoLargo(txtColaboradorApellido.Text, 30))
            {
                MessageBox.Show("Por favor, ingrese el apellido de maximo 30 caracteres para el colaborador.");
                return false;
            }

            if (!Validacion.verificarTextoLargo(txtColaboradorCorreo.Text, 50))
            {
                MessageBox.Show("Por favor, ingrese el correo de maximo 50 caracteres para el colaborador.");
                return false;
            }

            if (!Validacion.verificarTextoLargo(txtColaboradorUsuario.Text, 25))
            {
                MessageBox.Show("Por favor, ingrese el usuario de maximo 25 caracteres para el colaborador.");
                return false;
            }

            if (!Validacion.verificarTextoLargo(txtColaboradorContrasena.Text, 15))
            {
                MessageBox.Show("Por favor, ingrese la contraseña de maximo 15 caracteres para el colaborador.");
                return false;
            }

            return true;
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {        
                ObtenerParametros();
                colaborador.AgregarColaborador(colaborador);
                Cleaner();
        }

        private void txtColaboradorApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void txtColaboradorNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void dgvColaborador_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvColaborador.Rows[e.RowIndex];
                colaborador.IdColaborador = int.Parse(row.Cells["ID"].Value.ToString());
                txtColaboradorNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtColaboradorApellido.Text = row.Cells["Apellido"].Value.ToString();
                txtColaboradorCorreo.Text = row.Cells["Correo"].Value.ToString();
                txtColaboradorUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtColaboradorContrasena.Text = row.Cells["Contraseña"].Value.ToString();
                cmbColaboradorPuesto.Text= row.Cells["Puesto"].Value.ToString();
                selecionActiva = true;
                btnAgregar.Enabled = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (VerificarParametros())
            {

                if (!selecionActiva)
                {
                    MessageBox.Show("Por favor, selecione un cliente para modificar");
                }
                else
                {
                    ObtenerParametros();
                    colaborador.ModificarColaborador(colaborador);
                    MasterCleaner();
                }
            }       
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MasterCleaner();
        }
    }
}
