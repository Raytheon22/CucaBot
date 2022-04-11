using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDeNivel : MonoBehaviour
{
    public static List<Cucarachas> CantidadDeCucarachas;
    public static int CucarachasMuertas;
    public static bool Pausa;

    void Start()
    {
        Pausa = false;
        CantidadDeCucarachas = new List<Cucarachas>();
    }
    void Update()
    {
        if (CantidadDeCucarachas.Count > 20)
        {
            Debug.Log("Perdio");
        }
        if (CucarachasMuertas > 1)
        {
            Debug.Log("Jefe");
        }
    }
}
