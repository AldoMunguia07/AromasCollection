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
    public partial class rFrmGananciasPorMes : Form
    {
        public rFrmGananciasPorMes()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if  (ndAnio.Value != null)
            {
                // TODO: esta línea de código carga datos en la tabla 'AromasDBDataSet.sp_GananciasXMes' Puede moverla o quitarla según sea necesario.
                this.sp_GananciasXMesTableAdapter.Fill(this.AromasDBDataSet.sp_GananciasXMes, Convert.ToInt32(ndAnio.Value));

                this.reportViewer1.RefreshReport();

            }
        }

        private void rFrmGananciasPorMes_Load(object sender, EventArgs e)
        {
           
        }
    }
}
