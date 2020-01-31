using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colecionables : MonoBehaviour
{
    [SerializeField]
    int nColecionable;
    int posicion;
    List<float> posicionX1 = new List<float>() { 1.3f, 1.3f, -5.88f, 5.51f, -2.32f, -0.79f };
    List<float> posicionY1 = new List<float>() { -1.64f, 3, -4.64f, -2.98f, 0.29f, 0.94f };

    List<float> posicionX2 = new List<float>() { -3.00f, -4.08f, 7.21f, -0.76f, 2.52f, 5.62f };
    List<float> posicionY2 = new List<float>() { 0.94f, 4.21f, -2.73f, 4.62f, 0.12f, 4.19f };

    List<float> posicionX3 = new List<float>() { -6.14f, 0.76f, 0.76f, -3.33f, -6.22f, 4.58f };
    List<float> posicionY3 = new List<float>() { -1.67f , -1.67f ,4.36f,2.21f,0.16f,-1.54f};
    // Start is called before the first frame update
    void Start()
    {
        posicion = 0;
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

    // Update is called once per frame
    void Update()
    {
        //Rota el elemento una cantidad diferente en cada dirección y en cada intervalo de tiempo
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);

       // cambiarPosicion();

    }
    void cambiarPosicion()
    {
        posicion++;
        if (nColecionable == 1)
        {
            transform.position = new Vector2(posicionX1[posicion], posicionY1[posicion]);
        }
        if (nColecionable == 2)
        {
            transform.position = new Vector2(posicionX2[posicion], posicionY2[posicion]);
        }
        if (nColecionable == 3)
        {
            transform.position = new Vector2(posicionX3[posicion], posicionY3[posicion]);
        }

    }

}