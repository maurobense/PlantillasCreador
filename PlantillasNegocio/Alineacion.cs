using System;
using System.Collections.Generic;

public class Alineacion
{
	private List<Jugador> titulares;

	private List<Jugador> suplentes;

	private List<Jugador> cuerpoTecnico;

	private Formacion formacion;

	private string rival;

	private string equipo;

	public List<Jugador> Titualres
	{
		get { return this.titulares; }
	}
	public List<Jugador> Suplentes
	{
		get { return this.suplentes; }
	}
	public List<Jugador> CuerpoTecnico
    {
		get { return this.cuerpoTecnico; }
	}
	public Formacion Formacion
    {
        get { return this.formacion; }
    }
	public string Rival
    {
        get { return this.rival; }
    }
	public string Equipo
	{
		get { return this.equipo; }
	}
	public Alineacion(List<Jugador> titulares, List<Jugador> suplentes,List<Jugador> cuerpoTecnico, Formacion formacion, string rival,string equipo)
    {
		this.titulares = titulares;
		this.suplentes = suplentes;
		this.cuerpoTecnico = cuerpoTecnico;
		this.formacion = formacion;
		this.rival = rival;
		this.equipo = equipo;
    }



}

