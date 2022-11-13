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
            PrecargaFormaciones();
            
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
        private void AltaPosicion(string especifica, string nombre,string rol, int x, int y)
        {
            if(rol != "" && especifica != "" && nombre != "")
            {
                Posicion miPosicion = new Posicion(especifica, nombre,rol, x, y);
                posiciones.Add(miPosicion);
            }
        }

        private void AltaFormacion(string nombre, string[] posiciones)
        {
            List<Posicion> misPosicones = ListaPosiciones(posiciones);
            if(nombre != "" && misPosicones.Count == 11){
                Formacion miFormacion = new Formacion(nombre, misPosicones);
                formaciones.Add(miFormacion);
            }
        }
        public List<Posicion> ListaPosiciones(string[] posiciones)
        {
            List<Posicion> misPosiciones = new List<Posicion>();
            foreach(string posicion in posiciones)
            {
                Posicion miPosicion = BuscarPosicion(posicion);
                if(miPosicion != null)
                {
                    misPosiciones.Add(miPosicion);
                }
            }

            return misPosiciones;
        }

        public Posicion BuscarPosicion(string nombre)
        {
            Posicion miPosicion = null;
            int i = 0;
            while(miPosicion == null && i < posiciones.Count)
            {
                if(nombre == posiciones[i].Especifica)
                {
                    miPosicion = posiciones[i];
                }
                i++;
            }
            return miPosicion;
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
            this.AltaPosicion("POR", "POR","golero", 0, 140);
            this.AltaPosicion("DFC1", "DFC", "defensa", 0, 250);
            this.AltaPosicion("DFC2", "DFC", "defensa", 300, 270);
            this.AltaPosicion("DFC3", "DFC", "defensa", -300, 270);
            this.AltaPosicion("MC1", "MC", "mediocampista", -150, 450);
            this.AltaPosicion("MC2", "MC", "mediocampista", 150, 450);
            this.AltaPosicion("MD", "MC", "mediocampista", 460, 500);
            this.AltaPosicion("MI", "MC", "mediocampista", -460, 500);
            this.AltaPosicion("DC", "DC", "delantero", 0, 710);
            this.AltaPosicion("ED", "ED", "delantero", 250, 680);
            this.AltaPosicion("EI", "EI", "delantero", -250, 680);

        }

        private void PrecargaFormaciones()
        {
            string[] a_433 = { "POR","DFC1","DFC2","DFC3","MC1","MC2","MD","MI","DC","ED","EI" };
            this.AltaFormacion("4-3-3", a_433);
        }
    }
}

