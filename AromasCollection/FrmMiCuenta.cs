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
    public partial class FrmMiCuenta : Form
    {

        Colaborador miColaborador = new Colaborador();
        FrmMenuPrincipal frmMenuPrincipal;
        Validacion validacion = new Validacion();
        private string usuario, correo;
        public FrmMiCuenta(Colaborador colaborador, FrmMenuPrincipal frmMenu)
        {
            InitializeComponent();
            miColaborador.IdColaborador = colaborador.IdColaborador;
            miColaborador.IdPuesto = colaborador.IdPuesto;

            txtNombres.Text = colaborador.NombreColaborador;
            txtApellidos.Text = colaborador.ApellidoColaborador;
            txtCorreo.Text = colaborador.Correo;            
            txtUsuario.Text = colaborador.Usuario;
            txtContrasenia.Text = colaborador.Contrasenia;

            frmMenuPrincipal = frmMenu;

            txtContrasenia.UseSystemPasswordChar = true;

            usuario = txtUsuario.Text;
            correo = txtCorreo.Text;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(camposLlenos())
            {
                if(txtContrasenia.Text.Length >= 8)
                {
                    if(validacion.emailCorrecto(txtCorreo.Text))
                    {
                        if(!miColaborador.ExisteUsuario(txtUsuario.Text) || usuario == txtUsuario.Text)
                        {
                            if (!miColaborador.ExisteCorreo(txtCorreo.Text) || correo == txtCorreo.Text)
                            {
                                obtenerDatos();
                                miColaborador.ModificarColaborador(miColaborador);
                                frmMenuPrincipal.RecuperarValorAlCerrar(miColaborador);
                                usuario = txtUsuario.Text;
                                correo = txtCorreo.Text;
                                MessageBox.Show("Datos actualizados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El correo electrónico ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El nombre de usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("El correo electronico no tiene el formato correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("La contraseña debe ser mayor o igual a 8 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("No debe dejar campos vacios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

        private bool camposLlenos()
        {
            if(txtNombres.Text != "" && txtApellidos.Text != "" && txtCorreo.Text != "" && txtUsuario.Text != "" && txtContrasenia.Text != "")
            {
                return true;
            }

            return false;
        }

        

        private void obtenerDatos()
        {
            miColaborador.NombreColaborador = txtNombres.Text;
            miColaborador.ApellidoColaborador = txtApellidos.Text;
            miColaborador.Correo = txtCorreo.Text;
            miColaborador.Usuario = txtUsuario.Text;
            miColaborador.Contrasenia = txtContrasenia.Text;
        }

        private void chckVerPas_CheckedChanged(object sender, EventArgs e)
        {
            if(txtContrasenia.UseSystemPasswordChar)
            {
                txtContrasenia.UseSystemPasswordChar = false;
            }
            else
            {
                txtContrasenia.UseSystemPasswordChar = true;
            }
        }
    }
}
