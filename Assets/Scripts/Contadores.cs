using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contadores : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {
        this.gameObject.GetComponent<Text>().text = "Contador de Cucas: " + ManagerDeNivel.CantidadDeCucarachas.Count;
    }
}
