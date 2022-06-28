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
    public partial class FrmProducto : Form
    {
        Categoria categoria = new Categoria();
        Producto producto = new Producto();
        Validacion Validacion = new Validacion();
        bool selecionActiva = false;
        Colaborador miColaborador = new Colaborador();
        bool cargado = false;
        public FrmProducto(Colaborador colaborador)
        {
            InitializeComponent();

            categoria.CargarComboCategoria(cmbCategoria, 1);

            producto.IdColaborador = colaborador.IdColaborador;
            miColaborador = colaborador;
            producto.CargarComboBoxEstado(cmbVerEstado);
            producto.CargarComboBoxEstado(cmbEstado);
            inicializarDatagrid();
           
            cargado = true;

        }

        private void inicializarDatagrid()
        {
            producto.Mostrar(dgProducto, Convert.ToInt32(cmbVerEstado.SelectedValue));
           // dgProducto.Columns["Codigo"].Visible = false;
            dgProducto.Columns["idCategoria"].Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gbProductoInput_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(VerificarParametros())
            {
                ObtenerParametros();

                producto.AgregarProducto(producto);
                Cleaner();
            }
        }

        private bool VerificarParametros()
        {
            if (!Validacion.verificarTextoLargo(txtProductoNombre.Text, 150))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto.");
                return false;
            }

            if (!Validacion.verificarTextoLargo(txtDescripcion.Text, 255))
            {
                MessageBox.Show("Por favor, ingrese la descripcion del producto.");
                return false;
            }

            if (!Validacion.verificarContenidoTexto(txtPrecioDetalle.Text))
            {
                MessageBox.Show("Ingrese un valor valido en el campo de 'Precio de Detalle'");
                return false;
            }

            if (!Validacion.verificarContenidoTexto(txtPrecioMayorista.Text))
            {
                MessageBox.Show("Ingrese un valor valido en el campo de 'Precio de Mayorista'");
                return false;
            }

            return true;
        }

        private void ObtenerParametros()
        {
            producto.NombreProducto = txtProductoNombre.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.PrecioDetalle = float.Parse(txtPrecioDetalle.Text);
            producto.IdCategoria = (int)cmbCategoria.SelectedValue;
            producto.PrecioMayorista = float.Parse(txtPrecioMayorista.Text);
            producto.Estado = Convert.ToBoolean(Convert.ToInt32(cmbEstado.SelectedValue));
            
        }

        private void Cleaner()
        {
            foreach (Control ctr in gbProductoInput.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
            }

            cmbCategoria.SelectedIndex = 0;

            btnAgregar.Enabled = true;
            inicializarDatagrid();
        }

        private void btnNuevoLote_Click(object sender, EventArgs e)
        {
            
            if (!selecionActiva)
            {
                MessageBox.Show("Por favor, selecione un producto");
            }
            else
            {
                new FrmLote(producto.IdProducto, miColaborador).ShowDialog();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(!selecionActiva)
            {
                MessageBox.Show("Por favor, selecione un producto a modificar");
            }
            else
            {
                if(VerificarParametros())
                {
                    ObtenerParametros();
                    producto.ModificarProducto(producto);
                    MasterCleaner();
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Cleaner();
        }

        private void MasterCleaner()
        {
            Cleaner();
            selecionActiva = false;
            btnAgregar.Enabled = true;
        }

        private void dgProducto_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgProducto.Rows[e.RowIndex];

                producto.IdProducto = int.Parse(row.Cells["Codigo"].Value.ToString());
                producto.IdCategoria = int.Parse(row.Cells["idCategoria"].Value.ToString());

                txtProductoNombre.Text = row.Cells["Producto"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                txtPrecioDetalle.Text = row.Cells["Precio Detalle"].Value.ToString();
                txtPrecioMayorista.Text = row.Cells["Precio Mayorista"].Value.ToString();
                cmbEstado.SelectedValue = Convert.ToInt32(row.Cells["Estado"].Value);

                selecionActiva = true;
                btnAgregar.Enabled = false;
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MasterCleaner();
        }

        private void cmbVerEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cargado)
            {
                inicializarDatagrid();
            }
            if (Convert.ToInt32(cmbVerEstado.SelectedValue) == 0)
            {
                btnEliminar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(selecionActiva)
            {
                producto.DesactivarProducto(producto);
                MasterCleaner();
                inicializarDatagrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione un producto a desactivar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            producto.BuscarProducto(dgProducto, txtBuscar.Text, Convert.ToInt32(cmbVerEstado.SelectedValue));
        }
    }
}
