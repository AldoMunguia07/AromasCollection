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
    public partial class rFrmExistencias : Form
    {
        public rFrmExistencias()
        {
            InitializeComponent();
        }

        private void rFrmExistencias_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'AromasDBDataSet.sp_TotalExistencias' Puede moverla o quitarla según sea necesario.
            this.sp_TotalExistenciasTableAdapter.Fill(this.AromasDBDataSet.sp_TotalExistencias);

            this.reportViewer1.RefreshReport();
        }
    }
}
