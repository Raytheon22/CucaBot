using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojota : MonoBehaviour
{
    private bool Mato;
    void OnCollisionEnter(Collision other)
    {
        if (Mato == false && other.gameObject.tag == "Enemigos")
        {
            other.gameObject.GetComponent<Cucarachas>().Morir();
            ManagerDeNivel.CucarachasAsesinadas++;
            Mato = true;
        }
    }
}
