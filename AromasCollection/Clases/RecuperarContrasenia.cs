using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace AromasCollection.Clases
{
    class RecuperarContrasenia
    {
        Conexion conexion = new Conexion();
        Bitacora bitacora = new Bitacora();

        public void Recuperar(String correo)
        {
            try
            {

                conexion.sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("sp_Colaborador", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@correo", correo);
                sqlCommand.Parameters.AddWithValue("@accion", "obtenerColaboradorCorreo");


                DataTable data = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                using (sqlDataAdapter)
                {

                    sqlDataAdapter.Fill(data);
                }
                if (data.Rows.Count != 0)
                {

                    conexion.sqlConnection.Close();
                    GenerarNewPass(correo, Convert.ToInt32(data.Rows[0]["idColaborador"]));
                }
                else
                {
                    MessageBox.Show("Correo no encontrado", "Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.sqlConnection.Close();
            }
        }

        private void GenerarNewPass(string correo, int id)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            string newPass = random.Next(100000000, 999999999).ToString();

            try
            {

                conexion.sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("sp_Colaborador", conexion.sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@idColaborador", id);
                sqlCommand.Parameters.AddWithValue("@contrasenia", newPass);
                sqlCommand.Parameters.AddWithValue("@accion", "recuperarPass");

                bitacora.DefinirIdColaborador(id, conexion.sqlConnection);

                if (sqlCommand.ExecuteNonQuery() != 0)
                {
                    EnviarEmail(newPass, correo);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.sqlConnection.Close();
            }
        }

        private void EnviarEmail(string newPass, string email)
        {
            string contrasenia = "okqpgtpxdvopgwzu";
            string mensaje = string.Empty;

            string destinatario = email;
            string remitente = "aromascollectionhn@gmail.com";
            string asunto = "Nueva contraseña Aromas Collection";
            string message = String.Format("Su nueva contraseña es {0}", newPass);

            MailMessage ms = new MailMessage(remitente, destinatario, asunto, message);

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(remitente, contrasenia);
           

            try
            {
                Task.Run(() =>
                {
                    smtpClient.Send(ms);
                    ms.Dispose();
                    MessageBox.Show("¡Correo enviado exitosamente, revise su correo por favor!", "Restaurar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                );

                MessageBox.Show("Este proceso puede tardar unos segundos, por favor espere", "Restaurar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ha ocurrido un error al momento de enviar el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
