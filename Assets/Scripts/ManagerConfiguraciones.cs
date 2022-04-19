using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerConfiguraciones : MonoBehaviour
{
    public static ManagerConfiguraciones ConfiguracionesJuego;
    public float VolumenMusica;
    public float VolumenEfectos;
    public int Sensibilidad;

    void Awake() //* DECLARACION DEL SINGLETON
    {
        if (ConfiguracionesJuego == null)
        {
            VolumenMusica = 0.2f;
            VolumenEfectos = 0.4f;
            Sensibilidad = 200;
            ConfiguracionesJuego = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
        Application.targetFrameRate = 70;
    }
}
