using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Button Salir;
    int puntuacion = 0;


    public static string minutos, segundos;
    private float tiempo = 270;
    //colecionable
    public static int ColecionablesRecogidos = 0;
    public static bool col1 = false;
    public static bool col2 = false;
    public static bool col3 = false;

    public static int posicion = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Button btn = Salir.GetComponent<Button>();
        btn.onClick.AddListener(Cerrar);

    }
    private void Update()
    {
        tiempo -= Time.deltaTime;
        minutosSegundos(tiempo);
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
    }

    // Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coleccionable"))
        {
          
            ColecionablesRecogidos++;
            if (ColecionablesRecogidos==3) {
                posicion++;
                col1 = true;
                col2 = true;
                col3 = true;
                ColecionablesRecogidos = 0;
            }
            puntuacion += 10;
            textoPuntuacion.text = "Puntuación: " + puntuacion;
            other.transform.position = new Vector2(999,999);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
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


    void Cerrar()
    {
        Application.Quit();
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
}
