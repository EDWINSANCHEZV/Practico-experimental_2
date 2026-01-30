using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AsignacionAsientosCola
{
    // Clase que representa a una persona
    class Persona
    {
        public int Id { get; }
        public string Nombre { get; }

        public Persona(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"ID: {Id} - {Nombre}";
        }
    }

    // Clase que gestiona la asignación de asientos usando una cola
    class SistemaAsientos
    {
        private const int CapacidadMaxima = 30;
        private Queue<Persona> colaPersonas = new Queue<Persona>();

        public bool RegistrarPersona(Persona persona)
        {
            if (colaPersonas.Count >= CapacidadMaxima)
                return false;

            colaPersonas.Enqueue(persona);
            return true;
        }

        public void MostrarReporte()
        {
            Console.WriteLine("\n--- REPORTE DEL SISTEMA ---");
            Console.WriteLine($"Asientos ocupados: {colaPersonas.Count}");
            Console.WriteLine($"Asientos disponibles: {CapacidadMaxima - colaPersonas.Count}");
            Console.WriteLine("Personas registradas (orden de llegada):");

            int contador = 1;
            foreach (var persona in colaPersonas)
            {
                Console.WriteLine($"{contador}. {persona}");
                contador++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SistemaAsientos sistema = new SistemaAsientos();
            Stopwatch tiempo = new Stopwatch();

            Console.WriteLine("Sistema de Asignación de 30 Asientos\n");

            tiempo.Start();

            // Simulación: llegan 35 personas
            for (int i = 1; i <= 35; i++)
            {
                Persona persona = new Persona(i, "Persona" + i);

                if (sistema.RegistrarPersona(persona))
                {
                    Console.WriteLine($"Registrado correctamente: {persona}");
                }
                else
                {
                    Console.WriteLine($"Asientos llenos. No se pudo registrar a {persona}");
                }
            }

            tiempo.Stop();

            sistema.MostrarReporte();

            Console.WriteLine($"\nTiempo de ejecución: {tiempo.ElapsedMilliseconds} ms");
            Console.WriteLine("\nPresiona ENTER para salir...");
            Console.ReadLine();
        }
    }
}
