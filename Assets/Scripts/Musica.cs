using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private AudioSource TemaDeSonido;
    void Start()
    {
        TemaDeSonido = GetComponent<AudioSource>();
    }


    void Update()
    {
        TemaDeSonido.volume = ManagerConfiguraciones.VolumenMusica;
    }
}
