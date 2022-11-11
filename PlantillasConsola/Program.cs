using System;
using plantillasDominio;


namespace PlantillasConsola
{
    class Program
    {
        private static Administrador miAdmin = new Administrador();
        static void Main(string[] args)
        {
            foreach (Equipo miEquipo in miAdmin.Equipos)
            {
                Console.WriteLine(miEquipo.Nombre);
            }
        }
    }
}
