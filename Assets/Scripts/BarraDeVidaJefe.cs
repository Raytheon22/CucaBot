using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaJefe : MonoBehaviour
{
    private CucarachaReina ScriptJefe;
    private float Vida;
    void Start()
    {
        ScriptJefe = ManagerDeNivel.Instancia.GetComponent<CucarachaReina>();
    }
    void Update()
    {
        Vida = ScriptJefe.ResistenciaDeGolpe - ScriptJefe.CantidadDeGolpesRecibidos;
        GetComponent<Image>().fillAmount = Vida / 10f;
    }
}
