using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAerosol : MonoBehaviour
{
    [SerializeField] float DuracionDeAerosol;
    void Update()
    {
        timer();
    }

    void timer()
    {
        DuracionDeAerosol -= Time.deltaTime;
        if (DuracionDeAerosol <= 0.0f)
        {
            ManagerDeNivel.CargaDeAerosol = 0;
            DuracionDeAerosol = 5;
        }
    }
    void OnTriggerEnter(Collider ObjetoColisionado)
    {
        if (ObjetoColisionado.gameObject.tag == "Enemigos")
        {
            ObjetoColisionado.gameObject.SendMessage("RecibirDaño", 5);
        }
    }

}
