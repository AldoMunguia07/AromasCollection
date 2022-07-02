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
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void btnVentasPorMes_Click(object sender, EventArgs e)
        {
            rFrmVentasPorMes rFrmVentasPorMes = new rFrmVentasPorMes();
            rFrmVentasPorMes.ShowDialog();
        }

        private void btnGananciasPorMes_Click(object sender, EventArgs e)
        {
            rFrmGananciasPorMes rFrmGananciasPorMes = new rFrmGananciasPorMes();
            rFrmGananciasPorMes.ShowDialog();
        }

        private void btnTotalUnidadesVendidas_Click(object sender, EventArgs e)
        {
            rFrmTotalVentasYUnidades rFrmTotalVentasYUnidades = new rFrmTotalVentasYUnidades();
            rFrmTotalVentasYUnidades.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            rFrmExistencias rFrmExistencias = new rFrmExistencias();
            rFrmExistencias.ShowDialog();
        }
    }
}
