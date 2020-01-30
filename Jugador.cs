using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour	
{
	[SerializeField]
	private Text Cronometro;
	private float StartTime;

	float velocidad = 5;
	private Rigidbody2D rb;

	private int vidas=2, corazones=2;

	[SerializeField]
	private Button Salir;
	
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		Button btn = Salir.GetComponent<Button>();
		btn.onClick.AddListener(Cerrar);

	}

    void FixedUpdate()
    {
		actualizarCronometro();
		// capturo del eje vertical para la Raqueta
		float v = Input.GetAxis("Horizontal");
		float v2 = Input.GetAxis("Vertical");

		// modifico la velocidad de la Raqueta
		rb.velocity = new Vector2(v * velocidad, v2 * velocidad);

		if(Input.GetKey(KeyCode.RightArrow)){
			if((int)rb.transform.eulerAngles.y != 180){
				rb.transform.Rotate(0,180,0);
				
			}
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
					if((int)rb.transform.eulerAngles.y != 0){
				rb.transform.Rotate(0,-180,0);
				
			}
		}

		
	}

	// Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.CompareTag("Coleccionable"))
		{
			
			other.gameObject.SetActive(false);
		}
	}

	void actualizarCronometro()
	{

		float timerCronometro = Time.time - StartTime;
		string min = ((int)timerCronometro / 60).ToString("00");
		string seg = (timerCronometro % 60).ToString("00");
		string TimerString = string.Format("{00}:{01}", min, seg);
		Cronometro.text = TimerString;
	}


	void Cerrar()
	{
		Application.Quit();
	}
}
