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
    public partial class FrmBitacora : Form
    {
        Bitacora bitacora = new Bitacora();
        public FrmBitacora()
        {
            InitializeComponent();
            bitacora.MostrarRegistros(dgvBitacora);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            bitacora.MostrarBuscado(dgvBitacora, txtBuscar.Text);
        }
    }
}
