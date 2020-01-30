using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Inicio : MonoBehaviour
{
    [SerializeField]
    InputField email, contra;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Button>().onClick.AddListener(acepta);
    }

    void acepta()
    {
        if (email.text!="" && contra.text!="") {
              SceneManager.LoadScene("Juego");
        }

    }
}
