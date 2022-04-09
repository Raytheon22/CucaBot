using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDelJugador : MonoBehaviour
{
    //! Este script se encarga de manipular los estados del jugador.

    [SerializeField] int Vida;
    void Start()
    {
        ManagerDeNivel.CucarachasAsesinadas = 0;
        ManagerDeNivel.CantidadDeCucarachas = 0;
    }

    void Update()
    {

    }
}
