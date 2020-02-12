using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Jugador : MonoBehaviour
{

    [SerializeField]
    private Image corazon2;

    [SerializeField]
    private Text contadorVidas;

    float velocidad = 5;
    private Rigidbody2D rb;

    public static int vidas = 2, corazones = 2;
    public static bool vivo = true;
   
    //colecionable
    public static int ColecionablesRecogidos = 0;
    public static bool col1 = false;
    public static bool col2 = false;
    public static bool col3 = false;
	Color color;

	// Coleccionable especial variables utilizadas

	private bool matar = false;
	public static bool Huir = false;
	string segundosComiendo;


    public static int posicion = 0;
    private static bool relentizado = false;
    string segundoRelentizado;


    //Audio Source
    AudioSource fuenteDeAudio;
    //Clips de audio
    [SerializeField]
    private AudioClip recolectarMoneda, powerUps, trampa, tocarEnemigo;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
        fuenteDeAudio = GetComponent<AudioSource>();

		 color = GetComponent<SpriteRenderer>().color;

    }

    void relentizar()
    {
        int total = int.Parse(Hud.segundos) + 5;
        if (total.Equals(int.Parse(segundoRelentizado)))
        {
            velocidad = 5;
            relentizado = false;
        }
    }
    private void Update()
    {
        if (relentizado)
        {
            velocidad = 2;
            relentizar();
        }
        else
        {
            segundoRelentizado = Hud.segundos;
        }

    }
    void FixedUpdate()
    {

        // capturo del eje vertical para la Raqueta
        float v = Input.GetAxis("Horizontal");
        float v2 = Input.GetAxis("Vertical");

        // modifico la velocidad de la Raqueta
        rb.velocity = new Vector2(v * velocidad, v2 * velocidad);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if ((int)rb.transform.eulerAngles.y != 180)
            {
                rb.transform.Rotate(0, 180, 0);

            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if ((int)rb.transform.eulerAngles.y != 0)
            {
                rb.transform.Rotate(0, -180, 0);

            }
        }

        if (!vivo)
        {
            Time.timeScale = 0;
        }

        teletransporte();

		// comprobacion para matar/comer a los Enemigo
		if(matar){
		
			Matar();

		}else{
			segundosComiendo = Hud.segundos;
		}


    }

	void Matar(){

		int total = int.Parse(Hud.segundos) + 5;
        if (total.Equals(int.Parse(segundosComiendo)))
        {

            matar = false;
			ColeccionableEsp.reaparecer = true;
			Jugador.Huir = false;
			GetComponent<SpriteRenderer>().color = color;
			
        }
	
	}

    // Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
           fuenteDeAudio.clip = recolectarMoneda;
            fuenteDeAudio.Play();

            ColecionablesRecogidos++;
            if (ColecionablesRecogidos == 3)
            {
                posicion++;
                col1 = true;
                col2 = true;
                col3 = true;
                ColecionablesRecogidos = 0;
            }
            GameManager.puntuacion += 10;
            other.transform.position = new Vector2(999, 999);
			GameManager.ContadorColeccionable++;
        }

		if (other.gameObject.CompareTag("Coleccionable_especial"))
        {
            fuenteDeAudio.clip = recolectarMoneda;
            fuenteDeAudio.Play();
			GetComponent<SpriteRenderer>().color = new Color(1,1,1);
			matar = true;
			Jugador.Huir  = true;

            GameManager.puntuacion += 100;
           
            other.transform.position = new Vector2(999, 999);

			GameManager.ContadorColeccionable++;
        }



        if (other.gameObject.CompareTag("Enemigo"))
        {
			fuenteDeAudio.clip = tocarEnemigo;
            fuenteDeAudio.Play();
			if(!matar){
				bajarVida();
				GameManager.puntuacion -= 20;
				transform.position = new Vector2(-7.75f, -1.64f);
			}else{
				
				GameManager.puntuacion += 50;
				Vector2 actual = other.transform.position;
				other.transform.position = new Vector2(999,999);
				GameManager.ContadorEnemigos++;
			}
			

			
            
        }
        if (other.gameObject.CompareTag("trampa"))
        {
            
            other.transform.position = new Vector2(999, 999);
            GameManager.puntuacion -= 20;
            
            relentizado = true;
            fuenteDeAudio.clip = trampa;
            fuenteDeAudio.Play();
        }
        if (other.gameObject.CompareTag("trampaVida"))
        {
            other.transform.position = new Vector2(999, 999);
            GameManager.puntuacion -= 40;
           
            bajarVida();
            fuenteDeAudio.clip = trampa;
            fuenteDeAudio.Play();
        }
        if (other.gameObject.CompareTag("sumarVida"))
        {
            other.transform.position = new Vector2(999, 999);
            GameManager.puntuacion += 40;
            
            vidas++;
            contadorVidas.text = vidas + " X";
            fuenteDeAudio.clip = powerUps;
            fuenteDeAudio.Play();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {

            fuenteDeAudio.clip = tocarEnemigo;
            fuenteDeAudio.Play();
            bajarVida();
            transform.position = new Vector2(-7.75f, -1.64f);
        }
		if (collision.gameObject.CompareTag("Enemigo2"))
        {
			fuenteDeAudio.clip = tocarEnemigo;
            fuenteDeAudio.Play();
			if(!matar){
				bajarVida();
			  //  Destroy(collision);
				GameManager.puntuacion -= 20;
				transform.position = new Vector2(-7.75f, -1.64f);
			}else{
				GameManager.puntuacion += 50;
				GameManager.ContadorEnemigos++;
			}
			
            
        }
    }

   

    void bajarVida()
    {
        if (corazones == 2)
        {
            corazon2.enabled = false;
            corazones = 1;
        }
        else if (corazones == 1)
        {
            corazon2.enabled = true;
            corazones = 2;
            vidas--;
            contadorVidas.text = vidas + " X";
        }
        if (vidas == 0)
        {
            vivo = false;
			corazon2.enabled = false;
        }
    }

    void teletransporte()
    {
        if (transform.position.x <= -8.581168f)
        {
            transform.position = new Vector2(8.22f, -0.3035613f);
        }
        if (transform.position.x >= 8.38f)
        {
            transform.position = new Vector2(-8.22f, -0.3035613f);
        }
    }

}
