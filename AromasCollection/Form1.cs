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
    public partial class Form1 : Form
    {
        Factura factura = new Factura();
        public Form1()
        {
            InitializeComponent();

            factura.IdFactura = 87;
            factura.CodigoSAR = 1;
            factura.IdColaborador = 2;
            factura.IdCliente = 1;
            factura.Observaciones = "El cliente me miró feo";

            factura.AgregarFactura(factura);

            
        }
    }
}
