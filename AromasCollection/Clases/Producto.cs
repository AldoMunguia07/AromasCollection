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
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public float PrecioDetalle { get; set; }
        public float PrecioMayorista { get; set; }
        public int IdCategoria { get; set; }

        public bool Estado { get; set; }

        public int Existencia { get; set; }



        public int IdColaborador { get; set; }

        //METODOS
        public void Mostrar(DataGridView dataGrid, int estado)
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
                sqlCommand.Parameters.AddWithValue("@estado", estado);

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

        public void BuscarProducto(DataGridView dataGrid, string valorBuscado, int estado)
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
                sqlCommand.Parameters.AddWithValue("@estado", estado);
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
                sqlCommand.Parameters.AddWithValue("@nombreProducto", producto.NombreProducto);
                sqlCommand.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("@precioDetalle", producto.PrecioDetalle);
                sqlCommand.Parameters.AddWithValue("@precioMayorista", producto.PrecioMayorista);
                sqlCommand.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);
                sqlCommand.Parameters.AddWithValue("@estado", producto.Estado);

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
                sqlCommand.Parameters.AddWithValue("@nombreProducto", producto.NombreProducto);
                sqlCommand.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("@precioDetalle", producto.PrecioDetalle);
                sqlCommand.Parameters.AddWithValue("@precioMayorista", producto.PrecioMayorista);
                sqlCommand.Parameters.AddWithValue("@idCategoria", producto.IdCategoria);
                sqlCommand.Parameters.AddWithValue("@estado", producto.Estado);

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

        public void DesactivarProducto(Producto producto)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Producto", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@idProducto", producto.IdProducto);
                sqlCommand.Parameters.AddWithValue("@accion", "desactivarProducto");


                bitacora.DefinirIdColaborador(IdColaborador, conexion.sqlConnection);

                sqlCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Cerrar la conexión
                conexion.sqlConnection.Close();
            }
        }

        public void CargarComboBoxEstado(ComboBox comboBox)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Producto", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@accion", "CargarEstado");

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    comboBox.DisplayMember = "estado";
                    comboBox.ValueMember = "id";
                    comboBox.DataSource = dataTable.DefaultView;
                }

                conexion.sqlConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.sqlConnection.Close();
            }

        }

    }
}
