﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using AromasCollection.Clases;

namespace AromasCollection
{
    public partial class FrmCliente : Form
    {
        Cliente cliente = new Cliente();
        Factura factura = new Factura();
        Validacion Validacion = new Validacion();
        bool selecionActiva = false;
        bool cargado = false;
        public FrmCliente(Colaborador colaborador)
        {
            InitializeComponent();
            inicializarDatagrid();
            cliente.CargarComboBoxEstado(cmbEstado);
            cliente.CargarComboBoxEstado(cmbEstados);
            cargado = true;
            cliente.IdColaborador = colaborador.IdColaborador; 
        }
        private void inicializarDatagrid()
        {
            cliente.MostrarCliente(dgvCliente, Convert.ToInt32(cmbEstado.SelectedValue));
            //dgvCliente.Columns["idCliente"].Visible = false;
            dgvCliente.Columns["Codigo"].Visible = false;
        }
        private void ObtenerParametros()
        {
            cliente.Dni = txtID.Text;
            cliente.Rtn = txtRTN.Text;
            cliente.NombreCliente = txtNombre.Text;
            cliente.ApellidoCliente = txtApellido.Text;
            cliente.Estado = Convert.ToBoolean(Convert.ToInt32(cmbEstados.SelectedValue));
        }
        private bool VerificarParametros()
        {
            if (!Validacion.verificarTextoLargo(txtID.Text, 15))
            {
                MessageBox.Show("Por favor, ingrese el numero de identidad del cliente.");
                return false;
            }

            if (!Validacion.verificarTextoLargo(txtRTN.Text, 15))
            {
                MessageBox.Show("Por favor, ingrese el RTN del cliente.");
                return false;
            }

            if (!Validacion.verificarTextoLargo(txtNombre.Text, 55))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente");
                return false;
            }

            if (!Validacion.verificarTextoLargo(txtApellido.Text, 55))
            {
                MessageBox.Show("Por favor, ingrese el apellido del cliente");
                return false;
            }

            return true;
        }
        private void Cleaner()
        {
            foreach (Control ctr in gbpClienteInput.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
            }
            btnAgregar.Enabled = true;
            inicializarDatagrid();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (VerificarParametros())
            {
                ObtenerParametros();
                cliente.AgregarCliente(cliente);
                Cleaner();
            }
        }
        private void MasterCleaner()
        {
            Cleaner();
            selecionActiva = false;
            btnAgregar.Enabled = true;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!selecionActiva)
            {
                MessageBox.Show("Por favor, selecione un cliente para modificar");
            }
            else
            {
                if (VerificarParametros())
                {
                    ObtenerParametros();
                    cliente.ModificarCliente(cliente);
                    MasterCleaner();
                }
            }

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Cleaner();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MasterCleaner();
        }

        private void dgvCliente_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCliente.Rows[e.RowIndex];

                cliente.IdCliente = int.Parse(row.Cells["Codigo"].Value.ToString());
                
                txtID.Text = row.Cells["Identidad"].Value.ToString();
                txtRTN.Text = row.Cells["RTN"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();
                cmbEstados.SelectedValue = Convert.ToInt32(row.Cells["Estado"].Value);

                selecionActiva = true;
                btnAgregar.Enabled = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cliente.BuscarCliente(dgvCliente, txtBuscar.Text, Convert.ToInt32(cmbEstado.SelectedValue));
            ocultarColumnas();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }
        private void txtRTN_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloNumeros(e);
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.SoloLetras(e);
        }

        private void ocultarColumnas()
        {
            dgvCliente.Columns[0].Visible = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (selecionActiva)
            {
                cliente.DesactivarCliente(cliente);
                MasterCleaner();
                inicializarDatagrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione un cliente para desactivar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                inicializarDatagrid();
            }
            if (Convert.ToInt32(cmbEstado.SelectedValue) == 0)
            {
                btnEliminar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
            }
        }
    }
}
