using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] GameObject UIPausa;
    [SerializeField] GameObject Transicion;
    [SerializeField] GameObject Arma;
    [SerializeField] GameObject Jugador;

    [SerializeField] GameObject BarraDeVida;
    [SerializeField] GameObject PantallaVictoria;
    [SerializeField] GameObject PantallaDerrota;
    private bool CargarTransicion;
    private float Alpha = 2;
    private float Volumen;
    void Start()
    {
        CargarTransicion = true;

    }
    void Update()
    {
        ChequearVictoria();
        CambiarPotencia();
        if (ManagerDeNivel.JefeInstanciado)
        {
            BarraDeVida.SetActive(true);
        }
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

    private void ChequearVictoria()
    {
        if (ManagerDeNivel.Victoria == true)
        {
            PantallaDerrota.SetActive(false);
            PantallaVictoria.SetActive(true);
        }
        if (ManagerDeNivel.Derrota == true)
        {
            PantallaDerrota.SetActive(true);
            PantallaVictoria.SetActive(false);
        }
    }
    private void CambiarPotencia()
    {
        Arma.GetComponent<Text>().text = "Power: " + (int)(Jugador.GetComponent<ArmaOjota>().FuerzaDeLanzamiento / 150 * 100) + " %";
        if ((int)Jugador.GetComponent<ArmaOjota>().FuerzaDeLanzamiento > 100)
        {
            Arma.GetComponent<Text>().color = new Color(255, 255, 0, 255);
        }
        else
        {
            Arma.GetComponent<Text>().color = new Color(0, 255, 0, 255);
        }
        if ((int)Jugador.GetComponent<ArmaOjota>().FuerzaDeLanzamiento == 150)
        {
            Arma.GetComponent<Text>().color = new Color(255, 0, 0, 255);
        }
    }
}
