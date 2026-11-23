using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PersonaNegocio negocio = new PersonaNegocio();

            Console.Write("Ingrese el DNI a buscar: ");
            string dni = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(dni) || dni.Trim().Length < 7)
            {
                Console.WriteLine("DNI inválido. Ingrese un número de documento válido.");
            }
            else
            {
                var resultado = negocio.ConsultarPorDni(dni);

                if (resultado != null)
                {
                    Console.WriteLine($"DNI: {resultado.Value.Dni}");
                    Console.WriteLine($"Nombre: {resultado.Value.Nombre}");
                }
                else
                {
                    Console.WriteLine("No se encontró ningún registro con ese DNI.");
                }
            }

            Console.ReadKey();
        }
    }
}
