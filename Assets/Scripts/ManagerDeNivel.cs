using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerDeNivel : MonoBehaviour
{
    public static List<Cucarachas> CantidadDeCucarachas;
    public static int CucarachasMuertas;
    public static bool Pausa;
    public static int CargaDeAerosol;
    public static bool OjotaEnEscena;
    public GameObject Jefe;
    public bool JefeInstanciado;

    void Start()
    {
        Pausa = false;
        CantidadDeCucarachas = new List<Cucarachas>();
        CargaDeAerosol = 0;
        CucarachasMuertas = 0;
        OjotaEnEscena = false;
    }
    void Update()
    {
        if (CucarachasMuertas == 20 && JefeInstanciado == false)
        {
            Instantiate(Jefe, new Vector3(0, 0.5f, 0), Quaternion.identity);
            JefeInstanciado = true;
        }
        if (CantidadDeCucarachas.Count > 20000)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
