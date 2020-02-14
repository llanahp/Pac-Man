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

	[SerializeField]
	Text txtFecha1,txtFecha2,txtFecha3;
	[SerializeField]
	Text txtPuntuacion1, txtPuntuacion2, txtPuntuacion3;

    // Start is called before the first frame update
    void Start()
    {

		ImprimirPartidas();
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

	void ImprimirPartidas(){
		txtFecha1.text = GameManager.juegos[0].GetFecha();
		txtFecha2.text = GameManager.juegos[1].GetFecha();
		txtFecha3.text = GameManager.juegos[2].GetFecha();


		txtPuntuacion1.text = GameManager.juegos[0].GetPuntuacion().ToString();
		txtPuntuacion2.text = GameManager.juegos[1].GetPuntuacion().ToString();
		txtPuntuacion3.text = GameManager.juegos[2].GetPuntuacion().ToString();



	}

}
