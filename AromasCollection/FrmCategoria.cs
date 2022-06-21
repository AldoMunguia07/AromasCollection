﻿using AromasCollection.Clases;
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


        bool editarEstado = false;

        public FrmCategoria()
        {
            InitializeComponent();

            categoria.Mostrar(dgCategoria);
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
                categoria.AgregarCategoria(categoria);

                MasterCleaner();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese el nombre de la categoria");
            }
        }

        private void txtboxCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cleaner()
        {
            categoria.Mostrar(dgCategoria);

            foreach (Control ctr in gbCategoria.Controls)
            {
                if (ctr is TextBox)
                    ctr.Text = "";
            }

            txtBuscar.Text = "";
        }

        private void MasterCleaner()
        {
            Cleaner();
            editarEstado = false;

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
            editarEstado = true;

            btnEditar.Enabled = false;
            btnAgregar.Enabled = false;
            txtboxCategoria.Text = "";

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtboxCategoria.Enabled = true;
        }

        private void dgCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(editarEstado)
            {
                DataGridViewRow row = dgCategoria.Rows[e.RowIndex];

                txtboxCategoria.Text = row.Cells[1].Value.ToString();

                categoria.idCategoria = int.Parse(row.Cells[0].Value.ToString());
                categoria.categoria = row.Cells[1].Value.ToString();
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
            if (validacion.verificarTextoLargo(categoria.categoria, 30))
            {
                categoria.categoria = txtboxCategoria.Text;
                categoria.ModificarCategoria(categoria);
                MasterCleaner();
            }
            else
            {
                MessageBox.Show("Por favor, selecione la categoria a modificar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            (dgCategoria.DataSource as DataTable).DefaultView.RowFilter = "Categoria LIKE '%" + txtBuscar.Text + "%'";
        }
    }
}
