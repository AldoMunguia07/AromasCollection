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
    public partial class FrmProductoFactura : Form
    {
        Producto producto = new Producto();
        public FrmProductoFactura()
        {
            InitializeComponent();
            producto.Mostrar(dgProductos);
           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
         
   
            this.Close();
        }
    }
}
