﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoEdi3.Entidades;

namespace TrabajoEdi3.Shared
{
    public static class ConsoleExtension
    {
        public static string ReadString(string message)
        {
            string? stringVar = string.Empty;
            while (true)
            {

                Console.Write(message);
                stringVar = Console.ReadLine();
                if (stringVar == null)
                {
                    Console.WriteLine("Debe ingresar algo!!!");
                }
                else
                {
                    break;
                }
            }
            return stringVar;
        }

        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }
        public static bool ReadBool(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "SI")
                {
                    return true;
                }
                else if (input == "NO")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor ingrese 'SI' para sí o 'NO' para no.");
                }
            }
        }

            public static decimal ReadDecimal(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número decimal válido.");
                }
            }
        }
        public static decimal ReadDecimal(string message, decimal min, decimal max)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result))
                {
                    if (result >= min && result <= max)
                    {
                        return result;

                    }
                    else
                    {
                        Console.WriteLine($"Selección fuera de rango ({min}-{max}");
                    }

                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número decimal válido.");
                }
            }
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void EsperaEnter()
        {
            Console.WriteLine("ENTER para continuar");
            Console.ReadLine();

        }

        public static string GetValidOptions(string message, List<string>? options)
        {
            string answer = string.Empty;
            if (options != null)
            {
                options.Insert(0, "N");
                do
                {
                    answer = ReadString(message);

                    if (!options.Any(x => x.Equals(answer)))
                    {
                        Console.WriteLine("\nIngreso no válido... Otra vez!!!");
                    }
                    else
                    {
                        /*
                         * Si la opción tipiada es alguna de la lista, salgo del ciclo
                         */
                        break;

                    }

                } while (!options.Any(x => x.Equals(answer)));// mientras no sea un caracter válido me quedo esperando

            }
            return answer; //retorno el caracter ingresado y validado.

        }

        public static int SelectFromList<T>(List<T> lista, int minValue, int maxValue) where T : class
        {
            int seleccion = 0;
            Console.Write("Seleccione de la lista");
            foreach (var item in lista)
            {
                switch (item)
                {
                    case Marca marca:
                        Console.WriteLine($"{marca.MarcaId} - {marca.MarcaNombre}");
                        break;
                    case Deporte deporte:
                        Console.WriteLine($"{deporte.DeporteId} - {deporte.NombreDeporte}");
                        break;
                    case Color color:
                        Console.WriteLine($"{color.ColorId} - {color.ColorName}");
                        break;
                    case Genero genero:
                        Console.WriteLine($"{genero.GeneroId} - {genero.GeneroNombre}");
                        break;
                    default:
                        throw new ArgumentException("Tipo no compatible.");
                }
                Console.WriteLine(); // Agregar una línea en blanco entre los elementos
            }

            seleccion = ReadInt("Selecciona una opción del listado:", minValue, maxValue);

            return seleccion; // Devolver un valor por defecto

        }
        public static int ReadInt(string message, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    if (result >= min && result <= max)
                    {
                        return result;

                    }
                    else
                    {
                        Console.WriteLine($"Selección fuera de rango ({min}-{max}");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número entero válido.");
                }
            }
        }
    }
}
