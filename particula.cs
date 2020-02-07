using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particula : MonoBehaviour
{
    [SerializeField] GameObject jugador;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

    void Update()
    {
        transform.position = jugador.transform.position + offset;
    }
}
