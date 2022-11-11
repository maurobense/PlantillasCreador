public class Jugador
{
	private string nombre;

	private string rol;

	private Posicion posicion;

	private static bool disponible = true;

	private Equipo equipo;

	public string Nombre
	{
		get { return this.nombre; }
		set { this.nombre = value; }
	}

	public string Rol
    {
        get { return this.rol; }
		set { this.rol = value; }
    }

	public Posicion Posicion
    {
        get { return this.posicion; }
        set { this.posicion = value; }
    }
	public bool Disponible
    {
        get { return disponible; }
        set { disponible = value; }
    }
	public Equipo Equipo
    {
        get { return this.equipo; }
        set { this.equipo = value; }
    }

    public Jugador(string nombre, string rol,Equipo equipo)
    {
        this.nombre = nombre;
        this.rol = rol;
        this.equipo = equipo;
    }


}

