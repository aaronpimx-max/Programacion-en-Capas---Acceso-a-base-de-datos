using SolucionCapas.Entidades;
using SolucionCapas.Datos;
using SolucionCapas.Negocio;
using MySql.Data.MySqlClient;
using System;

namespace SolucionCapas.Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonaNegocio negocio = new PersonaNegocio();
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== ABM PERSONAS POR DNI ===");
                Console.WriteLine("1. Buscar por DNI");
                Console.WriteLine("2. Agregar persona");
                Console.WriteLine("3. Modificar persona");
                Console.WriteLine("4. Eliminar persona");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingrese DNI: ");
                        string dniBuscar = Console.ReadLine() ?? string.Empty;
                        var encontrada = negocio.BuscarPorDni(dniBuscar);

                        if (encontrada != null)
                        {
                            Console.WriteLine($"DNI: {encontrada.Value.Dni} | Nombre: {encontrada.Value.Nombre}");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ninguna persona con ese DNI.");
                        }
                        break;

                    case "2":
                        Console.Write("Ingrese DNI: ");
                        string dniAlta = Console.ReadLine() ?? string.Empty;
                        Console.Write("Ingrese Nombre: ");
                        string nombreAlta = Console.ReadLine() ?? string.Empty;

                        Persona nuevaPersona = new Persona
                        {
                            Dni = dniAlta.Trim(),
                            Nombre = nombreAlta.Trim()
                        };

                        bool agregado = negocio.AgregarPersona(nuevaPersona);
                        Console.WriteLine(agregado
                            ? "Persona agregada correctamente."
                            : "No se pudo agregar (revisá los campos o si el DNI ya existe).");
                        break;

                    case "3":
                        Console.Write("Ingrese DNI a modificar: ");
                        string dniMod = Console.ReadLine() ?? string.Empty;
                        Console.Write("Ingrese nuevo Nombre: ");
                        string nombreMod = Console.ReadLine() ?? string.Empty;

                        Persona personaModificada = new Persona
                        {
                            Dni = dniMod.Trim(),
                            Nombre = nombreMod.Trim()
                        };

                        bool modificada = negocio.ModificarPersona(personaModificada);
                        Console.WriteLine(modificada
                            ? "Persona modificada correctamente."
                            : "No se modificó ningún registro.");
                        break;

                    case "4":
                        Console.Write("Ingrese DNI a eliminar: ");
                        string dniElim = Console.ReadLine() ?? string.Empty;

                        bool eliminada = negocio.EliminarPersona(dniElim.Trim());
                        Console.WriteLine(eliminada
                            ? "Persona eliminada correctamente."
                            : "No se eliminó ningún registro.");
                        break;
                }

                if (opcion != "0")
                {
                    Console.WriteLine("\nPresioná una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != "0");
        }
    }
}