using System;
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
        public FrmCliente()
        {
            InitializeComponent();
            inicializarDatagrid();
            //factura.IdFactura = 87;
            //factura.CodigoSAR = 1;
            //factura.IdColaborador = 2;
            //factura.IdCliente = 1;
            //factura.Observaciones = "El cliente me miró feo";
            // factura.AgregarFactura(factura);   
        }
        private void inicializarDatagrid()
        {
            cliente.MostrarCliente(dgvCliente);
            dgvCliente.Columns["idCliente"].Visible = false;
        }
        private void ObtenerParametros()
        {
            cliente.Dni = txtID.Text;
            cliente.Rtn = txtRTN.Text;
            cliente.NombreCliente = txtNombre.Text;
            cliente.ApellidoCliente = txtApellido.Text;
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

                cliente.IdCliente = int.Parse(row.Cells["idCliente"].Value.ToString());
                txtID.Text = row.Cells["Identidad"].Value.ToString();
                txtRTN.Text = row.Cells["RTN"].Value.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value.ToString();

                selecionActiva = true;
                btnAgregar.Enabled = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cliente.BuscarCliente(dgvCliente, txtBuscar.Text);
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
    }
}
