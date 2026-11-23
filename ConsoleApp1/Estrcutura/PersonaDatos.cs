using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class PersonaDatos
    {
        private string _conexionString = "Server=localhost;Database=Biblioteca;Uid=root;Pwd=;";

        public (string Dni, string Nombre)? BuscarPorDni(string dni)
        {
            string query = "SELECT Dni, Nombre FROM autor WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string dniDb = reader["Dni"].ToString();
                        string nombreDb = reader["Nombre"].ToString();

                        return (dniDb, nombreDb);
                    }
                }
            }

            return null;
        }
    }
}