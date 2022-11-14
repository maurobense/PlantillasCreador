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
            PrecargaAsignarPos();
            PrecargaAlineacion();
            
        }
        public List<Equipo> Equipos
        {
            get { return this.equipos; }
        }
    
        public List<Jugador> Jugadores
        {
            get { return this.jugadores; }
        }
        public List<Formacion> Formaciones
        {
            get { return this.formaciones; }
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
                Jugador miJugador = new Jugador(nombre, rol, equipo);
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
        public string AltaAlineacion(string[] titulares, string[] suplentes,string[]cuerpoTecnico, Formacion formacion,string rival,string equipo)
        {
            string mensaje = "Error !, no se ha dado de alta la alineacion";
         


            if (titulares.Length == 11 && suplentes.Length <= 7 && cuerpoTecnico.Length >= 1 && formacion != null && rival != "")
            {
                List<Jugador> misTitulares = CargarTitulares(titulares,equipo);
                List<Jugador> misSuplentes = CargarSuplentes(suplentes,equipo);
                List<Jugador> miCuerpoTecnico = CargarCuerpoTecnico(cuerpoTecnico,equipo);




                Equipo miEquipo = BuscarEquipo(equipo);
                Alineacion miAlineacion = new Alineacion(misTitulares, misSuplentes, miCuerpoTecnico, formacion, rival, equipo);
                miEquipo.Alineaciones.Add(miAlineacion);
                mensaje = "Alineacion creada con exito!";
                ResetDisponibilidad();
                return mensaje;
            }
            ResetDisponibilidad();
            return mensaje;
        }
        public List<Jugador> CargarTitulares(string[]jugadores,string equipo)
        {
            List<Jugador> misJugadores = new List<Jugador>();
            foreach(string jugador in jugadores)
            {
                Jugador miJugador = BuscarJugadorEquipo(jugador, equipo);
                misJugadores.Add(miJugador);
            }
            return misJugadores;
        }
        public List<Jugador> CargarSuplentes(string[] jugadores, string equipo)
        {
            List<Jugador> misJugadores = new List<Jugador>();
            foreach (string jugador in jugadores)
            {
                Jugador miJugador = BuscarJugadorEquipo(jugador, equipo);
                misJugadores.Add(miJugador);
            }
            return misJugadores;
        }
        public List<Jugador> CargarCuerpoTecnico(string[] jugadores, string equipo)
        {
            List<Jugador> misJugadores = new List<Jugador>();
            foreach (string jugador in jugadores)
            {
                Jugador miJugador = BuscarJugadorEquipo(jugador, equipo);
                misJugadores.Add(miJugador);
            }
            return misJugadores;
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

        public Jugador BuscarJugadorEquipo(string nombre,string equipo)
        {
            Equipo miEquipo = BuscarEquipo(equipo);
            Jugador miJugador = null;
            int i = 0;
            while(i < miEquipo.Miembros.Count && miJugador == null)
            {
                if(nombre == miEquipo.Miembros[i].Nombre)
                {
                    miJugador = miEquipo.Miembros[i];
                }
                i++;
            }
            return miJugador;
        }

      
        public void AsignarPosicion(string jugador, string posicion, string equipo)
        {
            Jugador miJugador = BuscarJugadorEquipo(jugador, equipo);
            Posicion miPosicion = BuscarPosicion(posicion);
            if(miJugador != null && posicion != null && equipo != null)
            {
                miJugador.Posicion = miPosicion;
                miJugador.Disponible = false;
            }
            if(posicion == "SUP")
            {
                miJugador.Disponible = false;
            }
            
        }
        public void ResetDisponibilidad()
        {
            foreach(Jugador miJugador in jugadores)
            {
                miJugador.Disponible = true;
            }
        }
        public Formacion BuscarFormacion(string formacion)
        {
            Formacion miFormacion = null;
            int i = 0;
            while (i < formaciones.Count && miFormacion == null)
            {
                if(formacion == formaciones[i].Nombre)
                {
                    miFormacion = formaciones[i];
                }
                i++;
            }
            return miFormacion;
        }
       
        //public List<Jugador> Titulares(Equipo equipo)
        //{
        //    List<Jugador> misTitulares = new List<Jugador>();
        //    foreach(Jugador miJugador in equipo.Miembros)
        //    {
        //        if(!miJugador.Disponible && miJugador.Posicion != null)
        //        {
        //            misTitulares.Add(miJugador);
        //        }
        //    }
        //    return misTitulares;
        //}
        //public List<Jugador> Suplentes(Equipo equipo)
        //{
        //    List<Jugador> misSuplentes = new List<Jugador>();
        //    foreach (Jugador miJugador in equipo.Miembros)
        //    {
        //        if (!miJugador.Disponible && miJugador.Posicion == null)
        //        {
        //            misSuplentes.Add(miJugador);
        //        }
        //    }
        //    return misSuplentes;
        //}
        //public List<Jugador> CuerpoTecnico(Equipo equipo)
        //{
        //    List<Jugador> miCuerpoTecnico = new List<Jugador>();
        //    foreach (Jugador miJugador in equipo.Miembros)
        //    {
        //        if (miJugador.Rol == "ct")
        //        {
        //            miCuerpoTecnico.Add(miJugador);
        //        }
        //    }
        //    return miCuerpoTecnico;
        //}

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
            this.AltaJugador("Frank Ribery", "delantero", "Nacional");
            this.AltaJugador("Gigliotti", "delantero", "Nacional");
            this.AltaJugador("Puma Rodriguez", "mediocampista", "Nacional");
            this.AltaJugador("Francisco Ginella", "mediocampista", "Nacional");
            this.AltaJugador("Yonatan Rodriguez", "mediocampista", "Nacional");
            this.AltaJugador("Martin Rodriguez", "mediocampista", "Nacional");
            this.AltaJugador("Chiellini", "defensa", "Nacional");
            this.AltaJugador("Matias Laborda", "defensa", "Nacional");
            this.AltaJugador("Leandro Lozano", "defensa", "Nacional");
            this.AltaJugador("Sergio Rochet", "golero", "Nacional");
            this.AltaJugador("Renato Cesar", "mediocampista", "Nacional");
            this.AltaJugador("Lionel Messi", "delantero", "Nacional");
            this.AltaJugador("Juan Lopez", "ct", "Nacional");
            this.AltaJugador("Repetto", "ct", "Nacional");
            this.AltaJugador("Luis Martinez", "ct", "Nacional");

        }
        private void PrecargaPosiciones()
        {
            this.AltaPosicion("POR", "POR","golero", 0, 60);
            this.AltaPosicion("DFC1", "DFC", "defensa", 0, 280);
            this.AltaPosicion("DFC2", "DFC", "defensa", 100, 295);
            this.AltaPosicion("DFC3", "DFC", "defensa", -100, 295);
            this.AltaPosicion("MC1", "MC", "mediocampista", 290, 460);
            this.AltaPosicion("MC2", "MC", "mediocampista", -290, 460);
            this.AltaPosicion("MD", "MI", "mediocampista", -100, 560);
            this.AltaPosicion("MI", "MD", "mediocampista", 100,560);
            this.AltaPosicion("DC", "DC", "delantero", 0, 900);
            this.AltaPosicion("EI", "EI", "delantero", 180, 920);
            this.AltaPosicion("ED", "ED", "delantero", -180, 920);
            this.AltaPosicion("DFC4", "DFC", "defensa", 0, 260);
            this.AltaPosicion("DFC5", "DFC", "defensa", 240, 260);
            this.AltaPosicion("DFC6", "DFC", "defensa", -240, 260);
            this.AltaPosicion("LD", "LD", "defensa", -80, 360);
            this.AltaPosicion("LI", "LI", "defensa", 80, 360);
            this.AltaPosicion("MC3", "MC", "mediocampista", 300, 480);
            this.AltaPosicion("MC4", "MC", "mediocampista", -300, 480);
            this.AltaPosicion("MD2", "MD", "mediocampista", -100, 600);
            this.AltaPosicion("MI2", "MI", "mediocampista", 100, 600);
            this.AltaPosicion("DC2", "DC", "delantero", 0, 850);
            this.AltaPosicion("DT", "CT", "dt",0,0);

        }

        private void PrecargaFormaciones()
        {
            string[] a_433 = { "POR","DFC1","DFC2","DFC3","MC1","MC2","MD","MI","DC","ED","EI" };
            string[] a_541 = { "POR", "DFC4", "DFC5", "DFC6", "LI", "LD", "MC3", "MC4", "MI2", "MD2", "DC2" };
            this.AltaFormacion("4-3-3", a_433);
            this.AltaFormacion("4-2-1-3", a_541);
        }
        private void PrecargaAsignarPos()
        {
            this.AsignarPosicion("Franco Fagundez", "DC", "Nacional");
            this.AsignarPosicion("Frank Ribery", "EI", "Nacional");
            this.AsignarPosicion("Gigliotti", "ED", "Nacional");
            this.AsignarPosicion("Puma Rodriguez", "MC1", "Nacional");
            this.AsignarPosicion("Francisco Ginella", "MC2", "Nacional");
            this.AsignarPosicion("Yonatan Rodriguez", "MI", "Nacional");
            this.AsignarPosicion("Martin Rodriguez", "MD", "Nacional");
            this.AsignarPosicion("Chiellini", "DFC1", "Nacional");
            this.AsignarPosicion("Matias Laborda", "DFC2", "Nacional");
            this.AsignarPosicion("Leandro Lozano", "DFC3", "Nacional");
            this.AsignarPosicion("Sergio Rochet", "POR", "Nacional");
        }
        private void PrecargaAlineacion()
        {
            Formacion miFormacion = BuscarFormacion("4-3-3");
            
            string[] titulares = { "Franco Fagundez", "Frank Ribery", "Gigliotti","Francisco Ginella", "Puma Rodriguez", "Yonatan Rodriguez","Matias Laborda", "Martin Rodriguez", "Chiellini", "Leando Lozano", "Sergio Rochet" };
            string[] suplentes = { "Lionel Messi", "Renato Cesar" };
            string[] cuerpoTecnico = { "Repetto" };
            this.AltaAlineacion(titulares,suplentes,cuerpoTecnico,miFormacion,"Rentistas", "Nacional");
        }
    }
}

