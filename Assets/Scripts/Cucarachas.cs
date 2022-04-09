using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cucarachas : MonoBehaviour
{
    //!Este script se encarga de realizar el movimiento de las cucarachas.

    [SerializeField] int Vida;
    [SerializeField] int Velocidad;
    [SerializeField] int AleatoriedadDeGiro;
    [SerializeField] int Nerviosa;

    void Start()
    {
        Rotacion();
    }
    void Update()
    {
        Sensores();
        Movimiento();
    }
    void Movimiento()
    {
        transform.Translate(Vector3.forward * Velocidad * Time.deltaTime);
    }
    void Rotacion()
    {
        int VelocidadRotacion = 1 * Random.Range(-AleatoriedadDeGiro, AleatoriedadDeGiro);
        transform.Rotate(0, VelocidadRotacion, 0);
        Invoke("Rotacion", Random.Range(1, Nerviosa));
    }

    void Sensores()
    {
        RaycastHit Objetivo;
        Debug.DrawRay(transform.position, transform.forward * 1f);
        if (Physics.Raycast(transform.position, transform.forward, out Objetivo, 0.5f))
        {
            transform.rotation *= Quaternion.Euler(90f, 0, 0);
        }
    }
}
