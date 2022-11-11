using System;
using plantillasDominio;


namespace PlantillasConsola
{
    class Program
    {
        private static Administrador miAdmin = new Administrador();
        static void Main(string[] args)
        {
        
            foreach (Jugador miJugador in miAdmin.Jugadores)
            {
                Console.WriteLine(miJugador.Nombre);
            }
            foreach (Equipo miEquipo in miAdmin.Equipos)
            {
                foreach(Jugador miJugador in miEquipo.Miembros)
                {
                    Console.WriteLine(miJugador.Nombre + " " + miEquipo.Nombre);
                }
            }
        }
    }
}
