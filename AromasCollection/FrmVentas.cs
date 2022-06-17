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
        public FrmVentas()
        {
            InitializeComponent();
            factura.Mostrar(dgFacturas);

        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            
            new FrmFactura().ShowDialog();
            factura.Mostrar(dgFacturas);
        }

        private void btnDetalleVenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Comming soon...");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            factura.BuscarFactura(dgFacturas, txtBuscar.Text);
        }
    }
}
