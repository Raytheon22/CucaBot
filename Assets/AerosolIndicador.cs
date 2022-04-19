using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AerosolIndicador : MonoBehaviour
{
    private Image Script;

    void Start()
    {
        Script = GetComponent<Image>();
    }
    void Update()
    {
        float CargaEnDecimal = ManagerDeNivel.CargaDeAerosol;
        Script.fillAmount = CargaEnDecimal / 10f;
    }
}
