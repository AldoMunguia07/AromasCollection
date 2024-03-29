﻿using System;
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
        SAR sar = new SAR();
      
        public FrmFactura(Colaborador colaborador)
        {
            InitializeComponent();
            rbDetalle.Checked = true;
            rbNormal.Checked = true;
            factura.IdColaborador = colaborador.IdColaborador;
            //codigoFacturacion();
            //txtNumFactura.Text = factura.IdFactura.ToString();
            

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(camposLlenosCarrito()) // validación de campos llenos
            {
                for (int i = 0; i < dgCarrito.Rows.Count; i++)
                {
                    if (producto.IdProducto == Convert.ToInt32(dgCarrito.Rows[i].Cells[0].Value))
                    {
                        MessageBox.Show("El producto ya está agregado al carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        limpiarAggProducto();
                        return;
                    }
                }

                if (producto.Existencia >= numCantidad.Value) // no agregar si no hay producto en existencia
                {
                    int codigo = producto.IdProducto;
                    float precio = 0;

                    if(rbDetalle.Checked)
                    {
                        precio = producto.PrecioDetalle;
                    }
                    else if(rbMayorista.Checked)
                    {
                        precio = producto.PrecioMayorista;
                    }

                    float total = precio * float.Parse(numCantidad.Value.ToString());
                    dgCarrito.Rows.Add(codigo, txtProducto.Text, precio, numCantidad.Value, total);
                    limpiarAggProducto();
                    calculos();

                }
                else
                {
                    MessageBox.Show("Cantidad en inventario insuficiente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un producto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Seleccione producto a quitar del carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {


           FrmProductoFactura frmProductoFactura = new FrmProductoFactura(this);
            frmProductoFactura.ShowDialog();
            if(producto.IdProducto.ToString() != null)
            {
                txtProducto.Text = producto.NombreProducto;
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
            //detalleFactura.CodigoSAR = factura.CodigoSAR;


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
            // Para facturar se deben cumplir las siguientes validaciones
            if(camposLlenosFactura())
            {
                /*if (sar.CodigoSarActivo() != 0)
                {
                    if (sar.FechaLimiteEmisionVencio())
                    {*/
                        if (dgCarrito.Rows.Count > 0)
                        {
                            if (rbEnviosMall.Checked)
                            {
                                if (int.Parse(txtCodigoCliente.Text) == 1)
                                {
                                    agregar();
                                }
                                else
                                {
                                    MessageBox.Show("Debe elegir el codigo 1 del cliente (Envios Mall)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if (rbOtros.Checked)
                            {
                                if (int.Parse(txtCodigoCliente.Text) == 2)
                                {
                                    agregar();
                                }
                                else
                                {
                                    MessageBox.Show("Debe elegir el codigo 2 del cliente (Otras Salidas)", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                agregar();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Debe añadir productos al carrito", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    /*}
                     else
                    {
                        sar.IdColaborador = factura.IdColaborador;
                        sar.DesactivarRango(sar.CodigoSarActivo());
                        MessageBox.Show("¡Se a sobrepasado la fecha limite de emisión del rango!", "SAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("¡Ya no tiene rangos disponibles para su facturacion!, debe solicitar mas al SAR", "SAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }*/
            }
            else
            {
                MessageBox.Show("Debe llenar los datos de la factura", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       /* private void codigoFacturacion() // metodo para obtener el codigo de factira de manera automatica
        {
            if (sar.CodigoSarActivo() != 0)
            {
                factura.CodigoSAR = sar.CodigoSarActivo();

                if (sar.PrimeraFactura())
                {
                    factura.IdFactura = sar.ObtenerRangoInicial();
                }
                else
                {
                    factura.IdFactura = sar.ObtenerCodigoFactura();
                }
            }
        }*/


        private void obtenerValores() // Método para obtener los valores de los controles
        {

            //codigoFacturacion();
            factura.IdFactura = int.Parse(txtNumFactura.Text);
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

        private void calculos() // método para realizar calculos de impuesto, subtotal y total
        {
            double subtotal = 0;

            for (int i = 0; i < dgCarrito.Rows.Count; i++)
            {
                subtotal = subtotal + Convert.ToDouble(dgCarrito.Rows[i].Cells[4].Value);
            }

            int descuento = 0;

            descuento = Convert.ToInt16(numDescuento.Value);

            
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
            if (txtCodigoCliente.Text != "" && txtNumFactura.Text != "")
            {
                return true;
            }
            else
            {
                return false;
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

        private void numDescuento_ValueChanged(object sender, EventArgs e)
        {
            calculos();
        }

        private void txtNumFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

       

        }
    }
}
