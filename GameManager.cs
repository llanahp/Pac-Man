using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static int ContadorEnemigos, ContadorColeccionable, puntuacion;
	public static float tiempo = 150;

	public static EnviarPuntuacion[] juegos;

	void Start() {  

	
		//Busco el objeto llamado GameManager
		GameObject gameManager = GameObject.Find("GameManager");

		//Le indico que no se destruya al cargar otra escena 
		DontDestroyOnLoad(gameManager);

		//Cargo la escena de inicio
		SceneManager.LoadScene("Inicio");


		ContadorColeccionable = 0;
		ContadorEnemigos = 0;
		puntuacion = 0;



		
		
	}


	public static void cambioEscena(string texto){
		SceneManager.LoadScene(texto);
	}
	
}