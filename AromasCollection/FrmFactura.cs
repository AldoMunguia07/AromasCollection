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
        Cliente cliente = new Cliente();
        Factura factura = new Factura();
        DetalleFactura detalleFactura = new DetalleFactura();
        public FrmFactura()
        {
            InitializeComponent();
            rbDetalle.Checked = true;
            rbNormal.Checked = true;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(camposLlenosCarrito())
            {
                for (int i = 0; i < dgCarrito.Rows.Count; i++)
                {
                    if (producto.IdProducto == Convert.ToInt32(dgCarrito.Rows[i].Cells[0].Value))
                    {
                        MessageBox.Show("El producto ya está agregado al carrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        limpiarAggProducto();
                        return;
                    }
                }

                if (producto.Existencia >= numCantidad.Value)
                {
                    int codigo = producto.IdProducto;
                    float precio = 0;

                    if(rbDetalle.Checked)
                    {
                        precio = producto.precioDetalle;
                    }
                    else if(rbMayorista.Checked)
                    {
                        precio = producto.precioMayorista;
                    }

                    float total = precio * float.Parse(numCantidad.Value.ToString());
                    dgCarrito.Rows.Add(codigo, txtProducto.Text, precio, numCantidad.Value, total);
                    limpiarAggProducto();
                    calculos();

                }
                else
                {
                    MessageBox.Show("Cantidad en inventario insuficiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if(dgCarrito.Rows.Count > 0)
            {
                dgCarrito.Rows.Remove(dgCarrito.Rows[dgCarrito.SelectedCells[0].RowIndex]);
                calculos();
            }
            else
            {
                MessageBox.Show("Seleccione producto a quitar del carrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void RecuperarValorAlCerrarCliente(Cliente client)
        {
            cliente = client;
        }

        public void limpiarAggProducto()
        {
            txtProducto.Clear();
            numCantidad.Value = 1;
        }

        private void agregar()
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
                detalleFactura.AgregarDetalleFactura(detalleFactura);

            }

            MessageBox.Show("Venta realizada", "Aromas Colllection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if(camposLlenosFactura())
            {
                if (dgCarrito.Rows.Count > 0)
                {
                    if(rbEnviosMall.Checked)
                    {
                        if (int.Parse(txtCodigoCliente.Text) == 1)
                        {
                            agregar();
                        }
                        else
                        {
                            MessageBox.Show("Debe elegir el codigo 1 del cliente (Envios Mall)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if(rbOtros.Checked)
                    {
                        if (int.Parse(txtCodigoCliente.Text) == 2)
                        {
                            agregar();
                        }
                        else
                        {
                            MessageBox.Show("Debe elegir el codigo 2 del cliente (Otras Salidas)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        agregar();

                    }
                    
 

                }
                else
                {
                    MessageBox.Show("Debe añadir productos al carrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }
            else
            {
                MessageBox.Show("Debe llenar los datos de la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void obtenerValores()
        {
            factura.IdFactura = int.Parse(txtNumFactura.Text);
            factura.CodigoSAR = 1;
            factura.IdColaborador = 1;
            factura.IdCliente = int.Parse(txtCodigoCliente.Text);
            factura.FechaVenta = DateTime.Now;
            factura.Descuento = int.Parse(numDescuento.Value.ToString());
            if(rbNormal.Checked)
            {
                factura.EsVenta = true;
            }
            else
            {
                factura.EsVenta = false;
            }
            factura.Observaciones = txtObservaciones.Text;
        }

        private void calculos()
        {
            double subtotal = 0;

            for (int i = 0; i < dgCarrito.Rows.Count; i++)
            {
                subtotal = subtotal + Convert.ToDouble(dgCarrito.Rows[i].Cells[4].Value);
            }

            int descuento = 0;

            descuento = int.Parse(numDescuento.Value.ToString());

            
            double total = 0;
            double isv = subtotal * 0.15;
            total = subtotal + isv - descuento;

            if (rbEnviosMall.Checked || rbOtros.Checked)
            {
                txtSubtotal.Text = "0";
                txtISV.Text = "0";
                txtTotal.Text = "0";
            }
            else
            {
                txtTotal.Text = total + "";
                txtISV.Text = isv + "";
                txtSubtotal.Text = subtotal + "";
            }

           
           

        }

        private bool camposLlenosCarrito()
        {
            if(txtProducto.Text != "" && numCantidad.Value != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool camposLlenosFactura()
        {
            if (txtNumFactura.Text != "" && txtCodigoCliente.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void numDescuento_ValueChanged(object sender, EventArgs e)
        {
            if(int.Parse(numDescuento.Value.ToString()) <= double.Parse(txtTotal.Text))
            {
                calculos();
            }
            else
            {
                MessageBox.Show("El descuento no puede ser mayor al total de la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            FrmClienteFactura frmClienteFactura = new FrmClienteFactura(this);
            frmClienteFactura.ShowDialog();
         
            if (cliente.IdCliente > 0)
            {
                txtCliente.Text = String.Format("{0} -> {1} {2}", cliente.Rtn, cliente.NombreCliente, cliente.ApellidoCliente);
                txtCodigoCliente.Text = cliente.IdCliente.ToString();
            }
        }

        private void rbEnviosMall_CheckedChanged(object sender, EventArgs e)
        {
           
            numDescuento.Value = 0;
            numDescuento.Enabled = false;
            calculos();

        }

        private void rbOtros_CheckedChanged(object sender, EventArgs e)
        {
         
            numDescuento.Value = 0;
            numDescuento.Enabled = false;
            calculos();

        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            numDescuento.Enabled = true;
            calculos();
        }
    }
}
