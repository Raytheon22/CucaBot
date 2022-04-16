using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efectos : MonoBehaviour
{
    static AudioSource EfectoBoton;
    void Start()
    {
        EfectoBoton = GetComponent<AudioSource>();
        EfectoBoton.volume = ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos;
    }
    void Update()
    {
        EfectoBoton.volume = ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos;
    }
    public static void reproducir()
    {
        EfectoBoton.Play();
    }
}
