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
            MasterCleaner();
        }

        private void ObtenerParametros()
        {
            lote.cantidad = Convert.ToInt32(nudCantidad.Value);
            lote.precioCompra = Convert.ToInt32(nudCosto.Value);
            lote.idProducto = codigo;

        }

      

        private void MasterCleaner()
        {
            selecionActiva = false;
            nudCosto.Value = 1;
            nudCantidad.Value = 1;
            lote.Mostrar(dgLote, codigo);

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
            MasterCleaner();
        }


     

        private void dgLote_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = dgLote.Rows[e.RowIndex];

                lote.idLote = int.Parse(row.Cells["Codigo"].Value.ToString());
                lote.idProducto = codigo;

                nudCantidad.Value = int.Parse(row.Cells["cantidad"].Value.ToString());
                nudCosto.Value = int.Parse(row.Cells["costo"].Value.ToString());

                selecionActiva = true;
            }
        }
    }
}
