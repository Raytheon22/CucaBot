using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDelJugador : MonoBehaviour
{
    //! Este script se encarga de manipular los estados del jugador y sus armas.

    [SerializeField] GameObject[] Armas;
    private GameObject ArmaActual;

    void Start()
    {
        ArmaActual = Armas[0];
        Armas[1].SetActive(false);
    }
    void Update()
    {
        ArmasDelJugador();
        Pausa();
    }
    void ArmasDelJugador()
    {
        if (Input.GetKeyDown(KeyCode.Z) && ManagerDeNivel.CargaDeAerosol >= 1)
        {
            Armas[0].SetActive(false);
            Armas[1].SetActive(true);
            ArmaActual = Armas[1];
            Debug.Log("Aerosol");
        }

        if (ManagerDeNivel.CargaDeAerosol == 0)
        {
            Armas[0].SetActive(true);
            Armas[1].SetActive(false);
            ArmaActual = Armas[0];
            Debug.Log("Ojota");
        }
    }
    void Pausa()
    {
        if (ManagerDeNivel.Pausa)
        {
            ArmaActual.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            ArmaActual.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
