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
        private List<Posicion> posiciones = new List<Posicion>();
        public Administrador()
        {
            PrecargaEquipos();
            PrecargaJugadores();
            PrecargaPosiciones();
        }
        public List<Equipo> Equipos
        {
            get { return this.equipos; }
        }
        public List<Jugador> Jugadores
        {
            get { return this.jugadores; }
        }
        private void AltaEquipo(string nombre)
        {
                if (nombre != "")
                {
                    Equipo miEquipo = new Equipo(nombre);
                    equipos.Add(miEquipo);
                }
              
            }


        private void AltaJugador(string nombre, string rol,string equipo)
        {
            Equipo miEquipo = BuscarEquipo(equipo);
            if (nombre != "" && rol != "" && miEquipo != null)
            {
                Jugador miJugador = new Jugador(nombre, rol, miEquipo);
                jugadores.Add(miJugador);
                miEquipo.Miembros.Add(miJugador);
            }
        }
        private void AltaPosicion(string rol, string especifica, int x, int y)
        {
            if(rol != "" && especifica != "")
            {
                Posicion miPosicion = new Posicion(rol, especifica, x, y);
                posiciones.Add(miPosicion);
            }
        }
        public Equipo BuscarEquipo (string nombre)
        {
            Equipo miEquipo = null;
            int i = 0;
            while (i < equipos.Count && miEquipo == null)
            {
                if(nombre == equipos[i].Nombre)
                {
                    miEquipo = equipos[i];
                }
                i++;
            }
            return miEquipo;

        }

        private void PrecargaEquipos()
        {
            this.AltaEquipo("Rentistas");
            this.AltaEquipo("Nacional");
            this.AltaEquipo("Liverpool");
            this.AltaEquipo("Cerrito");

        }
        private void PrecargaJugadores()
        {
            this.AltaJugador("Franco Fagundez", "delantero", "Nacional");
            this.AltaJugador("Frank Rivery", "delantero", "Nacional");
            this.AltaJugador("Gigliotti", "delantero", "Nacional");
            this.AltaJugador("Puma Rodriguez", "mediocampista", "Nacional");
            this.AltaJugador("Francisco Ginella", "mediocampista", "Nacional");
            this.AltaJugador("Yonatan Rodriguez", "mediocampista", "Nacional");
            this.AltaJugador("Martin Rodriguez", "mediocampista", "Nacional");
            this.AltaJugador("Franco Fagundez", "defensa", "Nacional");
            this.AltaJugador("Matias Laborda", "defensa", "Nacional");
            this.AltaJugador("Leandro Lozano", "defensa", "Nacional");
            this.AltaJugador("Sergio Rochet", "golero", "Nacional");
            this.AltaJugador("Renato Cesar", "mediocampista", "Nacional");
            this.AltaJugador("Lionel Messi", "delantero", "Nacional");
            this.AltaJugador("Juan Lopez", "at", "Nacional");
            this.AltaJugador("Repetto", "dt", "Nacional");
            this.AltaJugador("Luis Martinez", "medico", "Nacional");

        }
        private void PrecargaPosiciones()
        {
            this.AltaPosicion("golero", "POR", 140, 0);
        }
    }
}

