using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDelJugador : MonoBehaviour
{


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
        if (Input.GetKeyDown(KeyCode.Z) && ManagerDeNivel.CargaDeAerosol >= 10)
        {
            Armas[0].SetActive(false);
            Armas[1].SetActive(true);
            Armas[2].SetActive(false); //ojota visual
            ArmaActual = Armas[1];
        }

        if (ManagerDeNivel.CargaDeAerosol == 0)
        {
            Armas[0].SetActive(true);
            Armas[1].SetActive(false);
            Armas[2].SetActive(true); //ojota visual
            ArmaActual = Armas[0];
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
