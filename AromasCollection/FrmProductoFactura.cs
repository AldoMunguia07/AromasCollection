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
        FrmFactura factura1;
        private bool seleccionado = false;
        public FrmProductoFactura(FrmFactura factura)
        {
            InitializeComponent();
            producto.Mostrar(dgProductos, 1);
            factura1 = factura;
          dgProductos.Columns["idCategoria"].Visible = false;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

             if(seleccionado)
             {
                
                factura1.RecuperarValorAlCerrar(producto);

                 
                 this.Close();
             }
             else
             {
                 MessageBox.Show("Seleccione primero un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
           
           



        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            producto.BuscarProducto(dgProductos, txtBuscar.Text, 1);
        }

        private void dgProductos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgProductos.Rows[e.RowIndex];

                
                
                producto.IdProducto = int.Parse(row.Cells["Codigo"].Value.ToString());
                producto.NombreProducto = row.Cells["Producto"].Value.ToString();
                producto.PrecioDetalle = float.Parse(row.Cells["Precio detalle"].Value.ToString());
                producto.PrecioMayorista = float.Parse(row.Cells["Precio mayorista"].Value.ToString());
                producto.Existencia = int.Parse(row.Cells["Existencia"].Value.ToString());

                seleccionado = true;
            }
        }


        /*public void recuperarValores(Producto producto)
        {
           
        }*/
    }
}
