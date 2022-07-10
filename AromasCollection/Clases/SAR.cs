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
    class SAR
    {
        Conexion conexion = new Conexion();

        Bitacora bitacora = new Bitacora();

        

        //PROPIEDADES
        public int CodigoSAR { get; set; }

        public int RangoInicial { get; set; }

        public int RangoFinal { get; set; }

        public DateTime FechaRecepcion { get; set; }

        public DateTime FechaLimiteEmision { get; set; }

        public string Cai { get; set; }

        public bool Estado { get; set; }


        public int IdColaborador { get; set; }


        //METODOS

        public void MostrarRangos(DataGridView dataGrid, int estado)
        {

            try
            {

                conexion.sqlConnection.Open();

                //Query para mostrar todos los rangos del sar obtenidos a traves del tiempo
                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Establecer los valores de los parámetros

                sqlCommand.Parameters.AddWithValue("@estado", estado);
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

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conexion.sqlConnection.Close();
            }
        }

        public void MostrarRangoBuscado(DataGridView dataGrid, int estado, string RangoBuscado)
        {

            try
            {

                conexion.sqlConnection.Open();


                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                // Establecer los valores de los parámetros

                sqlCommand.Parameters.AddWithValue("@estado", estado);
                sqlCommand.Parameters.AddWithValue("@rangoBuscado", RangoBuscado);
                sqlCommand.Parameters.AddWithValue("@accion", "Buscar");

                using (sqlDataAdapter)
                {
                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    dataGrid.DataSource = dataTable;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                conexion.sqlConnection.Close();
            }
        }

        public void InsertarRango(SAR sar)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@rangoInicial", sar.RangoInicial);
                sqlCommand.Parameters.AddWithValue("@rangoFinal", sar.RangoFinal);
                sqlCommand.Parameters.AddWithValue("@fechaRecepcion", sar.FechaRecepcion);
                sqlCommand.Parameters.AddWithValue("@fechaLimiteEmision", sar.FechaLimiteEmision);
                sqlCommand.Parameters.AddWithValue("@cai", sar.Cai);
                sqlCommand.Parameters.AddWithValue("@estado", sar.Estado);
                sqlCommand.Parameters.AddWithValue("@accion", "insertarRango");

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

        public void ModificarRango(SAR sar)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@rangoInicial", sar.RangoInicial);
                sqlCommand.Parameters.AddWithValue("@rangoFinal", sar.RangoFinal);
                sqlCommand.Parameters.AddWithValue("@fechaRecepcion", sar.FechaRecepcion);
                sqlCommand.Parameters.AddWithValue("@fechaLimiteEmision", sar.FechaLimiteEmision);
                sqlCommand.Parameters.AddWithValue("@cai", sar.Cai);
                sqlCommand.Parameters.AddWithValue("@codigoSAR", sar.CodigoSAR);
                sqlCommand.Parameters.AddWithValue("@estado", sar.Estado);
                sqlCommand.Parameters.AddWithValue("@accion", "modificarRango");


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



        public void DesactivarRango(int codigoSar)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Establecer los valores de los parámetros
                sqlCommand.Parameters.AddWithValue("@codigoSAR", codigoSar);
                sqlCommand.Parameters.AddWithValue("@accion", "desactivarRango");


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

        public bool PrimeraFactura()
        {
            try
            {

                conexion.sqlConnection.Open();
                //Query para añadir un paciente
                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@accion", "PrimerFactura");

                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);



                    if (dataTable.Rows.Count >= 1) //Si ya hay alguna factura
                    {
                        return false;
                    }

                    return true;
                }
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
        public int ObtenerRangoInicial()
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@accion", "ObtenerSAR");

                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    return Convert.ToInt32(dataTable.Rows[0]["RangoInicial"]); //Retorna el rango inicial del SAR
                }
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

        public int CodigoSarActivo()
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@accion", "CodigoSarActivo");

                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    return Convert.ToInt32(dataTable.Rows[0]["CodigoSAR"]); //Retorna el codigo del SAR activo
                }
            }
            catch (Exception)
            {
                return 0; // No hay rangos del SAR disponibles
            }
            finally
            {
                conexion.sqlConnection.Close();
            }

        }

        public int ObtenerCodigoFactura()
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@accion", "InsertarCodigoFactura");

                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);

                    return Convert.ToInt32(dataTable.Rows[0]["Codigo"]); //Retorna el codigo de la factura (el ultimo codigo + 1)
                }
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

        

        public bool FechaLimiteEmisionVencio()
        {
            try
            {


                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                using (sqlDataAdapter)
                {

                    sqlCommand.Parameters.AddWithValue("@accion", "FechaLimiteEmision");

                    DataTable dataTable = new DataTable();

                    sqlDataAdapter.Fill(dataTable);


                    if (DateTime.Now.Date <= Convert.ToDateTime(dataTable.Rows[0]["fechaLimiteEmision"]))
                    {


                        return true;
                    }



                    return false;





                }
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

        public void CargarComboBoxEstado(ComboBox comboBox)
        {
            try
            {
                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_SAR", conexion.sqlConnection);

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
