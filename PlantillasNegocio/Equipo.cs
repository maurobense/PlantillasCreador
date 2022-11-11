using System.Collections.Generic;

public class Equipo
{
	private string nombre;

	private List<Jugador> miembros = new List<Jugador>();

	private List<Alineacion> alineaciones = new List<Alineacion>();


	public List<Jugador> Miembros
	{
		get { return this.miembros; }
		set { this.miembros = value; }
	}

	public List<Alineacion> Alineaciones
	{
		get { return this.alineaciones; }
		set { this.alineaciones = value; }
	}

	public string Nombre
    {
		get { return this.nombre;  }
    }

	public Equipo(string nombre)
    {
		this.nombre = nombre;
    }
}


