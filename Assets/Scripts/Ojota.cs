using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojota : MonoBehaviour
{
    private bool Mato;
    void OnCollisionEnter(Collision ObjetoColisionado)
    {
        if (ObjetoColisionado.gameObject.tag == "Enemigos")
        {
            ObjetoColisionado.gameObject.SendMessage("RecibirDaño");
        }
    }
}
