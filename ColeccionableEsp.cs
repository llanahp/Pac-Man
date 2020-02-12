using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionableEsp : MonoBehaviour
{

	List<float> posicionX4 = new List<float>() { 1.42f, -4.26f, -7.08f, 7.12f, 7.12f,-2.15f };
    List<float> posicionY4 = new List<float>() { 0.15f , -2.68f, 3.05f, 3.05f, -3.7f, -0.89f};

	public static bool reaparecer = false;

    // Start is called before the first frame update
    void Start()
    {
       
			transform.position = new Vector2(posicionX4[0], posicionY4[0] );
		
    }

    // Update is called once per frame
    void Update()
    {
		
		 transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
        if (ColeccionableEsp.reaparecer){
				int aleatorio = Random.Range(0,6);
				ColeccionableEsp.reaparecer = false;
               transform.position = new Vector2(posicionX4[aleatorio], posicionY4[aleatorio]);
        }
    }
}
