using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;


public class Inicio : MonoBehaviour
{
    [SerializeField]
    InputField email, contra;
    [SerializeField]
    private Text texto;
    [SerializeField]
    private Button enlace;

    private Usuario usuario;
    private string urlNoticias = "http://157.230.102.160/formacion/ceu/daw-2019-20/cms/public/index.php/unitynoticias";

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(acepta);

        Button btnEnlace = enlace.GetComponent<Button>();
        btnEnlace.onClick.AddListener(pausar);
    }
    void pausar()
    {
        Application.OpenURL("http://unity3d.com/");
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void acepta()
    {
        if (email.text == "" || contra.text == "")
        {
            texto.text="Rellena los campos";
        }
        else
        {
            usuario = new Usuario(email.text, contra.text);
            StartCoroutine(ApiMostrarNoticias(urlNoticias, usuario));
        }

    }

    IEnumerator ApiMostrarNoticias(string urlNoticias, Usuario usuario)
    {
        WWWForm form = new WWWForm();
        form.AddField("usuario", usuario.Getusuario());
        form.AddField("clave", usuario.Getclave());

        using (UnityWebRequest webRequest = UnityWebRequest.Post(urlNoticias, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
             
                texto.text = "error";

            }
            else if (webRequest.downloadHandler.text == "no")
            {
                
                texto.text = "Usuario no autorizado";
            }
            else
            {
                texto.text = "si";
                SceneManager.LoadScene("Juego");
				GameManager.usuario=usuario.Getusuario();
                string jsonResponse = webRequest.downloadHandler.text;
                //GameManager.juegos = JsonHelper.getJsonArray<EnviarPuntuacion>(jsonResponse);
					
					/*--------------------------------------------------------------------------------*/
					// lo que faltqa lo de web
					GameManager.juegos = new EnviarPuntuacion[3];

					EnviarPuntuacion p1  = new EnviarPuntuacion(usuario.Getusuario(),DateTime.Today.ToString(),540,139);
					EnviarPuntuacion p2  = new EnviarPuntuacion(usuario.Getusuario(),DateTime.Today.ToString(),600,39);
					EnviarPuntuacion p3  = new EnviarPuntuacion(usuario.Getusuario(),DateTime.Today.ToString(),700,39);

					GameManager.juegos[0] = p2;
					GameManager.juegos[1] = p1;
					GameManager.juegos[2] = p3;

            }
        }
    }
}
