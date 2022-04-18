using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] GameObject UIPausa;
    [SerializeField] GameObject Transicion;
    private bool CargarTransicion;
    private float Alpha = 2;
    private float Volumen;
    void Start()
    {
        CargarTransicion = true;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ManagerDeNivel.Pausa == false)
        {
            UIPausa.SetActive(true);
            UIPausa.SendMessage("Fondo");
            ManagerDeNivel.Pausa = true;
            Time.timeScale = 0;
        }
        if (CargarTransicion == true)
        {
            Volumen += 0.5f * Time.deltaTime;
            Musica.TransicionSonido(Volumen);
            Alpha = Alpha - 1 * Time.deltaTime;
            Transicion.GetComponent<Image>().color = new Color(0, 0, 0, Alpha);
        }
        if (Alpha < 0)
        {
            CargarTransicion = false;
        }
    }
}
