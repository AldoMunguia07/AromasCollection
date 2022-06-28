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
    public partial class FrmCategoria : Form
    {
        Validacion validacion = new Validacion();
        Categoria categoria = new Categoria();
        bool cargado = false;

        bool editarEstado = false;
        bool seleccionado = false;

        public FrmCategoria(Colaborador colaborador)
        {
            InitializeComponent();

            categoria.CargarComboBoxEstado(cmbEstado);
            categoria.CargarComboBoxEstado(cmbVerEstado);
            categoria.Mostrar(dgCategoria, Convert.ToInt32(cmbEstado.SelectedValue));
            

            categoria.IdColaborador = colaborador.IdColaborador;


            cargado = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            editarEstado = false;
            btnEditar.Enabled = false;
            btnAgregar.Enabled = false; 

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtboxCategoria.Enabled = true;
        }

        private void insetarCategoria(string texto)
        {
            if (validacion.verificarTextoLargo(texto, 30))
            {
                categoria.categoria = texto;
                categoria.estado = Convert.ToBoolean(Convert.ToInt32(cmbEstado.SelectedValue));
                MessageBox.Show(categoria.estado.ToString());
                categoria.AgregarCategoria(categoria);

                MasterCleaner();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese el nombre de la categoria", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtboxCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cleaner()
        {
            categoria.Mostrar(dgCategoria, Convert.ToInt32(cmbVerEstado.SelectedValue));

            foreach (Control ctr in gbCategoria.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
            }

            txtBuscar.Text = "";
            cmbEstado.SelectedValue = 1;
        }

        private void MasterCleaner()
        {
            Cleaner();
            editarEstado = false;
            seleccionado = false;

            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;

            txtboxCategoria.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Cleaner();
        }

        private void dgCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(seleccionado)
            {
                editarEstado = true;

                btnEditar.Enabled = false;
                btnAgregar.Enabled = false;
              

                btnGuardar.Enabled = true;
                btnCancelar.Enabled = true;
                txtboxCategoria.Enabled = true;

            }
            else
            {
                MessageBox.Show("Por favor, selecione la categoria a modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void dgCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgCategoria.Rows[e.RowIndex];

                txtboxCategoria.Text = row.Cells[1].Value.ToString();
                cmbEstado.SelectedValue = Convert.ToInt32(row.Cells[2].Value);

                categoria.idCategoria = int.Parse(row.Cells[0].Value.ToString());
                categoria.categoria = row.Cells[1].Value.ToString();
                seleccionado = true;

            }

               


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MasterCleaner();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(editarEstado)
            {
                modificarCategoria();
            }
            else
            {
                string texto = txtboxCategoria.Text;
                insetarCategoria(texto);
            }
        }

        private void modificarCategoria()
        {
            categoria.categoria = txtboxCategoria.Text;
            categoria.estado = Convert.ToBoolean(Convert.ToInt32(cmbEstado.SelectedValue));
            if (validacion.verificarTextoLargo(categoria.categoria, 30))
            {
                
                categoria.ModificarCategoria(categoria);
                MasterCleaner();
            }
            else
            {
                MessageBox.Show("Por favor, selecione la categoria a modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            categoria.BuscarCategoria(dgCategoria, txtBuscar.Text, Convert.ToInt32(cmbVerEstado.SelectedValue));
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            categoria.BuscarCategoria(dgCategoria, txtBuscar.Text, Convert.ToInt32(cmbVerEstado.SelectedValue));
        }

        private void cmbVerEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargado)
            {
                categoria.Mostrar(dgCategoria, Convert.ToInt32(cmbVerEstado.SelectedValue));
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
            if (seleccionado)
            {
                categoria.DesactivarCategoria(categoria);
                categoria.Mostrar(dgCategoria, Convert.ToInt32(cmbEstado.SelectedValue));
                MasterCleaner();
            }
            else
            {
                MessageBox.Show("Por favor, selecione la categoria a Desactivar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
