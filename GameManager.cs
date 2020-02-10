using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemigo;
    public int numeroEnemigos;
    public float esperaInicial;
    public float esperaEntreEnemigos;
    public float esperaEntreOlas;
	private float [] posicionX = {2.466f, -0.05f, -4.5f, -2.06f};
	private float [] posicionY = {-1.826f, -0.05f, -2.56f, 4.52f};
	private int contador = 1;

	public static int ContadorEnemigos, ContadorColeccionable, puntuacion;
	


	void Start() {  

        //LLamo a la rutina de crear enemigos
        StartCoroutine(crearEnemigos());
		
		ContadorColeccionable = 0;
		ContadorEnemigos = 0;
		puntuacion = 0;
		
	}
	void Update(){
		if(!Jugador.vivo){
			SceneManager.LoadScene("Final");
		}
	}
		
    IEnumerator crearEnemigos()
    {
       //Espero un tiempo antes de crear enemigos
       yield return new WaitForSeconds(esperaInicial);

        //Bucle durante toda la vida del juego
        while (true)
        {
            //Bucle de número de enemigos
            for (int i = 0; i < numeroEnemigos; i++)
            {
                //Instancio el enemigo en una posición aleatoria del tablero
                Vector2 posicionEnemigo = new Vector2(posicionX[contador], posicionY[contador]);
                Quaternion rotacionEnemigo = Quaternion.identity;
                Instantiate(enemigo, posicionEnemigo, rotacionEnemigo);
				contador++;
				if(contador==4){contador = 0;}
                //Espero un tiempo entre la creación de cada enemigo
                yield return new WaitForSeconds(esperaEntreEnemigos);
            }
            //Espero un tiuempo entre oleadas de enemigos
            yield return new WaitForSeconds(esperaEntreOlas);
        }
    }


	
}