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

    void Awake()
    {
        Sensibilidad.value = ManagerConfiguraciones.Sensibilidad;
        VolumenMusica.value = ManagerConfiguraciones.VolumenMusica;
        VolumenEfecto.value = ManagerConfiguraciones.VolumenEfectos;
    }

    void Update()
    {
        if (Sensibilidad.value != ManagerConfiguraciones.Sensibilidad)
        {
            ManagerConfiguraciones.Sensibilidad = (int)Sensibilidad.value;
        }
        if (VolumenMusica.value != ManagerConfiguraciones.VolumenMusica)
        {
            ManagerConfiguraciones.VolumenMusica = VolumenMusica.value;
        }
        if (VolumenEfecto.value != ManagerConfiguraciones.VolumenEfectos)
        {
            ManagerConfiguraciones.VolumenEfectos = VolumenEfecto.value;
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
