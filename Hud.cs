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

 void minutosSegundos(float tiempo)
    {
        //Minutos
        if (tiempo > 120)
        {
            minutos = "02";
        }
        else if (tiempo >= 60)
        {
            minutos = "01";
        }
        else
        {
            minutos = "00";
        }

        //Segundos
        int numSegundos = Mathf.RoundToInt(tiempo % 60);
        if (numSegundos > 9)
        {
            segundos = numSegundos.ToString();
        }
        else
        {
            segundos = "0" + numSegundos.ToString();
        }

        //Escribo en la caja de texto
        Cronometro.text = minutos + ":" + segundos;
    }
	



}
