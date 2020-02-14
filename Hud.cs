using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{

	[SerializeField]
    private Text Cronometro;
    private float StartTime;

    [SerializeField]
    private Text contadorVidas, textoPuntuacion;
	
	public static string minutos, segundos;

    // Start is called before the first frame update
    void Start()
    {
         textoPuntuacion.text = "Puntuación: " + GameManager.puntuacion;
    }

    // Update is called once per frame
    void Update()
    {
        textoPuntuacion.text = "Puntuación: " + GameManager.puntuacion;
		GameManager.tiempo -= Time.deltaTime;
        minutosSegundos(GameManager.tiempo);


    }


	



}
