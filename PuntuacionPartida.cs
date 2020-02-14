using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PutuacionPartida : MonoBehaviour
{
    [SerializeField]
    Text colecionables, enemigos, tiempo, fecha,putuacion;

	float tiempoTranscurrido;
	float tiempoTotal = 150.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		tiempoTranscurrido = tiempoTotal - GameManager.tiempo;
        colecionables.text = GameManager.ContadorColeccionable.ToString();
        enemigos.text = GameManager.ContadorEnemigos.ToString();
        tiempo.text = minutosSegundos(tiempoTranscurrido);
        fecha.text = DateTime.Today.ToString();
        putuacion.text = GameManager.puntuacion.ToString();
    }

    private static string minutos, segundos;

    String minutosSegundos(float tiempo)
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
       return minutos + ":" + segundos;
    }

}
