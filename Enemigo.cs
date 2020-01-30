using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
	GameObject jugador;
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
		jugador = GameObject.Find("Jugador");
    }

    // Update is called once per frame
    void Update(){
        Vector3 direction = jugador.transform.position - transform.position;
        
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
