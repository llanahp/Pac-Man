using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	 public static float tiempo = 150;
	 
	[SerializeField]
    private Button Salir, Pausa, Home;
	 [SerializeField]
    private Sprite sptPausa, sptPlay;


	


	void Start() {  

        //LLamo a la rutina de crear enemigos
        StartCoroutine(crearEnemigos());
		
		ContadorColeccionable = 0;
		ContadorEnemigos = 0;
		puntuacion = 0;

		Button btn = Salir.GetComponent<Button>();
        btn.onClick.AddListener(Cerrar);

        Button btnPausa = Pausa.GetComponent<Button>();
        btnPausa.onClick.AddListener(pausar);


        Button btnHome = Home.GetComponent<Button>();
        btnHome.onClick.AddListener(home);
		
	}
	void Update(){
		if(!Jugador.vivo){
			SceneManager.LoadScene("Final");
		}
		if(tiempo <0.0f){
			Time.timeScale = 0;	
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

	    void Cerrar(){
        Application.Quit();
    }

    void pausar()
    {

        if (Pausa.GetComponent<Image>().sprite == sptPausa)//Pausa
        {
           // Pausado.enabled = true;
            Pausa.GetComponent<Image>().sprite = sptPlay;
            Time.timeScale = 0;
        }
        else
        {//play
            //Pausado.enabled = false;
            Pausa.GetComponent<Image>().sprite = sptPausa;
            Time.timeScale = 1;
        }

    }

    void home()
    {
        SceneManager.LoadScene("Inicio");

    }
	
}