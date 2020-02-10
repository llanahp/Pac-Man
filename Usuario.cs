using System;

public class Usuario
{
    public string usuario, clave;

    public Usuario(string usuario, string clave)
    {
        this.usuario = usuario;
		this.clave = clave;
    }

	public string Getusuario(){
		return this.usuario;
	}
	public String Getclave(){
		return this.clave;
	}

}
