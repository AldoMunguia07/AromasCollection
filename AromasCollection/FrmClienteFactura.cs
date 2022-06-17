using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AromasCollection.Clases;

namespace AromasCollection
{
    public partial class FrmClienteFactura : Form
    {
        Cliente cliente = new Cliente();
        FrmFactura factura1;
        public FrmClienteFactura(FrmFactura factura)
        {
            InitializeComponent();
            cliente.Mostrar(dgClientes);
            ocultarColumnas();



            factura1 = factura;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgClientes.SelectedRows.Count > 0)
            {
                cliente.IdCliente = int.Parse(dgClientes.SelectedRows[0].Cells[0].Value.ToString());
                cliente.Rtn = dgClientes.SelectedRows[0].Cells[1].Value.ToString();
                cliente.NombreCliente = dgClientes.SelectedRows[0].Cells[3].Value.ToString();
                cliente.ApellidoCliente = dgClientes.SelectedRows[0].Cells[4].Value.ToString();


                factura1.RecuperarValorAlCerrarCliente(cliente);


                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione primero un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ocultarColumnas()
        {
            dgClientes.Columns[3].Visible = false;
            dgClientes.Columns[4].Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cliente.BuscarCliente(dgClientes, txtBuscar.Text);
            ocultarColumnas();
        }
    }
}
