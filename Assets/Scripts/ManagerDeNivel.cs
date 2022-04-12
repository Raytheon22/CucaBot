using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerDeNivel : MonoBehaviour
{
    public static List<Cucarachas> CantidadDeCucarachas;
    public static int CucarachasMuertas;
    public static bool Pausa;
    public static int CantidadDeOjotas;
    public GameObject Jefe;

    void Start()
    {
        Pausa = false;
        CantidadDeCucarachas = new List<Cucarachas>();
    }
    void Update()
    {
        if (CantidadDeCucarachas.Count > 40)
        {
            SceneManager.LoadScene("Menu");
        }
        if (CucarachasMuertas > 20)
        {
            Instantiate(Jefe, new Vector3(0, 0.5f, 0), Quaternion.identity);
        }
    }
}
