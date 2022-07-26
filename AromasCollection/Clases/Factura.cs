using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AromasCollection.Clases
{
    class Factura
    {
        Conexion conexion = new Conexion();


        Bitacora bitacora = new Bitacora();

        //PROPIEDADES
        public int IdFactura { get; set; }
        //public int CodigoSAR { get; set; }
        public int IdColaborador { get; set; }
        public int IdCliente{ get; set; }
        public DateTime FechaVenta { get; set; }
        public float Descuento { get; set; }

        public bool EsVenta { get; set; }
        public string Observaciones { get; set; }

        //METODOS

        public void Mostrar(DataGridView dataGrid)
        {

            try
            {
                conexion.sqlConnection.Open();
                //Query para mostrar las ventas
                SqlCommand sqlCommand = new SqlCommand("sp_Venta", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Establecer los valores de los parámetros

                sqlCommand.Parameters.AddWithValue("@accion", "mostrar");

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    dataGrid.DataSource = dataTable;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.sqlConnection.Close();
            }
        }

        public void BuscarFactura(DataGridView dataGrid, string valorBuscado)
        {

            try
            {
                conexion.sqlConnection.Open();
                //Query para mostrar una venta
                SqlCommand sqlCommand = new SqlCommand("sp_Venta", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@facturaBuscada", valorBuscado);
                sqlCommand.Parameters.AddWithValue("@accion", "buscar");

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    dataGrid.DataSource = dataTable;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.sqlConnection.Close();
            }
        }

        public void AgregarFactura(Factura factura)
        {
            try
            {
                conexion.sqlConnection.Open();
                //Query para añadir una factura
                SqlCommand sqlCommand = new SqlCommand("sp_Venta", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@idFactura", factura.IdFactura);
               // sqlCommand.Parameters.AddWithValue("@codigoSAR", factura.CodigoSAR);
                sqlCommand.Parameters.AddWithValue("@idColaborador", factura.IdColaborador);
                sqlCommand.Parameters.AddWithValue("@idCliente", factura.IdCliente);
                sqlCommand.Parameters.AddWithValue("@descuento", factura.Descuento);
                sqlCommand.Parameters.AddWithValue("@esVenta", factura.EsVenta);
                sqlCommand.Parameters.AddWithValue("@observaciones", factura.Observaciones);
                sqlCommand.Parameters.AddWithValue("@accion", "insertar");

                bitacora.DefinirIdColaborador(IdColaborador, conexion.sqlConnection);

                sqlCommand.ExecuteNonQuery();

              

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión
                conexion.sqlConnection.Close();
            }
        }





    }
}
