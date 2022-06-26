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
    public partial class FrmLote : Form
    {
        Producto producto = new Producto();
        Validacion validacion = new Validacion();
        Lote lote = new Lote();
        bool selecionActiva = false;
        int codigo;
        public FrmLote(int idProducto, Colaborador colaborador)
        {
            InitializeComponent();
            codigo = idProducto;
            lote.Mostrar(dgLote, idProducto);

            lote.IdColaborador = colaborador.IdColaborador;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            ObtenerParametros();

            lote.AgregarLote(lote);
            Cleaner();
        }

        private void ObtenerParametros()
        {
            lote.cantidad = int.Parse(txtCantidad.Text);
            lote.precioCompra = float.Parse(txtCosto.Text);
            lote.idProducto = codigo;

        }

        private void Cleaner()
        {
            lote.Mostrar(dgLote, codigo);

            foreach (Control ctr in gbLote.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
            }

            txtBuscar.Text = "";
        }

        private void MasterCleaner()
        {
            Cleaner();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!selecionActiva)
            {
                MessageBox.Show("Por favor, selecione un producto a modificar");
            }
            else
            {
                ObtenerParametros();
                lote.ModificarLote(lote);
                MasterCleaner();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Cleaner();
        }

        private void dgLote_CellMouseClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgLote.Rows[e.RowIndex];

                lote.idLote = int.Parse(row.Cells["Codigo"].Value.ToString());
                lote.idProducto = int.Parse(row.Cells["idProducto"].Value.ToString());

                txtCantidad.Text = row.Cells["cantidad"].Value.ToString();
                txtCosto.Text = row.Cells["preciocompra"].Value.ToString();

                selecionActiva = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MasterCleaner();
        }
    }
}
