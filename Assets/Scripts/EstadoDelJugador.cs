using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDelJugador : MonoBehaviour
{
    //! Este script se encarga de manipular los estados del jugador.

    [SerializeField] int Vida;
    [SerializeField] GameObject Mano;
    [SerializeField] Lanzamiento Script;
    void Start()
    {

        Script = Mano.GetComponent<Lanzamiento>();
    }

    void Update()
    {
        if (ManagerDeNivel.Pausa)
        {
            Script.enabled = false;
        }
        else
        {
            Script.enabled = true;
        }
    }
}
