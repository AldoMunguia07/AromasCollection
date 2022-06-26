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
    public partial class FrmVentas : Form
    {
        Factura factura = new Factura();

        Colaborador miColaborador = new Colaborador();

        int codigoFactura;
        double subtotal;
        bool esVenta;
        bool seleccionado = false;
        public FrmVentas(Colaborador colaborador)
        {
            InitializeComponent();
            factura.Mostrar(dgFacturas);

            miColaborador = colaborador;

        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            
            new FrmFactura(miColaborador).ShowDialog();
            factura.Mostrar(dgFacturas);
        }

        private void btnDetalleVenta_Click(object sender, EventArgs e)
        {
            if (seleccionado)
            {
                new FrmDetalleVenta(codigoFactura, subtotal, esVenta).ShowDialog();
                seleccionado = false;
            }
            else
            {
                MessageBox.Show("Debe de seleccionar una factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            factura.BuscarFactura(dgFacturas, txtBuscar.Text);
        }

        private void dgFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codigoFactura = Convert.ToInt32(dgFacturas.Rows[e.RowIndex].Cells["Código factura"].Value.ToString());
            subtotal = Convert.ToDouble(dgFacturas.Rows[e.RowIndex].Cells["Subtotal"].Value.ToString());
            if(subtotal == 0)
            {
                esVenta = false;
            }
            else
            {
                esVenta = true;
            }
            seleccionado = true;

        }
    }
}
