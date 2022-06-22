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
        public FrmMiCuenta(Colaborador colaborador)
        {
            InitializeComponent();
            txtNombres.Text = colaborador.NombreColaborador;
            txtApellidos.Text = colaborador.ApellidoColaborador;
            txtCorreo.Text = colaborador.Correo;
            
            txtUsuario.Text = colaborador.Usuario;
            txtContrasenia.Text = colaborador.Contrasenia;
        }
    }
}
