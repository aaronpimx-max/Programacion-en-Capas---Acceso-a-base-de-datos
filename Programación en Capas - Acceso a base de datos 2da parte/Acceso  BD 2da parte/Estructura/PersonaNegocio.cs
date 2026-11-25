using SolucionCapas.Datos;
using SolucionCapas.Entidades;
using MySql.Data.MySqlClient;

namespace SolucionCapas.Negocio
{
    public class PersonaNegocio
    {
        private PersonaDatos _datos = new PersonaDatos();

        public (string Dni, string Nombre)? BuscarPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return null;
            return _datos.BuscarPorDni(dni.Trim());
        }

        public bool AgregarPersona(Persona persona)
        {
            if (persona == null) return false;
            if (string.IsNullOrWhiteSpace(persona.Dni) || string.IsNullOrWhiteSpace(persona.Nombre)) return false;
            if (_datos.BuscarPorDni(persona.Dni) != null) return false;

            return _datos.Agregar(persona.Dni, persona.Nombre);
        }

        public bool ModificarPersona(Persona persona)
        {
            if (persona == null) return false;
            if (string.IsNullOrWhiteSpace(persona.Dni) || string.IsNullOrWhiteSpace(persona.Nombre)) return false;

            return _datos.Modificar(persona.Dni, persona.Nombre);
        }
        public bool EliminarPersona(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return false;

            return _datos.Eliminar(dni);
        }
    }
}