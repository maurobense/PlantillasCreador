using System.Collections.Generic;

public class Posicion
{
	private string rol;

	private string especifica;

	private int x;

	private int y;

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
        get { return this.Y; }
    }

    public Posicion(string rol,string especifica,int x, int y)
    {
        this.rol = rol;
        this.especifica = especifica;
        this.x = x;
        this.y = y;
    }
}

