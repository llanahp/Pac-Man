using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
	[SerializeField]
    private Button Salir, Pausa, Home;
	[SerializeField]
    private Sprite sptPausa, sptPlay;

	
    // Start is called before the first frame update
    void Start()
    {
     
	 
		Button btn = Salir.GetComponent<Button>();
        btn.onClick.AddListener(Cerrar);

        Button btnPausa = Pausa.GetComponent<Button>();
        btnPausa.onClick.AddListener(pausar);


        Button btnHome = Home.GetComponent<Button>();
        btnHome.onClick.AddListener(home);
       



    }

    // Update is called once per frame
    void Update()
    {
        
    }
		


	void Cerrar(){
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
        GameManager.cambioEscena("Inicio");

    }
}
