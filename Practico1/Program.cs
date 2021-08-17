using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MENU\r\n");
            string menu = "1- Listar Personas \r\n2- Ingresar Persona \r\n3- Filtrar y Listar Personas\r\n";
            string opcion = "";
            string filtro = "";
            Persona personaFiltrada = new Persona();

            string nombre = "";
            string documento = "";
            string fnacimiento = "";
            string exit = "N";
            List<Persona> lista = new List<Persona>();

            while (exit == "N")
            {
                Console.WriteLine(menu);
                Console.WriteLine();

                Console.WriteLine("Eliga una opcion:");
                opcion = Console.ReadLine();
                Console.WriteLine();


                switch (opcion)
                {

                    case "1":
                        Console.WriteLine("- Lista de personas:");

                        // Mapeamos a una lista de string.
                        List<string> listaDatos = lista.Select(x => "Nombre: " + x.Nombre + ", Documento: " +
                                x.Documento + ", F. Nacimiento: " + x.FechaNacimiento.ToString("dd-MM-yyyy") +
                                ", Edad: " + x.GetEdad()).ToList();

                        // Imprimimos
                        listaDatos.ForEach(x =>
                        {
                            Console.WriteLine(x);
                        });
                        Console.WriteLine();

                        break;

                    case "2":
                        Console.WriteLine("- Ingrese una persona:");
                        Console.WriteLine();

                        Console.WriteLine("Nombre:");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Documento:");
                        documento = Console.ReadLine();
                        Console.WriteLine("Fecha Nacimiento (dd-mm-aaaa):");
                        fnacimiento = Console.ReadLine();
                        Console.WriteLine();


                        DateTime nacimiento = DateTime.ParseExact(fnacimiento, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        Persona p = new Persona(nombre, documento, nacimiento);
                        lista.Add(p);

                        break;
                    case "3":
                        Console.WriteLine("- Filtrar y Listar Personas");
                        Console.WriteLine();
                        Console.WriteLine("Ingrese Nombre o Documento:");
                        filtro = Console.ReadLine();

                        personaFiltrada = lista.Where(x => x.Nombre.Contains(filtro) || x.Documento.Contains(filtro)).First();

                        Console.WriteLine("Nombre: " + personaFiltrada.Nombre + " Documento: " + personaFiltrada.Documento +
                            " F.Nacimiento: " + personaFiltrada.FechaNacimiento.ToString("dd-MM-yyyy") +
                            " Edad: " + personaFiltrada.GetEdad());

                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Nothing");
                        break;
                }

                
                Console.WriteLine("Exit (Y/N):");
                exit = Console.ReadLine();
                Console.WriteLine();

            }

            Console.ReadLine();
        }
    }
}
