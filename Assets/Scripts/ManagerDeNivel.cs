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
    public static GameObject Instancia;
    public static bool JefeInstanciado;
    public static bool Victoria;
    public static bool Derrota;
    void Start()
    {
        Pausa = false;
        CantidadDeCucarachas = new List<Cucarachas>();
        CargaDeAerosol = 0;
        CucarachasMuertas = 0;
        OjotaEnEscena = false;
        Victoria = false;
        Derrota = false;
    }
    void Update()
    {
        if (CucarachasMuertas == 20 && JefeInstanciado == false)
        {
            Instancia = Instantiate(Jefe, new Vector3(0, 0.5f, 0), Quaternion.identity);
            JefeInstanciado = true;
        }
        if (CantidadDeCucarachas.Count > 40)
        {
            Derrota = true;
            Invoke("cargarNivel", 4);
        }
    }
    void cargarNivel()
    {
        SceneManager.LoadScene("Menu");
    }
}
