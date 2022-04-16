using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Opciones : MonoBehaviour
{
    [SerializeField] Slider Sensibilidad;
    [SerializeField] Slider VolumenMusica;
    [SerializeField] Slider VolumenEfecto;
    private GameObject UIAnterior;

    void Start()
    {
        Sensibilidad.value = ManagerConfiguraciones.ConfiguracionesJuego.Sensibilidad;
        VolumenEfecto.value = ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos;
        VolumenMusica.value = ManagerConfiguraciones.ConfiguracionesJuego.VolumenMusica;
    }

    void Update()
    {
        if (Sensibilidad.value != ManagerConfiguraciones.ConfiguracionesJuego.Sensibilidad)
        {
            ManagerConfiguraciones.ConfiguracionesJuego.Sensibilidad = (int)Sensibilidad.value;
        }
        if (VolumenMusica.value != ManagerConfiguraciones.ConfiguracionesJuego.VolumenMusica)
        {
            ManagerConfiguraciones.ConfiguracionesJuego.VolumenMusica = VolumenMusica.value;
        }
        if (VolumenEfecto.value != ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos)
        {
            ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos = VolumenEfecto.value;
        }
    }
    public void RecibirUiAnterior(GameObject UI)
    {
        UIAnterior = UI;

    }
    public void Atras()
    {
        Efectos.reproducir();
        UIAnterior.SetActive(true);
        Destroy(this.gameObject);
    }
}
