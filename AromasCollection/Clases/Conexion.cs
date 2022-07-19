using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace AromasCollection.Clases
{
    class Conexion
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["AromasCollection.Properties.Settings.conexionAromasDB"].ConnectionString;
        public SqlConnection sqlConnection = new SqlConnection(connectionString); //Metodo para conectarse a la base de datos


    }
}
