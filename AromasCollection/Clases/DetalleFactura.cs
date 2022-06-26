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
    class DetalleFactura
    {
        Conexion conexion = new Conexion();

        //PROPIEDADES
        public int IdFactura { get; set; }
        public int CodigoSAR { get; set; }
        public int IdProducto{ get; set; }
        public float Precio{ get; set; }
        public int Cantidad { get; set; }

        //METODOS

        public void AgregarDetalleFactura(DetalleFactura detalleFactura)
        {
            try
            {
                conexion.sqlConnection.Open();
                //Query para añadir un paciente
                SqlCommand sqlCommand = new SqlCommand("sp_detalleVenta", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@idFactura", detalleFactura.IdFactura);
                sqlCommand.Parameters.AddWithValue("@codigoSAR", detalleFactura.CodigoSAR);
                sqlCommand.Parameters.AddWithValue("@idProducto", detalleFactura.IdProducto);
                sqlCommand.Parameters.AddWithValue("@precio", detalleFactura.Precio);
                sqlCommand.Parameters.AddWithValue("@cantidad", detalleFactura.Cantidad);
                sqlCommand.Parameters.AddWithValue("@accion", "insertar");

                sqlCommand.ExecuteNonQuery();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar la conexión
                conexion.sqlConnection.Close();
            }
        }


        public void Mostrar(DataGridView dataGrid, int codigoFactura)
        {

            try
            {
                conexion.sqlConnection.Open();
                //Query para mostrar un zapato
                SqlCommand sqlCommand = new SqlCommand("sp_detalleVenta", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Establecer los valores de los parámetros

                sqlCommand.Parameters.AddWithValue("@idFactura", codigoFactura);
                sqlCommand.Parameters.AddWithValue("@accion", "mostrarDetalle");

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

    }
}
