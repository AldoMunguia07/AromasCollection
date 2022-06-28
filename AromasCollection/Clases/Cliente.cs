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
    public class Cliente
    {
        Conexion conexion = new Conexion();
        Bitacora bitacora = new Bitacora();
        //PROPIEDADES
        public int IdCliente { get; set; }
        public string Dni { get; set; }
        public string Rtn { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public bool Estado { get; set; }

        public int IdColaborador { get; set; }


        public int Existencia { get; set; }

        //METODOS
        public void MostrarCliente(DataGridView dataGrid, int estado)
        {

            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Cliente", conexion.sqlConnection);
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

        public void AgregarCliente(Cliente cliente)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Cliente", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@dni", cliente.Dni);
                sqlCommand.Parameters.AddWithValue("@rtn", cliente.Rtn);
                sqlCommand.Parameters.AddWithValue("@nombreCliente", cliente.NombreCliente);
                sqlCommand.Parameters.AddWithValue("@apellidoCliente", cliente.ApellidoCliente);
                sqlCommand.Parameters.AddWithValue("@estado", cliente.Estado);


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

        public void BuscarCliente(DataGridView dataGrid, string valorBuscado, int estado)
        {

            try
            {
                conexion.sqlConnection.Open();
                //Query para mostrar un zapato
                SqlCommand sqlCommand = new SqlCommand("sp_Cliente", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@clienteBuscado", valorBuscado);
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
        public void ModificarCliente(Cliente cliente)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Cliente", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                sqlCommand.Parameters.AddWithValue("@dni", cliente.Dni);
                sqlCommand.Parameters.AddWithValue("@rtn", cliente.Rtn);
                sqlCommand.Parameters.AddWithValue("@nombreCliente", cliente.NombreCliente);
                sqlCommand.Parameters.AddWithValue("@apellidoCliente", cliente.ApellidoCliente);
                sqlCommand.Parameters.AddWithValue("@estado", cliente.Estado);

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
        public void DesactivarCliente(Cliente cliente)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Cliente", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                sqlCommand.Parameters.AddWithValue("@accion", "desactivarCliente");


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

                SqlCommand sqlCommand = new SqlCommand("sp_Cliente", conexion.sqlConnection);

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
