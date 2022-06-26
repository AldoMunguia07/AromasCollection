using AromasCollection.Clases;
using System;
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
    public partial class FrmDetalleVenta : Form
    {
        DetalleFactura detalle = new DetalleFactura();
        public FrmDetalleVenta(int codigoFactura, double subtotal, bool esVenta)
        {
            InitializeComponent();
            detalle.Mostrar(dgDetalleFactura,codigoFactura);
            lblCodigoFactura.Text = codigoFactura.ToString();
            if (esVenta)
            {
                lblSubtotal.Text = subtotal.ToString();
            }
            else
            {
                lblTSub.Text = String.Empty;
            }


        }
    }
}
