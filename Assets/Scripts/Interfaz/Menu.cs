using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject UIOpciones;
    [SerializeField] GameObject UITutorial;
    [SerializeField] GameObject UIControles;
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
        Efectos.reproducir();
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
}
