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
        public FrmProductoFactura(FrmFactura factura)
        {
            InitializeComponent();
            producto.Mostrar(dgProductos);
            factura1 = factura;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

             if(dgProductos.SelectedRows.Count > 0)
             {
                producto.IdProducto = int.Parse(dgProductos.SelectedRows[0].Cells[0].Value.ToString());
                producto.nombreProducto = dgProductos.SelectedRows[0].Cells[1].Value.ToString();
                producto.precioDetalle = float.Parse(dgProductos.SelectedRows[0].Cells[3].Value.ToString());
                producto.precioMayorista = float.Parse(dgProductos.SelectedRows[0].Cells[4].Value.ToString());
                factura1.RecuperarValorAlCerrar(producto);

                 
                 this.Close();
             }
             else
             {
                 MessageBox.Show("Seleccione primero un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
           
           



        }


        /*public void recuperarValores(Producto producto)
        {
           
        }*/
    }
}
