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
    public partial class rFrmVentasPorMes : Form
    {
        public rFrmVentasPorMes()
        {
            InitializeComponent();
            cargarMeses();
            cmbMeses.SelectedIndex = 1;


        }

        private void rFrmVentasPorMes_Load(object sender, EventArgs e)
        {
            
        }

        private void cargarMeses()
        {
            string[] meses = {"NINGUNO","ENERO", "FEBRERO", "MARZO",
                              "ABRIL", "MAYO", "JUNIO",
                              "JULIO", "AGOSTO", "SEPTIEMBRE",
                              "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"
                             };

            cmbMeses.Items.Clear();

           
            for (int x = 0; x <= 12; x++)
            {
                cmbMeses.Items.Add(meses[x].ToString());
            }
                
            
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if(cmbMeses.SelectedIndex != null && ndAnio.Value != null)
            {
                // TODO: esta línea de código carga datos en la tabla 'AromasDBDataSet.sp_VentasXMes' Puede moverla o quitarla según sea necesario.
                this.sp_VentasXMesTableAdapter.Fill(this.AromasDBDataSet.sp_VentasXMes, cmbMeses.SelectedIndex, Convert.ToInt32(ndAnio.Value));

                this.reportViewer1.RefreshReport();
            }
            
        }
    }
}
