using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDeNivel : MonoBehaviour
{
    private static ManagerDeNivel EstadoDelNivel;
    public static int CantidadDeCucarachas = 0;
    public static int CucarachasAsesinadas = 0;
    public static bool Pausa;

    void Awake() //* DECLARACION DEL SINGLETON
    {
        if (EstadoDelNivel == null)
        {
            EstadoDelNivel = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }

    }
}
