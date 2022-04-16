using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerConfiguraciones : MonoBehaviour
{
    private static ManagerConfiguraciones ConfiguracionesJuego;
    public static float VolumenMusica = 0.3f;
    public static float VolumenEfectos = 0.4f;
    public static int Sensibilidad = 200;

    void Awake() //* DECLARACION DEL SINGLETON
    {
        if (ConfiguracionesJuego == null)
        {
            ConfiguracionesJuego = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

}
