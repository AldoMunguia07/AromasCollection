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
    public class Producto
    {
        Conexion conexion = new Conexion();

        Bitacora bitacora = new Bitacora();

        

        //PROPIEDADES
        public int IdProducto { get; set; }
        public string nombreProducto{ get; set; }
        public string descripcion { get; set; }
        public float precioDetalle { get; set; }
        public float precioMayorista { get; set; }
        public int idCategoria { get; set; }

        public int Existencia { get; set; }



        public int IdColaborador { get; set; }

        //METODOS
        public void Mostrar(DataGridView dataGrid)
        {

            try
            {
                conexion.sqlConnection.Open();
                //Query para mostrar un zapato
                SqlCommand sqlCommand = new SqlCommand("sp_Producto", conexion.sqlConnection);
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

        public void BuscarProducto(DataGridView dataGrid, string valorBuscado)
        {

            try
            {
                conexion.sqlConnection.Open();
                //Query para mostrar un zapato
                SqlCommand sqlCommand = new SqlCommand("sp_Producto", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@productoBuscado", valorBuscado);
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


        public void AgregarProducto(Producto producto)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Producto", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                sqlCommand.Parameters.AddWithValue("@descripcion", producto.descripcion);
                sqlCommand.Parameters.AddWithValue("@precioDetalle", producto.precioDetalle);
                sqlCommand.Parameters.AddWithValue("@precioMayorista", producto.precioMayorista);
                sqlCommand.Parameters.AddWithValue("@idCategoria", producto.idCategoria);

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

        public void ModificarProducto(Producto producto)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Producto", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@idProducto", producto.IdProducto);
                sqlCommand.Parameters.AddWithValue("@nombreProducto", producto.nombreProducto);
                sqlCommand.Parameters.AddWithValue("@descripcion", producto.descripcion);
                sqlCommand.Parameters.AddWithValue("@precioDetalle", producto.precioDetalle);
                sqlCommand.Parameters.AddWithValue("@precioMayorista", producto.precioMayorista);
                sqlCommand.Parameters.AddWithValue("@idCategoria", producto.idCategoria);

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

    }
}
