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
    public partial class FrmFactura : Form
    {
        int code = 0;
        public FrmFactura()
        {
            InitializeComponent();
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            code += 1;
            float precio = 50;
            float total = precio * float.Parse(numCantidad.Value.ToString());
            dgCarrito.Rows.Add(code, txtProducto.Text, numCantidad.Value, total);
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if(dgCarrito.Rows.Count > 0)
            {
                dgCarrito.Rows.Remove(dgCarrito.Rows[dgCarrito.SelectedCells[0].RowIndex]);
            }
            

           /* for (int i = 0; i < dgCarrito.SelectedRows.Count; i++)
            {
                dgCarrito.Rows.Remove(dgCarrito.SelectedRows[i]);
            }*/

            
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
          
           new FrmProductoFactura().ShowDialog();
                 
        }
    }
}
