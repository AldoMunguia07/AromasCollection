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
      
        Producto producto = new Producto();
        Factura factura = new Factura();
        DetalleFactura detalleFactura = new DetalleFactura();
        public FrmFactura()
        {
            InitializeComponent();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo = producto.IdProducto;
            float precio = producto.precioDetalle;
            float total = precio * float.Parse(numCantidad.Value.ToString());
            dgCarrito.Rows.Add(codigo, txtProducto.Text, precio, numCantidad.Value, total);
            limpiarAggProducto();
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


           FrmProductoFactura frmProductoFactura = new FrmProductoFactura(this);
            frmProductoFactura.ShowDialog();
            if(producto.IdProducto.ToString() != null)
            {
                txtProducto.Text = producto.nombreProducto;
            }
            
                 
        }

        public void RecuperarValorAlCerrar(Producto product)
        {
            producto = product;
        }

        public void limpiarAggProducto()
        {
            txtProducto.Clear();
            numCantidad.Value = 0;
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            obtenerValores();
            factura.AgregarFactura(factura);


            detalleFactura.IdFactura = factura.IdFactura;
            detalleFactura.CodigoSAR = factura.CodigoSAR;
            

            for (int i = 0; i < dgCarrito.Rows.Count; i++)
            {

                detalleFactura.IdProducto = Convert.ToInt32(dgCarrito.Rows[i].Cells[0].Value);
                detalleFactura.Precio = float.Parse(dgCarrito.Rows[i].Cells[2].Value.ToString());
                detalleFactura.Cantidad = Convert.ToInt32(dgCarrito.Rows[i].Cells[3].Value);
                detalleFactura.AgregarFactura(detalleFactura);
             
            }



        }

        private void obtenerValores()
        {
            factura.IdFactura = 1;
            factura.CodigoSAR = 1;
            factura.IdColaborador = 2;
            factura.IdCliente = int.Parse(txtRtn.Text);
            factura.FechaVenta = DateTime.Now;
            factura.Observaciones = txtObservaciones.Text;
        }
    }
}
