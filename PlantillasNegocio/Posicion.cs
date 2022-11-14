using System.Collections.Generic;

public class Posicion

{
    private string especifica; //Ya que hay posiciones como por ejemplo "DFC" que se representan en la cancha con el mismo nombre habiendo mas de 1, decidi darle una especial para las formaciones en las que esto sucede.

    private string nombre; //Nombre con el que se representara la posicion en el esquema.

	private string rol; //Rol de la posicion. Lo utilizaremos para la creacion del select y que sea mas dinamico seleccionar la posicion para un jugador(ej. mediocampista, defensa, suplente);

    private static bool disponible = true; //Indica si la posicion esta tomada por un jugador o el puesto se encuentra libre.

    private int x; //La "x" va a indicar el margen a la izquierda (pudo ser derecha) que va a tener dentro del esquema de la cancha.

	private int y; //La "y" va a indicar el margen con respecto a la parte inferior del esquema de la cancha.

	public string Rol
    {
        get { return this.rol; }
    }
	public string Especifica
    {
        get {return this.especifica; }
    }
    public int X
    {
        get { return this.x; }
    }
    public int Y
    {
        get { return this.y; }
    }
    public bool Disponible
    {
        get { return disponible; }
        set { disponible = value; }
    }
    public string Nombre
    {
        get { return this.nombre; }
    }
    public Posicion(string especifica,string nombre,string rol,int x, int y)
    {
        this.especifica = especifica;
        this.nombre = nombre;
        this.rol = rol;
        this.x = x;
        this.y = y;
    }
}

