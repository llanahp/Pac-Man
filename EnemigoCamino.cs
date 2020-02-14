using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoCamino : MonoBehaviour
{
   [SerializeField]
	float velocidad;
	[SerializeField]
	string Etiqueta;

	Vector2 posicion_Actual;
	string Volver;
	bool volver2 = false;
	
	private Waypoints wpoints;

	int waypointindex = 0;
	

    // Start is called before the first frame update
    void Start(){
	  wpoints = GameObject.FindGameObjectWithTag(Etiqueta).GetComponent<Waypoints>();
    }

    // Update is called once per frame
    void Update(){

		transform.position = Vector2.MoveTowards(transform.position, wpoints.waypoints[waypointindex].position, velocidad * Time.deltaTime);

		
		if(Vector2.Distance(transform.position, wpoints.waypoints[waypointindex].position) < 0.1f){
			waypointindex++;
		}
		
		if(waypointindex == wpoints.waypoints.Length){
			waypointindex = 0;	
		}

		if(volver2){
		
			a();

		}else{
			Volver =(int) GameManager.tiempo + "";
		}


    }


	void OnTriggerEnter2D(Collider2D other)
    {
		if(Jugador.matar){
			if (other.gameObject.CompareTag("Jugador"))
			{
			
				posicion_Actual = transform.position;
				volver2 = true;
				transform.position = new Vector2(999,999);
			}
		}
	}

		void a(){
		
		int total = (int)GameManager.tiempo + 5;
		Debug.Log(total+"---"+int.Parse(Volver));
		if (total.Equals(int.Parse(Volver)))
        {
            transform.position = posicion_Actual;
			volver2 = false;
			
        }
	}
}
