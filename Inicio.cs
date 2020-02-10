using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


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
            //SceneManager.LoadScene("Juego");
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
        //form.AddField("clave", usuario.Getclave());

        using (UnityWebRequest webRequest = UnityWebRequest.Post(urlNoticias, form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                // textoError.text = webRequest.error;
                texto.text = "error";

            }
            else if (webRequest.downloadHandler.text == "no")
            {
                //textoError.text = "Usuario no autorizado";
                texto.text = "no";
            }
            else
            {
                texto.text = "si";
                //SceneManager.LoadScene("Juego");
                string jsonResponse = webRequest.downloadHandler.text;
                EnviarPuntuacion[] juegos = JsonHelper.getJsonArray<EnviarPuntuacion>(jsonResponse);
            }
        }
    }
}
