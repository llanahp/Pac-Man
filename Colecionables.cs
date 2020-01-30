using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colecionables : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        //prueba de acceso
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rota el elemento una cantidad diferente en cada dirección y en cada intervalo de tiempo
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);

        

    }

}
