using System.Collections.Generic;

public class Formacion
{
	private string nombre;

	private List<Posicion> posiciones = new List<Posicion>();

	public string Nombre
    {
        get { return this.nombre;}
    }

	public List<Posicion> Posiciones
    {
        get { return this.posiciones; }
    }
	public Formacion(string nombre, List<Posicion> posiciones)
    {
		this.nombre = nombre;
		this.posiciones = posiciones;
    }

}

