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
    public partial class FrmMenuPrincipal : Form
    {
        Colaborador miColaborador = new Colaborador();
        public FrmMenuPrincipal(Colaborador colaborador)
        {
            InitializeComponent();
            miColaborador = colaborador;
            lblUser.Text = String.Format("{0} {1}", colaborador.NombreColaborador, colaborador.ApellidoColaborador );
            abrirFormPanel(new FrmInicio());
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        

        private void titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void abrirFormPanel(object form)
        {
            if(this.main.Controls.Count > 0)
            {
                this.main.Controls.RemoveAt(0);
            }

            Form fh = form as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.main.Controls.Add(fh);
            this.main.Tag = fh;
            fh.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmVentas(miColaborador));
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmInicio());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmProducto(miColaborador));
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmCategoria(miColaborador));
        }
        private void main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMiCuenta_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmMiCuenta(miColaborador));
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmCliente(miColaborador));
        }

        private void btnColaboradores_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmColaborador(miColaborador));
        }

        private void btnSAR_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmSAR(miColaborador));
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            abrirFormPanel(new FrmBitacora());
        }
    }
}
