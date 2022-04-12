using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDelJugador : MonoBehaviour
{
    //! Este script se encarga de manipular los estados del jugador.

    [SerializeField] int Vida;
    private Arma Script;
    void Start()
    {
        Script = GetComponentInChildren<Arma>();
    }
    void Update()
    {
        if (ManagerDeNivel.Pausa)
        {
            Script.enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Script.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
