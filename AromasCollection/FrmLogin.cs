using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AromasCollection.Clases;

namespace AromasCollection
{
    public partial class FrmLogin : Form
    {
        Colaborador colaborador = new Colaborador();
        public FrmLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Clear();
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "Contraseña")
            {
                txtContrasenia.Clear();
                txtContrasenia.ForeColor = Color.LightGray;
                txtContrasenia.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasenia_Leave(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "")
            {
                txtContrasenia.Text = "Contraseña";
                txtContrasenia.ForeColor = Color.DimGray;
                txtContrasenia.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            colaborador.BuscarColaborador(txtUsuario.Text.ToLower(), colaborador);
            
            if (colaborador.Usuario != null)
            {
                if(colaborador.Usuario == txtUsuario.Text && colaborador.Contrasenia == txtContrasenia.Text && colaborador.Estado)
                {
                    Bitacora bitacora = new Bitacora();

                   
                   
                    FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal(colaborador);


                    frmMenuPrincipal.Show();
                    frmMenuPrincipal.FormClosed += cerrarSesion;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("El usuario y/o la contraseña no es correcta o el usuario está inactivo. Favor verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
            else
            {
                MessageBox.Show("El usuario y/o la contraseña no es correcta o el usuario está inactivo. Favor verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text = "Usuario";
            txtContrasenia.Text = "Contraseña";
            txtContrasenia.UseSystemPasswordChar = false;
            this.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FrmRecuperarContrasenia frmRecuperarContrasenia = new FrmRecuperarContrasenia();


            frmRecuperarContrasenia.Show();
            frmRecuperarContrasenia.FormClosed += cerrarSesion;
            this.Hide();
        }
    }
}
