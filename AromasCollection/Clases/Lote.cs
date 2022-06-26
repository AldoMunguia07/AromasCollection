using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AromasCollection.Clases
{
    public class Lote
    {
        Conexion conexion = new Conexion();

        Bitacora bitacora = new Bitacora();

        public int idLote { get; set; }
        public int idProducto { get; set; }

        public int cantidad { get; set; }
        public float precioCompra { get; set; }
        public DateTime fecha { get; set; }


        public int IdColaborador { get; set; }


        public void AgregarLote(Lote lote)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Lote", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@idProducto", lote.idProducto);
                sqlCommand.Parameters.AddWithValue("@cantidad", lote.cantidad);
                sqlCommand.Parameters.AddWithValue("@preciocompra", lote.precioCompra);

                sqlCommand.Parameters.AddWithValue("@accion", "insertar");

                bitacora.DefinirIdColaborador(IdColaborador, conexion.sqlConnection);

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

        public void Mostrar(DataGridView dataGrid, int idProducto)
        {

            try
            {
                conexion.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("sp_Lote", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Establecer los valores de los parámetros

                sqlCommand.Parameters.AddWithValue("@accion", "mostrar");
                sqlCommand.Parameters.AddWithValue("@idProducto", idProducto);

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

        public void ModificarLote(Lote lote)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Lote", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@idLote", lote.idLote);
                sqlCommand.Parameters.AddWithValue("@idProducto", lote.idProducto);
                sqlCommand.Parameters.AddWithValue("@cantidad", lote.cantidad);
                sqlCommand.Parameters.AddWithValue("@preciocompra", lote.precioCompra);

                sqlCommand.Parameters.AddWithValue("@accion", "modificar");


                bitacora.DefinirIdColaborador(IdColaborador, conexion.sqlConnection);


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

        //public void BuscarLote(DataGridView dataGrid, string valorBuscado)
        //{

        //    try
        //    {
        //        conexion.sqlConnection.Open();
        //        SqlCommand sqlCommand = new SqlCommand("sp_Lote", conexion.sqlConnection);
        //        sqlCommand.CommandType = CommandType.StoredProcedure;

        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

        //        // Establecer los valores de los parámetros
        //        sqlCommand.Parameters.AddWithValue("@loteBusquedad", valorBuscado);
        //        sqlCommand.Parameters.AddWithValue("@accion", "buscar");

        //        using (sqlDataAdapter)
        //        {
        //            DataTable dataTable = new DataTable();

        //            sqlDataAdapter.Fill(dataTable);

        //            dataGrid.DataSource = dataTable;

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        conexion.sqlConnection.Close();
        //    }
        //}
    }
}
