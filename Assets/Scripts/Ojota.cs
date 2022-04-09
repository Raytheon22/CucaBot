using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojota : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemigos")
        {
            other.gameObject.GetComponent<Cucarachas>().Morir();
            ManagerDeNivel.CucarachasAsesinadas++;
        }
    }
}
