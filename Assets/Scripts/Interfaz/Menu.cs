using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject UIOpciones;
    [SerializeField] GameObject UITutorial;
    [SerializeField] GameObject UIControles;
    [SerializeField] GameObject Transicion;
    [SerializeField] GameObject Sonido;
    private bool CargarTransicion;
    private float Alpha;
    private float Volumen;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Tutorial()
    {
        Efectos.reproducir();
        GameObject UI = Instantiate(UITutorial, Vector3.zero, Quaternion.identity);
        gameObject.SetActive(false);

    }
    public void Controles()
    {
        Efectos.reproducir();
        GameObject UI = Instantiate(UIControles, Vector3.zero, Quaternion.identity);
        gameObject.SetActive(false);
    }
    public void Jugar()
    {
        Volumen = ManagerConfiguraciones.ConfiguracionesJuego.VolumenMusica;
        Efectos.reproducir();
        Transicion.SetActive(true);
        CargarTransicion = true;
        Invoke("CargarNivel", 2);
    }
    private void CargarNivel()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        ManagerDeNivel.Pausa = false;
        SceneManager.LoadScene("Escena de desarrollo");
    }
    public void Opciones()
    {
        Efectos.reproducir();
        GameObject UI = Instantiate(UIOpciones, Vector3.zero, Quaternion.identity);
        UI.SendMessage("RecibirUiAnterior", this.gameObject);
        this.gameObject.SetActive(false);
    }
    public void Salir()
    {
        Efectos.reproducir();
        Application.Quit();
    }
    void Update()
    {
        if (CargarTransicion)
        {
            Volumen -= 0.5f * Time.deltaTime;
            Musica.TransicionSonido(Volumen);
            Alpha += 1 * Time.deltaTime;
            Transicion.GetComponent<Image>().color = new Color(0, 0, 0, Alpha);
        }
    }
}

