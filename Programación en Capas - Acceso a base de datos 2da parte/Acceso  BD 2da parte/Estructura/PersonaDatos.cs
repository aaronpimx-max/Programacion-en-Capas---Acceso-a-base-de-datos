using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using SolucionCapas.Entidades;

namespace SolucionCapas.Datos
{
    public class PersonaDatos
    {
        private string _conexionString = "Server=localhost;Port=3307;Database=biblioteca;Uid=root;Pwd=;";

        public (string Dni, string Nombre)? BuscarPorDni(string dni)
        {
            string query = "SELECT Dni, Nombre FROM personas WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);

                conexion.Open();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string dniDb = reader["Dni"].ToString() ?? string.Empty;
                        string nombreDb = reader["Nombre"].ToString() ?? string.Empty;

                        return (dniDb, nombreDb);
                    }
                }
            }

            return null;
        }
        public bool Agregar(string dni, string nombre)
        {
            string query = "INSERT INTO personas (Dni, Nombre) VALUES (@Dni, @Nombre)";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Nombre", nombre);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
        public bool Modificar(string dni, string nuevoNombre)
        {
            string query = "UPDATE personas SET Nombre = @Nombre WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
        public bool Eliminar(string dni)
        {
            string query = "DELETE FROM personas WHERE Dni = @Dni";

            using (MySqlConnection conexion = new MySqlConnection(_conexionString))
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Dni", dni);

                conexion.Open();

                int filasAfectadas = comando.ExecuteNonQuery();
                return filasAfectadas > 0;
            }
        }
    }
}