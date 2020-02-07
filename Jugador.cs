using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class Jugador : MonoBehaviour
{
    [SerializeField]
    private Text Cronometro;
    private float StartTime;

    [SerializeField]
    private Image corazon2;

    [SerializeField]
    private Text contadorVidas, textoPuntuacion;

    float velocidad = 5;
    private Rigidbody2D rb;

    private int vidas = 2, corazones = 2;
    bool vivo = true;

    int puntuacion = 0;


    public static string minutos, segundos;
    private float tiempo = 270;
    //colecionable
    public static int ColecionablesRecogidos = 0;
    public static bool col1 = false;
    public static bool col2 = false;
    public static bool col3 = false;

    public static int posicion = 0;

    private static bool relentizado = false;
    string segundoRelentizado;



    //Audio Source
    AudioSource fuenteDeAudio;
    //Clips de audio
    [SerializeField]
    private AudioClip recolectarMoneda, powerUps, trampa, tocarEnemigo;

    [SerializeField]
    private Button Salir, Pausa, Home;
    //sprites
    [SerializeField]
    private Sprite sptPausa, sptPlay;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Button btn = Salir.GetComponent<Button>();
        btn.onClick.AddListener(Cerrar);

        Button btnPausa = Pausa.GetComponent<Button>();
        btnPausa.onClick.AddListener(pausar);


        Button btnHome = Home.GetComponent<Button>();
        btnHome.onClick.AddListener(home);
        fuenteDeAudio = GetComponent<AudioSource>();

     

    }

    void relentizar()
    {
        int total = int.Parse(segundos) + 5;
        if (total.Equals(int.Parse(segundoRelentizado)))
        {
            velocidad = 5;
            relentizado = false;
        }
    }
    private void Update()
    {
        tiempo -= Time.deltaTime;
        minutosSegundos(tiempo);
        if (relentizado)
        {
            velocidad = 2;
            relentizar();
        }
        else
        {
            segundoRelentizado = segundos;
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
            puntuacion += 10;
            textoPuntuacion.text = "Puntuación: " + puntuacion;
            other.transform.position = new Vector2(999, 999);
        }
        if (other.gameObject.CompareTag("Enemigo"))
        {
            bajarVida();
            transform.position = new Vector2(-7.75f, -1.64f);
        }
        if (other.gameObject.CompareTag("trampa"))
        {
            
            other.transform.position = new Vector2(999, 999);
            puntuacion -= 20;
            textoPuntuacion.text = "Puntuación: " + puntuacion;
            relentizado = true;
            fuenteDeAudio.clip = trampa;
            fuenteDeAudio.Play();
        }
        if (other.gameObject.CompareTag("trampaVida"))
        {
            other.transform.position = new Vector2(999, 999);
            puntuacion -= 40;
            textoPuntuacion.text = "Puntuación: " + puntuacion;
            bajarVida();
            fuenteDeAudio.clip = trampa;
            fuenteDeAudio.Play();
        }
        if (other.gameObject.CompareTag("sumarVida"))
        {
            other.transform.position = new Vector2(999, 999);
            puntuacion += 40;
            textoPuntuacion.text = "Puntuación: " + puntuacion;
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
    }

    void minutosSegundos(float tiempo)
    {

        //Minutos
        if (tiempo > 120)
        {
            minutos = "02";
        }
        else if (tiempo >= 60)
        {
            minutos = "01";
        }
        else
        {
            minutos = "00";
        }

        //Segundos
        int numSegundos = Mathf.RoundToInt(tiempo % 60);
        if (numSegundos > 9)
        {
            segundos = numSegundos.ToString();
        }
        else
        {
            segundos = "0" + numSegundos.ToString();
        }

        //Escribo en la caja de texto
        Cronometro.text = minutos + ":" + segundos;

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

    void Cerrar()
    {
        Application.Quit();
    }

    void pausar()
    {

        if (Pausa.GetComponent<Image>().sprite == sptPausa)//Pausa
        {
           // Pausado.enabled = true;
            Pausa.GetComponent<Image>().sprite = sptPlay;
            Time.timeScale = 0;
        }
        else
        {//play
            //Pausado.enabled = false;
            Pausa.GetComponent<Image>().sprite = sptPausa;
            Time.timeScale = 1;
        }

    }

    void home()
    {
        SceneManager.LoadScene("Inicio");

    }

    

    


}
