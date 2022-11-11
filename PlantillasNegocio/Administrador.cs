using System;
using System.Collections.Generic;

namespace plantillasDominio
{
    public class Administrador
    {
        private static Administrador instancia;
        
        //Implementamos el patron singleton para tener una unica instancia. 
        public static Administrador Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Administrador();
                }
                return instancia;
            }
        }
        //creamos las listas que vamos a utilizar en la clase administradora.
        private List<Equipo> equipos = new List<Equipo>();
        private List<Formacion> formaciones = new List<Formacion>();
        private List<Jugador> jugadores = new List<Jugador>();
        public Administrador()
        {
            PrecargaEquipos();
        }
        public List<Equipo> Equipos
        {
            get { return this.equipos; }
        }
        private void AltaEquipo(string nombre)
        {
            Equipo miEquipo = new Equipo(nombre);

            equipos.Add(miEquipo);
        }

        private void AltaJugador()
        {
            Jugador miJugador = new Jugador();
        }

        private void PrecargaEquipos()
        {
            this.AltaEquipo("Rentistas");
            this.AltaEquipo("Nacional");
            this.AltaEquipo("Liverpool");
            this.AltaEquipo("Cerrito");

        }
    }
}

