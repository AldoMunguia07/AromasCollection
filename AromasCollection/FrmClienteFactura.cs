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
        private bool seleccionado = false;
        public FrmClienteFactura(FrmFactura factura)
        {
            InitializeComponent();
            cliente.MostrarCliente(dgClientes, 1);
            dgClientes.Columns["nombreCliente"].Visible = false;
            dgClientes.Columns["apellidoCliente"].Visible = false;





            factura1 = factura;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (seleccionado)
            {
               

                factura1.RecuperarValorAlCerrarCliente(cliente);


                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione primero un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

   

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cliente.BuscarCliente(dgClientes, txtBuscar.Text, 1);
      
        }

        private void dgClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgClientes.Rows[e.RowIndex];



                cliente.IdCliente = int.Parse(row.Cells["Codigo"].Value.ToString());
                cliente.Rtn = row.Cells["RTN"].Value.ToString();
                cliente.NombreCliente = row.Cells["nombreCliente"].Value.ToString();
                cliente.ApellidoCliente = row.Cells["apellidoCliente"].Value.ToString();

                seleccionado = true;
            }
        }
    }
}
