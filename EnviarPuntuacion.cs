using System;

public class EnviarPuntuacion
{
	string usuario, fecha;
	int puntuacion, tiempo;
	
	public EnviarPuntuacion(string usuario, string fecha, int puntuacion, int tiempo){
		this.usuario = usuario;
		this.fecha = fecha;
		this.puntuacion = puntuacion;
		this.tiempo = tiempo;
	}
	
   public string GetUsuario(){
		return this.usuario;
	}
	public string GetFecha(){
		return this.fecha;
	}
	public int GetPuntuacion(){
		return this.puntuacion;
	}
	public int GetTiempo(){
		return this.tiempo;
	}
}
