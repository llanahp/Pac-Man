using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.tag.Equals("trampa") && (int)Jugador.tiempo ==100)
        {
            rb.transform.position = new Vector2(-4.87f, -1.64f);
        }

        if (rb.tag.Equals("trampaVida") && (int)Jugador.tiempo == 50)
        {
            rb.transform.position = new Vector2(3.1f, -1.64f);
        }

        if (rb.tag.Equals("sumarVida") && (int)Jugador.tiempo == 70)
        {
            rb.transform.position = new Vector2(-0.16f, 3.25f);
        }
    }
}
   