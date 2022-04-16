using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private static AudioSource TemaDeSonido;
    private bool Transicion;

    void Start()
    {
        TemaDeSonido = GetComponent<AudioSource>();
        TemaDeSonido.volume = ManagerConfiguraciones.ConfiguracionesJuego.VolumenMusica;
    }


    void Update()
    {
        TemaDeSonido.volume = ManagerConfiguraciones.ConfiguracionesJuego.VolumenMusica;
    }

    public static void TransicionSonido(float numero)
    {
        TemaDeSonido.volume = numero;
    }
}
