using System.Collections.Generic;

public class Formacion
{
	private string nombre;

	private List<Posicion> posiciones = new List<Posicion>(11);

	public Formacion(string nombre, List<Posicion> posiciones)
    {
		this.nombre = nombre;
		this.posiciones = posiciones;
    }

}

