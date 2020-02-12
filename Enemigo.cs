using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    GameObject jugador;
    public float moveSpeed = 0.5f;
    private Rigidbody2D rb;
	

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jugador = GameObject.Find("Jugador");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
		if(!Jugador.Huir){
			transform.position = Vector2.MoveTowards(transform.position, jugador.transform.position, moveSpeed * Time.deltaTime);
		}else{
			transform.position = Vector2.MoveTowards(transform.position, -jugador.transform.position, moveSpeed * Time.deltaTime);
		}
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Destroy(this.gameObject);
            
        }
     
    }
}
