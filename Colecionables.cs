using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colecionables : MonoBehaviour
{
    [SerializeField]
    int nColecionable;
    
    List<float> posicionX1 = new List<float>() { 1.3f, 1.3f, -5.88f, 5.51f, -2.13f, -0.79f };
    List<float> posicionY1 = new List<float>() { -1.64f, 3, -4.64f, -2.98f, -0.88f, 3.03f };

    List<float> posicionX2 = new List<float>() { 4.22f, -5f, 7.21f, -0.76f, 2.52f, 5.62f };
    List<float> posicionY2 = new List<float>() { 0.94f, 4.21f, -2.73f, 4.62f, 0.12f, 4.19f };

    List<float> posicionX3 = new List<float>() { -6.14f, 0.76f, 0.76f, -3.33f, -6.22f, 4.58f };
    List<float> posicionY3 = new List<float>() { -1.67f, -1.67f, 4.36f, 2.21f, 0.16f, -1.54f };


    void Start()
    {

        
        if (nColecionable == 1)
        {
            transform.position = new Vector2(posicionX1[0], posicionY1[0]);
        }
        if (nColecionable == 2)
        {
            transform.position = new Vector2(posicionX2[0], posicionY2[0]);
        }
        if (nColecionable == 3)
        {
            transform.position = new Vector2(posicionX3[0], posicionY3[0]);
        }
    }

    void Update()
    {
        //Rota el elemento una cantidad diferente en cada dirección y en cada intervalo de tiempo
        if (nColecionable != 3)
        {
            transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        }



        if (Jugador.posicion >= 6) { }
        else
        {

            if (nColecionable == 1 && Jugador.col1)
            {
                Jugador.col1 = false;
                transform.position = new Vector2(posicionX1[Jugador.posicion], posicionY1[Jugador.posicion]);
            }
            if (nColecionable == 2 && Jugador.col2)
            {
                Jugador.col2 = false;
                transform.position = new Vector2(posicionX2[Jugador.posicion], posicionY2[Jugador.posicion]);
            }
            if (nColecionable == 3 && Jugador.col3)
            {
                Jugador.col3 = false;
                transform.position = new Vector2(posicionX3[Jugador.posicion], posicionY3[Jugador.posicion]);
            }
        }
    }
}