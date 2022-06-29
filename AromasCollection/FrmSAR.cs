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
    public partial class FrmSAR : Form
    {
        SAR sar = new SAR();
        int codigoSAR, estado;
        bool seleccionado;
        Validacion validacion = new Validacion();
        DateTime fecha, fechaFLEmision;
        bool cargado = false;
        public FrmSAR(Colaborador colaborador)
        {
            InitializeComponent();

           sar.CargarComboBoxEstado(cmbEstado);
           sar.CargarComboBoxEstado(cmbVerEstado);
           sar.MostrarRangos(dgvSAR, Convert.ToInt32(cmbEstado.SelectedValue));

            sar.IdColaborador = colaborador.IdColaborador;
            cargado = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!seleccionado)
                {
                    if (validacion.ValidarLlenosSAR(txtRangoInicial, txtRangoFinal, txtCAI))
                    {
                        if (txtRangoInicial.Text.Length <= 8)
                        {
                            if (txtRangoFinal.Text.Length <= 8)
                            {
                                if (Convert.ToInt32(txtRangoInicial.Text) >= 0)
                                {
                                    if (Convert.ToInt32(txtRangoFinal.Text) >= 0)
                                    {
                                        if (dtpFRecepcion.Value <= DateTime.Now)
                                        {
                                            if (Convert.ToInt32(txtRangoFinal.Text) >= Convert.ToInt32(txtRangoInicial.Text))
                                            {
                                                if (dtpFLEmision.Value >= dtpFRecepcion.Value)
                                                {
                                                    if (dtpFLEmision.Value >= DateTime.Now)
                                                    {
                                                        if (sar.CodigoSarActivo() == 0)
                                                        {
                                                            ObtenerDatos();
                                                            sar.InsertarRango(sar);
                                                            LimpiarFormulario();
                                                            sar.MostrarRangos(dgvSAR, Convert.ToInt32(cmbVerEstado.SelectedValue));
                                                            MessageBox.Show("¡Registro agregado exitosamente!", "EMPLEADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("¡Aun cuenta con un rango disponible!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("¡La fecha limite de emision debe de ser mayor o igual a la fecha actual!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("¡La fecha limite de emision debe de ser mayor o igual a la fecha de recepción!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("¡El rango final debe ser mayor que el rango inicial!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }

                                        }
                                        else
                                        {
                                            MessageBox.Show("¡La fecha de recpcion debe de ser menor o igual a la fecha actual!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("¡El rango final debe ser un numero positivo!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("¡El rango inicial debe ser un numero positivo!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                MessageBox.Show("¡El rango final no debe ser un numero de mas de 8 digitos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡El rango inicial no debe ser un numero de mas de 8 digitos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("¡Debe de llenar todos los campos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No puede volver a ingresar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al momento de realizar la inserción... Favor intentelo de nuevo mas tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbVerEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cargado)
            {
                sar.MostrarRangos(dgvSAR, Convert.ToInt32(cmbVerEstado.SelectedValue));
            }
            if (Convert.ToInt32(cmbVerEstado.SelectedValue) == 0)
            {
                btnEliminar.Enabled = false;
            }
            else
            {
                btnEliminar.Enabled = true;
            }

           // LimpiarFormulario();
        }

        private void btnMofificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionado)
                {
                    if (validacion.ValidarLlenosSAR(txtRangoInicial, txtRangoFinal, txtCAI))
                    {
                        if (txtRangoInicial.Text.Length <= 8)
                        {
                            if (txtRangoFinal.Text.Length <= 8)
                            {
                                if (Convert.ToInt32(txtRangoInicial.Text) >= 0)
                                {
                                    if (Convert.ToInt32(txtRangoFinal.Text) >= 0)
                                    {
                                        if (Convert.ToInt32(txtRangoFinal.Text) >= Convert.ToInt32(txtRangoInicial.Text))
                                        {
                                            if (dtpFRecepcion.Value <= DateTime.Now || fecha == dtpFRecepcion.Value)
                                            {
                                                if (dtpFLEmision.Value >= dtpFRecepcion.Value)
                                                {
                                                    if (dtpFLEmision.Value >= DateTime.Now || fechaFLEmision == dtpFLEmision.Value)
                                                    {
                                                        if (sar.CodigoSarActivo() == 0 || Convert.ToInt32(cmbEstado.SelectedValue) == 0 || Convert.ToInt32(cmbVerEstado.SelectedValue) == 1)
                                                        {
                                                            ObtenerDatos();
                                                            sar.ModificarRango(sar);
                                                            LimpiarFormulario();
                                                            sar.MostrarRangos(dgvSAR, Convert.ToInt32(cmbVerEstado.SelectedValue));
                                                            MessageBox.Show("¡Registro modificado exitosamente!", "EMPLEADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("¡Aun cuenta con un rango disponible!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("¡La fecha limite de emision debe de ser mayor o igual a la fecha actual!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("¡La fecha limite de emision debe de ser mayor o igual a la fecha de recepción!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("¡La fecha de recpcion debe de ser menor o igual a la fecha actual!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("¡El rango final debe ser mayor que el rango inicial!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("¡El rango final debe ser un numero positivo!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("¡El rango inicial debe ser un numero positivo!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                MessageBox.Show("¡El rango final no debe ser un numero de mas de 8 digitos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡El rango inicial no debe ser un numero de mas de 8 digitos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("¡Debe de llenar todos los campos!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error al momento de realizar la modificación... Favor intentelo de nuevo mas tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionado)
                {
                    ObtenerDatos();
                    sar.DesactivarRango(sar.CodigoSAR);
                    LimpiarFormulario();
                    sar.MostrarRangos(dgvSAR, Convert.ToInt32(cmbVerEstado.SelectedValue));
                    MessageBox.Show("¡Registro desactivado exitosamente!", "EMPLEADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe de seleccionar un registro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error al momento de realizar la eliminación... Favor intentelo de nuevo mas tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

  

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            sar.MostrarRangoBuscado(dgvSAR, Convert.ToInt32(cmbVerEstado.SelectedValue), txtBuscar.Text);
        }

        private void dgvSAR_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seleccionado = true;
                codigoSAR = Convert.ToInt32(dgvSAR.Rows[e.RowIndex].Cells["Código"].Value.ToString());
                txtRangoInicial.Text = dgvSAR.Rows[e.RowIndex].Cells["Valor Inicial"].Value.ToString();
                txtRangoFinal.Text = dgvSAR.Rows[e.RowIndex].Cells["Valor Final"].Value.ToString();
                dtpFRecepcion.Value = Convert.ToDateTime(dgvSAR.Rows[e.RowIndex].Cells["Fecha de Recepcion"].Value.ToString());
                dtpFLEmision.Value = Convert.ToDateTime(dgvSAR.Rows[e.RowIndex].Cells["Fecha Limite de Emision"].Value.ToString());
                txtCAI.Text = dgvSAR.Rows[e.RowIndex].Cells["Cai"].Value.ToString();
                bool state = Convert.ToBoolean(dgvSAR.Rows[e.RowIndex].Cells["Estado"].Value);
                fecha = dtpFRecepcion.Value;
                fechaFLEmision = dtpFLEmision.Value;

                if (state)
                {
                    cmbEstado.SelectedValue = 1;
                }
                else
                {
                    cmbEstado.SelectedValue = 0;
                }



            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error... Favor intentelo de nuevo mas tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatos()
        {
            bool status;
            sar.CodigoSAR = codigoSAR;
            sar.RangoInicial = Convert.ToInt32(txtRangoInicial.Text);
            sar.RangoFinal = Convert.ToInt32(txtRangoFinal.Text);
            sar.Cai = txtCAI.Text;
            sar.FechaRecepcion = dtpFRecepcion.Value;
            sar.FechaLimiteEmision = dtpFLEmision.Value;
            estado = Convert.ToInt32(cmbEstado.SelectedValue);

            if (estado == 1)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            sar.Estado = status;
        }

        private void LimpiarFormulario()
        {
            codigoSAR = 0;
            txtRangoFinal.Text = string.Empty;
            txtRangoInicial.Text = string.Empty;
            dtpFRecepcion.ResetText();
            dtpFLEmision.ResetText();
            txtCAI.Text = String.Empty;
            cmbEstado.SelectedValue = 1;
            estado = 1;
            seleccionado = false;
            fecha = new DateTime();
            fechaFLEmision = new DateTime();

        }
    }
}
