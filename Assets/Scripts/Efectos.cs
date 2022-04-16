using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efectos : MonoBehaviour
{
    static AudioSource EfectoBoton;
    void Start()
    {
        EfectoBoton = GetComponent<AudioSource>();
    }
    void Update()
    {
        EfectoBoton.volume = ManagerConfiguraciones.VolumenEfectos;
    }
    public static void reproducir()
    {
        EfectoBoton.Play();
    }
}
