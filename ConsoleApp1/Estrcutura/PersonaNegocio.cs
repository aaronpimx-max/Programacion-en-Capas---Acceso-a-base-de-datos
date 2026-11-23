using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class PersonaNegocio
    {
        private PersonaDatos _datos = new PersonaDatos();

        public (string Dni, string Nombre)? ConsultarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni) || dni.Trim().Length < 7)
            {
                return null;
            }

            return _datos.BuscarPorDni(dni.Trim());
        }
    }
}
