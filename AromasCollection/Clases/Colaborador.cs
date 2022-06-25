using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace AromasCollection.Clases
{
    public class Colaborador
    {
        Conexion conexion = new Conexion();

        public int IdColaborador { get; set; }
        public string NombreColaborador { get; set; }
        public string ApellidoColaborador { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public int IdPuesto { get; set; }
        public bool Estado { get; set; }
        public void Mostrar(DataGridView dataGrid)
        {

            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Colaborador", conexion.sqlConnection);
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
        public void CargarComboBoxEstado(ComboBox comboBox)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Colaborador", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@accion", "mostrarPuesto");

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    comboBox.DisplayMember = "puesto";
                    comboBox.ValueMember = "IdPuesto";
                    comboBox.DataSource = dataTable.DefaultView;
                }
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
        public void AgregarColaborador(Colaborador colaborador)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Colaborador", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@nombreColaborador", colaborador.NombreColaborador);
                sqlCommand.Parameters.AddWithValue("@apellidoColaborador", colaborador.ApellidoColaborador);
                sqlCommand.Parameters.AddWithValue("@correo", colaborador.Correo);
                sqlCommand.Parameters.AddWithValue("@usuario", colaborador.Usuario);
                sqlCommand.Parameters.AddWithValue("@contrasenia", colaborador.Contrasenia);
                sqlCommand.Parameters.AddWithValue("@idPuesto", colaborador.IdPuesto);
                sqlCommand.Parameters.AddWithValue("@estado", 1);
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

        public void ModificarColaborador(Colaborador colaborador)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Colaborador", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@nombreColaborador", colaborador.NombreColaborador);
                sqlCommand.Parameters.AddWithValue("@apellidoColaborador", colaborador.ApellidoColaborador);
                sqlCommand.Parameters.AddWithValue("@correo", colaborador.Correo);
                sqlCommand.Parameters.AddWithValue("@usuario", colaborador.Usuario);
                sqlCommand.Parameters.AddWithValue("@contrasenia", colaborador.Contrasenia);
                sqlCommand.Parameters.AddWithValue("@idPuesto", colaborador.IdPuesto);
                sqlCommand.Parameters.AddWithValue("@estado", 1);
                sqlCommand.Parameters.AddWithValue("@IdColaborador", colaborador.IdColaborador);
                sqlCommand.Parameters.AddWithValue("@accion", "modificar");

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
        public void BuscarColaborador(string usuario, Colaborador colaborador)
        {

            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Colaborador", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@usuario", usuario.ToLower());
                sqlCommand.Parameters.AddWithValue("@accion", "obtenerColaborador");

                using (SqlDataReader rdr = sqlCommand.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        // Obtener los valores del empleado si la consulta retorna valores
                        colaborador.IdColaborador = Convert.ToInt32(rdr["idColaborador"]);
                        colaborador.NombreColaborador = rdr["nombreColaborador"].ToString();
                        colaborador.ApellidoColaborador = rdr["apellidoColaborador"].ToString();
                        colaborador.Correo = rdr["correo"].ToString();
                        colaborador.Usuario = rdr["usuario"].ToString();
                        colaborador.Contrasenia = rdr["contrasenia"].ToString();
                        colaborador.IdPuesto = Convert.ToInt32(rdr["idPuesto"]);
                        colaborador.Estado = Convert.ToBoolean(rdr["estado"]);


                    }

                }

                // Retornar el usuario con los valores

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "ERROR");


            }
            finally
            {
                // Cerrar la conexión
                conexion.sqlConnection.Close();
            }
        }
    }
}
