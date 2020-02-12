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
    }
}
